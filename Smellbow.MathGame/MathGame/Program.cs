using Spectre.Console;
using MathGame.Games;
using MathGame.Models;
internal class Program
{
    private static void Main(string[] args)
    {
        ShowMenu();
    }

    public static void ShowMenu()
    {

        List<GameResult>gameHistory = new List<GameResult>();



        while (true)
        {
            //using spectre console, i dont fully understand all its functions but i know it can be used to make the console look better, so i will use it here
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine("[green]Hello, Welcome to Math Game![/]");
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[green]Select an operation to play:[/]")
                    .AddChoices(new[] {
                    "Addition",
                    "Subtraction",
                    "Multiplication",
                    "Division",
                    "History",
                    "Exit"
                    }));
            Console.WriteLine($"Your choice: {(choice != null ? choice : "None yet!")}");


            switch (choice)
            {
                case "Addition":
                    Console.WriteLine("Starting Addition Game...");
                    int additionScore = Addition.PlayAddition();
                    gameHistory.Add(new GameResult // we create a new gameresult object from the score and other info after a game.
                    {
                        Score = additionScore,
                        PlayedAt = DateTime.Now,
                        Operation = "Addition",
                        QuestionCount = 5
                    });
                    break;
                case "Subtraction":
                    Console.WriteLine("Starting Subtraction Game...");
                    int subtractionScore = Subtraction.PlaySubtraction();
                    gameHistory.Add(new GameResult
                    {
                        Score = subtractionScore,
                        PlayedAt = DateTime.Now,
                        Operation = "Subtraction",
                        QuestionCount = 5
                    });
                    break;
                case "Multiplication":
                    Console.WriteLine("Starting Multiplication Game...");
                    int multiplicationScore = Multiplication.PlayMultiplication();
                    gameHistory.Add(new GameResult
                    {
                        Score = multiplicationScore,
                        PlayedAt = DateTime.Now,
                        Operation = "Multiplication",
                        QuestionCount = 5
                    });
                    break;
                case "Division":
                    Console.WriteLine("Starting Division Game...");
                    int divisionScore = Division.PlayDivision();
                    gameHistory.Add(new GameResult
                    {
                        Score = divisionScore,
                        PlayedAt = DateTime.Now,
                        Operation = "Division",
                        QuestionCount = 5
                    });
                    break;
                case "History":
                    History.ShowHistory(gameHistory);
                    break;
                case "Exit":
                    Console.WriteLine("Exiting Math Game...");
                    return;
            }
            AnsiConsole.MarkupLine("[grey]Press any key to return to the menu...[/]");
            Console.ReadKey(true); //true to not show the key pressed or make a beep sound??
        }
    }

    
}