# 🧮 Math Quiz Game

A command-line math quiz game that challenges players with arithmetic questions across multiple operations. Test your mental math skills and track your performance over multiple sessions!

---

## 📋 Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Gameplay](#gameplay)
- [Rules & Constraints](#rules--constraints)
- [Game History](#game-history)
- [Getting Started](#getting-started)

---

## Overview

Math Quiz Game is an interactive console-based application where players solve randomly generated math problems. Choose your preferred arithmetic operation, answer at least 5 questions per round, and see how many you can get right. Results from all sessions are tracked in memory for the duration of the program's runtime.

---

## Features

- ➕ **Multiple Operations** — Choose from addition, subtraction, multiplication, or division
- 🎯 **Score Tracking** — Earn a point for every correct answer
- 📜 **Game History** — Review scores from all previous rounds in the current session
- 🔢 **Integer-Safe Division** — Division questions are guaranteed to produce whole-number answers

---

## 📌 Notes

- Built with **C#** and **.NET 10** as a CLI programming exercise focused on control flow, user input handling, and in-memory data management.
- **No LLM's were used for code generation — the goal is personal skill and understanding, not shipping features in a timely manner.**
- No external NuGet packages or databases are required — only the .NET 10 SDK.

[Back to Top](#table-of-contents)

---

## Gameplay

1. Launch the program
2. Select an arithmetic operation from the main menu
3. Answer a minimum of **5 math questions** per game
4. Your score is displayed at the end of each round
5. Return to the menu to play again or view your history

[Back to Top](#table-of-contents)

### Main Menu Options

| Option | Description |
|--------|-------------|
| `1` | Addition ( + ) |
| `2` | Subtraction ( − ) |
| `3` | Multiplication ( × ) |
| `4` | Division ( / ) |
| `5` | View Game History |
| `6` | Quit |

---

[Back to Top](#table-of-contents)

## Rules & Constraints

- Each game consists of **5 questions**
- Division problems are guaranteed to yield **integer results only**
- Dividends for division questions are generated in the range **0 – 100**
- No fractions or decimal answers are required from the player
- Game history is stored **in memory only** — data is cleared when the program exits

[Back to Top](#table-of-contents)

---

## Game History

After completing one or more rounds, selecting **View Game History** from the menu displays a summary of all sessions played, including:

- Round number
- Operation used
- Score achieved (correct answers / total questions)

History is not persisted to a database or file — it exists only for the current session.

[Back to Top](#table-of-contents)

---

## Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0) or later

```bash
dotnet --version   # Should return 10.x.x
```

### Installation

```bash
# Clone the repository
git clone https://github.com/exadim/MathGame.git

# Navigate into the project directory
cd MathGame/MathGame
```

### Running the Game

```bash
dotnet run
```

### Build (optional)

```bash
dotnet build
```

[Back to Top](#table-of-contents)

