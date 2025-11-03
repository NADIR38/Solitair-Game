using SolitaireGame.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;
using Blazored.LocalStorage;  // ✅ ADD THIS


namespace SolitaireGame.Backend
{
    public class Movemanager
    {
        private readonly TableauPiles tableau;
        private readonly FoundationPile foundations;
        private readonly WastePile waste;
        private StockPile stock;

        private readonly MyStack<Commands> UndoStack;
        private readonly MyStack<Commands> RedoStack;
        private ILocalStorageService _localStorage;


        // ✅ ADD SCORE TRACKING
        private int currentScore = 0;

        public Movemanager(TableauPiles tableau, FoundationPile foundations, WastePile waste, StockPile stock)
        {
            this.tableau = tableau ?? throw new ArgumentNullException(nameof(tableau));
            this.foundations = foundations ?? throw new ArgumentNullException(nameof(foundations));
            this.waste = waste ?? throw new ArgumentNullException(nameof(waste));
            this.stock = stock ?? throw new ArgumentNullException(nameof(stock));

            UndoStack = new MyStack<Commands>();
            RedoStack = new MyStack<Commands>();
        }
        // ✅ ADD THIS - Set localStorage service
        public void SetLocalStorage(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }
        // ✅ ADD THIS - GET SCORE
        public int GetCurrentScore() => currentScore;

        // ✅ ADD THIS - RESET SCORE (for new game)
        public void ResetScore()
        {
            currentScore = 0;
        }

        private void RecordMove(Commands command)
        {
            UndoStack.Push(command);
            RedoStack.Clear();
        }

        public bool MoveWasteToTableau(int pileIndex, int wasteCardIndex)
        {
            var wasteCards = waste.GetAllCards();
            if (wasteCardIndex < 0 || wasteCardIndex >= wasteCards.Count)
                return false;

            Card cardToMove = wasteCards[wasteCardIndex];
            Card targetTop = tableau.GetTopCard(pileIndex);

            if (targetTop == null && cardToMove.Rank != Rank.King)
                return false;
            if (targetTop != null && !(IsOppositeColor(cardToMove, targetTop) && IsOneRankLower(cardToMove, targetTop)))
                return false;

            var command = new Commands(
                Execute: () =>
                {
                    waste.RemoveCard(cardToMove);
                    tableau.piles[pileIndex].AddCard(cardToMove);
                    currentScore += 5;  // ✅ ADD SCORE
                },
                Undo: () =>
                {
                    tableau.piles[pileIndex].RemoveCard();
                    waste.AddCard(cardToMove);
                    currentScore -= 5;  // ✅ UNDO SCORE
                }
            );

            command.Execute();
            RecordMove(command);
            return true;
        }

        public bool MoveWasteToFoundation(int wasteCardIndex)
        {
            var wasteCards = waste.GetAllCards();
            if (wasteCardIndex < 0 || wasteCardIndex >= wasteCards.Count)
                return false;

            Card cardToMove = wasteCards[wasteCardIndex];
            Foundation f = foundations.GetFoundation(cardToMove.Suit);

            if (!f.CanAdd(cardToMove))
                return false;

            var command = new Commands(
                Execute: () =>
                {
                    waste.RemoveCard(cardToMove);
                    f.Add(cardToMove);
                    currentScore += 10;  // ✅ ADD SCORE
                },
                Undo: () =>
                {
                    f.Cards.Pop();
                    waste.AddCard(cardToMove);
                    currentScore -= 10;  // ✅ UNDO SCORE
                }
            );

            command.Execute();
            RecordMove(command);
            return true;
        }

