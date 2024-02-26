using MathGamer.Models;
using static MathGamer.Models.Game;

namespace MathGamer;
internal class Helpers
{
    static List<Game> games = new List<Game>();

    public static void AddToHistory(int gameScore, GameType typeName)
    {
        games.Add(new Game
        {
            Date = DateTime.Now,
            Score = gameScore,
            Type = typeName
        });
    }

    public static int[] GetDivisionNumbers()
    {
        Random random = new Random();
        int firstNumber = random.Next(1, 99);
        int secondNumber = random.Next(1, 99);
        int[] result = new int[2];

        while (firstNumber % secondNumber != 0)
        {
            firstNumber = random.Next(1, 99);
            secondNumber = random.Next(1, 99);
        }

        result[0] = firstNumber;
        result[1] = secondNumber;

        return result;
    }

    public static void GetGames()
    {
        var gamesToPrint = games.OrderByDescending(x => x.Score).ToList();
        Console.Clear();
        Console.WriteLine("Games History");
        Console.WriteLine("------------------------------");
        foreach (Game game in gamesToPrint)
        {
            Console.WriteLine(game);
        }
        Console.WriteLine("------------------------------");
        Console.WriteLine("Press ENTER to retun...");
        Console.ReadLine();
        Console.Clear();
    }

    public static string? ValidateResult(string result)
    {
        while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
        {
            Console.WriteLine("This is not a valid number...");
            result = Console.ReadLine();
        }
        return result;
    }

    public static string? GetName()
    {
        Console.WriteLine("Enter your name, please...");
        string name = Console.ReadLine();

        while(string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Your name can't be empty");
            name = Console.ReadLine();
        }
        Console.Clear();
        return name;
    }

    public static void PrintMenu(string name, string[] options, int selectedIndex)
    {
        Console.WriteLine(Figgle.FiggleFonts.Ogre.Render("Math Game"));
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine($"Hello, {name}, it's {DateTime.Now}");
        Console.WriteLine();
        Console.WriteLine($@"What game would you like to play today?");
        for (int i = 0; i < options.Length; i++)
        {

            if (i == selectedIndex)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;



            }
            Console.WriteLine($"<<{options[i]}>>");

        }
        Console.ResetColor();
        Console.WriteLine("----------------------------------------------------");

    }

    public static int MenuRun(string name, string[] options, int selectedIndex)
    {
        ConsoleKey keypressed;
        do
        {
            
            Helpers.PrintMenu(name, options, selectedIndex);
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            keypressed = keyInfo.Key;

            Console.Clear();
            if (selectedIndex>0)
            {
                
                if (keypressed == ConsoleKey.UpArrow) { 
                    selectedIndex -= 1; 
                }
            }
            if (selectedIndex <5)
            {
                if (keypressed == ConsoleKey.DownArrow)
                {
                    selectedIndex += 1;
                }
            }
        }
        while (keypressed != ConsoleKey.Enter);

        return selectedIndex;
    }
}
