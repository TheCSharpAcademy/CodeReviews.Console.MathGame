using System.Text;

enum BasicOperations
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
    None
}

enum Difficulties
{
    Easy,
    Medium,
    Hard
}

class Program
{
    public static void Main(string[] args)
    {
        Game.LaunchGame();
    }
}

class Game
{
    private static GameCalculations _calculation = new GameCalculations();

    public static void LaunchGame()
    {
        string menuOption = String.Empty;

        var previousGames = new List<string>();

        Console.WriteLine("Math Game");
        while (menuOption != "q")
        {
            ShowMenu(true);
            switch (menuOption)
            {
                case "a":
                    previousGames.AddRange(_calculation.CalculateOperands(BasicOperations.Addition));
                    menuOption = String.Empty;
                    break;
                case "s":
                    previousGames.AddRange(_calculation.CalculateOperands(BasicOperations.Subtraction));
                    menuOption = String.Empty;
                    break;
                case "m":
                    previousGames.AddRange(_calculation.CalculateOperands(BasicOperations.Multiplication));
                    menuOption = String.Empty;
                    break;
                case "d":
                    previousGames.AddRange(_calculation.CalculateOperands(BasicOperations.Division));
                    menuOption = String.Empty;
                    break;
                case "r":
                    previousGames.AddRange(_calculation.CalculateOperands(BasicOperations.None, true));
                    menuOption = String.Empty;
                    break;
                case "g":
                    ShowMenu(false);
                    menuOption = String.Empty;
                    break;
                case "h":
                    Console.WriteLine("History of previous games: ");

                    previousGames.ForEach((game) => Console.WriteLine(game));
                    Console.WriteLine("\nPress enter to go back to menu");
                    Console.ReadLine();

                    menuOption = String.Empty;
                    break;
                default:
                    menuOption = Console.ReadLine() ?? "q";
                    break;
            }
        }
    }

    private static void ShowMenu(bool isGlobalMenu)
    {
        Console.WriteLine("--------------------");
        Console.WriteLine("Main Menu");
        Console.WriteLine("a - Addition");
        Console.WriteLine("s - Subtraction");
        Console.WriteLine("m - Multiplication");
        Console.WriteLine("d - Division");
        Console.WriteLine("r - Random");
        Console.WriteLine("h - History of previous games ");

        if (!isGlobalMenu)
        {
            Console.WriteLine("g - Go back to menu");
        }

        Console.WriteLine("q - To quit");
        Console.WriteLine("--------------------");
    }
}

class GameCalculations
{
    private static Difficulties _difficulty = Difficulties.Easy;
    private static int _numberOfGames = 1;

    public List<string> CalculateOperands(BasicOperations operation, bool isRandom = false)
    {
        SetDifficulty();
        SetNumberOfGames();

        var results = new List<string>();
        var startDate = DateTime.UtcNow;

        for (int i = 0; i < _numberOfGames; i++)
        {
            if (isRandom)
            {
                var random = new Random();
                operation = (BasicOperations)random.Next(0, 4);
            }
            Console.WriteLine("What is the result of this expression?");

            var isDivision = operation == BasicOperations.Division;
            var (first, second) = GetRandomValues(isDivision);

            int answer = 0;
            var gameRecord = new StringBuilder();


            switch (operation)
            {
                case BasicOperations.Addition:
                    answer = first + second;
                    gameRecord.Append($"{first} + {second} = ");
                    Console.WriteLine($"{first} + {second} = ");
                    break;
                case BasicOperations.Subtraction:
                    answer = first - second;
                    gameRecord.Append($"{first} - {second} = ");
                    Console.WriteLine($"{first} - {second} = ");
                    break;
                case BasicOperations.Multiplication:
                    answer = first * second;
                    gameRecord.Append($"{first} * {second} = ");
                    Console.WriteLine($"{first} * {second} = ");
                    break;
                case BasicOperations.Division:
                    answer = first / second;
                    gameRecord.Append($"{first} / {second} = ");
                    Console.WriteLine($"{first} / {second} = ");
                    break;
            }

            var userAnswer = GetValueFromConsole();

            while (userAnswer != answer)
            {
                Console.WriteLine("Incorrect, try again:");
                userAnswer = GetValueFromConsole();
            }

        

            gameRecord.Append(answer);
            results.Add(gameRecord.ToString());
            Console.WriteLine("Correct");
        }
        
        var endDate = DateTime.UtcNow;
        var timeSpan = endDate - startDate;
        
        Console.WriteLine($"It took: {timeSpan.Hours}:{timeSpan.Minutes}:{timeSpan.Seconds}");
        Console.WriteLine("\nPress enter to go back to menu");
        Console.ReadLine();

        return results;
    }

    private int GetValueFromConsole()
    {
        var str = Console.ReadLine();
        int value;
        var isNumber = int.TryParse(str, out value);

        if (!isNumber)
        {
            Console.WriteLine("Argument must be integer");
            value = GetValueFromConsole();
        }

        return value;
    }

    private (int, int) GetRandomValues(bool isDivision = false)
    {
        var first = GetRandomValue();
        var second = GetRandomValue();

        while (isDivision && first % second != 0)
        {
            first = GetRandomValue();
        }

        return (first, second);
    }

    private void SetDifficulty()
    {
        Console.WriteLine("Choose difficulty: ");
        Console.WriteLine("e - easy");
        Console.WriteLine("m - medium");
        Console.WriteLine("h - hard");

        string difficulty = String.Empty;

        while (difficulty != "e" && difficulty != "m" && difficulty != "h")
        {
            difficulty = Console.ReadLine() ?? String.Empty;
        }

        switch (difficulty)
        {
            case "e":
                _difficulty = Difficulties.Easy;
                break;
            case "m":
                _difficulty = Difficulties.Medium;
                break;
            case "h":
                _difficulty = Difficulties.Hard;
                break;
        }
    }

    private void SetNumberOfGames()
    {
        Console.WriteLine("Write number of games to play:");
        _numberOfGames = GetValueFromConsole();
    }

    private int GetRandomValue()
    {
        var random = new Random();

        var (min, max) = _difficulty switch
        {
            Difficulties.Easy => (0, 100),
            Difficulties.Medium => (-1000, 1000),
            Difficulties.Hard => (-10000, 100),
            _ => (0, 100)
        };

        return random.Next(min, max);
    }
}