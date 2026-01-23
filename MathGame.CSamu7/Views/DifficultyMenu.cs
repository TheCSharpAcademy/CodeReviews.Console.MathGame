using MathGame.Utils;

namespace MathGame.Views
{
    public class DifficultyMenu
    {
        private readonly string _title = "Choose a difficulty";
        private readonly List<string> _options = ["Easy", "Medium", "Hard"];
        private readonly string _instruction = "Enter the difficulty: ";
        public Difficulty GetDifficulty()
        {
            while (true) {
                Console.Clear();

                Console.WriteLine(_title);
                ConsoleUtils.DisplayList(_options);
                Console.Write(_instruction);

                if (!ConsoleUtils.ReadOption(out int option, x => x > 0 && x <= _options.Count))
                {
                    Thread.Sleep(2000);
                    continue;
                }

                return option switch
                {
                    1 => Difficulty.Easy,
                    2 => Difficulty.Medium,
                    _ => Difficulty.Hard
                };
            }
        }
    }
    public enum Difficulty { Easy, Medium, Hard }
}
