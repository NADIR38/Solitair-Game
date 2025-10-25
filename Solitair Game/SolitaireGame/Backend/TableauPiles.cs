using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitaireGame.Backend
{
    public class TableauPiles
    {
        public List<TableauPile> piles;
        public TableauPiles()
        {
            piles = new List<TableauPile>();
            for (int i = 0; i < 7; i++)
            {
                piles.Add(new TableauPile());
            }

        }
        public void DealCards(Deck deck)
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Card card = deck.DrawTopCard();
                    piles[i].Addcard(card);
                    if (j == i)
                    {
                        card.IsFaceUp = true;
                    }
                }
            }
        }
        public Card GetTopCard(int pileIndex) => piles[pileIndex].getTopCard();
        public List<Card> GetCardsInPile(int pileIndex) => piles[pileIndex].GetCards();
        public void AddSequenceToPile(int pileIndex, List<Card> sequence)
        {
            foreach (var card in sequence)
                piles[pileIndex].Addcard(card);
        }
        public void RemoveTopCardsFromPile(int pileIndex, int count)
        {
            piles[pileIndex].RemoveTopCards(count);
            piles[pileIndex].FlipTopCard();
        }

        public void PrintTableau()
        {
            Console.WriteLine("\n--- Tableau ---");
            for (int i = 0; i < 7; i++)
            {
                Console.Write($"Pile {i + 1}: ");
                foreach (var card in piles[i].GetCards())
                {
                    if (card.IsFaceUp)
                        Console.Write($"[{card}] ");
                    else
                        Console.Write("[XX] ");
                }
                Console.WriteLine();
            }
        }
    }
}