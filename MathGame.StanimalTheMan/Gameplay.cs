using MathGame.StanimalTheMan.Models;

namespace MathGame.StanimalTheMan;

internal class Gameplay
{
    private static List<Game> games = new List<Game>();
    internal static void PlayAdditionGame()
    {
        var rand = new Random();
        int gameScore = 0;
        int userSumInput;
        for (int i = 0; i < 5; i++)
        {
            int firstNumber = rand.Next(1, 9);
            int secondNumber = rand.Next(1, 9);
            Console.WriteLine($"{firstNumber} + {secondNumber}");

            do
            {
                Console.WriteLine("Please enter the sum (numbers only)");
            } while (!int.TryParse(Console.ReadLine(), out userSumInput));

            if (userSumInput == firstNumber + secondNumber)
            {
                gameScore++;
                Console.WriteLine("Your answer was correct!  Press any key to continue...");      
            }
            else
            {
                Console.WriteLine("Your answer was incorrect.  Press any key to continue...");
            }
            Console.ReadLine();
            Console.Clear();
        }

        Console.WriteLine($"Game over.  You got {gameScore} points.");
        games.Add(new Game
        {
            Score = gameScore,
            Date = DateTime.Now,
            Type = GameType.Addition
        });

        Console.WriteLine("Press any key to return to menu");
        Console.ReadLine();
        Console.Clear();
        Menu.ShowMenu();
    }

    internal static void PlaySubtractionGame()
    {
        var rand = new Random();
        int gameScore = 0;
        int userDifferenceInput;
        for (int i = 0; i < 5; i++)
        {
            int firstNumber = rand.Next(1, 9);
            int secondNumber = rand.Next(1, 9);
            Console.WriteLine($"{firstNumber} - {secondNumber}");

            do
            {
                Console.WriteLine("Please enter the difference (numbers only)");
            } while (!int.TryParse(Console.ReadLine(), out userDifferenceInput));

            if (userDifferenceInput == firstNumber - secondNumber)
            {
                gameScore++;
                Console.WriteLine("Your answer was correct!  Press any key to continue...");
            }else
            {
                Console.WriteLine("Your answer was incorrect.  Press any key to continue...");
            }
            Console.ReadLine();
            Console.Clear();
        }

        Console.WriteLine($"Game over.  You got {gameScore} points.");
        games.Add(new Game
        {
            Score = gameScore,
            Date = DateTime.Now,
            Type = GameType.Subtraction
        });

        Console.WriteLine("Press any key to return to menu");
        Console.ReadLine();
        Console.Clear();
        Menu.ShowMenu();
    }

    internal static void PlayMultiplicationGame()
    {
        var rand = new Random();
        int gameScore = 0;
        int userProductInput;
        for (int i = 0; i < 5; i++)
        {
            int firstNumber = rand.Next(1, 9);
            int secondNumber = rand.Next(1, 9);
            Console.WriteLine($"{firstNumber} * {secondNumber}");

            do
            {
                Console.WriteLine("Please enter the product (numbers only)");
            } while (!int.TryParse(Console.ReadLine(), out userProductInput));

            if (userProductInput == firstNumber * secondNumber)
            {
                gameScore++;
                Console.WriteLine("Your answer was correct!  Press any key to continue...");
            }
            else
            {
                Console.WriteLine("Your answer was incorrect.  Press any key to continue...");
            }
            Console.ReadLine();
            Console.Clear();
        }

        Console.WriteLine($"Game over.  You got {gameScore} points.");
        games.Add(new Game
        {
            Score = gameScore,
            Date = DateTime.Now,
            Type = GameType.Multiplication
        });

        Console.WriteLine("Press any key to return to menu");
        Console.ReadLine();
        Console.Clear();
        Menu.ShowMenu();
    }

    internal static void PlayDivisionGame()
    {
        var rand = new Random();
        int gameScore = 0;
        int userDivisionInput;
        for (int i = 0; i < 5; i++)
        {
            int firstNumber = rand.Next(1, 100);
            int secondNumber = rand.Next(1, 100);

            while (firstNumber % secondNumber != 0)
            {
                firstNumber = rand.Next(1, 100);
                secondNumber = rand.Next(1, 100);
            }

            Console.WriteLine($"{firstNumber} / {secondNumber}");

            do
            {
                Console.WriteLine("Please enter the product (numbers only)");
            } while (!int.TryParse(Console.ReadLine(), out userDivisionInput));

            if (userDivisionInput == firstNumber / secondNumber)
            {
                gameScore++;
                Console.WriteLine("Your answer was correct!  Press any key to continue...");
            }
            else
            {
                Console.WriteLine("Your answer was incorrect.  Press any key to continue...");
            }
            Console.ReadLine();
            Console.Clear();
        }

        Console.WriteLine($"Game over.  You got {gameScore} points.");
        games.Add(new Game
        {
            Score = gameScore,
            Date = DateTime.Now,
            Type = GameType.Division
        });

        Console.WriteLine("Press any key to return to menu");
        Console.ReadLine();
        Console.Clear();
        Menu.ShowMenu();
    }

    internal static void ViewGameHistory()
    {
        Console.WriteLine("Date\t\t\tScore\tGameType");
        foreach (Game game in games)
        {
            Console.WriteLine($"{game.Date}\t{game.Score}\t{game.Type}");
        }
        Console.WriteLine("Press any key to return to menu");
        Console.ReadLine();
        Console.Clear();
        Menu.ShowMenu();
    }
}
