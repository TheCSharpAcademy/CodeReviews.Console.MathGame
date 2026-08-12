using MathGameRecap.Common;
using MathGameRecap.Services;
using Spectre.Console;
using System.Diagnostics;
using static MathGameRecap.Common.Enums;

namespace MathGameRecap.Models
{
    internal abstract class BaseGame
    {
        protected static int Rounds { get; } = 5;

        internal abstract GameType Type { get; }

        internal abstract int PerformOperation(int a, int b);
        internal abstract (int, int) GenerateOperands(Difficulty difficulty);


        public GameData RunGame(Difficulty chosenDifficulty)
        {
            int score = 0;
            GameType gameDataType = Type; // Type might change if it's a RandomGame
            Stopwatch stopwatch = new();

            for (int i = 0; i < Rounds; i++)
            {
                AnsiConsole.MarkupLine(Helpers.RoundHeader("Addition Game", i + 1));

                (int firstNumber, int secondNumber) = GenerateOperands(chosenDifficulty);

                int result = PerformOperation(firstNumber, secondNumber);

                stopwatch.Start();
                int userResult = AnsiConsole.Ask<int>($"[blue]{firstNumber}[/] [cyan]{Enums.GameTypeToSymbol(Type)}[/] [blue]{secondNumber}[/] [cyan]=[/] ");
                stopwatch.Stop();

                if (Helpers.IsResultCorrect(userResult, result)) score++;

                Helpers.Intermission();
            }

            Helpers.EndGameMessage(score);

            TimeSpan gameDuration = stopwatch.Elapsed;

            return new GameData(
                id: MockDatabase.GetNextId(),
                score: score,
                date: DateTime.Now,
                operation: gameDataType,
                duration: gameDuration,
                difficulty: chosenDifficulty
                );
        }
    }
}
