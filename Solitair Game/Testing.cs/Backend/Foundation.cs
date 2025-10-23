using SolitaireGame.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitaireGame.Backend
{
    public  class Foundation
    {
        public MyStack<Card> Cards;
        public bool CanAdd(Card card)
        {
            if (Cards.Count == 0)
            {
                return card.Rank == Rank.Ace;
            }
            Card top = Cards.Peek();
            return card.Suit == top.Suit && (int)card.Rank == (int)top.Rank + 1;
          
        }
        public void Add(Card card) 
        {
            if (!CanAdd(card))
            {
                throw new InvalidOperationException("Cannot move to foundation");

            }
            Cards.Push(card);

        }
        public Card GetTopcard()
        {
            if(Cards.Count == 0)
            {
                return null;
            }
            return Cards.Peek();
        }

    }
}
