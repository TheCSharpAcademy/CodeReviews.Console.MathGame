using Spectre.Console;

namespace MathGame.Games;

internal static class Multiplication
{
    public static int PlayMultiplication()
    {
        AnsiConsole.Clear();
        AnsiConsole.MarkupLine("[green]Welcome to the Multiplication Game![/]");

        int score = 0;
        Random rand = new Random();
        for (int i = 0; i < 5; i++)
        {
            int a = rand.Next(1, 11);
            int b = rand.Next(1, 11);
            int correctAnswer = a * b;
            var userAnswer = AnsiConsole.Prompt(
                new TextPrompt<int>($"What is [yellow]{a} x {b}[/]?")
                    .PromptStyle("green"));
            if (userAnswer == correctAnswer)
            {
                AnsiConsole.MarkupLine("[green]Correct![/]");
                score++;
            }
            else
            {
                AnsiConsole.MarkupLine($"[red]Incorrect! The correct answer was {correctAnswer}.[/]");
            }
        }
        AnsiConsole.MarkupLine($"[blue]Your final score is: {score}/5[/]");
        return score;
    }

}
