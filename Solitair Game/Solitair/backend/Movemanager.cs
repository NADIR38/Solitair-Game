using SolitaireGame.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SolitaireGame.Backend
{
    public class Movemanager
    {
        private readonly TableauPiles tableau;
        private readonly FoundationPile foundations;
        private readonly WastePile waste;
        private readonly StockPile stock;

        private readonly MyStack<Commands> UndoStack;
        private readonly MyStack<Commands> RedoStack;

        public Movemanager(TableauPiles tableau, FoundationPile foundations, WastePile waste, StockPile stock)
        {
            this.tableau = tableau ?? throw new ArgumentNullException(nameof(tableau));
            this.foundations = foundations ?? throw new ArgumentNullException(nameof(foundations));
            this.waste = waste ?? throw new ArgumentNullException(nameof(waste));
            this.stock = stock ?? throw new ArgumentNullException(nameof(stock));

            UndoStack = new MyStack<Commands>();
            RedoStack = new MyStack<Commands>();
        }

        private void RecordMove(Commands command)
        {
            UndoStack.Push(command);
            RedoStack.Clear(); // Clear redo on new move
        }

        public bool MoveWasteToTableau(int pileIndex)
        {
            Card topWaste = waste.GetTopCard();
            if (topWaste == null) return false;

            Card targetTop = tableau.GetTopCard(pileIndex);
            if (targetTop == null && topWaste.Rank != Rank.King) return false;
            if (targetTop != null && !(IsOppositeColor(topWaste, targetTop) && IsOneRankLower(topWaste, targetTop)))
                return false;

            // Perform move
            waste.RemoveCard(topWaste);
            tableau.piles[pileIndex].Addcard(topWaste);

            // Record Undo/Redo
            RecordMove(new Commands(
                Execute: () =>
                {
                    waste.RemoveCard(topWaste);
                    tableau.piles[pileIndex].Addcard(topWaste);
                },
                Undo: () =>
                {
                    tableau.piles[pileIndex].Removecard();
                    waste.AddCard(topWaste);
                }
            ));

            return true;
        }

        public bool MoveWasteToFoundation()
        {
            Card topWaste = waste.GetTopCard();
            if (topWaste == null) return false;

            Foundation f = foundations.GetFoundation(topWaste.Suit);
            if (!f.CanAdd(topWaste)) return false;

            waste.RemoveCard(topWaste);
            f.Add(topWaste);

            RecordMove(new Commands(
                Execute: () =>
                {
                    waste.RemoveCard(topWaste);
                    f.Add(topWaste);
                },
                Undo: () =>
                {
                    f.Cards.pop(); // This is fine - we're just removing, not using the return value
                    waste.AddCard(topWaste);
                }
            ));

            return true;
        }

        public bool MoveTableauToFoundation(int pileIndex)
        {
            Card topCard = tableau.GetTopCard(pileIndex);
            if (topCard == null) return false;

            Foundation f = foundations.GetFoundation(topCard.Suit);
            if (!f.CanAdd(topCard)) return false;

            var removed = tableau.piles[pileIndex].Removecard();
            f.Add(removed);
            tableau.piles[pileIndex].FlipTopCard();

            // Fixed: Capture the wasFaceUp state before the move
            bool topCardWasFaceUp = tableau.GetTopCard(pileIndex)?.IsFaceUp ?? false;

            RecordMove(new Commands(
                Execute: () =>
                {
                    var c = tableau.piles[pileIndex].Removecard();
                    f.Add(c);
                    tableau.piles[pileIndex].FlipTopCard();
                },
                Undo: () =>
                {
                    f.Cards.pop();
                    tableau.piles[pileIndex].Addcard(removed);
                    // Flip back if it wasn't face up originally
                    if (!topCardWasFaceUp && tableau.GetTopCard(pileIndex) != null)
                    {
                        Card top = tableau.piles[pileIndex].Removecard();
                        top.IsFaceUp = false;
                        tableau.piles[pileIndex].Addcard(top);
                    }
                }
            ));

            return true;
        }

        public bool MoveTableauToTableau(int fromIndex, int startIndex, int toIndex)
        {
            var fromPile = tableau.piles[fromIndex];
            var toPile = tableau.piles[toIndex];
            var cards = fromPile.GetCards();

            if (startIndex < 0 || startIndex >= cards.Count) return false;
            if (!cards[startIndex].IsFaceUp) return false;

            var sequence = cards.GetRange(startIndex, cards.Count - startIndex);
            Card movingCard = sequence[0];
            Card targetTop = toPile.getTopCard();

            if (targetTop == null && movingCard.Rank != Rank.King) return false;
            if (targetTop != null && !(IsOppositeColor(movingCard, targetTop) && IsOneRankLower(movingCard, targetTop)))
                return false;

            // Capture the state before moving
            bool fromPileTopWasFaceUp = fromPile.getTopCard()?.IsFaceUp ?? false;

            fromPile.RemoveTopCards(sequence.Count);
            fromPile.FlipTopCard();
            foreach (var c in sequence)
                toPile.Addcard(c);

            // Record Undo/Redo
            RecordMove(new Commands(
                Execute: () =>
                {
                    fromPile.RemoveTopCards(sequence.Count);
                    fromPile.FlipTopCard();
                    foreach (var c in sequence)
                        toPile.Addcard(c);
                },
                Undo: () =>
                {
                    toPile.RemoveTopCards(sequence.Count);
                    foreach (var c in sequence)
                        fromPile.Addcard(c);
                    // Restore original face-up state
                    if (!fromPileTopWasFaceUp && fromPile.getTopCard() != null)
                    {
                        Card top = fromPile.Removecard();
                        top.IsFaceUp = false;
                        fromPile.Addcard(top);
                    }
                }
            ));

            return true;
        }

        public bool UndoLastMove()
        {
            if (UndoStack.Count == 0) return false;

            var command = UndoStack.pop();
            command.Undo();
            RedoStack.Push(command);
            return true;
        }

        public bool RedoLastMove()
        {
            if (RedoStack.Count == 0) return false;

            var command = RedoStack.pop();
            command.Execute(); // Fixed: Excecute -> Execute
            UndoStack.Push(command);
            return true;
        }

        public bool DrawFromStock()
        {
            // If stock is empty, recycle waste pile back to stock
            if (stock.IsEmpty())
            {
                var wasteCards = waste.GetAllCards();
                if (wasteCards.Count == 0) return false;

                // Clear waste and refill stock in reverse order (so cards maintain order)
                waste.Clear();
                var reversedCards = wasteCards;
                reversedCards.Reverse();

                foreach (var card in reversedCards)
                {
                    card.IsFaceUp = false; // Face down in stock
                }

                stock.RefillFromWaste(reversedCards);
            }

            // Draw from stock to waste
            waste.DrawFromStock(stock);
            return true;
        }

        public bool CheckWin()
        {
            return foundations.IsComplete();
        }

        private bool IsOppositeColor(Card a, Card b)
        {
            return a.Color != b.Color;
        }

        private bool IsOneRankLower(Card lower, Card higher)
        {
            return (int)higher.Rank - (int)lower.Rank == 1;
        }
    }
}