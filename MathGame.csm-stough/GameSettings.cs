using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    internal class GameSettings
    {

        public struct Difficulty
        {
            public int min;
            public int max;
            public string name;

            public Difficulty(int min, int max, string name)
            {
                this.min = min;
                this.max = max;
                this.name = name;
            }
        }

        public static Difficulty EASY = new Difficulty(1, 10, "Easy");
        public static Difficulty MEDIUM = new Difficulty(1, 100, "Medium");
        public static Difficulty HARD = new Difficulty(1, 1000, "Hard");

        private static Difficulty currentDifficulty = EASY;
        private static int currentRounds = 5;

        public static void ApplySettings()
        {
            Menu settingsMenu = new Menu($"Current difficulty is {currentDifficulty.name}, and current game length is {currentRounds} rounds.\nPlease select a new difficulty level");
            settingsMenu.AddOption("E", "Easy (values from 1 to 10)", () => { currentDifficulty = EASY; });
            settingsMenu.AddOption("M", "Medium (values from 1 to 100)", () => { currentDifficulty = MEDIUM; });
            settingsMenu.AddOption("H", "Hard (values from 1 to 1000)", () => { currentDifficulty = HARD; });

            Console.Clear();

            Console.WriteLine(settingsMenu.GetMenuText());

            settingsMenu.SelectOption(Console.ReadLine());

            Console.Clear();

            Console.WriteLine("Please enter the number of rounds per game:");

            currentRounds = GetInt();
        }

        private static int GetInt()
        {
            string answer = Console.ReadLine();
            int answerInt = 0;

            while (!int.TryParse(answer, out answerInt))
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.WriteLine("Invalid input, please enter a number...");
                answer = Console.ReadLine();
            }

            return answerInt;
        }

        public static Difficulty GetDifficulty()
        {
            return currentDifficulty;
        }

        public static int GetRoundsLength()
        {
            return currentRounds;
        }
    }
}
