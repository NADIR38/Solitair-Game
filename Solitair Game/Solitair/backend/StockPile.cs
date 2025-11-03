using SolitaireGame.DataStructures;
using System;
using System.Collections.Generic;

namespace SolitaireGame.Backend
{
    public class StockPile
    {
        private MyQueue<Card> stock;

        public StockPile(IEnumerable<Card> cards)
        {
            stock = new MyQueue<Card>(cards);
        }

        public bool IsEmpty()
        {
            return stock.IsEmpty();
        }

        public Card DrawOne()
        {
            if (stock.IsEmpty())
                return null;

            return stock.Dequeue();
        }

        // New method to support undo
        public void AddCard(Card card)
        {
            if (card == null)
                return;
            stock.Enqueue(card);
        }
        public List<Card> GetAllCards()
        {
            var cards = new List<Card>();
            var tempNode = stock.front;

            while (tempNode != null)
            {
                cards.Add(tempNode.Data);
                tempNode = tempNode.Next;
            }

            return cards;
        }
        // New method to add card to front (for undo of draw)
        public void AddCardToFront(Card card)
        {
            if (card == null)
                return;

            // Create new queue with card at front
            var tempList = new List<Card> { card };

            // Add existing cards
            while (!stock.IsEmpty())
            {
                tempList.Add(stock.Dequeue());
            }

            // Rebuild queue
            foreach (var c in tempList)
            {
                stock.Enqueue(c);
            }
        }

        public int Count
        {
            get { return stock.Count; }
        }
    }
}