using CodeReviews.Console.MathGame.Controllers;
using Spectre.Console;

namespace mathGame.qua9k.Models;

internal class Game
{
    readonly List<string> history = [];

    readonly Dictionary<Operator, string> operatorMap = new()
    {
        { Operator.Add, "+" },
        { Operator.Subtract, "-" },
        { Operator.Divide, "/" },
        { Operator.Multiply, "*" },
        { Operator.Random, "?" },
    };

    internal void Initialize()
    {
        bool keepPlaying = true;

        while (keepPlaying)
        {
            PrintController.Welcome();

            string? playerInput = Console.ReadLine();

            switch (playerInput!.ToLower())
            {
                case "p":
                    Play();
                    break;
                case "x":
                    keepPlaying = false;
                    break;
                case "h":
                    PrintController.PrintHistory(history);
                    break;
                default:
                    AnsiConsole.WriteLine("Your input was not understood. Please try again.");
                    break;
            }
        }

        AnsiConsole.WriteLine("Thank you for playing. Goodbye!");
    }

    internal void Play(int winningScore = 5, int losingScore = -3)
    {
        int playerScore = 0;

        PrintController.PresentRules(winningScore, losingScore);

        while (true)
        {
            AnsiConsole.Clear();

            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<Operator>()
                    .Title("Please choose one:")
                    .AddChoices(Enum.GetValues<Operator>())
            );

            int operand1 = Random.Shared.Next(0, 100);
            int operand2 = Random.Shared.Next(0, 100);

            if (choice == Operator.Random)
            {
                choice = GetRandomOperator(choice);
            }

            if (choice == Operator.Divide)
            {
                while (operand1 <= operand2 || operand1 % operand2 != 0)
                {
                    operand1 = Random.Shared.Next(0, 100);
                    operand2 = Random.Shared.Next(1, 100);
                }
            }

            string question = $"{operand1} {operatorMap[choice]} {operand2} = ";

            AnsiConsole.Write(question);

            string? playerAnswer = Console.ReadLine();

            while (!int.TryParse(playerAnswer, out int _))
            {
                AnsiConsole.WriteLine($"Your answer was not understood. Please try again.");
                PrintController.Pause();
                AnsiConsole.Clear();
                AnsiConsole.Write(question);
                playerAnswer = Console.ReadLine();
            }

            if (Convert.ToInt32(playerAnswer) == CalculateAnswer(choice, operand1, operand2))
            {
                playerScore += 1;
                AnsiConsole.MarkupLine($"[green]Correct![/]");
            }
            else
            {
                playerScore -= 1;
                AnsiConsole.MarkupLine($"[yellow]Incorrect...[/]");
            }

            AnsiConsole.WriteLine($"Your score: {playerScore}");

            if (GameOver(playerScore, winningScore, losingScore))
            {
                break;
            }
        }
    }

    internal bool GameOver(int playerScore, int winningScore, int losingScore)
    {
        bool isGameOver = false;

        if (playerScore >= winningScore)
        {
            isGameOver = true;
            history.Add("Win");
            AnsiConsole.MarkupLine($"[green]Congratulations. You won![/]");
        }

        if (playerScore <= losingScore)
        {
            isGameOver = true;
            history.Add("Loss");
            AnsiConsole.MarkupLine($"[red]You lost... :([/]");
        }

        PrintController.Pause();

        return isGameOver;
    }

    internal static int CalculateAnswer(Operator op, int operand1, int operand2)
    {
        return op switch
        {
            Operator.Add => operand1 + operand2,
            Operator.Subtract => operand1 - operand2,
            Operator.Divide => operand1 / operand2,
            Operator.Multiply => operand1 * operand2,
            _ => 0,
        };
    }

    internal static Operator GetRandomOperator(Operator choice)
    {
        Random random = new();

        while (choice == Operator.Random)
        {
            int i = random.Next(0, Enum.GetNames<Operator>().Length);
            choice = (Operator)i;
        }

        return choice;
    }
}
