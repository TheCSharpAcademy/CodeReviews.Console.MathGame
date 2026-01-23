using MathGame.Logic;
using MathGame.Utils;

namespace MathGame.Views
{
    public class ContestTypeMenu
    {
        private readonly List<string> _options = ["Normal", "Random"];
        private readonly string _title = "Choose a mode of game";
        private readonly string _instruction = "Select the mode of game: ";
        public ContestType GetGameType()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(_title);
                ConsoleUtils.DisplayList(_options);
                Console.Write(_instruction);

                if (!ConsoleUtils.ReadOption(out int option, x => x > 0 && x <= _options.Count))
                {
                    Thread.Sleep(2000);
                    continue;
                }

                return option == 1
                    ? ContestType.Normal
                    : ContestType.Random;
            }
        }
    }
}
