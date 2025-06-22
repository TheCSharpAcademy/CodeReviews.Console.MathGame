// See https://aka.ms/new-console-template for more information

using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

Random random = new Random();

string? guess = "";
string? gameType = "";
List<string> gameHistory = new List<string>();
bool wonGame = false;
int finalResult = 0;
int answer = 0;
string? gameSelector = "";

var timer = System.Diagnostics.Stopwatch.StartNew();
StartGame();
GameStatistics();
ContinueGame();

int StartGame()
{
    string gameType = "";
    int a = random.Next(1, 101); // Generates a random number between 1 and 100
    int b = random.Next(1, 101); // Generates a random number between 1 and 100
    int result = 0;
    Console.WriteLine("Welcome to Jack's Math Game!");
    Console.WriteLine("Please guess the correct result of two random numbers depending on the operation selected");
    Console.WriteLine("Please now choose from the following operations");
    Console.WriteLine("1. Add");
    Console.WriteLine("2: Subtract");
    Console.WriteLine("3: Multiply");
    Console.WriteLine("4: Divide ");
    gameSelector = Console.ReadLine();
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
            Console.WriteLine($"Welcome to the Subtraction Game! The numbers are {a} and {b}.");
            result = a - b;
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
            try
            {
                result = a / b;
                Console.WriteLine($"{a} / {b} = ?");
                Console.WriteLine("Please enter your guess: ");
                guess = Console.ReadLine();
                if (int.TryParse(guess, out answer) == false)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
            catch (DivideByZeroException e)
            {
                throw new DivideByZeroException($"Error: Division by zero is not allowed.{e.Message}");
            }
            break;
        default:
            Console.WriteLine("Invalid selection. Please try again.");
            break;
    }
    finalResult = result;
    return result;

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
    if (HasWon() == true)
    {
        gameStatus = "Won";
    }
    else
    {
        gameStatus = "Lost";
    }
    gameNumber++;
    if (gameSelector == "1")
    {
        gameType = "Addition";
    }
    else if (gameSelector == "2")
    {
        gameType = "Subtraction";
    }
    else if (gameSelector == "3")
    {
        gameType = "Multiplication";
    }
    else if (gameSelector == "4")
    {
        gameType = "Division";
    }
    gameData = $"GameType: {gameType} || " + $"Game number: {gameNumber}. Won or lost?: {gameStatus}";
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
void ContinueGame()
{
    string? continueGame;
    if (wonGame == true)
    {
        Console.WriteLine("Congratulations! You have won this game! Would you like to continue playing? Y/N");
    }
    else
    {
        Console.WriteLine("I am sorry, you have lost this game. Would you like to continue playing? Y/N");
    }
    {
        continueGame = Console.ReadLine().ToUpper();
        do
        {

            if (continueGame != null)
            {
                if (continueGame == "N")
                {
                    Console.WriteLine("Thank you for playing! Goodbye!");
                    Environment.Exit(0);
                }
                StartGame();
                GameStatistics();
            }

            else
            {
                Console.WriteLine("Invalid input. Please enter Y or N");
            }
        }
        while (continueGame != "N");
    }

}

