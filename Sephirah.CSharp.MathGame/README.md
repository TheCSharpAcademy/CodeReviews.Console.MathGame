# Console Math Game

A console-based math quiz game built in C# as part of the [C# Academy](https://thecsharpacademy.com/) curriculum.

---

## Overview

Console Math Game is an interactive console application that challenges players with arithmetic questions across four operations. Players can customize their experience by selecting an operation and a difficulty level, and compete against the clock to achieve the best score.

---

## Feature

- **Four operations** - Addition, Subtraction, Multiplication, Division
- **Random Operation mode** - Questions are drawn from all four operations at random each round
- **Three difficulty levels** - Easy, Normal, Hard (affects the range of generated numbers)
- **Timer** - Tracks how long each game session takes
- **Game history** - All completed sessions are recorded in-memory and viewable from the main menu
- **Input validation** - Invalid inputs are rejected and the player is prompted to re-enter
- **Integer-only divisions** - The game guarantees division questions always result in whole numbers, with dividends ranging from 0 to 100

---

## How To Run

### Prerequisites

- [.NET SDK] (https://dotnet.microsoft.com/download) 10.0 or later

### Steps

```bash
git clone https://github.com/Sephydev/STUDY.CSharp.MathGame.git
cd math-game
dotnet run
```

---

## Gameplay

1. From the **Main Menu**, select `New Game`, `Game History`, or `Exit`.
2. If you choose `New Game`, choose an **operation** (or `Random Operation` for a mixed challenge).
3. Select a **difficulty level**:
	- `Easy` - numbers from 0 to 10
	- `Normal` - numbers from 0 to 50
	- `Hard` - numbers from 0 to 100
4. Answer **5 math questions**. Your score and time are recorded at the end of each session.
5. View all past sessions at any time via `Game History`.

---

## License

This project was built for educational purposes as part of the C# Academy curriculum. Feel free to use or adapt it.