namespace MathProject
{
    internal class GameEngine
    {
        public int low;
        public int high;
        internal void AdditionGame(string message)
        {
            Console.WriteLine(message);

            Random random = new Random();
            int score = 0;


            int firstNumber;
            int secondNumber;

            for (int i = 0; i < 5; i++)
            {

                Console.Clear();
                Console.WriteLine(message);

                firstNumber = random.Next(low, high);
                secondNumber = random.Next(low, high);

                

                Console.WriteLine($"{firstNumber} + {secondNumber}");
                string result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                

                if (int.Parse(result) == firstNumber + secondNumber)
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your anser was wrong. Type any key for the next question");
                    Console.ReadLine();
                }

                if (i == 4)
                {
                    Console.WriteLine($"Game over. Your final score is {score}. Press any key to go back to the main menu.");
                    Console.ReadLine();
                }
            }

            // Need better way to check what difficulty. 
            if(high == 9)
            {
                Helpers.AddToHistory(score, Models.GameType.Addition, Models.GameDifficulty.Easy);
            }

            if(high == 99)
            {
                Helpers.AddToHistory(score, Models.GameType.Addition, Models.GameDifficulty.Medium);
            }

            if(high == 999)
            {
                Helpers.AddToHistory(score, Models.GameType.Addition, Models.GameDifficulty.Hard);
            }
            
        }

        internal void SubtractionGame(string message)
        {
            Console.WriteLine(message);


            Random random = new Random();
            int score = 0;


            int firstNumber;
            int secondNumber;

            for (int i = 0; i < 5; i++)
            {

                Console.Clear();
                Console.WriteLine(message);

                firstNumber = random.Next(low, high);
                secondNumber = random.Next(low, high);

                Console.WriteLine($"{firstNumber} - {secondNumber}");
                string result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber - secondNumber)
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your anser was wrong. Type any key for the next question");
                    Console.ReadLine();
                }

                if (i == 1) Console.WriteLine($"Game over. Your final score is {score}");
            }

            // Need better way to check what difficulty. 
            if (high == 9)
            {
                Helpers.AddToHistory(score, Models.GameType.Subtraction, Models.GameDifficulty.Easy);
            }

            if (high == 99)
            {
                Helpers.AddToHistory(score, Models.GameType.Subtraction, Models.GameDifficulty.Medium);
            }

            if (high == 999)
            {
                Helpers.AddToHistory(score, Models.GameType.Subtraction, Models.GameDifficulty.Hard);
            }
        }

        internal void MultiplicationGame(string message)
        {
            Console.WriteLine(message);

            Random random = new Random();
            int score = 0;

            int firstNumber;
            int secondNumber;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);

                firstNumber = random.Next(low, high);
                secondNumber = random.Next(low, high);

                Console.WriteLine($"{firstNumber} * {secondNumber}");
                string result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber * secondNumber)
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your anser was wrong. Type any key for the next question");
                    Console.ReadLine();
                }

                if (i == 1) Console.WriteLine($"Game over. Your final score is {score}");
            }

            // Need better way to check what difficulty. 
            if (high == 9)
            {
                Helpers.AddToHistory(score, Models.GameType.Multiplication, Models.GameDifficulty.Easy);
            }

            if (high == 99)
            {
                Helpers.AddToHistory(score, Models.GameType.Multiplication, Models.GameDifficulty.Medium);
            }

            if (high == 999)
            {
                Helpers.AddToHistory(score, Models.GameType.Multiplication, Models.GameDifficulty.Hard);
            }
        }

        internal void DivisionGame(string message)
        {
            int score = 0;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);

                int[] divisionNumbers = Helpers.GetDivisionNumbers(low, high);
                int firstNumber = divisionNumbers[0];
                int secondNumber = divisionNumbers[1];

                Console.WriteLine($"{firstNumber} / {secondNumber}");
                string result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber / secondNumber)
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your anser was wrong. Type any key for the next question");
                    Console.ReadLine();
                }

                if (i == 1) Console.WriteLine($"Game over. Your final score is {score}");
            }

            // Need better way to check what difficulty. 
            if (high == 99)
            {
                Helpers.AddToHistory(score, Models.GameType.Multiplication, Models.GameDifficulty.Easy);
            }

            if (high == 999)
            {
                Helpers.AddToHistory(score, Models.GameType.Multiplication, Models.GameDifficulty.Medium);
            }

            if (high == 9999)
            {
                Helpers.AddToHistory(score, Models.GameType.Multiplication, Models.GameDifficulty.Hard);
            }
        }     
    }   
}
