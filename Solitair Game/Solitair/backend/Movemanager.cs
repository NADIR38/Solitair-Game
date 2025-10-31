using SolitaireGame.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;

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
            RedoStack.Clear(); // Clear redo stack when new move is made
        }

        public bool MoveWasteToTableau(int pileIndex, int wasteCardIndex)
        {
            var wasteCards = waste.GetAllCards();
            if (wasteCardIndex < 0 || wasteCardIndex >= wasteCards.Count)
                return false;

            Card cardToMove = wasteCards[wasteCardIndex];
            Card targetTop = tableau.GetTopCard(pileIndex);

            // Validate move
            if (targetTop == null && cardToMove.Rank != Rank.King)
                return false;
            if (targetTop != null && !(IsOppositeColor(cardToMove, targetTop) && IsOneRankLower(cardToMove, targetTop)))
                return false;

            // Create command
            var command = new Commands(
                Execute: () =>
                {
                    waste.RemoveCard(cardToMove);
                    tableau.piles[pileIndex].AddCard(cardToMove);
                },
                Undo: () =>
                {
                    tableau.piles[pileIndex].RemoveCard();
                    waste.AddCard(cardToMove);
                }
            );

            // Execute and record
            command.Execute();
            RecordMove(command);
            return true;
        }

        public bool MoveWasteToFoundation(int wasteCardIndex)
        {
            var wasteCards = waste.GetAllCards();
            if (wasteCardIndex < 0 || wasteCardIndex >= wasteCards.Count)
                return false;

            Card cardToMove = wasteCards[wasteCardIndex];
            Foundation f = foundations.GetFoundation(cardToMove.Suit);

            if (!f.CanAdd(cardToMove))
                return false;

            var command = new Commands(
                Execute: () =>
                {
                    waste.RemoveCard(cardToMove);
                    f.Add(cardToMove);
                },
                Undo: () =>
                {
                    f.Cards.Pop();
                    waste.AddCard(cardToMove);
                }
            );

            command.Execute();
            RecordMove(command);
            return true;
        }

        public bool MoveTableauToFoundation(int pileIndex)
        {
            Card topCard = tableau.GetTopCard(pileIndex);
            if (topCard == null)
                return false;

            Foundation f = foundations.GetFoundation(topCard.Suit);
            if (!f.CanAdd(topCard))
                return false;

            // Capture state before move
            var removedCard = topCard;
            var pileCardsBeforeMove = tableau.piles[pileIndex].GetCards();

            // Check if there's a card below that will be flipped
            Card cardThatWillBeFlipped = null;
            if (pileCardsBeforeMove.Count > 1)
            {
                cardThatWillBeFlipped = pileCardsBeforeMove[pileCardsBeforeMove.Count - 2];
            }

            var command = new Commands(
                Execute: () =>
                {
                    var card = tableau.piles[pileIndex].RemoveCard();
                    f.Add(card);
                    tableau.piles[pileIndex].FlipTopCard();
                },
                Undo: () =>
                {
                    f.Cards.Pop();

                    // If there was a card that got flipped, flip it back down first
                    if (cardThatWillBeFlipped != null && cardThatWillBeFlipped.IsFaceUp)
                    {
                        cardThatWillBeFlipped.IsFaceUp = false;
                    }

                    // Add the removed card back
                    tableau.piles[pileIndex].AddCard(removedCard);
                }
            );

            command.Execute();
            RecordMove(command);
            return true;
        }

        public bool MoveTableauToTableau(int fromIndex, int startIndex, int toIndex)
        {
            var fromPile = tableau.piles[fromIndex];
            var toPile = tableau.piles[toIndex];
            var cards = fromPile.GetCards();

            if (startIndex < 0 || startIndex >= cards.Count)
                return false;
            if (!cards[startIndex].IsFaceUp)
                return false;

            var sequence = cards.GetRange(startIndex, cards.Count - startIndex);
            Card movingCard = sequence[0];
            Card targetTop = toPile.GetTopCard();

            if (targetTop == null && movingCard.Rank != Rank.King)
                return false;
            if (targetTop != null && !(IsOppositeColor(movingCard, targetTop) && IsOneRankLower(movingCard, targetTop)))
                return false;

            // Capture state
            var sequenceCopy = new List<Card>(sequence);

            // Check if there's a card that will be flipped
            Card cardThatWillBeFlipped = null;
            if (startIndex > 0)
            {
                cardThatWillBeFlipped = cards[startIndex - 1];
            }

            var command = new Commands(
                Execute: () =>
                {
                    fromPile.RemoveTopCards(sequenceCopy.Count);
                    fromPile.FlipTopCard();
                    foreach (var c in sequenceCopy)
                        toPile.AddCard(c);
                },
                Undo: () =>
                {
                    toPile.RemoveTopCards(sequenceCopy.Count);

                    // If a card was flipped, flip it back down first
                    if (cardThatWillBeFlipped != null && cardThatWillBeFlipped.IsFaceUp)
                    {
                        cardThatWillBeFlipped.IsFaceUp = false;
                    }

                    // Add cards back to original pile
                    foreach (var c in sequenceCopy)
                        fromPile.AddCard(c);
                }
            );

            command.Execute();
            RecordMove(command);
            return true;
        }

        public bool DrawFromStock()
        {
            if (stock.IsEmpty())
            {
                // Recycle waste back to stock
                var wasteCards = waste.GetAllCards();
                if (wasteCards.Count == 0)
                    return false;

                var wasteCardsCopy = new List<Card>(wasteCards);

                var command = new Commands(
                    Execute: () =>
                    {
                        waste.Clear();
                        var reversedCards = new List<Card>(wasteCardsCopy);
                        reversedCards.Reverse();

                        foreach (var card in reversedCards)
                        {
                            card.IsFaceUp = false;
                            stock.AddCard(card);
                        }
                    },
                    Undo: () =>
                    {
                        for (int i = 0; i < wasteCardsCopy.Count; i++)
                        {
                            stock.DrawOne();
                        }

                        foreach (var card in wasteCardsCopy)
                        {
                            card.IsFaceUp = true;
                            waste.AddCard(card);
                        }
                    }
                );

                command.Execute();
                RecordMove(command);
                return true;
            }
            else
            {
                // Draw up to 3 cards from stock
                var drawnCards = new List<Card>();
                int drawCount = Math.Min(3, stock.Count);

                for (int i = 0; i < drawCount; i++)
                {
                    if (!stock.IsEmpty())
                    {
                        drawnCards.Add(stock.DrawOne());
                    }
                }

                if (drawnCards.Count == 0)
                    return false;

                var command = new Commands(
                    Execute: () =>
                    {
                        foreach (var card in drawnCards)
                        {
                            card.IsFaceUp = true;
                            waste.AddCard(card);
                        }
                    },
                    Undo: () =>
                    {
                        // Remove from waste in reverse order
                        for (int i = drawnCards.Count - 1; i >= 0; i--)
                        {
                            waste.RemoveCard(drawnCards[i]);
                            drawnCards[i].IsFaceUp = false;
                            stock.AddCardToFront(drawnCards[i]);
                        }
                    }
                );

                command.Execute();
                RecordMove(command);
                return true;
            }
        }

        public bool UndoLastMove()
        {
            if (UndoStack.Count == 0)
                return false;

            var command = UndoStack.Pop();
            command.Undo();
            RedoStack.Push(command);
            return true;
        }

        public bool RedoLastMove()
        {
            if (RedoStack.Count == 0)
                return false;

            var command = RedoStack.Pop();
            command.Execute();
            UndoStack.Push(command);
            return true;
        }

        public bool CanUndo()
        {
            return UndoStack.Count > 0;
        }

        public bool CanRedo()
        {
            return RedoStack.Count > 0;
        }

        public bool CheckWin()
        {
            return foundations.IsComplete();
        }

        public bool CanAutoComplete()
        {
            // Check if all cards are face up
            for (int i = 0; i < 7; i++)
            {
                var cards = tableau.GetCardsInPile(i);
                if (cards.Any(c => !c.IsFaceUp))
                {
                    return false;
                }
            }
            return true;
        }

        public int AutoComplete()
        {
            int movesMade = 0;
            bool madeMoves = true;

            while (madeMoves)
            {
                madeMoves = false;

                // Try waste to foundation
                var wasteCards = waste.GetAllCards();
                if (wasteCards.Count > 0)
                {
                    if (MoveWasteToFoundation(wasteCards.Count - 1))
                    {
                        madeMoves = true;
                        movesMade++;
                        continue;
                    }
                }

                // Try all tableau piles to foundation
                for (int i = 0; i < 7; i++)
                {
                    if (MoveTableauToFoundation(i))
                    {
                        madeMoves = true;
                        movesMade++;
                        break;
                    }
                }
            }

            return movesMade;
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