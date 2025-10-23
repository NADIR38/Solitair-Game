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
            return stock.Isempty();
        }

        public List<Card> DrawThree()
        {
            var drawnCards = new List<Card>();

            for (int i = 0; i < 3 && !stock.Isempty(); i++)
            {
                drawnCards.Add(stock.Dequeue());
            }

            return drawnCards;
        }

        public void RefillFromWaste(IEnumerable<Card> wasteCards)
        {
            // When stock is empty, refill it from the waste pile
            foreach (var card in wasteCards)
            {
                stock.enqueue(card);
            }
        }
        public Card DrawOne()
        {
            if (stock.Isempty())
                return null;

            return stock.Dequeue();
        }
        public int Count
        {
            get { return stock.Count; }
        }
    }
}
