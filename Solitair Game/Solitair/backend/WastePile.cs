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

        public void AddCard(Card card)
        {
            if (card == null)
                return;

            card.IsFaceUp = true;  
            wasteCards.AddLast(card);
        }

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

        public List<Card> GetAllCards()
        {
            return wasteCards.ToList();
        }

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

        public void RemoveCard(Card card)
        {
            if (card == null)
                return;

            wasteCards.Remove(card);
        }

        public void Clear()
        {
            wasteCards.Clear();
        }

        public override string ToString()
        {
            return wasteCards.ToString();
        }
    }
}
