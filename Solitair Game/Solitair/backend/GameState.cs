using System;
using System.Collections.Generic;

namespace SolitaireGame.Backend
{
    [Serializable]
    public class GameState
    {
        // Card positions
        public List<SerializableCard> StockCards { get; set; }
        public List<SerializableCard> WasteCards { get; set; }
        public List<List<SerializableCard>> TableauCards { get; set; }
        public List<List<SerializableCard>> FoundationCards { get; set; }

        // Game progress
        public int MoveCount { get; set; }
        public int ElapsedSeconds { get; set; }
        public int CurrentScore { get; set; }

        // Metadata
        public DateTime SavedAt { get; set; }

        public GameState()
        {
            TableauCards = new List<List<SerializableCard>>();
            FoundationCards = new List<List<SerializableCard>>();
            StockCards = new List<SerializableCard>();
            WasteCards = new List<SerializableCard>();
        }
    }

    [Serializable]
    public class SerializableCard
    {
        public int Suit { get; set; }
        public int Rank { get; set; }
        public int Color { get; set; }
        public bool IsFaceUp { get; set; }
    }
}