using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathGame.Models;
using Spectre.Console;
using static MathGame.Enums;

namespace MathGame
{
    internal class UserInterface : IUserInterface
    {
        internal void MainMenu()
        {
            bool exitGame = false;

            while (!exitGame)
            {
                displayHeader();

                bool historyCheck = MockDatabase.GameHistory.Count > 0;

                var optionChoice = AnsiConsole.Prompt(
                    new SelectionPrompt<MenuAction>()
                        .Title("[bold]Welcome to Math Game![/]")
                        .AddChoices(
                            Enum.GetValues<MenuAction>()
                                .Where(opt => opt != MenuAction.ShowHistory || historyCheck)
                        )
                );

                switch (optionChoice)
                {
                    case MenuAction.PlayGame:
                        Game selectedGame = GameSettings();
                        if (selectedGame is IGame playableGame)
                        {
                            bool playAgain;
                            do
                            {
                                displayHeader();
                                displayGameInfo(selectedGame);
                                playAgain = playableGame.PlayGame();
                            } while (playAgain);
                        }
                        break;
                    case MenuAction.About:
                        break;
                    case MenuAction.ShowHistory:
                        ShowGameHistory();
                        break;
                    case MenuAction.ExitGame:
                        exitGame = true;
                        break;
                }
            }
        }

        private Game GameSettings()
        {
            displayHeader();
            var difficulty = chooseDifficulty();
            return chooseGameType(difficulty);
        }

        private Difficulty chooseDifficulty()
        {
            var difficultyChoice = AnsiConsole.Prompt(
                new SelectionPrompt<Difficulty>()
                    .Title("Choose difficulty:")
                    .AddChoices(Enum.GetValues<Difficulty>())
                    .UseConverter(difficulty =>
                    {
                        return difficulty switch
                        {
                            Difficulty.Easy => "[green]Easy[/]",
                            Difficulty.Medium => "[orange3]Medium[/]",
                            Difficulty.Hard => "[red]Hard[/]",
                            _ => difficulty.ToString(),
                        };
                    })
            );

            return difficultyChoice;
        }

        private Game chooseGameType(Difficulty difficulty)
        {
            var gameTypeChoice = AnsiConsole.Prompt(
                new SelectionPrompt<GameType>()
                    .Title("Choose game mode:")
                    .AddChoices(Enum.GetValues<GameType>())
            );

            if (gameTypeChoice == GameType.Training)
            {
                var operatorChoice = AnsiConsole.Prompt(
                    new SelectionPrompt<Operator>()
                        .Title("Choose operator:")
                        .AddChoices(Enum.GetValues<Operator>())
                );
                return new TrainingGame(difficulty, operatorChoice, this);
                //Launch TrainingGame
            }
            else
            {
                //Launch RandomGame
                return new RandomGame(difficulty, this);
            }
        }

        private void displayHeader()
        {
            Console.Clear();

            AnsiConsole.Write(new FigletText("MathGame").Centered().Color(Color.Red));
        }

        private void displayGameInfo(Game game)
        {
            var rule = new Rule(
                $"[blue]{game.GetType().Name}[/] - [bold]{game.difficulty.ToString()}[/]"
            ).Centered();
            rule.Style = Style.Parse("red dim");

            AnsiConsole.Write(rule);
        }

        private void ShowGameHistory()
        {
            var table = new Table().Centered();
            table.Border(TableBorder.Rounded);

            table.AddColumn("[yellow]Game Type[/]");
            table.AddColumn("[yellow]Difficulty[/]");
            table.AddColumn("[yellow]Score[/]");
            table.AddColumn("[yellow]Rating[/]");
            table.AddColumn("[yellow]Duration[/]");

            foreach (var game in MockDatabase.GameHistory)
            {
                table.AddRow(
                    game.GetType().Name,
                    $"[yellow]{game.difficulty}[/]",
                    $"[cyan]{game.score}[/]",
                    $"[cyan]{game.rating}[/]",
                    $"[green]{game.DisplayDuration()}[/]"
                );
            }

            AnsiConsole.Write(table);
            WriteInfo("Press any key to continue", "blue");
            Console.ReadKey();
        }

        public int PromptInt(string message, string color)
        {
            int userAnswer = AnsiConsole.Prompt(new TextPrompt<int>($"[{color}]{message} ?[/]"));
            return userAnswer;
        }

        public void WriteSuccess()
        {
            AnsiConsole.MarkupLine("[green]Correct![/]");
        }

        public void WriteError()
        {
            AnsiConsole.MarkupLine("[red]Incorrect![/]");
        }

        public void WriteInfo(string message, string color)
        {
            AnsiConsole.MarkupLine($"[{color}]{message}[/]");
        }

        public bool Confirm(string message)
        {
            return AnsiConsole.Confirm(message);
        }

        public void displayGameResult(string message, string color, string duration)
        {
            var rule = new Rule($"[{color}]{message}[/] - [bold]{duration}[/]").Centered();
            rule.Style = Style.Parse("red dim");
            AnsiConsole.Write(rule);
        }
    }
}
