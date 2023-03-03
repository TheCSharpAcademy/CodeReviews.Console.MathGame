namespace MathGame_
{
    internal class Helpers
    {
        internal static List<string> games = new List<string>();

        internal static string ValidateAns(string? answer)
        {
            while (string.IsNullOrEmpty(answer) || !Int32.TryParse(answer, out _))
            {
                Console.WriteLine("Invalid Input, Please Try Again..");
                answer = Console.ReadLine();
            }

            return answer;
        }

        internal static string ValidateMode(string? selection) 
        {
            

            while (string.IsNullOrEmpty(selection) || (!Int32.TryParse(selection, out _) && selection.ToLower() != "q"))
            {
                Console.WriteLine("Invalid selection, press [enter] to try again.");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Select a game mode: ");
                Console.WriteLine(@"||| 0 - History
||| 1 - Addition
||| 2 - Subtraction
||| 3 - Multiplication
||| 4 - Division
||| Q - Quit Program");
                Console.WriteLine("-------------------------");
                selection = Console.ReadLine();
            }

            return selection;
        }

        internal static string ValidateDifficulty(string? selection)
        {
            while (selection?.Trim() != "1" && selection?.Trim() != "2" && selection?.Trim() != "3")
            {
                Console.WriteLine("Invalid selection, press [enter] to try again.");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Select Difficult:\t1 - Easy\t2 - Medium\t3 - Hard");
                selection = Console.ReadLine();
            }

            return selection.Trim();
        }

        internal static string ValidateQuestions(string? selection)
        {
            while (selection?.Trim() != "1" && selection?.Trim() != "3" && selection?.Trim() != "5")
            {
                Console.WriteLine("Invalid selection, press [enter] to try again.");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Select Number of Questions:\t[1]\t[3]\t[5]");
                selection = Console.ReadLine();
            }

            return selection.Trim();
        }

        internal static void AddToHistory(int score, string gameType, long ts)
        {
            games.Add($"{gameType.PadRight(43)} - {score}pts ({ts}s)");
        }

        internal static void PrintGames()
        {
            Console.Clear();
            Console.WriteLine($"Game History");
            Console.WriteLine("-------------------------");

            foreach (var game in games)
            {
                Console.WriteLine(game);
            }

            Console.WriteLine("-------------------------");
            Console.WriteLine("Press [enter] to return to Main Menu..");
            Console.ReadLine();
        }

        internal static int[] GetDivisionNumbers(int difficulty)
        {
            Random random = new Random();
            var num1 = random.Next(0, 101 + difficulty);
            var num2 = random.Next(1, 101 + difficulty);

            int[] result = new int[2];

            while (num1 % num2 != 0)
            {
                num1 = random.Next(0, 101 + difficulty);
                num2 = random.Next(1, 101 + difficulty);
            }

            result[0] = num1;
            result[1] = num2;

            return result;
        }
    }
}
