using MathGame.MartinL_no.Models;

namespace MathGame.MartinL_no
{
	internal class Helpers
	{
        internal static List<GameResult> GetDummyGameResults()
        {
            return new List<GameResult>
            {
                new GameResult(DateTime.Now.AddDays(1), new TimeSpan(0, 15, 0), GameType.Addition, Difficulty.Easy, 6, 5),
                new GameResult(DateTime.Now.AddDays(2), new TimeSpan(0, 15, 0), GameType.Multiplication, Difficulty.Medium, 6, 4),
                new GameResult(DateTime.Now.AddDays(3), new TimeSpan(0, 15, 0), GameType.Division, Difficulty.Easy, 6, 4),
                new GameResult(DateTime.Now.AddDays(4), new TimeSpan(0, 15, 0), GameType.Subtraction,  Difficulty.Hard, 5, 3),
                new GameResult(DateTime.Now.AddDays(5), new TimeSpan(0, 15, 0), GameType.Addition, Difficulty.Medium, 7, 1),
                new GameResult(DateTime.Now.AddDays(6), new TimeSpan(0, 15, 0), GameType.Multiplication, Difficulty.Easy, 4, 2),
                new GameResult(DateTime.Now.AddDays(7), new TimeSpan(0, 15, 0), GameType.Division, Difficulty.Hard, 3, 3),
                new GameResult(DateTime.Now.AddDays(8), new TimeSpan(0, 15, 0), GameType.Subtraction, Difficulty.Medium, 6, 4),
                new GameResult(DateTime.Now.AddDays(9), new TimeSpan(0, 15, 0), GameType.Addition, Difficulty.Easy, 8, 4),
                new GameResult(DateTime.Now.AddDays(10), new TimeSpan(0, 15, 0), GameType.Multiplication, Difficulty.Easy, 2, 1),
                new GameResult(DateTime.Now.AddDays(11), new TimeSpan(0, 15, 0), GameType.Subtraction, Difficulty.Hard, 3, 0),
                new GameResult(DateTime.Now.AddDays(12), new TimeSpan(0, 15, 0), GameType.Division, Difficulty.Hard, 5, 2),
                new GameResult(DateTime.Now.AddDays(13), new TimeSpan(0, 15, 0), GameType.Subtraction, Difficulty.Medium, 8, 5),
            };
        }
    }
}

