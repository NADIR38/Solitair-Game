using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitaireGame.Backend
{
    public class FoundationPile
    {
        public List<Foundation> piles;
        public FoundationPile()
        {
            piles=new List<Foundation>();
            for(int i=0; i < 4; i++)
            {
                piles.Add(new Foundation());
            }
        }
        public Foundation GetFoundation(Suit suit)
        {
            return piles[(int)suit];
        }
        public void PrintFoundations()
        {
            Console.WriteLine("\n--- Foundations ---");
            for (int i = 0; i < piles.Count; i++)
            {
                var top = piles[i].GetTopcard();
                Console.WriteLine($"Foundation {((Suit)i)}: {(top != null ? top.ToString() : "[Empty]")}");
            }
        }
        public bool IsComplete()
        {
            return piles.All(f => f.Cards.Count == 13);
        }

    }
}
