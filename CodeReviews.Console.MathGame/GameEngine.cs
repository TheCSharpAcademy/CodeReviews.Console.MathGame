

using MyFirstProgram.Models;

namespace MyFirstProgram
{
    internal class GameEngine
    {

        public int firstNumber { get; set; }
        public int secondNumber { get; set; }

        internal static void AdditionGame(string message)
        {

            int firstNumber;
            int secondNumber;
            var random = new Random();
            
            var score = 0;

            //Helpers.SelectDifficult(GameEngine.AdditionGame);

            for (int i = 0; i < 5; i++)
            {

                 
                firstNumber = random.Next(1, 10);
                secondNumber = random.Next(1, 10);

                Console.Clear();
                Console.WriteLine(message);
                Console.WriteLine($"{firstNumber} + {secondNumber}");
                
                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                

                if (int.Parse(result) == firstNumber + secondNumber)
                {
                    Console.WriteLine("Your answer was correct!.Type any key to continue.");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect.Type any key to continue.");
                    Console.ReadLine();
                }

                if (i == 4)
                {
                    Console.WriteLine($"Game over. Your final score is {score}");
                    Console.WriteLine("\n");
                }
            }

            Helpers.AddToHistory(score, Models.GameType.Addition);

        }

        internal static void SubstractionGame(string message)
        {
            var random = new Random();
            var score = 0;

            int firstNumber;
            int secondNumber;

            for (int i = 0; i < 5; i++)
            {
                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);

                Console.Clear();
                Console.WriteLine(message);
                Console.WriteLine($"{firstNumber} - {secondNumber}");
                
                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber - secondNumber)
                {
                    Console.WriteLine("Your answer was correct!.Type any key to continue.");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect.Type any key to continue.");
                    Console.ReadLine();
                }

                if (i == 4)
                {
                    Console.WriteLine($"Game over. Your final score is {score}");
                    Console.WriteLine("\n");
                }


            }
            Helpers.AddToHistory(score, GameType.Substraction);
        }

        internal static void MultiplicationGame(string message)
        {
            var random = new Random();
            var score = 0;

            int firstNumber;
            int secondNumber;

            for (int i = 0; i < 5; i++)
            {
                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);

                Console.Clear();
                Console.WriteLine(message);
                Console.WriteLine($"{firstNumber} * {secondNumber}");
               
                var result = Console.ReadLine();
                result= Helpers.ValidateResult(result); 

                if (int.Parse(result) == firstNumber * secondNumber)
                {
                    Console.WriteLine("Your answer was correct!.Type any key to continue.");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect.Type any key to continue.");
                    Console.ReadLine();
                }

                if (i == 4)
                {
                    Console.WriteLine($"Game over. Your final score is {score}");
                    Console.WriteLine("\n");
                }
            }
            Helpers.AddToHistory(score, GameType.Multiplication);
        }

        internal static void DivisionGame(string message)
        {

            var score = 0;
            for (int i = 0; i < 5; i++)
            {

                var divisionNumbers = Helpers.GetDivisionNumbers();
                var firstNumber = divisionNumbers[0];
                var secondNumber = divisionNumbers[1];

                Console.Clear();
                Console.WriteLine(message);

                Console.WriteLine($"{firstNumber}/{secondNumber}");

                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber / secondNumber)
                {
                    Console.WriteLine("Your answer was correct!.Type any key to continue.");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect.Type any key to continue.");
                    Console.ReadLine();
                }

                if (i == 4)
                {
                    Console.WriteLine($"Game over. Your final score is {score}");
                    Console.WriteLine("\n");
                }
            }
            Helpers.AddToHistory(score, GameType.Division );
        }
    }
}
