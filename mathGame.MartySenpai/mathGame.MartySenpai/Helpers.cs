using MathGame.Models;
using System.Diagnostics;
using static System.Formats.Asn1.AsnWriter;

namespace MathGame;

internal class Helpers
{
    internal static List<Game> games = new List<Game>();
    internal static void PrintGames()
    {
        Console.Clear();
        Console.WriteLine("Games History");
        Console.WriteLine("------------------------------------");
        foreach (Game game in games)
        {
            Console.WriteLine($"{game.Date} - {game.Difficulty} - {game.Type} : {game.Score}/{game.NQuestions} pts - Time: {game.GameTime:mm\\:ss\\:ff}");
        }
        Console.WriteLine("------------------------------------\n");
        Console.WriteLine("Press any key to return to the main menu");
        Console.ReadLine();
    }
    internal static void AddToHistory(int gameScore, int nQuestions, GameType gameType, string difficulty, TimeSpan timeTaken)
    {
        games.Add(new Game
        {
            Date = DateTime.Now,
            Score = gameScore,
            NQuestions = nQuestions,
            Type = gameType,
            Difficulty = difficulty,
            GameTime = timeTaken
        });
    }
    internal static List<int> GetDivisionNumbers()
    {
        Random random = new Random();
        int firstNumber = random.Next(1, 101);
        int secondNumber = random.Next(1, 101);

        List<int> numbers = new List<int>();

        while (firstNumber % secondNumber != 0)
        {
            firstNumber = random.Next(1, 101);
            secondNumber = random.Next(1, 101);
        }

        numbers.Add(firstNumber);
        numbers.Add(secondNumber);

        return numbers;
    }
    internal static string ValidateInput(string input)
    {
        while (string.IsNullOrEmpty(input) || !Int32.TryParse(input, out _))
        {
            Console.WriteLine("Your input needs to be an integer, Try again.");
            input = Console.ReadLine();
        }
        return input;
    }
    internal static string GetName()
    {
        Console.WriteLine("Please type your name");
        string name = Console.ReadLine();

        while (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Name can't be empty");
            name = Console.ReadLine();
        }
        return name;
    }
    internal static int GetAmountOfQuestions()
    {

        Console.Clear();
        Console.WriteLine("Please enter how many questions you would like to recieve.");

        string input = (Console.ReadLine());

        input = ValidateInput(input);

        int amount = Int32.Parse(input);

        return amount;
    }
    internal static void PrintQuestions(string difficulty, List<int> numbers, char operand)
    {
        var random = new Random();

        int n = 0;

        // Makes sure division only print two numbers.
        if (operand == '/')
        {
            difficulty = "Easy";
        }

        switch (difficulty)
        {
            case "Easy":
                n = 2;
                break;
            case "Normal":
                n = 3;
                break;
            case "Hard":
                n = 4;
                break;
        }

        // Prints different amounts of values in a question based on difficulty.
        for (int j = 0; j < n; j++)
        {
            if (operand != '/')
            {
                numbers.Add(random.Next(1, 11));
            }
            
            if (j == n - 1)
            {
                Console.Write($"{numbers[j]}\n");
            }
            else
            {
                Console.Write($"{numbers[j]} {operand} ");
            }
        }
    }
    internal static int GetOutput(int output, char operand, List<int> numbers)
    {
        for (int j = 1; j < numbers.Count; j++)
        {
            switch (operand)
            {
                case '+':
                    output += numbers[j];
                    break;
                case '-':
                    output += numbers[j];
                    break;
                case '*':
                    output += numbers[j];
                    break;
                case '/':
                    output += numbers[j];
                    break;
            }
        }
        return output;
    }

    internal static int GetScore(string input, int output, int score)
    {
        if (int.Parse(input) == output)
        {
            Console.WriteLine("Your answer was correct! Type any key for the next question");
            score++;
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Your answer was incorrect. Type any key for the next question");
            Console.ReadLine();
        }
        return score;
    }
}
