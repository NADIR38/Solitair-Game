using SolitaireGame.DataStructures;
using System;
using System.Collections.Generic;

namespace SolitaireGame.Backend
{
    public class WastePile
    {
        private MyLinkedList<Card> wasteCards;

        public WastePile()
        {
            wasteCards = new MyLinkedList<Card>();
        }

        // ✅ Add one card (e.g., when drawn from StockPile)
        public void AddCard(Card card)
        {
            if (card == null)
                return;

            card.IsFaceUp = true;  // Waste cards are always face up
            wasteCards.AddLast(card);
        }

        // ✅ Draw top 3 cards from stock
        public void DrawFromStock(StockPile stock)
        {
            if (stock == null)
                throw new ArgumentNullException(nameof(stock));

            int drawCount = 3;
            int count = 0;

            while (!stock.IsEmpty() && count < drawCount)
            {
                Card drawn = stock.DrawOne();
                AddCard(drawn);
                count++;
            }
        }

        // ✅ Get all waste cards as a list (for UI display or logic)
        public List<Card> GetAllCards()
        {
            return wasteCards.ToList();
        }

        // ✅ Get top (most recent) card
        public Card GetTopCard()
        {
            Node<Card> current = wasteCards.GetHead();
            if (current == null)
                return null;

            while (current.Next != null)
            {
                current = current.Next;
            }
            return current.Data;
        }

        // ✅ Remove a specific card (if one of the 3 visible is played)
        public void RemoveCard(Card card)
        {
            if (card == null)
                return;

            wasteCards.Remove(card);
        }

        // ✅ Clear all cards (used when resetting game)
        public void Clear()
        {
            wasteCards.Clear();
        }

        // ✅ Helper for debugging
        public override string ToString()
        {
            return wasteCards.ToString();
        }
    }
}
