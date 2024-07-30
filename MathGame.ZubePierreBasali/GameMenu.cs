using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace MathGame
{
    internal class GameMenu
    {
        private static string? readResult;
        private static int option;
        private static int difficulty;
        private static Random random = new();
        private static int numberOfGames = 1;
        private static bool validOption;
        public static int gameOption()
        {
            DisplayMessage("Choose an otpion:\n");
            DisplayMessage("1. Play\n");
            DisplayMessage("2. Choose difficulty (default easy)\n");
            DisplayMessage("3. Choose number of consecutive games (default 5)\n");
            DisplayMessage("4. Choose game type (default random type)\n");
            DisplayMessage("5. Reset to default parameter\n");
            DisplayMessage("6. Show highest score for the session\n");
            DisplayMessage("exit. Exit the game");

            do
            {
                readResult = Console.ReadLine();
                validOption = int.TryParse(readResult, out option);
                if (validOption && option > 0 && option < 7)
                { return option; }
                else if(readResult != null && readResult.ToLower() == "exit") return option = 7;
            } while (readResult == null || readResult.ToLower() != "exit" || (option < 1 && option > 6));

            return option;
        }

        public static void SelectedOption(string option)
        {
            switch (option)
            {
                case "1":
                    break;
            }
        }

        public static int GameDifficulty()
        {
            DisplayMessage("Set difficulty of the game:");
            DisplayMessage("1. Easy");
            DisplayMessage("2. Normal");
            DisplayMessage("3. Hard");
            DisplayMessage("4. Very hard");
            do
            {
                readResult = Console.ReadLine();
                if (readResult != null) validOption = int.TryParse(readResult, out option);
            } while (readResult == null || !validOption || (option < 1 && option > 4));

            switch (option)
            {
                case 1: difficulty = 1; break;
                case 2: difficulty = 2; break;
                case 3: difficulty = 3; break;
                case 4: difficulty = 4; break;
            }
            return difficulty;
        }

        public static int NumberOfGames()
        {
            DisplayMessage("Coose a number of game(min: 1 ,max: 50)");
            do
            {
                readResult = Console.ReadLine();
                validOption = int.TryParse(readResult, out numberOfGames);
                if (validOption && readResult != null && numberOfGames < 51 && numberOfGames > 0)
                { return numberOfGames; }
            } while (numberOfGames > 0 && numberOfGames < 51 && !validOption);
            return numberOfGames = 1;
        }

        public static int GameType()
        {
            {
                DisplayMessage("Choose an option:");
                DisplayMessage("1. Random");
                DisplayMessage("2. Select for every game");
                DisplayMessage("3. Set to one type of game");
                do
                {
                    readResult = Console.ReadLine();
                    validOption = int.TryParse(readResult, out option);
                } while (readResult != null && !validOption || (option < 1 || option > 3));
                return option;
            }
        }
        public static void LaunchGame(int option, int difficulty = 1, int gameType = 1, int numberOfGames = 5)
        {
            Games.score = 0;

            if (gameType == 3)
            {
                DisplayMessage("Select a game type:");
                DisplayMessage("1. Addition");
                DisplayMessage("2. Subtraction");
                DisplayMessage("3. Multiplication");
                DisplayMessage("4. Division");

                do
                {
                    readResult = Console.ReadLine();
                    validOption = int.TryParse(readResult, out option);
                } while (readResult == null || !validOption || (option < 1 || option > 4));
            }

            do
            {
                if (gameType == 1)
                {
                    option = random.Next(1, 5);
                }
                if (gameType == 2)
                {
                    DisplayMessage("Select a game type:");
                    DisplayMessage("1. Addition");
                    DisplayMessage("2. Subtraction");
                    DisplayMessage("3. Multiplication");
                    DisplayMessage("4. Division");

                    do
                    {
                        readResult = Console.ReadLine();
                        validOption = int.TryParse(readResult, out option);
                    } while (readResult == null || !validOption || (option < 1 || option > 4));
                }

                switch (option)
                {
                    case 1:
                        Games.Addition(random, difficulty);
                        break;
                    case 2:
                        Games.Subtracion(random, difficulty);
                        break;
                    case 3:
                        Games.Multiplication(random, difficulty);
                        break;
                    case 4:
                        Games.Division(random, difficulty);
                        break;
                }
                numberOfGames--;
            } while (numberOfGames > 0);

            DisplayMessage($"Your score is: {Games.score}");
            Games.HighestScore = Games.score > Games.HighestScore ? Games.score : Games.HighestScore;
        }

        public static bool Replay()
        {
            DisplayMessage("Do you want to replay? Y(yes) N(no)");

            do
            {
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    if (readResult.ToLower() == "y") return true;
                    if (readResult.ToLower() == "n") return false;
                }
            } while (readResult == null || readResult.ToLower() != "n" || readResult.ToLower() != "y");
            return false;
        }

        public static void DisplayMessage(string message)
        {

            string output = "";

            foreach (char letter in message)
            {
                output += letter;
                Console.Write($"\r{output}");
                Thread.Sleep(10);
            }
            Console.WriteLine();
        }
    }
}