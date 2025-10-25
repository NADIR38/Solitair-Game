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
               throw new InvalidOperationException("Pile is empty");
        }
        public List<Card> GetSequenceFromIndex(int startIndex)
        {
            List<Card> list = piles.ToListReversed(); 
            if (startIndex < 0 || startIndex >= list.Count)
                return new List<Card>();

            for (int i = startIndex; i < list.Count; i++)
            {
                if (!list[i].IsFaceUp)
                    return new List<Card>(); 
            }

            return list.GetRange(startIndex, list.Count - startIndex);
        }

        public void RemoveTopCards(int count)
        {
            if (count <= 0) return;
            for (int i = 0; i < count; i++)
            {
                if (piles.Count == 0) throw new InvalidOperationException("Not enough cards to remove");
                piles.pop();
            }
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
        public bool CanPlaceOnTop(Card card)
        {
            if (piles.Count == 0)
            {
                return card.Rank == Rank.King;
            }
             Card top = piles.Peek();    
            return top.IsFaceUp &&top.Color!=card.Color &&(int)card.Rank==(int)top.Rank-1;

        }
    }
}
