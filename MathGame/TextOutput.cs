using System.Diagnostics;

namespace MathGame
{
    public class TextOutput
    {
        public static int Rounds { get; set; }
        public static int UserResult { get; set; }
        public static int CorrectResult { get; set; }
        public static string Time { get; set; }
        public static char Operator { get; set; }
        public static string Operation { get; set; }
        public static string Win { get; set; }

        public static int StartGame(string operation)
        {
            Operation = operation;
            Console.WriteLine("How many games would you like to play?");

            Rounds = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            return Rounds;
            
        }
        public static (int, int, string, string) TimedCalculation(string operation)
        {
            Console.Clear();
            Operation = operation;
            var timer = new Stopwatch();

            switch (operation)
            {
                case "Addition":
                    CorrectResult = Difficulty.Numbers[0] + Difficulty.Numbers[1];
                    Operator = '+';
                    break;
                case "Substraction":
                    CorrectResult = Difficulty.Numbers[0] - Difficulty.Numbers[1];
                    Operator = '-';
                    break;
                case "Multiplication":
                    CorrectResult = Difficulty.Numbers[0] * Difficulty.Numbers[1];
                    Operator = 'x';
                    break;
                case "Divison":
                    CorrectResult = Difficulty.Numbers[0] - Difficulty.Numbers[1];
                    Operator = '/';
                    break;
            }            

            timer.Start();
            Console.WriteLine($"What is the result of {Difficulty.Numbers[0]} {Operator} {Difficulty.Numbers[1]}?");

            UserResult = Convert.ToInt32(Console.ReadLine());
            timer.Stop();

            if (CorrectResult == UserResult)
            {
                Win = "Win";
            }
            else
            {
                Win = "Lose";
            }           

            TimeSpan timeTaken = timer.Elapsed;
            Time = timeTaken.ToString(@"s\.ff");
            Console.Clear();


            return (UserResult, CorrectResult, Time, Win);
        }

        public static void Result()
        {
            if (Win == "Win")
            {
                Console.WriteLine($"That's correct!\n" +
                    $"It took you {Time} seconds to answer.\n");
                Score.AddScores(
                    Difficulty.Numbers[0], 
                    Difficulty.Numbers[1], 
                    Operation, 
                    Win,
                    CorrectResult, 
                    Operator, 
                    Time,
                    UserResult);
                Difficulty.Numbers.RemoveRange(0, 2);
            }
            else
            {
                Console.WriteLine($"That is not correct. The correct answer is: {CorrectResult}. \n" +
                    $"It took you {Time} seconds to answer.\n");
                Score.AddScores(
                    Difficulty.Numbers[0], 
                    Difficulty.Numbers[1], 
                    Operation, 
                    Win, 
                    CorrectResult, 
                    Operator, 
                    Time,
                    UserResult);
                Difficulty.Numbers.RemoveRange(0, 2);
            }
            Console.ReadKey();
        }

        public static bool PlayAgain()
        {
            Console.WriteLine("Type \"Y\" if you want to try again, type \"N\" if you want to go back to menu.");
            string again = Console.ReadLine();
            Console.Clear();

            if(again.ToLower() == "y")
            {
                return true;
            }
            return false;
        }
    }
}
