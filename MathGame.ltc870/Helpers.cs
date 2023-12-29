namespace MathGame.ltc870
{
    internal static class Helpers
    {
        //@ Get operands method
        public static int[] GetOperands(char difficultyLevel, char gameType)
        {
            int topRange = 0;

            switch (difficultyLevel)
            {
                case 'e':
                    topRange = gameType == 'd' ? 99 : 9;
                    break;
                case 'm':
                    topRange = gameType == 'd' ? 999 : 99;
                    break;
                case 'h':
                    topRange = gameType == 'd' ? 9999 : 999;
                    break;
            }

            Random random = new Random();
            int num1 = random.Next(1, topRange);
            int num2 = random.Next(1, topRange);

            int[] operands = new int[2];

            while (num1 % num2 != 0)
            {
                num1 = random.Next(1, 9);
                num2 = random.Next(1, 9);
            }

            operands[0] = num1;
            operands[1] = num2;

            return operands;
        }

        //@ Get difficulty level methods
        public static char GetDifficultyLevel()
        {
            Console.WriteLine(@"Choose your difficulty level:
        E - Easy
        M - Medium
        H - Hard");

            char difficultyLevel = char.ToLower(Console.ReadKey().KeyChar);
            Console.WriteLine();
            char[] options = { 'e', 'm', 'h' };

            while (!options.Contains(difficultyLevel))
            {
                Console.WriteLine("Invalid option. Try again.");
                difficultyLevel = char.ToLower(Console.ReadKey().KeyChar);
            }
            return difficultyLevel;
        }

        //@ Get game history method
        public static List<string> gameHistory = new List<string>();

        public static void ViewScoreHistory()
        {
            foreach (string score in gameHistory)
            {
                Console.WriteLine(score);
            }
            Console.ReadLine();
            Console.Clear();
        }

        //@ Validate name method
        public static string ValidateName()
        {
            string name;
            bool isInputValid;

            do
            {
                name = Console.ReadLine();
                isInputValid = !string.IsNullOrEmpty(name);

                if (!isInputValid)
                {
                    Console.WriteLine("Please enter a valid name.");
                }
            } while (!isInputValid);
            return name;
        }

        //@ Validate menu input method
        public static char ValidateMenuInput()
        {
            char userInput;
            bool isInputValid;

            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                userInput = char.ToLower(keyInfo.KeyChar);

                isInputValid = userInput == 'a' || userInput == 's' || userInput == 'm' || userInput == 'd' || userInput == 'r' || userInput == 'v' || userInput == 'q';

                if (!isInputValid)
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }

            } while (!isInputValid);
            return userInput;
        }

        //@ Validate number to play method
        public static int ValidateNumToPlay()
        {
            int numToPlay;
            bool isInputValid;

            do
            {
                isInputValid = int.TryParse(Console.ReadLine(), out numToPlay);

                if (!isInputValid)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    isInputValid = false;
                }
                else if (numToPlay < 1)
                {
                    Console.WriteLine("Please enter a number greater than 0.");
                    isInputValid = false;
                }
                else if (numToPlay > 10)
                {
                    Console.WriteLine("Please enter a number less than 10.");
                    isInputValid = false;
                }
            } while (!isInputValid);
            return numToPlay;
        }

        //@ Validate answer input method
        public static int ValidateAnswerInput()
        {
            int answer;
            bool isInputValid;

            do
            {
                isInputValid = int.TryParse(Console.ReadLine(), out answer);

                if (!isInputValid)
                {
                    Console.WriteLine("Please enter a valid number.");
                    isInputValid = false;
                }
            } while (!isInputValid);
            return answer;
        }
    }
}
