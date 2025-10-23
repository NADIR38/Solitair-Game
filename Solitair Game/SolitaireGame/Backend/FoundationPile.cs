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
    }
}
