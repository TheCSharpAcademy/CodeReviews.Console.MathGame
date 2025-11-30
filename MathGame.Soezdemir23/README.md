
# MathGame

## minimum requirements reached for review?

Yes


## Project Overview

MathGame is a C# console application that challenges users with basic arithmetic operations: addition, subtraction, multiplication, and division. The game tracks player scores, supports a highscore list with persistent storage, and records elapsed time for each game session.

## Architecture

- **Template Method Pattern**: All game modes inherit from abstract `GameMode` base class
  - Shared 5-round game loop managed by base `Play()` method
  - Subclasses override question generation (`GenerateQuestion()`), mode name, and operator symbol
  - Consistent input validation, scoring, and timing across all modes
- **Namespaces**:
  - `mathgame.GameModes`: All game mode classes (`AdditionGame`, `SubtractionGame`, `MultiplicationGame`, `DivisionGame`, `GameMode`)
  - `mathgame.GameManager`: Main game orchestration
  - `mathgame.Model`: Player data model
- **Timing**: `Stopwatch` measures total game duration; stored as minutes:seconds with each player record
- **Scoring**: 
  - Correct answers advance rounds and gain points
  - Wrong answers lose points but repeat the same question
  - Players can quit mid-game with 'q' or 'quit'

## Features

✅ Four basic arithmetic operations (addition, subtraction, multiplication, division)  
✅ Integer-only division (ensures clean divisibility, no remainders)  
✅ Menu-driven operation selection  
✅ Game history tracking in-memory (List\<Player\>)  
✅ Persistent highscore storage in `Highscore.txt`  
✅ Player naming with anonymous option  
✅ Elapsed time tracking per game (mm:ss format)  
✅ Input validation (handles quit commands, invalid input, null values)  
✅ DRY principle via Template Method pattern

## Data Format

### Highscore.txt
Each line: `name, points, yyyy-MM-ddTHH:mm:ss, mm:ss`

Example:
```
Alice, 5, 2025-11-30T14:23:45, 1:42
Anonymous, 3, 2025-11-30T15:10:12, 2:05
```

- Loaded on startup and saved on exit
- Time component (mm:ss) is optional for backward compatibility with older entries
- File created automatically if missing

## Build & Run

**Target Framework**: .NET 10

```bash
dotnet build
dotnet run
```

## C# Academy Requirements Met

**Core Requirements:**
- ✅ Math game with 4 basic operations
- ✅ Integer-only division (0-100 range, no fractional results)
- ✅ Menu to choose operations
- ✅ Record previous games in a List
- ✅ View game history option
- ✅ No database requirement (file-based storage exceeds this)

**Challenge Features Implemented:**
- ✅ DRY Principle (Template Method extracts common game logic)
- ✅ Timer (Stopwatch tracks game completion time)

## Project Structure

```
mathgame/
├── GameManager.cs          # Main menu, game flow, highscore I/O
├── Program.cs              # Entry point
├── Model/
│   └── Player.cs           # Player data (name, points, date, time)
├── GameModes/
│   ├── GameMode.cs         # Abstract base class (template method)
│   ├── AdditionGame.cs     # Addition mode
│   ├── SubtractionGame.cs  # Subtraction mode
│   ├── MultiplicationGame.cs  # Multiplication mode
│   └── DivisionGame.cs     # Division mode (ensures divisibility)
└── Highscore.txt           # Persistent storage (created at runtime)
```

---

Feel free to contribute or suggest improvements!
