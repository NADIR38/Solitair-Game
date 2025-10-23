using System;
using System.Linq;
using SolitaireGame.Backend;

namespace Testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ✅ 1. Create and prepare the deck
            Deck deck = new Deck();
            deck.IntializeDeck();
            deck.ShuffleCards(deck.GetCards());

            Console.WriteLine("Deck initialized and shuffled.");
            Console.WriteLine($"Total cards in deck: {deck.GetCards().Count}\n");

            // ✅ 2. Create StockPile using shuffled deck
            var stock = new StockPile(deck.GetCards().ToList());

            // ✅ 3. Create an empty WastePile
            var waste = new WastePile();

            // ✅ 4. Draw 3 cards from stock into waste
            waste.DrawFromStock(stock);

            // ✅ 5. Show results
            Console.WriteLine("Waste Pile after drawing 3 cards:");
            Console.WriteLine("----------------------------------");

            var wasteCards = waste.GetAllCards();
            int i = 1;
            foreach (var card in wasteCards)
            {
                Console.WriteLine($"{i}. {card}");
                i++;
            }

            Console.WriteLine($"\nCards left in StockPile: {stock.Count}");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Test complete ✅");

            Console.ReadKey();
        }
    }
}