        public bool MoveTableauToFoundation(int pileIndex)
        {
            Card topCard = tableau.GetTopCard(pileIndex);
            if (topCard == null)
                return false;

            Foundation f = foundations.GetFoundation(topCard.Suit);
            if (!f.CanAdd(topCard))
                return false;

            var removedCard = topCard;
            var pileCardsBeforeMove = tableau.piles[pileIndex].GetCards();

            Card cardThatWillBeFlipped = null;
            if (pileCardsBeforeMove.Count > 1)
            {
                cardThatWillBeFlipped = pileCardsBeforeMove[pileCardsBeforeMove.Count - 2];
            }

            var command = new Commands(
                Execute: () =>
                {
                    var card = tableau.piles[pileIndex].RemoveCard();
                    f.Add(card);
                    tableau.piles[pileIndex].FlipTopCard();
                    currentScore += 10;  // ✅ ADD SCORE
                },
                Undo: () =>
                {
                    f.Cards.Pop();

                    if (cardThatWillBeFlipped != null && cardThatWillBeFlipped.IsFaceUp)
                    {
                        cardThatWillBeFlipped.IsFaceUp = false;
                    }

                    tableau.piles[pileIndex].AddCard(removedCard);
                    currentScore -= 10;  // ✅ UNDO SCORE
                }
            );

            command.Execute();
            RecordMove(command);
            return true;
        }

        public bool MoveTableauToTableau(int fromIndex, int startIndex, int toIndex)
        {
            var fromPile = tableau.piles[fromIndex];
            var toPile = tableau.piles[toIndex];
            var cards = fromPile.GetCards();

            if (startIndex < 0 || startIndex >= cards.Count)
                return false;
            if (!cards[startIndex].IsFaceUp)
                return false;

            var sequence = cards.GetRange(startIndex, cards.Count - startIndex);
            Card movingCard = sequence[0];
            Card targetTop = toPile.GetTopCard();

            if (targetTop == null && movingCard.Rank != Rank.King)
                return false;
            if (targetTop != null && !(IsOppositeColor(movingCard, targetTop) && IsOneRankLower(movingCard, targetTop)))
                return false;

            var sequenceCopy = new List<Card>(sequence);

            Card cardThatWillBeFlipped = null;
            if (startIndex > 0)
            {
                cardThatWillBeFlipped = cards[startIndex - 1];
            }

            var command = new Commands(
                Execute: () =>
                {
                    fromPile.RemoveTopCards(sequenceCopy.Count);
                    fromPile.FlipTopCard();
                    foreach (var c in sequenceCopy)
                        toPile.AddCard(c);
                    currentScore += 3;  // ✅ ADD SCORE
                },
                Undo: () =>
                {
                    toPile.RemoveTopCards(sequenceCopy.Count);

                    if (cardThatWillBeFlipped != null && cardThatWillBeFlipped.IsFaceUp)
                    {
                        cardThatWillBeFlipped.IsFaceUp = false;
                    }

                    foreach (var c in sequenceCopy)
                        fromPile.AddCard(c);
                    currentScore -= 3;  // ✅ UNDO SCORE
                }
            );

            command.Execute();
            RecordMove(command);
            return true;
        }

        public bool DrawFromStock()
        {
            if (stock.IsEmpty())
            {
                var wasteCards = waste.GetAllCards();
                if (wasteCards.Count == 0)
                    return false;

                var wasteCardsCopy = new List<Card>(wasteCards);

                var command = new Commands(
                    Execute: () =>
                    {
                        waste.Clear();
                        var reversedCards = new List<Card>(wasteCardsCopy);
                        reversedCards.Reverse();

                        foreach (var card in reversedCards)
                        {
                            card.IsFaceUp = false;
                            stock.AddCard(card);
                        }
                    },
                    Undo: () =>
                    {
                        for (int i = 0; i < wasteCardsCopy.Count; i++)
                        {
                            stock.DrawOne();
                        }

                        foreach (var card in wasteCardsCopy)
                        {
                            card.IsFaceUp = true;
                            waste.AddCard(card);
                        }
                    }
                );

                command.Execute();
                RecordMove(command);
                return true;
            }
            else
            {
                var drawnCards = new List<Card>();
                int drawCount = Math.Min(3, stock.Count);

                for (int i = 0; i < drawCount; i++)
                {
                    if (!stock.IsEmpty())
                    {
                        drawnCards.Add(stock.DrawOne());
                    }
                }

                if (drawnCards.Count == 0)
                    return false;

                var command = new Commands(
                    Execute: () =>
                    {
                        foreach (var card in drawnCards)
                        {
                            card.IsFaceUp = true;
                            waste.AddCard(card);
                        }
                    },
                    Undo: () =>
                    {
                        for (int i = drawnCards.Count - 1; i >= 0; i--)
                        {
                            waste.RemoveCard(drawnCards[i]);
                            drawnCards[i].IsFaceUp = false;
                            stock.AddCardToFront(drawnCards[i]);
                        }
                    }
                );

                command.Execute();
                RecordMove(command);
                return true;
            }
        }

