using MathGame.Logic;
using MathGame.Utils;

namespace MathGame.Views
{
    public class Game
    {
        private readonly List<HistoryRecord> history = [];

        private readonly List<string> _options = ["Play a match", "View history"];
        private readonly string _title = "============MATH GAME============";
        private readonly string _instruction = "Enter the option: ";

        private readonly ContestConfigView _contestConfigView = new();
        private readonly ContestView _contestView = new();
        public void Start()
        {
            while (true)
            {
                Console.WriteLine(_title);
                ConsoleUtils.DisplayList(_options);
                Console.Write(_instruction);

                if (!ConsoleUtils.ReadOption(out int option, x => x > 0 && x <= _options.Count))
                {
                    Thread.Sleep(2000);
                    continue;
                }

                if (option == 1)
                {
                    Contest contest = _contestConfigView.GetContest();
                    _contestView.Display(history, contest);
                } else
                {
                    History view = new History();
                    view.Display(history);
                }

                Console.Clear();
            }
        }
    }
}
