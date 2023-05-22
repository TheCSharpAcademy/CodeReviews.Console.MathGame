namespace firstAppCalculator;

internal class Menu
{
    GameEngine gamesClass = new();

    internal void ShowMenu(string name, DateTime date)
    {
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine($"Hello {name}. It's {date}. This is your math's game. That's great that you're working on improving yourself");
        Console.WriteLine("\n");

        var isGameOn = true;
        string difficultySelected = null;

        do
        {
            Console.Clear();
            Console.WriteLine(@$"
What game would you like to play today? Choose from the options below:
V - View Previous Games
A - Addition
S - Subtraction
M - Multiplication
D - Division
R - Random operators
Q - Quit the program");
            Console.WriteLine("---------------------------------------------");
            var gameSelected = Console.ReadLine();
            Console.Clear();

            switch (gameSelected.Trim().ToLower()) {
                case "a":
                case "m":
                case "d":
                case "s":
                case "r":
                   Console.WriteLine(@"
Game chosen, please chose your difficulty (enter the number please):
1 - Easy
2 - Medium
3 - Hard
");
                   difficultySelected = Console.ReadLine();
                    break;
                default:
                    break;
        }

            switch (gameSelected.Trim().ToLower())
            {
                case "v":
                    Helpers.PrintGames();
                    break;
                case "a":
                    gamesClass.AdditionGame("Addition game", difficultySelected);
                    break;
                case "s":
                    gamesClass.SubtractionGame("Subtraction game", difficultySelected);
                    break;
                case "m":
                    gamesClass.MultiplicationGame("Multiplication game", difficultySelected);
                    break;
                case "d":
                    gamesClass.DivisionGame("Division game",difficultySelected);
                    break;
                case "q":
                    Console.WriteLine("Goodbye");
                    isGameOn = false;
                    break;
                case "r":
                    gamesClass.RandomGame("Random Game", difficultySelected);
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        } while (isGameOn);
    }
}