using MathGame.Utils;

namespace MathGame.Views
{
    public class ContestResults
    {
        public void Display(TimeSpan time, int points)
        {
            DisplayResults(points);
            Console.Write($"Your time is {time.ToMinutesSeconds()}");
            Thread.Sleep(2000);
        }
        private void DisplayResults(int points)
        {
            ConsoleColor color = points switch
            {
                >= 4 => ConsoleColor.Green,
                >= 2 => ConsoleColor.Yellow,
                _ => ConsoleColor.Red
            };

            ConsoleUtils.WriteLine($"You won {points} points", color);
        }
    }
}
