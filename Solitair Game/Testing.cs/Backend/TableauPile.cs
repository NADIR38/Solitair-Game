using SolitaireGame.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SolitaireGame.Backend
{
    public class TableauPile
    {
        public MyStack<Card> piles;
        public TableauPile() 
        { 
        piles=new MyStack<Card>();
        }
        public void Addcard(Card card)
        {
            piles.Push(card);
        }
        public Card Removecard()
        {if (piles.Count > 0)
                return piles.pop();
            else
                return null;
        }
        public Card getTopCard()
        {
            if(piles.Count == 0)
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
                Card top=piles.pop();
                top.IsFaceUp = true;
                piles.Push(top);
            }
        }
    }
}
