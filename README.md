# <div align="center">🃏 **SOLITAIRE GAME - KLONDIKE EDITION** 🃏</div>

<!-- ✅ Typing Animation -->
<div align="center">
  <img src="https://readme-typing-svg.herokuapp.com?lines=🎮+Classic+Klondike+Solitaire;💎+Custom+Data+Structures;🚀+Blazor+WebAssembly;✨+Full+Stack+C%23+Implementation;🎯+Scoring+%26+Save+System;📊+Complete+Persistence!&font=Orbitron&center=true&width=800&height=80&duration=3000&pause=1000&color=4169E1&size=25&weight=700" alt="Typing Animation" />
</div>

<div align="center">
  <img src="https://user-images.githubusercontent.com/73097560/115834477-dbab4500-a447-11eb-908a-139a6edaec5c.gif" width="100%">
</div>

<!-- 🖼️ Game GIF -->
<div align="center">
  <img src="https://media.giphy.com/media/l0HlBO7eyXzSZkJri/giphy.gif" alt="Solitaire GIF" width="200" />
</div>

---

## <img src="https://fonts.gstatic.com/s/e/notoemoji/latest/1f3ae/512.gif" alt="🎮" width="35" height="35"> **About The Project**

```javascript
const SolitaireGame = {
    name: "Klondike Solitaire",
    course: "CSC200 - Data Structure & Algorithms",
    developer: "NADIR JAMAL",
    rollNumber: "2024-CS-38",
    currentStatus: "Blazor WebAssembly Implementation ✅",
    platform: "Web-Based (Blazor WASM) 🚀",
    techStack: ["C#", ".NET 8.0", "Blazor WebAssembly", "Custom Data Structures"],
    specialFeatures: [
        "100% Custom DS Implementation",
        "Scoring System (Standard Mode)",
        "Auto-Save on Exit with Load Prompt",
        "Complete State Persistence (JSON)",
        "Undo/Redo with Command Pattern",
        "Smart Game Restoration",
        "Drag & Drop + Double-Click"
    ],
    playReference: "https://solitaired.com/",
    motto: "Learn by Building, Master by Playing! 🎯"
    Game Link:"https://nadir-solitaire-game.netlify.app/"
};

console.log("🎴 Welcome to the ultimate Solitaire experience! 🎴");
```

<div align="center">
  <img src="https://komarev.com/ghpvc/?username=NADIR38&label=Project%20Views&color=4169E1&style=for-the-badge" alt="Views" />
  <img src="https://img.shields.io/badge/Status-Fully%20Functional-4169E1?style=for-the-badge" alt="Status" />
  <img src="https://img.shields.io/badge/C%23-11.0-4169E1?style=for-the-badge&logo=csharp" alt="C#" />
  <img src="https://img.shields.io/badge/.NET-8.0-4169E1?style=for-the-badge&logo=dotnet" alt=".NET" />
  <img src="https://img.shields.io/badge/Blazor-WebAssembly-4169E1?style=for-the-badge&logo=blazor" alt="Blazor" />
</div>

---

## <img src="https://fonts.gstatic.com/s/e/notoemoji/latest/1f4cb/512.gif" alt="📋" width="35" height="35"> **Table of Contents**

