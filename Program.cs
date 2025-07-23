// See https://aka.ms/new-console-template for more information

using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Numerics;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;

Random random = new Random();

string? guess = "";
string? gameType = "";
List<string> gameHistory = new List<string>();
bool wonGame = false;
int finalResult = 0;
int answer = 0;
string? gameSelector = "";
string? difficultyMode = "";

var timer = System.Diagnostics.Stopwatch.StartNew();

SelectGameType();
GameStatistics();
ContinueGame();


void SelectGameType()
{
    Console.WriteLine("Would you like to play a custom or random game? C/R");
    string? gameChoice = Console.ReadLine()?.ToUpper();
    if (gameChoice == "C")
    {
        Console.WriteLine("You have chosen a custom game!");
        CustomGame();
    }
    else if (gameChoice == "R")
    {
        Console.WriteLine("You have chosen a random game!");
        RandomGame();
    }
    else
    {
        Console.WriteLine("Invalid choice. Please enter C for custom or R for random.");
        Environment.Exit(0);
    }
}
void RandomGame()

{ 
    Console.WriteLine("Welcome to Jack's Math Game!");
    Console.WriteLine("Please guess the correct result of two random numbers depending on the random operation selected");
    ChooseDifficulty();
    SelectRandomGame();

}
void CustomGame()
{
    Console.WriteLine("Welcome to Jack's Math Game!");
    ChooseDifficulty();
    Console.WriteLine("Please guess the correct result of two random numbers depending on the operation selected");
    Console.WriteLine("Please now choose from the following operations");
    Console.WriteLine("1. Add");
    Console.WriteLine("2: Subtract");
    Console.WriteLine("3: Multiply");
    Console.WriteLine("4: Divide ");
    SelectCustomGame();
    
    

}

bool HasWon()
{
    if (finalResult == answer)
    {
        Console.WriteLine("Congratulations! You guessed correctly!");
        wonGame = true;
    }
    else
    {
        Console.WriteLine("Sorry, you did not guess correctly. Better luck next time!");
    }
    return wonGame;
}

