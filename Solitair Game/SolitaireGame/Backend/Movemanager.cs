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
                    f.Cards.pop();
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
            tableau.piles[pileIndex].FlipTopCard();
            f.Add(removed);

            RecordMove(new Commands(
                Execute: () =>
                {
                    var c = tableau.piles[pileIndex].Removecard();
                    f.Add(c);
                },
                Undo: () =>
                {
                    f.Cards.pop();
                    tableau.piles[pileIndex].Addcard(removed);
                    tableau.piles[pileIndex].FlipTopCard();
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

            fromPile.RemoveTopCards(sequence.Count);
            foreach (var c in sequence)
                toPile.Addcard(c);
            fromPile.FlipTopCard();

            // Record Undo/Redo
            RecordMove(new Commands(
                Execute: () =>
                {
                    fromPile.RemoveTopCards(sequence.Count);
                    foreach (var c in sequence)
                        toPile.Addcard(c);
                    fromPile.FlipTopCard();
                },
                Undo: () =>
                {
                    toPile.RemoveTopCards(sequence.Count);
                    foreach (var c in sequence)
                        fromPile.Addcard(c);
                    fromPile.FlipTopCard();
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
            command.Excecute();
            UndoStack.Push(command);
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