        public bool UndoLastMove()
        {
            if (UndoStack.Count == 0)
                return false;

            var command = UndoStack.Pop();
            command.Undo();
            RedoStack.Push(command);
            return true;
        }

        public bool RedoLastMove()
        {
            if (RedoStack.Count == 0)
                return false;

            var command = RedoStack.Pop();
            command.Execute();
            UndoStack.Push(command);
            return true;
        }

        public bool CanUndo()
        {
            return UndoStack.Count > 0;
        }

        public bool CanRedo()
        {
            return RedoStack.Count > 0;
        }

        public bool CheckWin()
        {
            return foundations.IsComplete();
        }

        public bool CanAutoComplete()
        {
            for (int i = 0; i < 7; i++)
            {
                var cards = tableau.GetCardsInPile(i);
                if (cards.Any(c => !c.IsFaceUp))
                {
                    return false;
                }
            }
            return true;
        }

        public int AutoComplete()
        {
            int movesMade = 0;
            bool madeMoves = true;

            while (madeMoves)
            {
                madeMoves = false;

                var wasteCards = waste.GetAllCards();
                if (wasteCards.Count > 0)
                {
                    if (MoveWasteToFoundation(wasteCards.Count - 1))
                    {
                        madeMoves = true;
                        movesMade++;
                        continue;
                    }
                }

                for (int i = 0; i < 7; i++)
                {
                    if (MoveTableauToFoundation(i))
                    {
                        madeMoves = true;
                        movesMade++;
                        break;
                    }
                }
            }

            return movesMade;
        }

        // ✅ ========== COMPLETE FIXED SAVE/LOAD IMPLEMENTATION ========== 

