using SolitaireGame.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SolitaireGame.Backend
{
    public class TableauPile
    {
        private MyStack<Card> piles;

        public TableauPile()
        {
            piles = new MyStack<Card>();
        }

        public void AddCard(Card card)
        {
            piles.Push(card);
        }

        public Card RemoveCard()
        {
            if (piles.Count > 0)
                return piles.Pop();
            else
                throw new InvalidOperationException("Pile is empty");
        }

        public void RemoveTopCards(int count)
        {
            if (count <= 0) return;
            for (int i = 0; i < count; i++)
            {
                if (piles.Count == 0)
                    throw new InvalidOperationException("Not enough cards to remove");
                piles.Pop();
            }
        }
        // ✅ ADD THIS METHOD
        public void Clear()
        {
            piles.Clear();
        }

        public Card GetTopCard()
        {
            if (piles.Count == 0)
            {
                return null;
            }
            return piles.Peek();
        }

        public List<Card> GetCards()
        {
            return piles.ToListReversed();
        }

        public void FlipTopCard()
        {
            if (piles.Count > 0)
            {
                Card top = piles.Peek();
                if (!top.IsFaceUp)
                {
                    top.IsFaceUp = true;
                }
            }
        }

        public bool CanPlaceOnTop(Card card)
        {
            if (piles.Count == 0)
            {
                return card.Rank == Rank.King;
            }
            Card top = piles.Peek();
            return top.IsFaceUp && top.Color != card.Color && (int)card.Rank == (int)top.Rank - 1;
        }
    }
}