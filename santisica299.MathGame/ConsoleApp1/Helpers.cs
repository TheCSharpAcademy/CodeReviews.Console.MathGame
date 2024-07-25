using ConsoleApp1.Models;
using static ConsoleApp1.Models.Game;

namespace ConsoleApp1;

internal class Helpers
{
    static List<Game> games = new()
    {
        new Game { Date = DateTime.Now.AddDays(1), Type = GameType.Addition, Score = 5 },
        new Game { Date = DateTime.Now.AddDays(2), Type = GameType.Multiplication, Score = 4 },
        new Game { Date = DateTime.Now.AddDays(3), Type = GameType.Division, Score = 4 },
        new Game { Date = DateTime.Now.AddDays(4), Type = GameType.Substraction, Score = 3 },
        new Game { Date = DateTime.Now.AddDays(5), Type = GameType.Addition, Score = 1 },
        new Game { Date = DateTime.Now.AddDays(6), Type = GameType.Multiplication, Score = 2 },
        new Game { Date = DateTime.Now.AddDays(7), Type = GameType.Division, Score = 3 },
        new Game { Date = DateTime.Now.AddDays(8), Type = GameType.Substraction, Score = 4 },
        new Game { Date = DateTime.Now.AddDays(9), Type = GameType.Addition, Score = 4 },
        new Game { Date = DateTime.Now.AddDays(10), Type = GameType.Multiplication, Score = 1 },
        new Game { Date = DateTime.Now.AddDays(11), Type = GameType.Substraction, Score = 0 },
        new Game { Date = DateTime.Now.AddDays(12), Type = GameType.Division, Score = 2 },
        new Game { Date = DateTime.Now.AddDays(13), Type = GameType.Substraction, Score = 5 },
    };

    internal static string GetName()
    {
        Console.WriteLine("Please type your name");

        var name = Console.ReadLine();

        while (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Enter a name please.\n");
            name = Console.ReadLine();
        }

        return name;
    }


    internal static void ViewPrevGames()
    {
        var gamesToShow = games.OrderByDescending(x => x.Date);

        if (gamesToShow.Count() == 0)
        {
            Console.WriteLine("There are no games recorded.");
            Console.ReadLine();
            return;
        }

        Console.Clear();
        Console.WriteLine("Games History");
        Console.WriteLine("--------------------------");
        foreach (var game in gamesToShow)
        {
            string time = Helpers.FormatTimeSpanToStr(game.Time);

            Console.WriteLine($"{game.Date}: {time} - {game.Type}: {game.Score}/{game.NumOfQ} pts");
        }

        Console.WriteLine("--------------------------\n");
        Console.WriteLine("Press any key to go back to menu");
        Console.ReadLine();

    }

    internal static void AddToHistory(int score, GameType typeGame, TimeSpan time, int numOfQ)
    {
        games.Add(new Game
        {
            Date = DateTime.Now,
            Score = score,
            Type = typeGame,
            Time = time,
            NumOfQ = numOfQ
        });
        // char.ToUpper(typeGame[0])+typeGame.Substring(1) makes typegame first letter string uppercase
    }

    internal static void ShowFinalResult(int score, int numOfQ, string time)
    {
        Console.WriteLine($"Game over. Your final score is {score}/{numOfQ}.\nIt took you {time} to finish the game. \nPress any key to go back to the main menu.");
        Console.ReadLine();
    }


    internal static int[] GetDivisionNumbers()
    {
        var random = new Random();
        var firstNumber = random.Next(0, 99);
        var secondNumber = random.Next(0, 99);

        var result = new int[2];

        while (firstNumber % secondNumber != 0)
        {
            firstNumber = random.Next(1, 99);
            secondNumber = random.Next(1, 99);
        }

        result[0] = firstNumber;
        result[1] = secondNumber;

        return result;
    }

    internal static int[] GetRandomNumbers(string gameDifficulty)
    {
        var numbers = new int[2];

        var random = new Random();

        int firstNumber = 0;
        int secondNumber = 0;

        if (string.Compare(gameDifficulty, GameDifficulty.Easy.ToString(), StringComparison.OrdinalIgnoreCase) == 0)
        {
            firstNumber = random.Next(1, 9);
            secondNumber = random.Next(1, 9);
        }
        else if (string.Equals(gameDifficulty, GameDifficulty.Medium.ToString(), StringComparison.OrdinalIgnoreCase))
        {
            firstNumber = random.Next(1, 50);
            secondNumber = random.Next(1, 50);
        }
        else if (StringComparer.OrdinalIgnoreCase.Equals(gameDifficulty, GameDifficulty.Hard.ToString()))
        {
            firstNumber = random.Next(1, 100);
            secondNumber = random.Next(1, 100);
        }

        numbers[0] = firstNumber;
        numbers[1] = secondNumber;

        return numbers;
    }

    internal static string? ValidateResult(string? result)
    {
        while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
        {
            Console.WriteLine("Your answer needs to be a number. Try again.");
            result = Console.ReadLine();
        }
        return result;
    }

    internal static string GetGameDifficulty()
    {
        bool x = false;
        string diff = "";

        while (x == false)
        {
            Console.Clear();
            Console.WriteLine("Choose a difficulty: \n\nEasy - Medium - Hard\n");

            diff = Console.ReadLine().ToLower();

            if (diff == "easy" || diff == "medium" || diff == "hard")
            {
                x = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Try again.");
                Console.ReadLine();
            }
        }

        return diff;
    }

    internal static string FormatTimeSpanToStr(TimeSpan ts)
    {
        string timeInString = String.Format("({0:0} min - {1:0} sec)",
            (int)ts.Minutes, ts.Seconds);

        return timeInString;
    }

    internal static int GetNumberOfQuestions()
    {
        bool flag = false;
        var result = "";

        while (!flag)
        {
            Console.Clear();
            Console.WriteLine("Select the number of questions you want to get asked.\nPick from 3 - 10\n");
            result = Console.ReadLine();

            if (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _) || (int.Parse(result) < 3 || int.Parse(result) > 10))
            {
                Console.WriteLine("Invalid input. Try again.");
            }
            else
            {
                Console.WriteLine($"You will be asked {result} questions. Good luck!");
                flag = true;
            }
            Console.ReadLine();
        }

        return int.Parse(result);
    }

    internal static int GetResultOfOperation(int n1, int n2, char op)
    {
        if (op == '+')
            return n1 + n2;

        if (op == '-')
            return n1 - n2;

        if (op == '/')
            return n1 / n2;

        return n1 * n2;
    }

    internal static char GetRandomTypeOfGame()
    {
        var r = new Random();
        var typeOfGame = r.Next(1, 5);
        char op = 'a';

        switch (typeOfGame)
        {
            case 1:
                op = '*';
                break;
            case 2:
                op = '+';
                break;
            case 3:
                op = '-';
                break;
            case 4:
                op = '/';
                break;
            default:
                break;
        }

        return op;
    }

    internal static int[] GetNumbersForGame(char op, string difficulty)
    {
        if (op == '/')
        {
            return Helpers.GetDivisionNumbers();
        }

        return Helpers.GetRandomNumbers(difficulty);
    }

    internal static GameType GetGameType(char op)
    {
        GameType gameType = GameType.Multiplication;

        switch (op)
        {
            case '*':
                gameType = GameType.Multiplication;
                break;
            case '+':
                gameType = GameType.Addition;
                break;
            case '-':
                gameType = GameType.Substraction;
                break;
            case '/':
                gameType = GameType.Division;
                break;
            default:
                break;
        }

        return gameType;
    }
}
