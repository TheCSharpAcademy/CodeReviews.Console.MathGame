using MathGame.Logic;
using MathGame.Utils;

namespace MathGame.Views
{
    public class History
    {
        private readonly string _title = "History";
        public void Display(List<HistoryRecord> history)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(_title);

                if (history.Count == 0)
                {
                    DisplayNotGames();
                } else
                {
                    DisplayPreviousGames(history);
                }

                Console.WriteLine("Press any key to exit.");
                string? exit = Console.ReadLine();

                if (exit is not null) break;
            }
        }
        private void DisplayPreviousGames(List<HistoryRecord> history)
        {
            for (int i = 0; i < history.Count; i++)
            {
                Console.WriteLine($" Game {i + 1}: " +
                    $"{history[i].Difficulty} ({history[i].Operation}). {history[i].Points} points. " +
                    $"{history[i].Time.ToMinutesSeconds()}");
            }
        }
        private void DisplayNotGames()
        {
            Console.WriteLine("There aren't previous matches");
        }
    }
}
