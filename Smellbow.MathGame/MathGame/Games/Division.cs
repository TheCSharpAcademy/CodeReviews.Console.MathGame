using Spectre.Console;

namespace MathGame.Games;

internal static class Division
{
    public static int PlayDivision()
    {
        AnsiConsole.Clear();
        AnsiConsole.MarkupLine("[green]Welcome to the Division Game![/]");
        int score = 0;
        Random rand = new Random();
        for (int i = 0; i < 5; i++)
        {

            int divisor = rand.Next(1, 11); // Random divisor between 1 and 10
            int answer = rand.Next(0, 11); // Random answer between 0 and 10
            int dividend = divisor * answer; // Calculate the dividend to ensure a whole number result

            
            
            var userAnswer = AnsiConsole.Prompt(
                new TextPrompt<int>($"What is [yellow]{dividend} ÷ {divisor}[/]?")
                    .PromptStyle("green"));
            if (userAnswer == answer)
            {
                AnsiConsole.MarkupLine("[green]Correct![/]");
                score++;
            }
            else
            {
                AnsiConsole.MarkupLine($"[red]Incorrect! The correct answer was {answer}.[/]");
            }
        }
        AnsiConsole.MarkupLine($"[blue]Your final score is: {score}/5[/]");
        return score; // Return the score to the caller
    }


}