void GameStatistics()
{
    string gameStatus;
    int gameNumber = 0;
    string gameData = "";
    string difficulty = "";
    if (HasWon() == true)
    {
        gameStatus = "Won";
    }
    else
    {
        gameStatus = "Lost";
    }
    gameNumber++;
    switch (gameSelector)
    {
        case "1":
            gameType = "Addition";
            break;
        case "2":
            gameType = "Subtraction";
            break;
        case "3":
            gameType = "Multiplication";
            break;
        case "4":
            gameType = "Division";
            break;
        default:
            Console.WriteLine("No operation selected");
            break;
    }
    switch (difficultyMode)
    {
        case "1":
            difficulty = "Easy";
            break;
        case "2":
            difficulty = "Medium";
            break;
        case "3":
            difficulty = "Hard";
            break;
        default:
            Console.WriteLine("No difficulty selected");
            break;
    }
    gameData = $"GameType: {gameType} || " + $"Game number: {gameNumber} || Difficulty Mode: {difficulty} || Won or lost?: {gameStatus}";
    gameHistory.Add(gameData);
    Console.WriteLine("Thank you for playing. Play more games to improve your score!");
    Console.WriteLine("Your game history is as follows: ");
    Console.WriteLine("-------------------------------------------------");
    foreach (string game in gameHistory)
    {
        Console.WriteLine(game);
    }
    Console.WriteLine("-------------------------------------------------");
    timer.Stop();
    var elapsedTime = timer.ElapsedMilliseconds / 1000;
    Console.WriteLine($"You took {elapsedTime.ToString()} seconds to complete the game");

}
int SelectCustomGame()
{
    int result = 0;
    int a = 0;
    int b = 0;
    if (difficultyMode == "1")
    {
        a = random.Next(1, 11); // Generates a random number between 1 and 10
        b = random.Next(1, 11); // Generates a random number between 1 and 10
    }
    else if (difficultyMode == "2")
    {
        a = random.Next(1, 51); // Generates a random number between 1 and 50
        b = random.Next(1, 51); // Generates a random number between 1 and 50
    }
    else if (difficultyMode == "3")
    {
        a = random.Next(1, 101); // Generates a random number between 1 and 100
        b = random.Next(1, 101); // Generates a random number between 1 and 100
    }
    else
    {
        Console.WriteLine("Invalid difficulty mode selected. Please try again.");
    }
    gameSelector = Console.ReadLine();
    if (gameSelector != null)
    {

        switch (gameSelector)
        {
            case "1":
                Console.WriteLine($"Welcome to the Addition Game! The numbers are {a} and {b}.");
                result = a + b;
                Console.WriteLine($"{a} + {b} = ?");
                Console.WriteLine("Please enter your guess: ");
                guess = Console.ReadLine();
                if (int.TryParse(guess, out answer) == false)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
                break;
            case "2":
                result = a - b;

                if (a < b)
                {
                    b = a;
                }
                Console.WriteLine($"Welcome to the Subtraction Game! The numbers are {a} and {b}.");
                Console.WriteLine($"{a} - {b} = ?");
                Console.WriteLine("Please enter your guess: ");
                guess = Console.ReadLine();
                if (int.TryParse(guess, out answer) == false)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
                break;
            case "3":
                Console.WriteLine($"Welcome to the Multiplication Game! The numbers are {a} and {b}.");
                result = a * b;
                Console.WriteLine($"{a} * {b} = ?");
                Console.WriteLine("Please enter your guess: ");
                guess = Console.ReadLine();
                if (int.TryParse(guess, out answer) == false)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
                break;
            case "4":
                Console.WriteLine($"Welcome to the Division Game! The numbers are {a} and {b}.");
                if (b > a)
                {
                    b = a;
                    a = b;
                }
                result = a / b;
                Console.WriteLine($"{a} / {b} = ?");
                Console.WriteLine("Please enter your guess: ");
                guess = Console.ReadLine();
                if (int.TryParse(guess, out answer) == false)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }

                break;
            default:
                Console.WriteLine("Invalid selection. Please try again.");
                break;
        }
    }
    finalResult = result;
    return result;
}
int SelectRandomGame()
{
    int result = 0;
    int a = 0;
    int b = 0;
    if (difficultyMode == "1")
    {
        a = random.Next(1, 11); // Generates a random number between 1 and 10
        b = random.Next(1, 11); // Generates a random number between 1 and 10
    }
    else if (difficultyMode == "2")
    {
        a = random.Next(1, 51); // Generates a random number between 1 and 50
        b = random.Next(1, 51); // Generates a random number between 1 and 50
    }
    else if (difficultyMode == "3")
    {
        a = random.Next(1, 101); // Generates a random number between 1 and 100
        b = random.Next(1, 101); // Generates a random number between 1 and 100
    }
    else
    {
        Console.WriteLine("Invalid difficulty mode selected. Please try again.");
    }
    int gameSelector = random.Next(1, 5); // Randomly selects a game between 1 and 4
    switch (gameSelector)
    {
        case 1:
            Console.WriteLine($"Welcome to the Addition Game! The numbers are {a} and {b}.");
            result = a + b;
            Console.WriteLine($"{a} + {b} = ?");
            Console.WriteLine("Please enter your guess: ");
            guess = Console.ReadLine();
            if (int.TryParse(guess, out answer) == false)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            break;
        case 2:
            result = a - b;
            if (a < b)
            {
                b = a;
            }
            Console.WriteLine($"Welcome to the Subtraction Game! The numbers are {a} and {b}.");
            Console.WriteLine($"{a} - {b} = ?");
            Console.WriteLine("Please enter your guess: ");
            guess = Console.ReadLine();
            if (int.TryParse(guess, out answer) == false)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            break;
        case 3:
            Console.WriteLine($"Welcome to the Multiplication Game! The numbers are {a} and {b}.");
            result = a * b;
            Console.WriteLine($"{a} * {b} = ?");
            Console.WriteLine("Please enter your guess: ");
            guess = Console.ReadLine();
            if (int.TryParse(guess, out answer) == false)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            break;
        case 4:
            Console.WriteLine($"Welcome to the Division Game! The numbers are {a} and {b}.");
            if (b > a)
            {
                b = a;
            }
            result = a / b;
            Console.WriteLine($"{a} / {b} = ?");
            Console.WriteLine("Please enter your guess: ");
            guess = Console.ReadLine();
            if (int.TryParse(guess, out answer) == false)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }

            break;
        default:
            Console.WriteLine("Invalid selection. Please try again.");
            break;
    }
    finalResult = result;
    return result;
}
string ChooseDifficulty()
{
    int a = 0;
    int b = 0;
    Console.WriteLine("Please choose from the following difficulty options: ");
    Console.WriteLine("1. Easy");
    Console.WriteLine("2. Medium");
    Console.WriteLine("3. Hard");
    difficultyMode = Console.ReadLine();
    if (difficultyMode != null)
    {
        if (difficultyMode == "1")
        {
            a = random.Next(1, 11); // Generates a random number between 1 and 10
            b = random.Next(1, 11); // Generates a random number between 1 and 10
        }
        else if (difficultyMode == "2")
        {
            a = random.Next(1, 51); // Generates a random number between 1 and 50
            b = random.Next(1, 51); // Generates a random number between 1 and 50
        }
        else if (difficultyMode == "3")
        {
            a = random.Next(1, 101); // Generates a random number between 1 and 100
            b = random.Next(1, 101); // Generates a random number between 1 and 100
        }
        else
        {
            Console.WriteLine("Invalid difficulty mode selected. Please try again.");
        }
    }
    return difficultyMode;
}
void ContinueGame()
{
    string? continueGame;
    if (wonGame == true)
    {
        Console.WriteLine("Congratulations! You have won this game! Would you like to continue playing Y/N");
    }
    else
    {
        Console.WriteLine("I am sorry, you have lost this game. Would you like to continue playing Y/N");
    }
    {
        do
        {
            continueGame = Console.ReadLine().ToUpper();
            if (continueGame == "N")
                {
                    Console.WriteLine("Thank you for playing! Goodbye!");
                    Environment.Exit(0);
                }
                SelectGameType();
                GameStatistics();
                ContinueGame();

        }
        while (continueGame != "Y" || continueGame != "N");
    }

}

