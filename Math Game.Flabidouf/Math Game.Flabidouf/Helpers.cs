namespace Math_Game_v2.Models;

internal class Helpers
{
    
    internal static List<Game> games = new List<Game>
    {
     
    };
    
    public static void AddToHistory(int gameScore, GameType gameType) // Allows for game history.
    {
        games.Add(new Game
        {
            Date = DateTime.Now,
            Score = gameScore,
            Type = gameType
        });
    }
    
    internal static void PrintGames()
    {
        var gamesToPrint = games.Where(x => x.Type == GameType.Addition); 
        // Where() filters a sequence of values based on a predicate(condition). Linq
        
        Console.Clear();
        Console.WriteLine("Games History");
        Console.WriteLine("----------------------");
        foreach (var game in gamesToPrint)
        {
            Console.WriteLine($"{game.Date} - {game.Type}: {game.Score}pts");
        }

        Console.WriteLine("----------------------\n");
        Console.WriteLine("Press any key to return to Main Menu");
        Console.ReadLine();
    }
    
    internal static int[] GetDivisionNumbers()
    {
        Random rand = new Random();
        int firstNumber = rand.Next(1, 99);
        int secondNumber = rand.Next(1, 99);

        int[] result = new int[2];

        while (firstNumber % secondNumber != 0) // So that nbs always have no remainder (if not, float answers).
        {
            firstNumber = rand.Next(1, 99);
            secondNumber = rand.Next(1, 99);
        }
            
        result[0] = firstNumber;
        result[1] = secondNumber;
            
        return result;
    }

    public static string ValidateResult(string result)
    {
        while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
            // Prevents crash when input is not in a valid format.
        {
            Console.WriteLine("Your answer must be a valid integer");
            result = Console.ReadLine();
        }

        return result;
    }
    
    public static string GetUsername()
    {
        Console.WriteLine("Please type your name");
        string username = Console.ReadLine();
        // Added validation loop to prevent empty input
        while (string.IsNullOrEmpty(username))
            // Prevents crash when input is not in a valid format.
        {
            Console.WriteLine("Name can't be empty");
            username = Console.ReadLine();
        }
        return username;
    }
}