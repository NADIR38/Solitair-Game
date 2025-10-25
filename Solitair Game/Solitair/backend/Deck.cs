

using SolitaireGame.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SolitaireGame.Backend
{
   public class Deck
    {
       private MyLinkedList<Card> Cards;
        private static readonly Random rand = new Random();
        public Deck() { 
        Cards = new MyLinkedList<Card>();

        }
        public void IntializeDeck()
        {
            foreach(Suit suit in Enum.GetValues(typeof(Suit)))
                {
                foreach(Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    Color color;
                    if (suit == Suit.Hearts || suit == Suit.Diamonds)
                    {
                        color = Color.Red;
                    }
                    else
                    {
                        color = Color.Black;
                    }
                    //string imagePath = $"Images/{suit}/{rank}.png";
                    var card=new Card(suit,rank,false,color);
                    Cards.AddLast(card);
                }

            }
        }
        public MyLinkedList<Card> GetCards()
        {
            return Cards;
        }
        public void ShuffleCards(MyLinkedList<Card> cards)
        {
            List<Card> list = new List<Card>();
            var current = cards.Head;
            while (current != null)
            {
                list.Add(current.Data);
                current = current.Next;
            }

            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }

            cards.Clear();
            foreach (var card in list)
                cards.AddLast(card);
        }
        public Card DrawTopCard()
        {
            if(Cards.Count == 0)
            {
                throw new InvalidOperationException("No cards left in the deck");

            }
            Node<Card> TopCard = Cards.GetHead();
            Card card=TopCard.Data;
            Cards.RemoveFirst();
            return card;
        }
        public List<Card> DealCards()
        {
            List<Card> dealt = new List<Card>();
            while (Cards.Count > 0)
            {
                dealt.Add(DrawTopCard());
            }
            return dealt;
        }

        public int GetrmainingCardCount()
        {
            return Cards.Count;
        }   
    }
}
