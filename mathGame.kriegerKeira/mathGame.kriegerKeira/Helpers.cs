namespace mathGame.kriegerKeira;
using Models;
public static class Helpers
{
    public static List<Game> Games = [];
    public static string GetName()
    {
        Console.Write("Please enter your name: ");
        var name = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Name cannot be empty, press any key to try again");
            Console.ReadKey();
            Console.Clear();
            Console.Write("Please enter your name: ");
            name = Console.ReadLine();
            Console.Clear();
        }
        return name;

    }

    public static int[] GetDivisionNumbers()
    {
        var random = new Random();
        var firstNumber = random.Next(1, 99);
        var secondNumber = random.Next(1, 99);
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

    public static string ValidateResult(string? result)
    {
        while (string.IsNullOrWhiteSpace(result) || !Int32.TryParse(result, out _))
        {
            Console.WriteLine("Invalid entry, please enter an integer");
            result = Console.ReadLine();
        }
        return result;
    }

    public static void AddToHistory(int gameScore, GameType gameType)
    {
        Games.Add( new Game
        {
            Date = DateTime.Now,
            Score = gameScore,
            Type = gameType
        });
    }

    public static void PrintGames()
    {
        var historyRunning = true;

        do
        {
            Console.Clear();
            Console.WriteLine($@"What game history would you like to view? You may select from the following options:
E - All history
A - Addition history
S - Subtraction history
M - Multiplication history
D - Division history
Q - Quit to main menu");
            Console.WriteLine("----------------------------------------------------------------------------");
            var gameSelection = Console.ReadLine()?.Trim().ToUpper();

            switch (gameSelection)
            {
                case "E":
                    var allGameHistory = Games.OrderBy(g => g.Type).ThenByDescending(g => g.Score);
                    foreach (var game in allGameHistory)
                    { Console.WriteLine($"{game.Date} - {game.Type} - {game.Score}pts"); }
                    Console.WriteLine("Press any key to return to the history menu");
                    Console.ReadKey();
                    break;
                case "A":
                    var additionGameHistory = Games.Where(g => g.Type == GameType.Addition).OrderByDescending(g => g.Score);
                    foreach (var game in additionGameHistory)
                    { Console.WriteLine($"{game.Date} - {game.Type} - {game.Score}pts"); }
                    Console.WriteLine("Press any key to return to the history menu");
                    Console.ReadKey();
                    break;
                case "S":
                    var subtractionGameHistory = Games.Where(g => g.Type == GameType.Subtraction).OrderByDescending(g => g.Score);
                    foreach (var game in subtractionGameHistory)
                    { Console.WriteLine($"{game.Date} - {game.Type} - {game.Score}pts"); }
                    Console.WriteLine("Press any key to return to the history menu");
                    Console.ReadKey();
                    break;
                case "M":
                    var multiplicationGameHistory = Games.Where(g => g.Type == GameType.Multiplication).OrderByDescending(g => g.Score);
                    foreach (var game in multiplicationGameHistory)
                    { Console.WriteLine($"{game.Date} - {game.Type} - {game.Score}pts"); }
                    Console.WriteLine("Press any key to return to the history menu");
                    Console.ReadKey();
                    break;
                case "D":
                    var divisionGameHistory = Games.Where(g => g.Type == GameType.Division).OrderByDescending(g => g.Score);
                    foreach (var game in divisionGameHistory)
                    { Console.WriteLine($"{game.Date} - {game.Type} - {game.Score}pts"); }
                    Console.WriteLine("Press any key to return to the history menu");
                    Console.ReadKey();
                    break;
                case "Q":
                    Console.WriteLine("Returning to main menu...");
                    Thread.Sleep(2000);
                    historyRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid selection, press any key to try again!");
                    Console.ReadKey();
                    break;
            }
        } while (historyRunning);
    }
}