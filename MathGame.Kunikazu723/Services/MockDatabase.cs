using MathGameRecap.Common;
using MathGameRecap.Models;
using Spectre.Console;

namespace MathGameRecap.Services
{
    internal class MockDatabase
    {
        public static List<GameData> Database { get; private set; } = new();
        private static int LastId { get; set; } = 0;
        public static void AddGame(GameData game)
        {
            if (Database.Any(gameData => gameData.Id == game.Id))
            {
                throw new ArgumentException();
            }

            var date = DateTime.Now;

            Database.Add(game);

            LastId = game.Id;
        }

        public static int GetNextId() => LastId + 1;

        public static void ViewGamesHistory()
        {
            if (Database.Count == 0)
            {
                AnsiConsole.MarkupLine("The [bold blue]History[/] of games is [bold red]Empty[/]");
                Helpers.Intermission();
                return;
            }

            var table = new Table();
            table.AddColumns(new string[] {
                "Id", "Type", "Date", "Score", "Duration(sec)", "Difficulty"
            });

            DateTime yesterday = DateTime.Now - TimeSpan.FromDays(1); 

            foreach (GameData gameData in Database.Where(game => game.Date >= yesterday))
            {
                var id = gameData.Id.ToString();
                var type = gameData.Type.ToString();
                var date = gameData.Date.ToString();
                var score = gameData.Score.ToString();
                var duration = gameData.Duration.TotalSeconds.ToString();
                
                table.AddRow(new string[] {
                    id, type, date, score, duration, gameData.Difficulty.ToString()
                });
            }

            AnsiConsole.Write(table);
            Helpers.Intermission();
        }
    }
}