        private static string GetSavePath()
        {
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string saveFolder = Path.Combine(appData, "SolitaireGame");

            if (!Directory.Exists(saveFolder))
                Directory.CreateDirectory(saveFolder);

            return saveFolder;
        }
        public async Task<bool> SaveGameAsync(int moveCount, int elapsedSeconds, string key = "solitaire_savegame")
        {
            if (_localStorage == null)
            {
                Console.WriteLine("❌ LocalStorage not initialized");
                return false;
            }

            try
            {
                var gameState = new GameState
                {
                    MoveCount = moveCount,
                    ElapsedSeconds = elapsedSeconds,
                    CurrentScore = currentScore,
                    SavedAt = DateTime.Now
                };

                SerializableCard ToSerializable(Card c) => new SerializableCard
                {
                    Suit = (int)c.Suit,
                    Rank = (int)c.Rank,
                    Color = (int)c.Color,
                    IsFaceUp = c.IsFaceUp
                };

                // Serialize Stock
                var stockCards = stock.GetAllCards();
                gameState.StockCards = stockCards.Select(ToSerializable).ToList();

                // Serialize Waste
                var wasteCards = waste.GetAllCards();
                gameState.WasteCards = wasteCards.Select(ToSerializable).ToList();

                // Serialize Tableau
                gameState.TableauCards = new List<List<SerializableCard>>();
                for (int i = 0; i < 7; i++)
                {
                    var pileCards = tableau.GetCardsInPile(i);
                    gameState.TableauCards.Add(pileCards.Select(ToSerializable).ToList());
                }

                // Serialize Foundations
                gameState.FoundationCards = new List<List<SerializableCard>>();
                for (int i = 0; i < 4; i++)
                {
                    var foundation = foundations.GetFoundation((Suit)i);
                    var foundationCards = foundation.Cards.ToListReversed();
                    gameState.FoundationCards.Add(foundationCards.Select(ToSerializable).ToList());
                }

                // ✅ Save to localStorage
                await _localStorage.SetItemAsync(key, gameState);

                Console.WriteLine($"✅ Game saved to localStorage with key: {key}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Save failed: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> DeleteSavedGameAsync(string key = "solitaire_savegame")
        {
            if (_localStorage == null)
                return false;

            try
            {
                await _localStorage.RemoveItemAsync(key);
                Console.WriteLine($"🗑️ Deleted saved game with key: {key}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Delete failed: {ex.Message}");
                return false;
            }
        }

        // ✅ RestoreGame stays the same (synchronous is fine)
        public bool RestoreGame(
             GameState state,
             out TableauPiles restoredTableau,
             out FoundationPile restoredFoundations,
             out WastePile restoredWaste,
             out StockPile restoredStock,
             out int moveCount,
             out int elapsedSeconds,
             out int score)
        {
            // ... (keep your existing RestoreGame implementation exactly the same) ...
            try
            {
                moveCount = state.MoveCount;
                elapsedSeconds = state.ElapsedSeconds;
                score = state.CurrentScore;
                currentScore = state.CurrentScore;

                Card DeserializeCard(SerializableCard sc) => new Card(
                    (Suit)sc.Suit,
                    (Rank)sc.Rank,
                    sc.IsFaceUp,
                    (Color)sc.Color
                );

                var stockCards = state.StockCards.Select(DeserializeCard).ToList();
                restoredStock = new StockPile(stockCards);

                restoredWaste = new WastePile();
                foreach (var sc in state.WasteCards)
                {
                    restoredWaste.AddCard(DeserializeCard(sc));
                }

                restoredTableau = new TableauPiles();
                for (int i = 0; i < 7; i++)
                {
                    restoredTableau.piles[i].Clear();
                    foreach (var sc in state.TableauCards[i])
                    {
                        restoredTableau.piles[i].AddCard(DeserializeCard(sc));
                    }
                }

                restoredFoundations = new FoundationPile();
                for (int i = 0; i < 4; i++)
                {
                    foreach (var sc in state.FoundationCards[i])
                    {
                        var card = DeserializeCard(sc);
                        restoredFoundations.GetFoundation((Suit)i).Cards.Push(card);
                    }
                }

                stock = restoredStock;

                waste.Clear();
                foreach (var sc in state.WasteCards)
                {
                    waste.AddCard(DeserializeCard(sc));
                }

                for (int i = 0; i < 7; i++)
                {
                    tableau.piles[i].Clear();
                    foreach (var sc in state.TableauCards[i])
                    {
                        tableau.piles[i].AddCard(DeserializeCard(sc));
                    }
                }

                for (int i = 0; i < 4; i++)
                {
                    while (foundations.GetFoundation((Suit)i).Cards.Count > 0)
                    {
                        foundations.GetFoundation((Suit)i).Cards.Pop();
                    }

                    foreach (var sc in state.FoundationCards[i])
                    {
                        var card = DeserializeCard(sc);
                        foundations.GetFoundation((Suit)i).Cards.Push(card);
                    }
                }

                UndoStack.Clear();
                RedoStack.Clear();

                Console.WriteLine("✅ Game restored successfully!");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Restore failed: {ex.Message}");

                restoredTableau = null;
                restoredFoundations = null;
                restoredWaste = null;
                restoredStock = null;
                moveCount = 0;
                elapsedSeconds = 0;
                score = 0;
                return false;
            }
        }
        // ✅ REPLACE LoadGame method with this async version
        public async Task<GameState> LoadGameAsync(string key = "solitaire_savegame")
        {
            if (_localStorage == null)
            {
                Console.WriteLine("❌ LocalStorage not initialized");
                return null;
            }

            try
            {
                var gameState = await _localStorage.GetItemAsync<GameState>(key);

                if (gameState == null)
                {
                    Console.WriteLine($"ℹ️ No save found with key: {key}");
                    return null;
                }

                Console.WriteLine($"✅ Loaded game from localStorage");
                return gameState;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Load failed: {ex.Message}");
                return null;
            }
        }



        // ✅ Helper methods
        private bool IsOppositeColor(Card a, Card b)
        {
            return a.Color != b.Color;
        }

        private bool IsOneRankLower(Card lower, Card higher)
        {
            return (int)higher.Rank - (int)lower.Rank == 1;
        }
    }
}