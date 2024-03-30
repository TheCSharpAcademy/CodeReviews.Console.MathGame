namespace CSharpAcademy_MathsGame;

internal class Menu
{
    private GameEngine engine = new();
    internal void ShowMenu(string? name, DateTime date)
    {
        bool isGameOn = true;

        Console.WriteLine("============================================================================================");
        Console.WriteLine($"Hello {name}. It's {date}. This is the CSharpAcademy Maths game challenge.");

        do
        {
            Console.WriteLine($"""
                               Which game would you like to play. Select from the options below:
                               A - Addition
                               S - Subtraction
                               M - Multiplication
                               D - Division
                               V - View previous scores
                               Q - Quit the program
                               """);
            Console.WriteLine(
                "============================================================================================");

            string? gameSelected = Console.ReadLine();

            switch (gameSelected?.Trim().ToLower())
            {
                case "a":
                    engine.AdditionGame();
                    break;
                case "s":
                    engine.SubtractionGame();
                    break;
                case "m":
                    engine.MultiplicationGame();
                    break;
                case "d":
                    engine.DivisionGame();
                    break;
                case "v":
                    Helpers.ShowScores();
                    break;
                case "q":
                    Console.WriteLine("Game over. Goodbye.");
                    isGameOn = false;
                    break;
                default:
                    Console.WriteLine("Invalid response");
                    Environment.Exit(1);
                    break;
            }
        } while (isGameOn);
    }
}