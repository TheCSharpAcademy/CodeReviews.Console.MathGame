# MathGame

## Overview

MathGame is a simple console application written in C# that helps 
users practice basic
arithmetic operations: addition, subtraction, multiplication, and division. The game
presents random math problems and checks the user's answers, 
providing immediate feedback.
Additionally, it maintains a history of past games for review.

Repository created to make the project
[MathGame](https://thecsharpacademy.com/project/53/math-game) from
[The C# Academy](https://thecsharpacademy.com/)

## Features

- Four basic arithmetic operations: addition, subtraction, multiplication, and division.
- Division problems always result in integer answers.
- User-friendly menu to select operations and view game history.
- History of past games displayed on request.
- Immediate feedback on the correctness of user answers.

## Requirements

- [.NET SDK](https://dotnet.microsoft.com/download) (version 5.0 or later)

## How to Run

1. Clone the repository:

   ```sh
   git clone https://github.com/BarbosaThaissa/Console.MathGame.git
   cd MathGame
   ```

2. Build and run the application:

   ```sh
   dotnet build
   dotnet run
   ```

3. Follow the on-screen instructions to play the game.

## Game Instructions

1. Run the application.
2. Choose an arithmetic operation from the menu:
   - 1 for Addition
   - 2 for Subtraction
   - 3 for Multiplication
   - 4 for Division
   - 5 to View Game History
   - 6 to Exit
3. Solve the presented math problem and input your answer.
4. Receive immediate feedback on your answer.
5. Choose to play again or exit.

## Example

```text
Welcome to MathGame!

Choose an operation:
1 - Addition
2 - Subtraction
3 - Multiplication
4 - Division
5 - Exit

Enter your choice: 1
What is 7 + 5?
12
Correct answer!

5 - View game history
Do you want to play again? (y/n)
```

## Contributing

1. Fork the repository.
2. Create a new branch for your feature or bugfix (`git checkout -b feature-name`).
3. Commit your changes (`git commit -am 'Add new feature'`).
4. Push to the branch (`git push origin feature-name`).
5. Create a new Pull Request.
