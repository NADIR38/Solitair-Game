using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitaireGame.Backend
{
    
        public class Card
        {
            public Suit Suit { get; set; }
            public Color Color { get; set; }
            public bool IsFaceUp { get; set; }
            public Rank Rank { get; set; }
            //public string ImagePath { get; set; }

            public Card(Suit suit, Rank rank, bool isFaceUp ,Color color)
            {
                Suit = suit;
                Rank = rank;
                IsFaceUp = isFaceUp;
                Color = color;
            }

            public override string ToString()
            {
                return $"{Rank} of {Suit} ({Color})";
            }

        }
    
        public enum Suit
        {
            Hearts,
            Diamonds,
            Clubs,
            Spades
        }

        public enum Color
        {
            Red,
            Black
        }

        public enum Rank
        {
            Ace = 1,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King
        }
    }

