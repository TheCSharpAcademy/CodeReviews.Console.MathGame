// See https://aka.ms/new-console-template for more information

using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

Random random = new Random();

string? guess = "";
int answer = 0;
string? gameSelector = "";
List<string> gameHistory = new List<string>();
int successfulGames = 0;
string gameData = "";
bool wonGame = false;
int additionResult = 0;
int subtractionResult = 0;
int multiplicationResult = 0;
int divisionResult = 0;




StartGame();
GameStatistics();
if (wonGame == true)
{
    string? continueGame;
    do
    {
        Console.WriteLine("You have won this game. Please start a new game to continue playing Y/N.");
        continueGame = Console.ReadLine().ToUpper();
        if (continueGame == "N")
        {
            Console.WriteLine("Thank you for playing! Goodbye!");
            Environment.Exit(0);
        }
        else
        {
            StartGame();
            GameStatistics();
        }
    }
    while (continueGame != "N");
}
else
{
    Console.WriteLine("Invalid input. Please enter Y or N.");

}


int AdditionGame()
{
    int a = random.Next(1, 101); // Generates a random number between 1 and 100
    int b = random.Next(1, 101); // Generates a random number between 1 and 100
    Console.WriteLine($"Welcome to the Addition Game! The numbers are {a} and {b}.");
    additionResult = a + b;
    Console.WriteLine($"{a} + {b} = ?");
    Console.WriteLine("Please enter your guess: ");
    guess = Console.ReadLine();
    if (int.TryParse(guess, out answer) == false)
    {
        Console.WriteLine("Invalid input. Please enter a valid number.");
    }
    return additionResult;
}
int SubtractionGame()
{
    int a = random.Next(1, 101); // Generates a random number between 1 and 100
    int b = random.Next(1, 101); // Generates a random number between 1 and 100
    Console.WriteLine($"Welcome to the Subtraction Game! The numbers are {a} and {b}.");
    subtractionResult = a - b;
    Console.WriteLine($"{a} - {b} = ?");
    Console.WriteLine("Please enter your guess: ");
    guess = Console.ReadLine();
    if (int.TryParse(guess, out answer) == false)
    {
        Console.WriteLine("Invalid input. Please enter a valid number.");
    }
    return subtractionResult;
}
int MultiplicationGame()
{
    int a = random.Next(1, 101); // Generates a random number between 1 and 100
    int b = random.Next(1, 101); // Generates a random number between 1 and 100
    Console.WriteLine($"Welcome to the Multiplication Game! The numbers are {a} and {b}.");
    multiplicationResult = a * b;
    Console.WriteLine($"{a} * {b} = ?");
    Console.WriteLine("Please enter your guess: ");
    guess = Console.ReadLine();
    if (int.TryParse(guess, out answer) == false)
    {
        Console.WriteLine("Invalid input. Please enter a valid number.");
    }
    return multiplicationResult;
}
int DivisionGame()
{
    int a = random.Next(1, 101); // Generates a random number between 1 and 100
    int b = random.Next(1, 101); // Generates a random number between 1 and 100
    Console.WriteLine($"Welcome to the Division Game! The numbers are {a} and {b}.");
    try
    {
        divisionResult = a / b;
        Console.WriteLine($"{a} / {b} = ?");
        Console.WriteLine("Please enter your guess: ");
        guess = Console.ReadLine();
        if (int.TryParse(guess, out answer) == false)
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
        return divisionResult;
    }
    catch (DivideByZeroException e)
    {
        throw new DivideByZeroException($"Error: Division by zero is not allowed.{e.Message}");
    }
}
string StartGame()
{
    Console.WriteLine("Welcome to Jack's Math Game!");
    Console.WriteLine("Please guess the correct result of two random numbers depending on the operation selected");
    Console.WriteLine("Please now choose from the following operations");
    Console.WriteLine("1. Add");
    Console.WriteLine("2: Substract");
    Console.WriteLine("3: Multiply");
    Console.WriteLine("4: Divide ");
    gameSelector = Console.ReadLine();
    switch (gameSelector)
    {
        case "1":
            AdditionGame();
            break;
        case "2":
            SubtractionGame();
            break;
        case "3":
            MultiplicationGame();
            break;
        case "4":
            DivisionGame();
            break;
        default:
            Console.WriteLine("Invalid selection. Please try again.");
            break;
    }
    return gameSelector;
}

bool HasWon()
{
    if (guess != null)
    {
        if (int.TryParse(guess, out answer))
        {
            if (gameSelector == "1")
            {
                if (additionResult == answer)
                {
                    Console.WriteLine("Congratulations! You guessed correctly!");
                    wonGame = true;
                }
                else
                {
                    Console.WriteLine("Sorry, you did not guess correctly. Better luck next time!");
                }
            }
            if (gameSelector == "2")
            {
                if (subtractionResult == answer)
                {
                    Console.WriteLine("Congratulations! You guessed correctly!");
                    wonGame = true;
                }
                else
                {
                    Console.WriteLine("Sorry, you did not guess correctly.Better luck next time!");
                }
            }
            if (gameSelector == "3")
            {
                if (multiplicationResult == answer)
                {
                    Console.WriteLine("Congratulations! You guessed correctly!");
                    wonGame = true;
                }
                else
                {
                    Console.WriteLine("Sorry, you did not guess correctly. Better luck next time!");
                }
            }

            if (gameSelector == "4")
            {
                if (divisionResult == answer)
                {
                    Console.WriteLine("Congratulations! You guessed correctly!");
                    wonGame = true;
                }
                else
                {
                    Console.WriteLine("Sorry, you did not guess correctly. Better luck next time!");

                }
            }
        }
    }
    else
    {
        Console.WriteLine("You did not enter a valid guess. Please try again.");
    }
    return wonGame;
}

void GameStatistics()
{
    if (HasWon() == true)
    {
        if (gameSelector == "1")
        {
            successfulGames++;
            gameData = "GameType: Addition || " + $"Number of games won: {successfulGames}";
            gameHistory.Add(gameData);

        }
        if (gameSelector == "2")
        {
            successfulGames++;
            gameData = "GameType: Subtraction || " + $"Number of games won: {successfulGames}";
            gameHistory.Add(gameData);
        }
        if (gameSelector == "3")
        {
            successfulGames++;
            gameData = "GameType: Multiplication || " + $"Number of games won: {successfulGames}";
            gameHistory.Add(gameData);
        }
        if (gameSelector == "4")
        {
            successfulGames++;
            gameData = "GameType: Division ||" + $"Number of games won: {successfulGames}";
            gameHistory.Add(gameData);
        }
        if (successfulGames == 0)
        {
            Console.WriteLine("You have not won any games yet. Please try again!");
        }
        else
        {
            Console.WriteLine("Well done on winning! Play more games to improve your score!");
            Console.WriteLine("Your game history is as follows: ");
            Console.WriteLine("-------------------------------------------------");
            foreach (string game in gameHistory)
            {
                Console.WriteLine(game);
            }
            Console.WriteLine("-------------------------------------------------");
        }

    }
       
}