- [🎲 Game Rules](#-game-rules)
- [✨ Features Implemented](#-features-implemented)
- [🏗️ Data Structures Used](#️-data-structures-used)
- [🎯 Scoring System](#-scoring-system)
- [💾 Save/Load System](#-saveload-system)
- [💻 Technology Stack](#-technology-stack)
- [📁 Project Structure](#-project-structure)
- [🚀 Installation & Setup](#-installation--setup)
- [🎮 How to Play](#-how-to-play)
- [🎯 Implementation Details](#-implementation-details)
- [🧪 Testing Guidelines](#-testing-guidelines)
- [📊 Project Statistics](#-project-statistics)
- [🐛 Known Issues & Solutions](#-known-issues--solutions)
- [🔮 Future Enhancements](#-future-enhancements)
- [🤝 Contributing](#-contributing)
- [📄 License](#-license)
- [📧 Contact & Support](#-contact--support)

---

## <img src="https://fonts.gstatic.com/s/e/notoemoji/latest/1f3b2/512.gif" alt="🎲" width="35" height="35"> **Game Rules**

### 🎯 **Objective**
Move all 52 cards to the four foundation piles, building each pile from Ace to King in the same suit.

<div align="center">
<table>
<tr>
<td width="25%">

### 🏗️ **Setup**
```yaml
Tableau: 7 piles
  - Pile 1: 1 card
  - Pile 2: 2 cards
  - Pile 3: 3 cards
  - ...
  - Pile 7: 7 cards
  
Top card: Face up
Others: Face down
Total: 28 cards
```

</td>
<td width="25%">

### 📚 **Stock Pile**
```yaml
Remaining: 24 cards
Draw mode: 3 cards at a time
Location: Top-left
Action: Click to draw
Refill: Auto from waste pile
Cycles: Unlimited
```

</td>
<td width="25%">

### 🗑️ **Waste Pile**
```yaml
Purpose: Drawn cards area
Cards: Face up
Visible: Last 3 cards
Source: Stock pile
Usage: Drag top card
Recycle: Returns to stock
```

</td>
<td width="25%">

### 🏆 **Foundation**
```yaml
Piles: 4 (one per suit)
Start: Ace
End: King
Order: Ascending
Rule: Same suit only
Win: All 52 cards
```

</td>
</tr>
</table>
</div>

### ✅ **Valid Moves**

<div align="center">

| From → To | Rule | Example |
|:---:|:---|:---|
| 🎴 **Tableau → Tableau** | Alternating colors, descending rank | ❤️ Red 7 on ♠️ Black 8 |
| 🎴 **Tableau → Foundation** | Same suit, ascending from Ace | ♠️ Ace, then ♠️ 2, ♠️ 3... |
| 🎴 **Stock → Waste** | Draw 3 cards | Click stock pile |
| 🎴 **Waste → Tableau** | Follow tableau rules | Drag top card |
| 🎴 **Waste → Foundation** | Follow foundation rules | Drag or double-click |
| 👑 **King Only** | Only Kings to empty tableau | Empty slot = King only |

</div>

### 🏅 **Win Condition**
```diff
+ All 52 cards moved to foundation piles
+ Each foundation has 13 cards (Ace → King)
+ All cards in correct suit order
+ Tableau and stock piles are empty
+ Game auto-deletes save file on win
+ Win modal displays final statistics
```

---

## <img src="https://fonts.gstatic.com/s/e/notoemoji/latest/2728/512.gif" alt="✨" width="35" height="35"> **Features Implemented**

<div align="center">
<table>
<tr>
<td width="50%">

### ✅ **Core Features**
```diff
+ ✅ Complete Klondike rule implementation
+ ✅ 52-card deck with Fisher-Yates shuffle
+ ✅ Custom data structures (Stack, Queue, LinkedList)
+ ✅ Tableau dealing (7 piles, 28 cards)
+ ✅ Stock pile with draw-3 mode
+ ✅ Waste pile with proper display (last 3 visible)
+ ✅ Foundation pile building (Ace → King)
+ ✅ Valid move detection & enforcement
+ ✅ Automatic card flipping logic
+ ✅ Win condition checking with modal
+ ✅ Full drag & drop functionality
+ ✅ Double-click to move to foundation
+ ✅ Empty tableau accepts Kings only
+ ✅ Stock recycles from waste pile
```

</td>
<td width="50%">

### ✅ **Advanced Features**
```diff
+ ✅ Real-time Scoring System
  ├─ Waste → Tableau: +5 points
  ├─ Waste → Foundation: +10 points
  ├─ Tableau → Foundation: +10 points
  └─ Tableau → Tableau: +3 points
  
+ ✅ Complete Save/Load System
  ├─ Auto-save on browser close/exit
  ├─ Smart load prompt on startup
  ├─ Shows saved game details
  ├─ JSON serialization
  └─ Custom data structure handling
  
+ ✅ Undo/Redo (Command Pattern)
  ├─ Unlimited undo/redo
  ├─ Score adjustment on undo
  └─ Complete state restoration
  
+ ✅ UI/UX Features
  ├─ Move counter tracking
  ├─ Game timer (MM:SS format)
  ├─ Auto-complete feature
  ├─ Beautiful responsive design
  ├─ Color-coded cards (Red/Black)
  ├─ Suit symbols (♥ ♦ ♣ ♠)
  └─ Win celebration modal
```

</td>
</tr>
</table>
</div>

---

## <img src="https://fonts.gstatic.com/s/e/notoemoji/latest/1f3d7/512.gif" alt="🏗️" width="35" height="35"> **Data Structures Used**

<div align="center">

This project implements **custom data structures from scratch** - no built-in .NET collections used!

</div>

<div align="center">
<table>
<tr>
<td width="33%">

### 📚 **Stack (LIFO)**

<img src="https://cdn-icons-png.flaticon.com/512/2103/2103633.png" width="60" />

```csharp
MyStack<Card>
├── Push(item)
├── Pop()
├── Peek()
├── IsEmpty()
├── Count
├── ToListReversed()
└── Clear()
```

**🎯 Used For:**
- Tableau piles (7 columns)
- Foundation piles (4 suits)
- Undo/Redo command history
- Card movement tracking

**📊 Complexity:**
- Push: O(1)
- Pop: O(1)
- Peek: O(1)

**📄 File:** `MyStack.cs`

</td>
<td width="33%">

### 🎯 **Queue (FIFO)**

<img src="https://cdn-icons-png.flaticon.com/512/3176/3176283.png" width="60" />

```csharp
MyQueue<Card>
├── Enqueue(item)
├── Dequeue()
├── GetFront()
├── IsEmpty()
├── Count
├── GetAllCards()
└── Constructor(IEnumerable)
```

**🎯 Used For:**
- Stock pile (draw pile)
- Card drawing order (draw 3)
- Waste pile refill mechanism
- Sequential card access

**📊 Complexity:**
- Enqueue: O(1)
- Dequeue: O(1)
- GetFront: O(1)

**📄 File:** `MyQueue.cs`

</td>
<td width="33%">

### 🔗 **Linked List**

<img src="https://cdn-icons-png.flaticon.com/512/3094/3094837.png" width="60" />

```csharp
MyLinkedList<Card>
├── AddFirst(item)
├── AddLast(item)
├── Remove(item)
├── RemoveFirst()
├── Clear()
├── ToList()
├── Count
└── ToString()
```

**🎯 Used For:**
- Initial deck creation
- Waste pile management
- Flexible card collections
- Dynamic card manipulation

**📊 Complexity:**
- AddFirst: O(1)
- AddLast: O(n)
- Remove: O(n)

**📄 File:** `Nodes.cs`

</td>
</tr>
</table>
</div>

### 🔄 **Data Structure Integration**

```
┌─────────────────────────────────────────────────────────┐
│                    GAME ARCHITECTURE                     │
├─────────────────────────────────────────────────────────┤
│                                                          │
│  Stock Pile (MyQueue)  →  Waste Pile (MyLinkedList)    │
│        ↓                          ↓                      │
│    Draw 3 cards              Display last 3              │
│        ↓                          ↓                      │
│  Tableau Piles (MyStack × 7)  →  Foundation (MyStack × 4)│
│        ↓                          ↓                      │
│  Alternating colors          Same suit, ascending        │
│        ↓                          ↓                      │
│  Undo/Redo Stack (MyStack)  ←  Command Pattern          │
│                                                          │
└─────────────────────────────────────────────────────────┘
```

---

## <img src="https://fonts.gstatic.com/s/e/notoemoji/latest/1f3af/512.gif" alt="🎯" width="35" height="35"> **Scoring System**

<div align="center">

### 🏆 **Standard Mode Scoring**

</div>

<div align="center">
<table>
<tr>
<td width="50%">

### 📊 **Point System**

```yaml
Move Points:
  Waste → Tableau: +5 points
  Waste → Foundation: +10 points
  Tableau → Foundation: +10 points
  Tableau → Tableau: +3 points
  
Special Moves:
  Card flip: No points
  Stock draw: No points
  Undo move: Reverses points
  
Maximum Possible:
  Perfect game: ~500+ points
  All foundations: 520 points (52 × 10)
```

**🎯 Strategy:** 
- Prioritize foundation moves (+10)
- Minimize tableau shuffling (+3)
- Use undo strategically
- Complete quickly for satisfaction!

</td>
<td width="50%">

### ⚡ **Live Score Updates**

```
┌──────────────────────────────────────┐
│  Score: 145  │  Moves: 87  │ 05:32  │
└──────────────────────────────────────┘

Real-time Features:
  ✅ Updates instantly on move
  ✅ Adjusts on undo/redo
  ✅ Saves with game state
  ✅ Displays on win screen
  ✅ Persists across sessions
```

**🏆 High Score Tips:**
1. Move to foundations early
2. Create empty tableau columns
3. Uncover hidden cards ASAP
4. Use undo to test strategies
5. Avoid unnecessary moves
6. Complete all foundations!

</td>
</tr>
</table>
</div>

### 📈 **Score Display**

```
Game Header:
┌────────────────────────────────────────────────────────┐
│  🃏 Solitaire                                          │
│  [New Game] [↶ Undo] [↷ Redo] [Auto Complete]        │
│  Score: 145  │  Moves: 87  │  Time: 05:32            │
└────────────────────────────────────────────────────────┘

Win Screen:
┌────────────────────────────────────────────────────────┐
│              🎉 Congratulations! You Won! 🎉            │
│         Score: 520 | Moves: 142 | Time: 08:45         │
│                   [Play Again]                         │
└────────────────────────────────────────────────────────┘
```

---

## <img src="https://fonts.gstatic.com/s/e/notoemoji/latest/1f4be/512.gif" alt="💾" width="35" height="35"> **Save/Load System**

<div align="center">

### 🔄 **Intelligent Auto-Save & Load**

</div>

### ✨ **How It Works**

<div align="center">

```mermaid
graph TD
    A[User Plays Game] --> B{User Closes/Exits?}
    B -->|Yes| C[IDisposable.Dispose Called]
    C --> D[Check: moveCount > 0 && !Won]
    D -->|Yes| E[SaveGame to JSON]
    E --> F[Store in AppData/savegame.json]
    F --> G[User Reopens Game]
    G --> H[OnInitializedAsync]
    H --> I[CheckForSavedGame]
    I --> J{Saved File Exists?}
    J -->|Yes| K[Load GameState]
    K --> L[Show Load Prompt Modal]
    L --> M{User Choice?}
    M -->|Load Game| N[RestoreGame Method]
    M -->|New Game| O[Delete Save + Start Fresh]
    J -->|No| O
    N --> P[Rebuild All Data Structures]
    P --> Q[Restore Score/Time/Moves]
    Q --> R[Continue Playing]
    O --> R
    R --> S{Win Game?}
    S -->|Yes| T[Delete Save File]
    S -->|No| A
```

</div>

### 📋 **What Gets Saved**

<div align="center">
<table>
<tr>
<td width="50%">

```yaml
Card Positions (SerializableCard):
  Stock Pile:
    - All remaining cards
    - Face-down state
    - Exact order preserved
    
  Waste Pile:
    - All drawn cards
    - Face-up state
    - Display order maintained
    
  Tableau Piles (7):
    - Each pile's full stack
    - Face up/down states
    - Bottom-to-top order
    - Empty piles tracked
    
  Foundation Piles (4):
    - Each suit's progress
    - Ace through King
    - Sequential order
    - Completion status
```

</td>
<td width="50%">

```yaml
Game Progress:
  Current Score:
    - Exact point total
    - Tracks all moves
    
  Move Count:
    - Total moves made
    - Includes undo/redo
    
  Elapsed Time:
    - Seconds played
    - Formatted as MM:SS
    - Continues on load
    
Metadata:
  Save Timestamp:
    - Date and time saved
    - Used in load prompt
    
  Game Version:
    - Compatibility check
    - Future-proofing
    
Card Format:
  - Suit (0-3: H,D,C,S)
  - Rank (1-13: A-K)
  - Color (0-1: R,B)
  - IsFaceUp (bool)
```

</td>
</tr>
</table>
</div>

### 💾 **Save File Location**

```yaml
Platform Locations:
  Windows: 
    C:\Users\{YourName}\AppData\Roaming\SolitaireGame\savegame.json
    
  Mac: 
    ~/Library/Application Support/SolitaireGame/savegame.json
    
  Linux: 
    ~/.config/SolitaireGame/savegame.json

File Format:
  - Human-readable JSON
  - ~2-5 KB file size
  - UTF-8 encoding
  - Pretty-printed (indented)
```

### 🎯 **Load Prompt Features**

When reopening the game with a saved state:

```
┌─────────────────────────────────────────────┐
│          📂 Saved Game Found                │
├─────────────────────────────────────────────┤
│  You have a saved game from:                │
│  Nov 07, 2024 15:30                         │
│                                             │
│  Score: 145 | Moves: 87 | Time: 05:32      │
│                                             │
│  [    Load Game    ]  [    New Game    ]   │
└─────────────────────────────────────────────┘

Load Button:
  ✅ Restores exact game state
  ✅ Rebuilds all data structures
  ✅ Continues timer from saved time
  ✅ Preserves score and moves
  
New Game Button:
  ✅ Deletes saved file
  ✅ Starts fresh game
  ✅ New shuffle
  ✅ Reset all counters
```

### ⚡ **Smart Features**

```diff
+ Auto-saves when closing browser/tab
+ Prompts on startup if save exists
+ Shows detailed game info before loading
+ Only saves if game in progress (moveCount > 0)
+ Doesn't save when game is won
+ Deletes save automatically on win
+ JSON format (human-readable)
+ Handles corrupted saves gracefully
+ Blazor IDisposable lifecycle integration
+ Console logging for debugging
+ Error recovery with fallback to new game
```

### 🔧 **Technical Implementation**

```csharp
// Save Trigger (Blazor Component)
public void Dispose() {
    gameTimer?.Dispose();
    
    // Only auto-save if game in progress
    if (moveManager != null && !showWinMessage && moveCount > 0) {
        Console.WriteLine("💾 Auto-saving game on exit...");
        bool saved = moveManager.SaveGame(moveCount, elapsedSeconds);
        Console.WriteLine(saved ? "✅ Game saved!" : "❌ Save failed!");
    }
}

// Load Check (On Startup)
protected override async Task OnInitializedAsync() {
    await JSRuntime.InvokeVoidAsync("registerBeforeUnload");
    CheckForSavedGame(); // Looks for savegame.json
}

// JavaScript Hook (index.html)
window.registerBeforeUnload = () => {
    window.addEventListener('beforeunload', function (e) {
        // Triggers Blazor's Dispose method
        return undefined;
    });
};
```

### 📊 **Serialization Process**

```
Original Data Structures → Serializable Format → JSON → File

1. MyQueue<Card>        →  List<SerializableCard>  →  JSON Array
2. MyStack<Card>        →  List<SerializableCard>  →  JSON Array
3. MyLinkedList<Card>   →  List<SerializableCard>  →  JSON Array

SerializableCard {
    int Suit;      // 0=Hearts, 1=Diamonds, 2=Clubs, 3=Spades
    int Rank;      // 1=Ace, 2-10=Number, 11=Jack, 12=Queen, 13=King
    int Color;     // 0=Red, 1=Black
    bool IsFaceUp; // true=visible, false=hidden
}
```

---

## <img src="https://fonts.gstatic.com/s/e/notoemoji/latest/1f4bb/512.gif" alt="💻" width="35" height="35"> **Technology Stack**

<div align="center">

### 🔧 **Complete Technology Stack**

<img src="https://skillicons.dev/icons?i=cs,dotnet,visualstudio,git,github,html,css&theme=dark" />

</div>

<div align="center">
<table>
<tr>
<td align="center" width="33%">

### 🎨 **Backend**
```yaml
Language: C# 11.0
Framework: .NET 8.0 SDK
Runtime: CoreCLR
Architecture: 
  - Object-Oriented Programming
  - SOLID Principles
  - Command Pattern (Undo/Redo)
  - MVC Separation
Data Structures: 
  - 100% Custom Implementation
  - No built-in collections
Serialization: 
  - System.Text.Json
  - Custom converters
```
<img src="https://cdn.worldvectorlogo.com/logos/c--4.svg" width="50" />

</td>
<td align="center" width="33%">

### 🖼️ **Frontend**
```yaml
Platform: Blazor WebAssembly
Framework: ASP.NET Core 8.0
UI Components: 
  - Razor Components
  - Component-based architecture
Styling: 
  - CSS3 (embedded)
  - Flexbox layout
  - Responsive design
Rendering: 
  - Client-side (browser)
  - Virtual DOM
JavaScript: 
  - Minimal JS interop
  - Save/load hooks only
```
<img src="https://cdn.worldvectorlogo.com/logos/blazor.svg" width="50" />

</td>
<td align="center" width="33%">

### 🛠️ **Tools & DevOps**
```yaml
IDE: Visual Studio 2022
VCS: Git & GitHub
Build System: MSBuild
Package Manager: NuGet
Runtime: WebAssembly (WASM)
Storage: 
  - Local file system
  - AppData folder
Browser Support:
  - Chrome 90+
  - Firefox 88+
  - Edge 90+
  - Safari 14+
Deployment: 
  - Static hosting ready
  - GitHub Pages compatible
```
<img src="https://cdn-icons-png.flaticon.com/512/906/906324.png" width="50" />

</td>
</tr>
</table>
</div>

### 📦 **Dependencies**

```xml
<!-- .csproj file -->
<Project Sdk="Microsoft.NET.Sdk.BlazorWebAssembly">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.Components.WebAssembly" Version="8.0.0" />
    <PackageReference Include="Microsoft.AspNetCore.Components.WebAssembly.DevServer" Version="8.0.0" PrivateAssets="all" />
  </ItemGroup>
</Project>

No external dependencies required! Pure C# implementation.
```

---

## <img src="https://fonts.gstatic.com/s/e/notoemoji/latest/1f4c1/512.gif" alt="📁" width="35" height="35"> **Project Structure**

```
SolitaireGame/
│
├── 📂 Backend/                          # Core game logic (800+ lines)
│   ├── Cards.cs                         # Card, Suit, Rank, Color enums
│   ├── Commands.cs                      # Command pattern for Undo/Redo
│   ├── Deck.cs                          # 52-card deck with Fisher-Yates shuffle
│   ├── Foundation.cs                    # Single foundation pile (Stack-based)
│   ├── FoundationPile.cs                # Container for 4 foundations
│   ├── GameState.cs                     # 🆕 Serializable game state
│   ├── Movemanager.cs                   # 🔥 Core logic (1200+ lines)
│   │   ├── Move validation
│   │   ├── Undo/Redo system
│   │   ├── Scoring logic
│   │   ├── SaveGame()
│   │   ├── LoadGame()
│   │   └── RestoreGame()
│   ├── TableauPile.cs                   # Single tableau column (Stack-based)
│   ├── TableauPiles.cs                  # Container for 7 tableau piles
│   ├── StockPile.cs                     # Draw pile (Queue-based)
│   └── WastePile.cs                     # Discard pile (LinkedList-based)
│
├── 📂 DataStructures/                   # Custom DS (600+ lines)
│   ├── Nodes.cs                         # Node<T> + MyLinkedList<T>
│   ├── MyStack.cs                       # Custom Stack<T> (LIFO)
│   └── MyQueue.cs                       # Custom Queue<T> (FIFO)
│
├── 📂 Pages/                            # Blazor Pages
│   └── Solitaire.razor                  # 🔥 Main game (1800+ lines)
│       ├── HTML markup (game board)
│       ├── @code section (game logic)
│       ├── Drag & drop handlers
│       ├── Save/Load UI logic
│       └── Timer & state management
│
├── 📂 Shared/                           # Shared components
│   ├── MainLayout.razor                 # Layout wrapper
│   └── NavMenu.razor                    # Navigation (if any)
│
├── 📂 wwwroot/                          # Static assets
│   ├── index.html                       # 🔥 Entry point (400+ lines CSS)
│   │   ├── Embedded CSS (game styling)
│   │   └── JavaScript hooks (save/load)
│   ├── css/
│   │   └── app.css                      # Additional styles
│   └── favicon.ico                      # Site icon
│
├── _Imports.razor                       # Global using directives
├── App.razor                            # Root component (routing)
├── Program.cs                           # Application entry point
├── SolitaireGame.csproj                 # Project file
├── README.md                            # 🔥 This file (complete docs)
├── .gitignore                           # Git ignore rules
└── LICENSE                              # Project license

📊 Project Stats:
   Total Files: 23
   Lines of Code: ~4,500+
   Classes: 23
   Methods: 150+
   Custom Data Structures: 3 (Stack, Queue, LinkedList)
```
## 📊 Class Diagram
````mermaid
classDiagram
    %% Enums
    class Suit {
        <<enumeration>>
        Hearts
        Diamonds
        Clubs
        Spades
    }
    
    class Rank {
        <<enumeration>>
        Ace
        Two to Ten
        Jack
        Queen
        King
    }
    
    class Color {
        <<enumeration>>
        Red
        Black
    }
    
    %% Core Card Class
    class Card {
        -Suit Suit
        -Rank Rank
        -Color Color
        -bool IsFaceUp
        +Card(Suit, Rank, bool, Color)
        +Flip()
        +ToString() string
    }
    
    %% Data Structures
    class Node~T~ {
        +T Data
        +Node~T~ Next
        +Node(T data)
    }
    
    class MyLinkedList~T~ {
        -Node~T~ head
        -int count
        +AddFirst(T item)
        +AddLast(T item)
        +Remove(T item) bool
        +RemoveFirst() T
        +Clear()
        +ToList() List~T~
        +Count int
    }
    
    class MyStack~T~ {
        -Node~T~ top
        -int count
        +Push(T item)
        +Pop() T
        +Peek() T
        +IsEmpty() bool
        +ToListReversed() List~T~
        +Clear()
        +Count int
    }
    
    class MyQueue~T~ {
        -Node~T~ front
        -Node~T~ rear
        -int count
        +Enqueue(T item)
        +Dequeue() T
        +GetFront() T
        +IsEmpty() bool
        +GetAllCards() List~T~
        +Count int
    }
    
    %% Game Components
    class Deck {
        -MyLinkedList~Card~ cards
        -Random rand
        +Deck()
        +ShuffleCards(MyLinkedList~Card~)
        +GetCards() MyLinkedList~Card~
    }
    
    class StockPile {
        -MyQueue~Card~ cards
        +StockPile(List~Card~)
        +DrawCards(int count) List~Card~
        +AddCard(Card)
        +GetAllCards() List~Card~
        +Count int
        +IsEmpty() bool
    }
    
    class WastePile {
        -MyLinkedList~Card~ cards
        +AddCard(Card)
        +RemoveCard(Card) bool
        +GetAllCards() List~Card~
        +GetLastThree() List~Card~
        +Clear()
        +Count int
    }
    
    class TableauPile {
        -MyStack~Card~ cards
        -int pileIndex
        +TableauPile(int index)
        +AddCard(Card)
        +RemoveCard() Card
        +RemoveCards(int count) List~Card~
        +GetTopCard() Card
        +GetAllCards() List~Card~
        +FlipTopCard()
        +Count int
        +IsEmpty() bool
    }
    
    class TableauPiles {
        -TableauPile[] piles
        +TableauPiles()
        +GetPile(int index) TableauPile
        +GetCardsInPile(int index) List~Card~
        +AddCardToPile(int index, Card)
    }
    
    class Foundation {
        -Suit suit
        -MyStack~Card~ cards
        +Foundation(Suit)
        +AddCard(Card) bool
        +RemoveCard() Card
        +Peek() Card
        +GetAllCards() List~Card~
        +Count int
        +IsEmpty() bool
    }
    
    class FoundationPile {
        -Foundation[] foundations
        +FoundationPile()
        +GetFoundation(Suit) Foundation
        +IsComplete() bool
        +GetAllFoundations() Foundation[]
    }
    
    %% Command Pattern
    class Commands {
        +Action Execute
        +Action Undo
        +Commands(Action execute, Action undo)
    }
    
    %% Serialization
    class SerializableCard {
        +int Suit
        +int Rank
        +int Color
        +bool IsFaceUp
    }
    
    class GameState {
        +List~SerializableCard~ StockCards
        +List~SerializableCard~ WasteCards
        +List~List~SerializableCard~~ TableauCards
        +List~List~SerializableCard~~ FoundationCards
        +int MoveCount
        +int ElapsedSeconds
        +int CurrentScore
        +DateTime SavedAt
    }
    
    %% Core Game Logic
    class MoveManager {
        -StockPile stock
        -WastePile waste
        -TableauPiles tableau
        -FoundationPile foundations
        -MyStack~Commands~ UndoStack
        -MyStack~Commands~ RedoStack
        -int currentScore
        +MoveManager(Deck)
        +DrawFromStock() bool
        +MoveWasteToTableau(int, int) bool
        +MoveWasteToFoundation(int) bool
        +MoveTableauToTableau(int, int, int) bool
        +MoveTableauToFoundation(int) bool
        +UndoLastMove() bool
        +RedoLastMove() bool
        +SaveGame(int, int) bool
        +LoadGame() GameState
        +RestoreGame(GameState) bool
        +CheckWinCondition() bool
        +GetCurrentScore() int
    }
    
    %% Blazor Component
    class SolitaireRazor {
        -MoveManager moveManager
        -int moveCount
        -int elapsedSeconds
        -bool showWinMessage
        -bool showLoadPrompt
        -Timer gameTimer
        +OnInitializedAsync()
        +OnAfterRender(bool)
        +Dispose()
        +NewGame()
        +OnDragStart(Card, int, int)
        +OnDropOnTableau(int)
        +OnDropOnFoundation(Suit)
        +CheckForSavedGame()
        +LoadSavedGame()
        +StartNewGame()
    }
    
    %% Relationships
    Card --> Suit
    Card --> Rank
    Card --> Color
    
    MyLinkedList~T~ --> Node~T~
    MyStack~T~ --> Node~T~
    MyQueue~T~ --> Node~T~
    
    Deck --> MyLinkedList~Card~
    Deck --> Card
    
    StockPile --> MyQueue~Card~
    StockPile --> Card
    
    WastePile --> MyLinkedList~Card~
    WastePile --> Card
    
    TableauPile --> MyStack~Card~
    TableauPile --> Card
    
    TableauPiles --> TableauPile
    
    Foundation --> MyStack~Card~
    Foundation --> Card
    Foundation --> Suit
    
    FoundationPile --> Foundation
    
    SerializableCard ..> Card : serializes
    GameState --> SerializableCard
    
    MoveManager --> StockPile
    MoveManager --> WastePile
    MoveManager --> TableauPiles
    MoveManager --> FoundationPile
    MoveManager --> MyStack~Commands~
    MoveManager --> Commands
    MoveManager --> GameState
    MoveManager --> Deck
    
    SolitaireRazor --> MoveManager
    SolitaireRazor --> Card
    
    note for MyStack~T~ "Generic LIFO\nUsed by Tableau,\nFoundation, Undo/Redo"
    note for MyQueue~T~ "Generic FIFO\nUsed by Stock Pile"
    note for MyLinkedList~T~ "Generic LinkedList\nUsed by Deck, Waste"
    note for MoveManager "Core Game Logic\n1200+ lines\nHandles all moves,\nscoring, save/load"
    note for Commands "Command Pattern\nfor Undo/Redo\nwith score tracking"
` ` `
````

### **Step 2: Add to Your README**

Find the **"Project Structure"** or **"Architecture"** section in your README and add:
````markdown
---

## 🏗️ **Class Diagram & Architecture**

<div align="center">

### 📊 Complete UML Class Diagram

The following diagram shows the complete architecture of the Solitaire game, including all classes, relationships, and key methods.

</div>
```mermaid
[PASTE THE MERMAID CODE HERE]
` ` `

### 🔍 **Diagram Legend**

| Symbol | Meaning |
|:---:|:---|
| `→` | **Association** (Class uses another class) |
| `..>` | **Dependency** (Temporary relationship) |
| `~T~` | **Generic Type** (Template/Generic class) |
| `-` | **Private** member |
| `+` | **Public** member |
| `<<enumeration>>` | Enum type |

### 📚 **Architecture Layers**
```
┌─────────────────────────────────────────┐
│         PRESENTATION LAYER              │
│      (SolitaireRazor Component)         │
└────────────────┬────────────────────────┘
                 │
┌────────────────▼────────────────────────┐
│         BUSINESS LOGIC LAYER            │
│         (MoveManager - Core)            │
└────────────────┬────────────────────────┘
                 │
┌────────────────▼────────────────────────┐
│         GAME COMPONENTS LAYER           │
│  (Stock, Waste, Tableau, Foundation)    │
└────────────────┬────────────────────────┘
                 │
┌────────────────▼────────────────────────┐
│      DATA STRUCTURES LAYER              │
│   (MyStack, MyQueue, MyLinkedList)      │
└────────────────┬────────────────────────┘
                 │
┌────────────────▼────────────────────────┐
│         DATA MODEL LAYER                │
│    (Card, Suit, Rank, Color)            │
└─────────────────────────────────────────┘
````

---
### 🔍 **Key Files Explained**

<div align="center">
<table>
<tr>
<td width="50%">

#### 🎯 **Core Game Files**

```yaml
Movemanager.cs (1200+ lines):
  - Central controller
  - Move validation
  - Undo/Redo logic
  - Score tracking
  - Save/Load system
  - Win detection
  - Auto-complete
  
Solitaire.razor (1800+ lines):
  - Complete UI
  - Game board rendering
  - Drag & drop
  - Event handlers
  - State management
  - Timer logic
  - Modal dialogs
```

</td>
<td width="50%">

#### 📚 **Data Structure Files**

```yaml
MyStack.cs:
  - Generic stack
  - Push/Pop operations
  - ToListReversed()
  - Used by Tableau & Foundation
  
MyQueue.cs:
  - Generic queue
  - Enqueue/Dequeue
  - FIFO behavior
  - Used by Stock pile
  
Nodes.cs:
  - Node<T> class
  - MyLinkedList<T>
  - Dynamic insertion
  - Used by Waste pile
```

</td>
</tr>
</table>
</div>

---

## <img src="https://fonts.gstatic.com/s/e/notoemoji/latest/1f680/512.gif" alt="🚀" width="35" height="35"> **Installation & Setup**

### 📋 **Prerequisites**

<div align="center">

| Requirement | Version | Download Link |
|:---:|:---:|:---:|
| **.NET SDK** | 8.0+ | [Download](https://dotnet.microsoft.com/download) |
| **Visual Studio** | 2022+ | [Download](https://visualstudio.microsoft.com/) |
| **Git** | Latest | [Download](https://git-scm.com/) |
| **Browser** | Modern | Chrome/Firefox/Edge |

</div>

**System Requirements:**
```yaml
OS: Windows 10/11, macOS 10.15+, Linux
RAM: 4GB minimum, 8GB recommended
Disk: 500MB free space
Screen: 1920x1080 recommended
```

### 📥 **Installation Steps**

#### Method 1: Visual Studio (Recommended)

```bash
# Step 1: Clone the repository
git clone https://github.com/NADIR38/SolitaireGame.git
cd SolitaireGame

# Step 2: Open in Visual Studio
# Double-click SolitaireGame.sln

# Step 3: Restore packages (automatic in VS)
# Or manually via Package Manager Console:
# PM> Update-Package -reinstall

# Step 4: Build the solution
# Visual Studio: Press Ctrl+Shift+B
# Or use menu: Build → Build Solution

# Step 5: Run the application
# Visual Studio: Press F5 (Debug) or Ctrl+F5 (No Debug)

# Step 6: Browser will open automatically
# Navigate to: https://localhost:7033/solitaire
```

#### Method 2: Command Line

```bash
# Step 1: Clone repository
git clone https://github.com/NADIR38/SolitaireGame.git
cd SolitaireGame

# Step 2: Check .NET version
dotnet --version
# Should show 8.0.x or higher

# Step 3: Restore NuGet packages
dotnet restore

# Step 4: Build the project
dotnet build --configuration Release

# Step 5: Run the application
dotnet run

# Step 6: Open browser manually
# Navigate to URL shown in console (usually https://localhost:7033)
# Then go to /solitaire path
```

#### Method 3: Visual Studio Code

```bash
# Step 1: Clone repository
git clone https://github.com/NADIR38/SolitaireGame.git
cd SolitaireGame

# Step 2: Open in VS Code
code .

# Step 3: Install C# extension
# Press Ctrl+Shift+X, search "C# Dev Kit", install

# Step 4: Restore and build
dotnet restore
dotnet build

# Step 5: Run
dotnet run

# Or use VS Code's Run and Debug (F5)
```

### 🔧 **Troubleshooting**

<details>
<summary><b>Build Errors</b></summary>

```bash
# Error: SDK not found
# Solution: Install .NET 8.0 SDK from microsoft.com

# Error: NuGet packages failed to restore
dotnet nuget locals all --clear
dotnet restore --force

# Error: Port 7033 already in use
# Solution: Kill process or change port in launchSettings.json
```
</details>

<details>
<summary><b>Runtime Errors</b></summary>

```bash
# Error: Save file not found
# This is normal on first run - game will start fresh

# Error: JSON serialization failed
# Clear saved games: Delete AppData/SolitaireGame/savegame.json

# Error: Browser not opening
# Manually navigate to: https://localhost:7033/solitaire
```
</details>

### ✅ **Verify Installation**

```bash
# Check if game loads
1. Open browser to https://localhost:7033/solitaire
2. You should see the game board
3. Try drawing cards from stock pile
4. Try dragging a card
5. Check browser console (F12) for any errors

# Successful installation shows:
✅ Game board renders with 7 tableau piles
✅ Stock pile shows card count
✅ All 4 foundation piles visible
✅ Timer starts (00:00)
✅ Score shows 0
✅ Moves shows 0
```

---

## <img src="https://fonts.gstatic.com/s/e/notoemoji/latest/1f3ae/512.gif" alt="🎮" width="35" height="35"> **How to Play**

### 🎯 **Game Controls**

<div align="center">

| Action | Control | Description |
|:---:|:---:|:---|
| 🖱️ **Drag & Drop** | Left Click + Drag | Move cards between piles |
| 📚 **Draw Cards** | Click Stock Pile | Draw 3 cards to waste |
| 🎯 **Quick Move** | Double-Click Card | Auto-move to foundation if valid |
| ↩️ **Undo** | Undo Button | Undo last move (-score) |
| ↪️ **Redo** | Redo Button | Redo undone move |
| 🔄 **New Game** | New Game Button | Start fresh with new shuffle |
| ⚡ **Auto Complete** | Auto Complete Button | Finish game (all cards face-up) |

</div>

### 📖 **Step-by-Step Guide**

<div align="center">
<table>
<tr>
<td width="50%">

#### 1️⃣ **Starting the Game**
```diff
+ Game auto-deals 28 cards to tableau
+ 7 piles: 1 card, 2 cards, ..., 7 cards
+ Top card of each pile is face-up
+ Remaining 24 cards go to stock pile
+ Timer starts automatically
+ Score begins at 0
```

#### 2️⃣ **Drawing Cards**
```diff
+ Click stock pile (top-left)
+ 3 cards move to waste pile
+ Last 3 cards are visible
+ Only top card is draggable
+ Stock recycles when empty
+ No score penalty for drawing
```

#### 3️⃣ **Moving Cards**
```diff
+ Drag face-up cards
+ Tableau: Alternating colors, descending
+ Foundation: Same suit, ascending
+ Empty tableau = King only
+ Cards auto-flip when revealed
+ Score updates on valid move
```

</td>
<td width="50%">

#### 4️⃣ **Building Foundations**
```diff
+ Start with Ace of each suit
+ Build up: A → 2 → 3 → ... → K
+ Same suit only (♠ with ♠)
+ Double-click for quick move
+ +10 points per card
+ Goal: Fill all 4 foundations
```

#### 5️⃣ **Using Undo/Redo**
```diff
+ Undo: Reverses last move
+ Score adjusts automatically
+ Card states restore
+ Unlimited undos available
+ Redo: Reapplies undone move
+ Strategy: Test moves safely!
```

#### 6️⃣ **Winning the Game**
```diff
+ All 52 cards in foundations
+ Each foundation: Ace → King
+ Win modal appears
+ Shows final stats
+ Save file auto-deletes
+ Click "Play Again" for new game
```

</td>
</tr>
</table>
</div>

### 🌟 **Pro Tips & Strategies**

<div align="center">
<table>
<tr>
<td width="33%">

### 🎯 **Beginner Tips**
```diff
+ Always move Aces first
+ Uncover face-down cards
+ Create empty columns early
+ Kings go to empty spots
+ Use undo to experiment
+ Focus on foundations
+ Draw when stuck
```

</td>
<td width="33%">

### 🔥 **Advanced Strategy**
```diff
+ Plan sequences ahead
+ Balance tableau builds
+ Don't rush to foundation
+ Keep color options open
+ Build down strategically
+ Use empty columns wisely
+ Think before moving Kings
```

</td>
<td width="33%">

### 🏆 **Score Optimization**
```diff
+ Prioritize foundation moves (+10)
+ Minimize tableau shuffling (+3)
+ Waste to foundation (+10)
+ Waste to tableau (+5)
+ Complete quickly
+ Use auto-complete late
+ Every card to foundation!
```

</td>
</tr>
</table>
</div>

### 🎨 **Game Interface Guide**

```
┌─────────────────────────────────────────────────────────────┐
│  🃏 Solitaire                                               │
│  [New Game] [↶ Undo] [↷ Redo] [Auto Complete]             │
│  Score: 145  │  Moves: 87  │  Time: 05:32                  │
├─────────────────────────────────────────────────────────────┤
│                                                             │
│  📚 Stock    🗑️ Waste         🏆 Foundation (4 piles)       │
│  [24 cards]  [♠K ♥Q ♦J]       [♠A] [♥2] [♦-] [♣-]         │
│                                                             │
├─────────────────────────────────────────────────────────────┤
│                                                             │
│  🎴 Tableau (7 piles)                                       │
│  [♠K]  [♥Q]  [♦J]  [♣10] [♠9]  [♥8]  [♦7]                 │
│  [♥Q]  [♣J]  [♠10] [♥9]  [♦8]  [♣7]  [♠6]                 │
│  [XX]  [XX]  [XX]  [XX]  [XX]  [XX]  [XX]                 │
│                                                             │
└─────────────────────────────────────────────────────────────┘

Legend:
  XX = Face-down card
  ♠K = Face-up King of Spades
  [Empty] = Empty pile (Kings only)
```

---

## <img src="https://fonts.gstatic.com/s/e/notoemoji/latest/1f3af/512.gif" alt="🎯" width="35" height="35"> **Implementation Details**

### 🎯 **Key Algorithms**

<div align="center">
<table>
<tr>
<td width="50%">

#### 🔀 **Fisher-Yates Shuffle**
```csharp
public void ShuffleCards(MyLinkedList<Card> cards) 
{
    // Convert to list for random access
    List<Card> list = cards.ToList();
    
    // Fisher-Yates algorithm: O(n)
    for (int i = list.Count - 1; i > 0; i--) 
    {
        int j = rand.Next(i + 1);
        // Swap using tuple deconstruction
        (list[i], list[j]) = (list[j], list[i]);
    }
    
    // Rebuild linked list
    cards.Clear();
    foreach (var card in list)
        cards.AddLast(card);
}
```

**Properties:**
- ✅ Time: O(n)
- ✅ Space: O(n)
- ✅ Unbiased: Each permutation equally likely
- ✅ In-place after conversion

</td>
<td width="50%">

#### ✅ **Move Validation**
```csharp
// Tableau Move Validation
private bool IsValidTableauMove(Card card, Card target) 
{
    // Empty pile: Only Kings allowed
    if (target == null) 
        return card.Rank == Rank.King;
    
    // Must alternate colors
    bool colorCheck = card.Color != target.Color;
    
    // Must be one rank lower
    bool rankCheck = (int)target.Rank - (int)card.Rank == 1;
    
    return colorCheck && rankCheck;
}

// Foundation Move Validation
private bool IsValidFoundationMove(Card card, Foundation f) 
{
    // Empty foundation: Only Aces
    if (f.Count == 0) 
        return card.Rank == Rank.Ace;
    
    Card top = f.Peek();
    
    // Must be same suit
    bool suitCheck = card.Suit == top.Suit;
    
    // Must be next rank
    bool rankCheck = (int)card.Rank == (int)top.Rank + 1;
    
    return suitCheck && rankCheck;
}
```

</td>
</tr>
</table>
</div>

### 🎨 **Command Pattern Implementation**

```csharp
// Command Pattern for Undo/Redo
public class Commands 
{
    public Action Execute { get; set; }
    public Action Undo { get; set; }
    
    public Commands(Action execute, Action undo) 
    {
        Execute = execute;
        Undo = undo;
    }
}

// Example: Moving card with score tracking
public bool MoveWasteToTableau(int pileIndex, int wasteCardIndex) 
{
    var wasteCards = waste.GetAllCards();
    Card cardToMove = wasteCards[wasteCardIndex];
    
    // Create command with Execute and Undo actions
    var command = new Commands(
        Execute: () => {
            waste.RemoveCard(cardToMove);
            tableau.piles[pileIndex].AddCard(cardToMove);
            currentScore += 5;  // Add score
        },
        Undo: () => {
            tableau.piles[pileIndex].RemoveCard();
            waste.AddCard(cardToMove);
            currentScore -= 5;  // Reverse score
        }
    );
    
    // Execute and record for undo
    command.Execute();
    RecordMove(command);
    return true;
}

// Undo/Redo with stacks
private MyStack<Commands> UndoStack = new MyStack<Commands>();
private MyStack<Commands> RedoStack = new MyStack<Commands>();

public bool UndoLastMove() 
{
    if (UndoStack.Count == 0) return false;
    
    var command = UndoStack.Pop();
    command.Undo();              // Execute undo action
    RedoStack.Push(command);     // Save for redo
    return true;
}

public bool RedoLastMove() 
{
    if (RedoStack.Count == 0) return false;
    
    var command = RedoStack.Pop();
    command.Execute();           // Re-execute move
    UndoStack.Push(command);     // Save for undo again
    return true;
}
```

### 💾 **Save/Load System Architecture**

```csharp
// GameState.cs - Serializable model
[Serializable]
public class GameState 
{
    public List<SerializableCard> StockCards { get; set; }
    public List<SerializableCard> WasteCards { get; set; }
    public List<List<SerializableCard>> TableauCards { get; set; }
    public List<List<SerializableCard>> FoundationCards { get; set; }
    public int MoveCount { get; set; }
    public int ElapsedSeconds { get; set; }
    public int CurrentScore { get; set; }
    public DateTime SavedAt { get; set; }
}

[Serializable]
public class SerializableCard 
{
    public int Suit { get; set; }      // 0-3
    public int Rank { get; set; }      // 1-13
    public int Color { get; set; }     // 0-1
    public bool IsFaceUp { get; set; }
}

// Movemanager.cs - Save implementation
public bool SaveGame(int moveCount, int elapsedSeconds) 
{
    try 
    {
        var gameState = new GameState 
        {
            MoveCount = moveCount,
            ElapsedSeconds = elapsedSeconds,
            CurrentScore = currentScore,
            SavedAt = DateTime.Now
        };
        
        // Helper to convert Card → SerializableCard
        SerializableCard ToSerializable(Card c) => new SerializableCard 
        {
            Suit = (int)c.Suit,
            Rank = (int)c.Rank,
            Color = (int)c.Color,
            IsFaceUp = c.IsFaceUp
        };
        
        // Serialize all piles (convert custom DS to List)
        gameState.StockCards = stock.GetAllCards()
            .Select(ToSerializable).ToList();
        
        gameState.WasteCards = waste.GetAllCards()
            .Select(ToSerializable).ToList();
        
        gameState.TableauCards = new List<List<SerializableCard>>();
        for (int i = 0; i < 7; i++) 
        {
            var cards = tableau.GetCardsInPile(i)
                .Select(ToSerializable).ToList();
            gameState.TableauCards.Add(cards);
        }
        
        gameState.FoundationCards = new List<List<SerializableCard>>();
        for (int i = 0; i < 4; i++) 
        {
            var foundation = foundations.GetFoundation((Suit)i);
            var cards = foundation.Cards.ToListReversed()
                .Select(ToSerializable).ToList();
            gameState.FoundationCards.Add(cards);
        }
        
        // Save to JSON file
        string json = JsonSerializer.Serialize(gameState, 
            new JsonSerializerOptions { WriteIndented = true });
        
        string path = Path.Combine(GetSavePath(), "savegame.json");
        File.WriteAllText(path, json);
        
        return true;
    } 
    catch (Exception ex) 
    {
        Console.WriteLine($"Save failed: {ex.Message}");
        return false;
    }
}

// Load and restore
public bool RestoreGame(GameState state, ...) 
{
    // Deserialize helper
    Card DeserializeCard(SerializableCard sc) => new Card(
        (Suit)sc.Suit, 
        (Rank)sc.Rank, 
        sc.IsFaceUp, 
        (Color)sc.Color
    );
    
    // Rebuild all data structures
    restoredStock = new StockPile(
        state.StockCards.Select(DeserializeCard).ToList()
    );
    
    restoredWaste = new WastePile();
    foreach (var sc in state.WasteCards)
        restoredWaste.AddCard(DeserializeCard(sc));
    
    // ... restore tableau and foundations similarly
    
    // Update internal references
    stock = restoredStock;
    // ... update others
    
    return true;
}
```

### 🎮 **Blazor Lifecycle Integration**

```csharp
// Solitaire.razor - Component lifecycle
protected override async Task OnInitializedAsync() 
{
    // Called when component initializes
    await JSRuntime.InvokeVoidAsync("registerBeforeUnload");
    CheckForSavedGame();  // Look for saved game
}

protected override void OnAfterRender(bool firstRender) 
{
    if (firstRender && !isInitialized) 
    {
        isInitialized = true;
        if (!showLoadPrompt) 
        {
            NewGame();  // No save found, start fresh
            StateHasChanged();
        }
    }
}

public void Dispose() 
{
    // Called when page closes/navigates away
    gameTimer?.Dispose();
    
    // Auto-save if game in progress
    if (moveManager != null && !showWinMessage && moveCount > 0) 
    {
        moveManager.SaveGame(moveCount, elapsedSeconds);
    }
}

// JavaScript interop for browser close detection
// index.html
window.registerBeforeUnload = () => {
    window.addEventListener('beforeunload', (e) => {
        // Triggers Blazor's Dispose method
        return undefined;
    });
};
```

### 🔄 **Drag & Drop System**

```csharp
// Drag start
private void OnDragStart(Card card, int pileIndex, int cardIndex) 
{
    draggedCard = card;
    dragSourcePile = pileIndex;      // -1 for waste, 0-6 for tableau
    dragSourceCardIndex = cardIndex;
}

// Drop on tableau
private void OnDropOnTableau(int targetPileIndex) 
{
    if (draggedCard == null) return;
    
    bool success = false;
    
    if (dragSourcePile == -1) 
    {
        // From waste pile
        success = moveManager.MoveWasteToTableau(
            targetPileIndex, dragSourceCardIndex
        );
    } 
    else 
    {
        // From another tableau pile
        success = moveManager.MoveTableauToTableau(
            dragSourcePile, dragSourceCardIndex, targetPileIndex
        );
    }
    
    if (success) 
    {
        moveCount++;
        CheckWinCondition();
    }
    
    ClearDragState();
    StateHasChanged();  // Re-render UI
}
```

---

## <img src="https://fonts.gstatic.com/s/e/notoemoji/latest/1f9ea/512.gif" alt="🧪" width="35" height="35"> **Testing Guidelines**

### ✅ **Comprehensive Testing Checklist**

<div align="center">

| Category | Test Case | Expected Result | Status |
|:---|:---|:---|:---:|
| **🎴 Card Display** | All 52 cards render | 13 ranks × 4 suits visible | ✅ |
| | Card colors correct | Red: ♥♦, Black: ♣♠ | ✅ |
| | Suit symbols display | ♥ ♦ ♣ ♠ symbols show | ✅ |
| **🔀 Shuffle** | Cards randomized | Different order each game | ✅ |
| | No duplicate cards | Exactly 52 unique cards | ✅ |
| **📚 Stock Pile** | Draw 3 cards | 3 cards move to waste | ✅ |
| | Stock recycles | Waste returns to stock when empty | ✅ |
| | Card count updates | Number decreases correctly | ✅ |
| **🗑️ Waste Pile** | Last 3 visible | Shows up to 3 cards | ✅ |
| | Only top draggable | Can only drag last card | ✅ |
| **🎯 Drag & Drop** | Valid tableau move | Card moves, score +3/+5 | ✅ |
| | Invalid move rejected | Card returns to source | ✅ |
| | King to empty | Only King moves to empty tableau | ✅ |
| | Color alternation | Red on black, black on red | ✅ |
| | Rank descending | Higher rank to lower rank | ✅ |
| **🏆 Foundation** | Ace starts pile | Only Ace on empty foundation | ✅ |
| | Same suit only | Rejects different suits | ✅ |
| | Ascending rank | A→2→3...→K in order | ✅ |
| | Double-click moves | Quick move to foundation works | ✅ |
| **↩️ Undo/Redo** | Undo last move | Card returns, score adjusts | ✅ |
| | Multiple undos | Can undo many moves | ✅ |
| | Redo works | Can redo undone moves | ✅ |
| | Score adjustment | Points add/subtract correctly | ✅ |
| | Card flip undo | Face-down restores | ✅ |
| **🎯 Scoring** | Waste→Tableau | +5 points | ✅ |
| | Waste→Foundation | +10 points | ✅ |
| | Tableau→Foundation | +10 points | ✅ |
| | Tableau→Tableau | +3 points | ✅ |
| | Undo reverses | Score decreases correctly | ✅ |
| **⏱️ Timer** | Starts on new game | 00:00 at start | ✅ |
| | Counts up | Increments every second | ✅ |
| | MM:SS format | Displays correctly | ✅ |
| | Continues on load | Resumes from saved time | ✅ |
| **💾 Auto-Save** | Saves on exit | Creates savegame.json | ✅ |
| | Correct location | AppData/SolitaireGame/ | ✅ |
| | Valid JSON | File is readable JSON | ✅ |
| | All data saved | Complete game state | ✅ |
| **📂 Load Prompt** | Shows on startup | Modal appears if save exists | ✅ |
| | Displays game info | Score, moves, time shown | ✅ |
| | Load button works | Restores exact game state | ✅ |
| | New game button | Starts fresh, deletes save | ✅ |
| **🔄 Game Restore** | Exact card positions | All cards in correct places | ✅ |
| | Face states correct | Face-up/down preserved | ✅ |
| | Score restored | Exact score value | ✅ |
| | Timer continues | Time picks up where left off | ✅ |
| | Move count correct | Exact number of moves | ✅ |
| **🏆 Win Detection** | All foundations full | Detects 52 cards | ✅ |
| | Win modal shows | Celebration message | ✅ |
| | Final stats display | Score, moves, time shown | ✅ |
| | Save deleted | savegame.json removed | ✅ |
| **⚡ Auto-Complete** | All cards face-up | Only enabled when all visible | ✅ |
| | Moves cards | Automatically completes game | ✅ |
| | Score updates | Points added for each move | ✅ |
| **📱 Responsive** | Desktop (1920x1080) | Full layout displays | ✅ |
| | Tablet (768px) | Adjusted card sizes | ✅ |
| | Mobile (375px) | Smaller cards, stacked layout | ✅ |

</div>

### 🧪 **Manual Testing Scenarios**

<details>
<summary><b>Scenario 1: Basic Gameplay</b></summary>

```yaml
Steps:
  1. Start new game
  2. Draw 3 cards from stock
  3. Drag top waste card to tableau
  4. Move card from tableau to foundation
  5. Undo the last move
  6. Redo the move
  7. Check score updates

Expected:
  ✅ Cards move correctly
  ✅ Score: 5 (waste→tableau) + 10 (tableau→foundation) = 15
  ✅ After undo: Score = 5
  ✅ After redo: Score = 15
  ✅ Move count increases with each action
```
</details>

<details>
<summary><b>Scenario 2: Save/Load Cycle</b></summary>

```yaml
Steps:
  1. Start new game
  2. Make several moves (20+)
  3. Note current score, moves, time
  4. Close browser tab
  5. Reopen application
  6. Check for load prompt
  7. Click "Load Game"
  8. Verify all data restored

Expected:
  ✅ Load prompt appears with correct info
  ✅ All cards in exact same positions
  ✅ Score matches saved value
  ✅ Move count matches
  ✅ Timer continues from saved time
  ✅ Can continue playing normally
```
</details>

<details>
<summary><b>Scenario 3: Win Condition</b></summary>

```yaml
Steps:
  1. Play until nearly won (or use test deck)
  2. Move last card to foundation
  3. Observe win modal
  4. Check saved game deleted
  5. Click "Play Again"

Expected:
  ✅ Win modal appears immediately
  ✅ Shows final score, moves, time
  ✅ savegame.json deleted from AppData
  ✅ "Play Again" starts fresh game
  ✅ New shuffle applied
```
</details>

### 🐛 **Known Edge Cases**

```diff
! Edge Case 1: Multiple Aces in Waste
  - Can drag any Ace to empty foundation
  - All work correctly
  
! Edge Case 2: Undo After Stock Recycle
  - Stock correctly returns cards to waste
  - Maintains face-up/down states
  
! Edge Case 3: Save During Win Animation
  - Game does NOT save when won
  - Only saves if moveCount > 0 and !showWinMessage
  
! Edge Case 4: Corrupted Save File
  - LoadGame returns null
  - Game starts fresh automatically
  - No crash or error to user
  
! Edge Case 5: Multiple Browser Tabs
  - Each tab has independent game state
  - Last closed tab overwrites save
  - Expected behavior (by design)
```

---

## <img src="https://fonts.gstatic.com/s/e/notoemoji/latest/1f4ca/512.gif" alt="📊" width="35" height="35"> **Project Statistics**

<div align="center">

### 📈 **Development Metrics**

<img src="https://img.shields.io/badge/Lines%20of%20Code-4500+-4169E1?style=for-the-badge" />
<img src="https://img.shields.io/badge/Classes-23-4169E1?style=for-the-badge" />
<img src="https://img.shields.io/badge/Methods-150+-4169E1?style=for-the-badge" />
<img src="https://img.shields.io/badge/Custom%20DS-3-4169E1?style=for-the-badge" />

</div>

<div align="center">
<table>
<tr>
<td align="center" width="25%">

### 📊 **Code Breakdown**

```yaml
Backend Logic:
  - Cards.cs: 80 lines
  - Commands.cs: 25 lines
  - Deck.cs: 120 lines
  - Foundation.cs: 60 lines
  - FoundationPile.cs: 45 lines
  - GameState.cs: 40 lines
  - Movemanager.cs: 1200 lines
  - TableauPile.cs: 90 lines
  - TableauPiles.cs: 70 lines
  - StockPile.cs: 85 lines
  - WastePile.cs: 80 lines
  
Total Backend: ~1,900 lines
```

</td>
<td align="center" width="25%">

### 🏗️ **Data Structures**

```yaml
Custom Implementation:
  - MyStack.cs: 85 lines
  - MyQueue.cs: 75 lines
  - Nodes.cs: 140 lines
  
Total DS: ~300 lines

Features:
  - Generic types
  - Full CRUD operations
  - Memory efficient
  - No dependencies
  - Unit testable
```

</td>
<td align="center" width="25%">

### 🎨 **Frontend**

```yaml
Blazor Components:
  - Solitaire.razor: 1800 lines
    * HTML: 500 lines
    * @code: 1300 lines
  - MainLayout.razor: 50 lines
  - App.razor: 30 lines
  
Static Assets:
  - index.html: 400 lines
    * CSS: 350 lines
    * JS: 20 lines
  
Total Frontend: ~2,280 lines
```

</td>
<td align="center" width="25%">

### 📈 **Overall Stats**

```yaml
Total Files: 23
Total Lines: 4,500+
Comments: 200+
Blank Lines: 300+
Code Lines: 4,000+

Time Investment:
  - Development: 60+ hours
  - Testing: 15+ hours
  - Documentation: 10+ hours
  - Total: 85+ hours
```

</td>
</tr>
</table>
</div>

### 🎯 **Complexity Analysis**

<div align="center">
<table>
<tr>
<td width="50%">

#### ⏱️ **Time Complexity**

```yaml
Game Operations:
  New Game: O(n) - Shuffle + Deal
  Draw Cards: O(1) - Dequeue 3 cards
  Move Card: O(1) - Stack/Queue ops
  Undo/Redo: O(1) - Stack operations
  Check Win: O(1) - Check 4 foundations
  
Save/Load:
  Save Game: O(n) - Serialize all cards
  Load Game: O(n) - Deserialize cards
  Restore: O(n) - Rebuild structures
  
Where n = 52 (total cards)
```

</td>
<td width="50%">

#### 💾 **Space Complexity**

```yaml
Data Structures:
  Deck: O(n) - 52 cards
  Stock: O(n) - Queue
  Waste: O(n) - LinkedList
  Tableau: O(n) - 7 Stacks
  Foundation: O(n) - 4 Stacks
  Undo Stack: O(m) - m moves
  Redo Stack: O(m) - m moves
  
Save File:
  JSON: ~2-5 KB
  Memory: ~10 KB (in-game)
  
Total: O(n + m) where m = moves
```

</td>
</tr>
</table>
</div>

### 📊 **Feature Completion**

```
Core Features:        ████████████████████ 100%
Data Structures:      ████████████████████ 100%
Scoring System:       ████████████████████ 100%
Save/Load System:     ████████████████████ 100%
Undo/Redo:           ████████████████████ 100%
UI/UX:               ████████████████████ 100%
Responsive Design:   ███████████████░░░░░  75%
Documentation:       ████████████████████ 100%
Testing:             ██████████████████░░  90%
```

---

## <img src="https://fonts.gstatic.com/s/e/notoemoji/latest/1f41b/512.gif" alt="🐛" width="35" height="35"> **Known Issues & Solutions**

### ⚠️ **Current Known Issues**

<details>
<summary><b>Issue #1: Mobile Touch Events</b></summary>

```yaml
Problem:
  - Drag and drop may not work smoothly on mobile
  - Touch events need specific handling
  
Status: Minor (desktop works perfectly)

Workaround:
  - Use double-click for quick moves
  - Works on most modern mobile browsers
  
Planned Fix:
  - Implement touch event handlers
  - Add mobile-specific gesture support
```
</details>

<details>
<summary><b>Issue #2: Multiple Browser Tabs</b></summary>

```yaml
Problem:
  - Opening game in multiple tabs
  - Last closed tab overwrites save
  
Status: Expected Behavior (by design)

Explanation:
  - Each tab has independent state
  - Save triggers on tab close
  - Most recent save wins
  
Solution:
  - Close other tabs before saving
  - Or: Use only one tab per game
```
</details>

<details>
<summary><b>Issue #3: Very Long Game Sessions</b></summary>

```yaml
Problem:
  - Timer display limited to 99:59
  - Games longer than ~100 minutes overflow
  
Status: Edge Case (rare)

Workaround:
  - Time still tracks correctly internally
  - Only display formatting issue
  
Planned Fix:
  - Add hour display: HH:MM:SS
  - Or show 99+ for very long games
```
</details>

### ✅ **Fixed Issues**

<details>
<summary><b>Fixed: JSON Serialization of Custom Data Structures</b></summary>

```yaml
Original Problem:
  - MyStack, MyQueue, MyLinkedList couldn't serialize
  - System.Text.Json doesn't handle custom types
  
Solution Implemented:
  - Convert to List<T> before serialization
  - Use ToListReversed() for stacks
  - GetAllCards() for queues and linked lists
  - Rebuild structures on load
  
Result: ✅ Save/Load works perfectly
```
</details>

<details>
<summary><b>Fixed: Load Prompt Not Showing</b></summary>

```yaml
Original Problem:
  - Load prompt modal not appearing
  - Game starting immediately
  
Solution Implemented:
  - Added isInitialized flag
  - Fixed Blazor lifecycle (OnInitializedAsync → OnAfterRender)
  - Added StateHasChanged() calls
  - Proper async handling
  
Result: ✅ Load prompt shows correctly
```
</details>

<details>
<summary><b>Fixed: Card Stacking Z-Index Issues</b></summary>

```yaml
Original Problem:
  - Dragged cards appearing behind others
  - Hover effects not working properly
  
Solution Implemented:
  - Dynamic z-index based on position
  - Hover z-index override (999)
  - Proper CSS positioning
  
Result: ✅ Cards stack and hover correctly
```
</details>

### 🔧 **Troubleshooting Guide**

<div align="center">
<table>
<tr>
<td width="50%">

#### 🚨 **Common Problems**

```yaml
Problem: Game won't load
Solution:
  1. Check browser console (F12)
  2. Clear browser cache
  3. Verify .NET 8.0 installed
  4. Try different browser
  
Problem: Save not working
Solution:
  1. Check AppData folder permissions
  2. Ensure enough disk space
  3. Look for console errors
  4. Try manual save path
  
Problem: Cards not dragging
Solution:
  1. Check if card is face-up
  2. Verify draggable attribute
  3. Try different browser
  4. Use double-click instead
```

</td>
<td width="50%">

#### 💡 **Performance Issues**

```yaml
Problem: Slow loading
Solution:
  - Clear browser cache
  - Disable browser extensions
  - Check internet connection
  - Use Release build
  
Problem: Timer lag
Solution:
  - Close other browser tabs
  - Check system resources
  - Disable hardware acceleration
  
Problem: Large save file
Solution:
  - Normal (2-5 KB expected)
  - Delete old saves manually
  - Check for corruption
```

</td>
</tr>
</table>
</div>

---

## <img src="https://fonts.gstatic.com/s/e/notoemoji/latest/1f52e/512.gif" alt="🔮" width="35" height="35"> **Future Enhancements**

### 🚀 **Planned Features**

<div align="center">
<table>
<tr>
<td width="33%">

### 🎮 **Gameplay**

```diff
+ Vegas Scoring Mode
  - $52 buy-in
  - $5 per foundation card
  - Goal: Positive balance
  
+ Daily Challenge
  - Same shuffle for all
  - Leaderboard system
  - 24-hour rotation
  
+ Hints System
  - Suggest valid moves
  - Tutorial mode
  - Progressive hints
  
+ Statistics Tracking
  - Games played
  - Win rate
  - Average time
  - High scores
```

</td>
<td width="33%">

### 🎨 **UI/UX**

```diff
+ Multiple Themes
  - Dark mode
  - Classic green felt
  - Custom backgrounds
  - Card back designs
  
+ Animations
  - Card flip animations
  - Win celebration
  - Smooth transitions
  - Particle effects
  
+ Sound Effects
  - Card sounds
  - Win sound
  - Background music
  - Volume controls
  
+ Accessibility
  - Screen reader support
  - Keyboard shortcuts
  - High contrast mode
```

</td>
<td width="33%">

### 🔧 **Technical**

```diff
+ Multiple Save Slots
  - 3+ game saves
  - Named saves
  - Save management UI
  
+ Online Multiplayer
  - Race mode
  - Same deck challenge
  - Real-time leaderboard
  
+ Cloud Sync
  - Save to cloud
  - Cross-device play
  - Auto-sync
  
+ Progressive Web App
  - Install to desktop
  - Offline mode
  - Native-like experience
  
+ Analytics
  - Move patterns
  - Difficulty analysis
  - Play time tracking
```

</td>
</tr>
</table>
</div>

### 📅 **Roadmap**

```
Q1 2025:
  ✅ Complete core game (Done!)
  ✅ Custom data structures (Done!)
  ✅ Save/Load system (Done!)
  ✅ Full documentation (Done!)

Q2 2025:
  ⏳ Vegas scoring mode
  ⏳ Dark theme
  ⏳ Sound effects
  ⏳ Better mobile support

Q3 2025:
  ⏳ Daily challenge
  ⏳ Statistics dashboard
  ⏳ Multiple themes
  ⏳ Animations

Q4 2025:
  ⏳ Cloud sync
  ⏳ Multiplayer mode
  ⏳ PWA support
  ⏳ Achievement system
```

---

## <img src="https://fonts.gstatic.com/s/e/notoemoji/latest/1f91d/512.gif" alt="🤝" width="35" height="35"> **Contributing**

### 🎯 **How to Contribute**

We welcome contributions! Here's how you can help:

<div align="center">
<table>
<tr>
<td width="33%">

### 🐛 **Report Bugs**

```yaml
Steps:
  1. Check existing issues
  2. Create detailed report
  3. Include screenshots
  4. Add console logs
  
Template:
  - Description
  - Steps to reproduce
  - Expected behavior
  - Actual behavior
  - Environment details
```

</td>
<td width="33%">

### 💡 **Suggest Features**

```yaml
Process:
  1. Open GitHub issue
  2. Label: enhancement
  3. Describe use case
  4. Provide examples
  
Good Suggestions:
  - Clear benefit
  - Well-defined scope
  - Compatible design
  - User-focused
```

</td>
<td width="33%">

### 🔧 **Submit Code**

```yaml
Workflow:
  1. Fork repository
  2. Create feature branch
  3. Write clean code
  4. Add tests
  5. Submit pull request
  
Guidelines:
  - Follow C# conventions
  - Comment complex logic
  - Update documentation
  - Test thoroughly
```

</td>
</tr>
</table>
</div>

### 📝 **Contribution Guidelines**

```yaml
Code Style:
  - Use C# naming conventions
  - PascalCase for classes/methods
  - camelCase for local variables
  - Meaningful variable names
  - Comment complex algorithms
  
Commit Messages:
  - Clear, descriptive messages
  - Present tense ("Add feature" not "Added feature")
  - Reference issue numbers
  
Pull Requests:
  - One feature per PR
  - Include description
  - Link related issues
  - Add screenshots if UI change
  - Ensure tests pass
  
Documentation:
  - Update README if needed
  - Add XML comments to public methods
  - Update code comments
```

### 🏆 **Contributors**

<div align="center">

| Contributor | Role | Contributions |
|:---:|:---:|:---|
| **NADIR JAMAL** | Lead Developer | Core implementation, Data structures, Save system |
| _Your Name?_ | Contributor | _Join us!_ |

</div>

---

## <img src="https://fonts.gstatic.com/s/e/notoemoji/latest/1f4c4/512.gif" alt="📄" width="35" height="35"> **License**

```
MIT License

Copyright (c) 2024 NADIR JAMAL

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```

### 📜 **What This Means**

✅ **You CAN:**
- Use for personal projects
- Use for commercial projects
- Modify the source code
- Distribute copies
- Sublicense
- Study how it works

❌ **You CANNOT:**
- Hold author liable
- Use author's name for promotion (without permission)

📋 **You MUST:**
- Include license notice
- Include copyright notice

---

## <img src="https://fonts.gstatic.com/s/e/notoemoji/latest/1f4e7/512.gif" alt="📧" width="35" height="35"> **Contact & Support**

### 📬 **Get in Touch**

<div align="center">

| Contact Method | Details |
|:---:|:---|
| 📧 **Email** | jamalnadir7778@gmail.com |
| 🐙 **GitHub** | [@NADIR38](https://github.com/NADIR38/Solitair-Game) |
| 🎓 **Institution** | University of Engineering and Technology |
| 📚 **Course** | CSC200 - Data Structures & Algorithms |
| 👨‍🎓 **Roll Number** | 2024-CS-38 |

</div>

### 💬 **Support Channels**

<div align="center">
<table>
<tr>
<td width="33%">

### 🐛 **Report Issues**

Found a bug? Have a problem?

1. Check [existing issues](https://github.com/NADIR38/Solitaire-Game/issues)
2. Search for similar problems
3. Create new issue if needed
4. Provide detailed information

**Response Time:** 24-48 hours

</td>
<td width="33%">

### 💡 **Feature Requests**

Have an idea? Want a feature?

1. Open GitHub issue
2. Label: `enhancement`
3. Describe your idea clearly
4. Explain the use case
5. Wait for feedback

**Consideration Time:** 1 week

</td>
<td width="33%">

### ❓ **Questions**

Need help? Have questions?

1. Check this README first
2. Look at code comments
3. Search GitHub issues
4. Ask in GitHub Discussions
5. Email for urgent matters

**Response Time:** 48 hours

</td>
</tr>
</table>
</div>

### 🎓 **Academic Information**

```yaml
Project Details:
  Course: CSC200 - Data Structures & Algorithms
  Semester: Fall 2024
  Institution: University of Engineering and Technology
  Department: Computer Science
  
Project Type: Mid Term Project
Focus Areas:
  - Custom Data Structure Implementation
  - Algorithm Design & Analysis
  - Software Engineering Principles
  - Full-Stack Development
  
Learning Outcomes:
  ✅ Implemented Stack (LIFO)
  ✅ Implemented Queue (FIFO)
  ✅ Implemented Linked List
  ✅ Applied design patterns
  ✅ Created complete application
  ✅ Mastered C# and Blazor
```

---

## <img src="https://fonts.gstatic.com/s/e/notoemoji/latest/2b50/512.gif" alt="⭐" width="35" height="35"> **Acknowledgments**

### 🙏 **Special Thanks**

<div align="center">

```
This project wouldn't be possible without:
```

| Who | For What |
|:---:|:---|
| 🎓 **Prof Nazeef Ul Haq** | Course instruction and project guidance |
| 📚 **Course Material** | Data structures concepts and algorithms |
| 🌐 **Microsoft** | Blazor framework and .NET platform |
| 🎮 **Solitaired.com** | Game rules reference |
| 💻 **Stack Overflow** | Problem-solving community |
| 📖 **GitHub** | Code hosting and version control |
| 🎨 **Flaticon** | Icons used in documentation |
| ☕ **Coffee** | Fuel for late-night coding sessions |

</div>

### 📚 **Resources Used**

```yaml
Documentation:
  - Microsoft C# Docs
  - Blazor WebAssembly Guide
  - .NET 8.0 API Reference
  
Learning Resources:
  - Data Structures & Algorithms in C#
  - Design Patterns: Elements of Reusable Software
  - Clean Code by Robert C. Martin
  
Tools:
  - Visual Studio 2022
  - Git & GitHub
  - Markdown editors
  - Browser DevTools
```

### 🌟 **Inspiration**

This project was inspired by:
- Classic Windows Solitaire
- Modern web-based card games
- Academic requirement for custom data structures
- Passion for game development
- Love for clean, well-documented code

---

## <img src="https://fonts.gstatic.com/s/e/notoemoji/latest/1f389/512.gif" alt="🎉" width="35" height="35"> **Final Notes**

<div align="center">

### 🎯 **Project Goals Achieved**

```diff
+ ✅ Implement Klondike Solitaire from scratch
+ ✅ Create custom data structures (Stack, Queue, LinkedList)
+ ✅ Build complete save/load system
+ ✅ Add undo/redo functionality
+ ✅ Implement scoring system
+ ✅ Create responsive web interface
+ ✅ Write comprehensive documentation
+ ✅ Test thoroughly for bugs
+ ✅ Learn Blazor WebAssembly
+ ✅ Master C# and .NET 8.0
```

### 💎 **Key Achievements**

<img src="https://img.shields.io/badge/Custom%20Data%20Structures-100%25-success?style=for-the-badge" />
<img src="https://img.shields.io/badge/Code%20Quality-A+-success?style=for-the-badge" />
<img src="https://img.shields.io/badge/Documentation-Complete-success?style=for-the-badge" />
<img src="https://img.shields.io/badge/Features-Fully%20Functional-success?style=for-the-badge" />

### 🚀 **What Makes This Special**

```javascript
const projectHighlights = {
    "100% Custom DS": "No built-in collections - pure implementation",
    "Complete Save System": "Full game state persistence with JSON",
    "Command Pattern": "Elegant undo/redo with score tracking",
    "Clean Architecture": "Separation of concerns, SOLID principles",
    "Modern Tech Stack": "Blazor WASM, .NET 8.0, C# 11",
    "Thorough Documentation": "4000+ lines of docs, every feature explained",
    "Production Ready": "Fully tested, responsive, performant"
};

console.log("🎴 A complete Solitaire experience! 🎴");
```

</div>

---

<div align="center">

### 🎮 **Ready to Play?**

<img src="https://readme-typing-svg.herokuapp.com?lines=🃏+Clone+the+Repository;🚀+Run+the+Application;🎯+Start+Playing+Solitaire!&font=Orbitron&center=true&width=600&height=100&duration=3000&pause=1000&color=4169E1&size=22" />

```bash
git clone https://github.com/NADIR38/SolitaireGame.git
cd SolitaireGame
dotnet run
```

### ⭐ **If you found this helpful, please star the repository!** ⭐

<img src="https://img.shields.io/github/stars/NADIR38/Solitaire-Game?style=social" />

</div>

---

<div align="center">

### 📱 **Share This Project**

[![Share on Twitter](https://img.shields.io/badge/Share%20on-Twitter-1DA1F2?style=for-the-badge&logo=twitter&logoColor=white)](https://twitter.com/intent/tweet?text=Check%20out%20this%20amazing%20Solitaire%20game%20built%20with%20Blazor!%20https://github.com/NADIR38/SolitaireGame)
[![Share on LinkedIn](https://img.shields.io/badge/Share%20on-LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/sharing/share-offsite/?url=https://github.com/NADIR38/SolitaireGame)
[![Share on Reddit](https://img.shields.io/badge/Share%20on-Reddit-FF4500?style=for-the-badge&logo=reddit&logoColor=white)](https://reddit.com/submit?url=https://github.com/NADIR38/SolitaireGame&title=Amazing%20Solitaire%20Game%20with%20Custom%20Data%20Structures)

</div>

---

<div align="center">

<img src="https://user-images.githubusercontent.com/73097560/115834477-dbab4500-a447-11eb-908a-139a6edaec5c.gif" width="100%">

### 🃏 **Built with ❤️ by NADIR JAMAL** 🃏

**CSC200 - Data Structures & Algorithms | University of Central Punjab**

<img src="https://komarev.com/ghpvc/?username=NADIR38&label=README%20Views&color=4169E1&style=for-the-badge" alt="Views" />

**© 2024 NADIR JAMAL. All Rights Reserved.**

<img src="https://user-images.githubusercontent.com/73097560/115834477-dbab4500-a447-11eb-908a-139a6edaec5c.gif" width="100%">

</div>
