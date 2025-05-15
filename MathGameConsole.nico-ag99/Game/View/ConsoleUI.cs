using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.View
{
    internal class ConsoleUI
    {
        public static void ShowPlayerNamePrompt()
        {
            Console.WriteLine("+----------------------+");
            Console.WriteLine("|       MATH GAME      |");
            Console.WriteLine("+----------------------+");
            Console.WriteLine("+----------------------+");
            Console.WriteLine("|  Please enter your   |");
            Console.WriteLine("|     player name.     |");
            Console.WriteLine("| Maximum 8 characters |");
            Console.WriteLine("+----------------------+");
            Console.Write("\n[ Name player ]: ");
        }
        public static void ShowMainMenuMessage()
        {
            Console.Clear();
            Console.WriteLine("+--------------------+");
            Console.WriteLine("|      MATH GAME     |");
            Console.WriteLine("+--------------------+");
            Console.WriteLine("+--------------------+");
            Console.WriteLine("|  1 - Play Game.    |");
            Console.WriteLine("|  2 - Game History. |");
            Console.WriteLine("|  3 - Difficulty.   |");
            Console.WriteLine("|  4 - New Player.   |");
            Console.WriteLine("|  0 - Exit.         |");
            Console.WriteLine("+--------------------+");
            Console.Write("\n[ Enter an option ]: ");
        }
        public static void ShowGameOptionsMessage()
        {
            Console.Clear();
            Console.WriteLine("+---------------------------------+");
            Console.WriteLine("|          Game Selection         |");
            Console.WriteLine("+---------------------------------+");
            Console.WriteLine("+---------------------------------+");
            Console.WriteLine("| Choose a mathematical operation |");
            Console.WriteLine("|         to start playing.       |");
            Console.WriteLine("+---------------------------------+");
            Console.WriteLine("    +-------------------------+");
            Console.WriteLine("    |  1 - Addition.          |");
            Console.WriteLine("    |  2 - Subtraction.       |");
            Console.WriteLine("    |  3 - Multiplication.    |");
            Console.WriteLine("    |  4 - Division.          |");
            Console.WriteLine("    |  5 - Random Mode.       |");
            Console.WriteLine("    |  0 - Back to main menu. |");
            Console.WriteLine("    +-------------------------+");
            Console.Write("\n       [ Enter an option ]: ");
        }
        public static void ShowMathQuest(char sign, int num1, int num2, int score) 
        {
            Console.Clear();
            Console.Write($"[   {num1} {sign} {num2}   ]               [  Score: {score}  ]\n\n[ Answer ]: ");
        }
        public static void ShowRandomMessage(bool isCorrect, int random)
        {
            string[] correctMessages = { "Correct!", "Well done!", "Great!", "Nice!", "Perfect!", "Awesome!", "Nice job!" };
            string[] incorrectMessages = { "Incorrect!", "Try again!", "Wrong answer!", "Not quite!", "That's wrong!", "Keep trying!", "Nope!" };

            string[] messages = isCorrect ? correctMessages : incorrectMessages;

            Console.WriteLine($"\n[ {messages[random]} ]");
            Console.ReadKey();
        }
        public static void ShowDifficultyMainMessage()
        {
            Console.Clear();
            Console.WriteLine(" +-------------------------+");
            Console.WriteLine(" |       Difficulty        |");
            Console.WriteLine(" +-------------------------+");
            Console.WriteLine(" +-------------------------+");
            Console.WriteLine(" |  1 - Easy Mode.         |");
            Console.WriteLine(" |  2 - Medium Mode.       |");
            Console.WriteLine(" |  3 - Hard Mode.         |");
            Console.WriteLine(" |  0 - Back to main menu. |");
            Console.WriteLine(" +-------------------------+");
            Console.Write("\n[ Enter an option ]: ");
        }
        public static void ShowDifficultyChangeMessage(string difficultyMode)
        {
            Console.WriteLine("+---------------------+");
            Console.WriteLine("  Difficulty level");
            Console.WriteLine($"  changed to: {difficultyMode}.");
            Console.WriteLine("+---------------------+");
            Console.ReadKey();
        }
        public static void ShowGameHistoryMessage(string[] historyGames) 
        {
            Console.Clear();
            Console.WriteLine("+---------------------------------------------------------------------+");
            Console.WriteLine("|                           Game History                              |");
            Console.WriteLine("+---------------------------------------------------------------------+");
            Console.WriteLine("| Name     | Score | Difficulty | Date       | Time  | Type           |");
            Console.WriteLine("+---------------------------------------------------------------------+");

            if (historyGames.Length > 0)
            {
                foreach (string game in historyGames)
                {
                    Console.WriteLine(game);
                    Console.WriteLine("+---------------------------------------------------------------------+");
                }
            }
            else
            {
                Console.WriteLine("|                          No game records                            |");
                Console.WriteLine("+---------------------------------------------------------------------+");
            }
            Console.ReadKey();
        }
        public static void ShowFinishScoreMessage(string time, int score)
        {
            Console.Clear();
            Console.WriteLine("[     Party Finish    ]");
            Console.WriteLine($"[  Total Time: {time} (minutes:seconds)  ]");
            Console.WriteLine($"[  Finished Score: {score}  ]");
            Console.ReadKey();
        }
        public static void ShowChangePlayerMessage()
        {
            Console.Clear();
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("|        Add Player       |");
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("|  1 - New Player.        |");
            Console.WriteLine("|  0 - Back to main menu. |");
            Console.WriteLine("+-------------------------+");
            Console.Write("\n[ Enter an option ]: ");
        }
        public static void ShowErrorMessage() 
        {
            Console.Write("\n[ Incorrect Option ]");
            Console.ReadKey();
        }
    }
}
