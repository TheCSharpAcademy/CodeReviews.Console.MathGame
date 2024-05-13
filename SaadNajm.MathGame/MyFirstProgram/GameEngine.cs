

using MyFirstProgram.Models;

namespace MyFirstProgram
{
    internal class GameEngine
    {
        internal void DivisionGame(string message)
        {
            var startTime = DateTime.Now;  // Capture start time
            var score = 0;
            var difficulty = Helpers.getDifficultyLevel();
            int numberOfQuestions = Helpers.numberOfQuestions();

            var random = new Random(); // Initialize Random outside the loop

            for (int i = 0; i < numberOfQuestions; i++)
            {
                int firstNumber, secondNumber;
                do
                {
                    if (difficulty == GameDifficulty.Easy)
                    {
                        firstNumber = random.Next(1, 9);
                        secondNumber = random.Next(1, 9);
                    }
                    else if (difficulty == GameDifficulty.Medium)
                    {
                        firstNumber = random.Next(10, 50);
                        secondNumber = random.Next(10, 50);
                    }
                    else
                    {
                        firstNumber = random.Next(50, 100);
                        secondNumber = random.Next(50, 100);
                    }
                }
                while (firstNumber % secondNumber != 0);

                Console.WriteLine($"{firstNumber}/{secondNumber}");
                var result = Console.ReadLine();

                while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
                {
                    Console.WriteLine("Your answer needs to be an integer. Try again.");
                    result = Console.ReadLine();
                }

                if (int.Parse(result) == firstNumber / secondNumber)
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question");
                    Console.ReadLine();
                    score++;
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                    Console.ReadLine();
                }

                if (i == numberOfQuestions - 1)
                {
                    Console.WriteLine($"Game over.Your final score is {score}. Press any key to go back to the main menu");
                    Console.ReadLine();
                }
            }

            var endTime = DateTime.Now;  // Capture end time
            var totalSeconds = Math.Round((endTime - startTime).TotalSeconds, 2);  // Calculate total time

            Helpers.AddToHistory(score, GameType.Division, difficulty, totalSeconds);
        }



        internal void MultiplicationGame(string message)
        {
            int numberOfQuestions = Helpers.numberOfQuestions();
            var startTime = DateTime.Now;  // Capture start time
            var difficulty = Helpers.getDifficultyLevel();
            var random = new Random();
            var score = 0;
            int firstNumber;
            int secondNumber;
            for (int i = 0; i < numberOfQuestions; i++)
            {
                Console.Clear();
                Console.WriteLine(message);
                if (difficulty == GameDifficulty.Easy)
                {
                    firstNumber = random.Next(1, 9);
                    secondNumber = random.Next(1, 9);
                }
                else if(difficulty == GameDifficulty.Medium)
                {
                    firstNumber = random.Next(10, 50);
                    secondNumber = random.Next(10, 50);
                }
                else
                {
                    firstNumber = random.Next(50, 100);
                    secondNumber = random.Next(50, 100);
                }
                Console.WriteLine($"{firstNumber} * {secondNumber}");
                var result = Console.ReadLine();
                while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
                {
                    Console.WriteLine("Your answer needs to be an integer. Try again.");
                    result = Console.ReadLine();
                }
                if (int.Parse(result) == firstNumber * secondNumber)
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question");
                    Console.ReadLine();
                    score++;
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                    Console.ReadLine();
                }
                if (i == numberOfQuestions-1)
                {
                    Console.WriteLine($"Game over.Your final score is {score}. Press any key to go back to the main menu");
                    Console.ReadLine();
                }
            }
            var endTime = DateTime.Now;  // Capture end time
            var totalSeconds = Math.Round((endTime - startTime).TotalSeconds, 2);  // Calculate total time

            Helpers.AddToHistory(score, GameType.Multiplication, difficulty, totalSeconds);
        }

        internal void SubstractionGame(string message)
        {
            int numberOfQuestions = Helpers.numberOfQuestions();
            var startTime = DateTime.Now;  // Capture start time
            var difficulty = Helpers.getDifficultyLevel();
            var random = new Random();
            var score = 0;
            int firstNumber;
            int secondNumber;
            for (int i = 0; i < numberOfQuestions; i++)
            {
                Console.Clear();
                Console.WriteLine(message);
                if (difficulty == GameDifficulty.Easy)
                {
                    firstNumber = random.Next(1, 9);
                    secondNumber = random.Next(1, 9);
                }
                else if (difficulty == GameDifficulty.Medium)
                {
                    firstNumber = random.Next(10, 50);
                    secondNumber = random.Next(10, 50);
                }
                else
                {
                    firstNumber = random.Next(50, 100);
                    secondNumber = random.Next(50, 100);
                }
                Console.WriteLine($"{firstNumber} - {secondNumber}");
                var result = Console.ReadLine();
                while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
                {
                    Console.WriteLine("Your answer needs to be an integer. Try again.");
                    result = Console.ReadLine();
                }
                if (int.Parse(result) == firstNumber - secondNumber)
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question");
                    Console.ReadLine();
                    score++;
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                    Console.ReadLine();
                }
                if (i == numberOfQuestions-1)
                {
                    Console.WriteLine($"Game over.Your final score is {score}. Press any key to go back to the main menu");
                    Console.ReadLine();
                }
            }
            var endTime = DateTime.Now;  // Capture end time
            var totalSeconds = Math.Round((endTime - startTime).TotalSeconds, 2);  // Calculate total time

            Helpers.AddToHistory(score, GameType.Substraction, difficulty, totalSeconds);
        }

        internal void AdditionGame(string message)
        {
            int numberOfQuestions = Helpers.numberOfQuestions();
            var startTime = DateTime.Now;  // Capture start time
            var difficulty = Helpers.getDifficultyLevel();
            var random = new Random();
            var score = 0;
            int firstNumber;
            int secondNumber;
            for (int i = 0; i < numberOfQuestions; i++)
            {
                Console.Clear();
                Console.WriteLine(message);
                if (difficulty == GameDifficulty.Easy)
                {
                    firstNumber = random.Next(1, 9);
                    secondNumber = random.Next(1, 9);
                }
                else if (difficulty == GameDifficulty.Medium)
                {
                    firstNumber = random.Next(10, 50);
                    secondNumber = random.Next(10, 50);
                }
                else
                {
                    firstNumber = random.Next(50, 100);
                    secondNumber = random.Next(50, 100);
                }
                Console.WriteLine($"{firstNumber} + {secondNumber}");
                var result = Console.ReadLine();
                while(string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _)) {
                    Console.WriteLine("Your answer needs to be an integer. Try again.");
                    result = Console.ReadLine();
                }
                if (int.Parse(result) == firstNumber + secondNumber)
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question");
                    Console.ReadLine();
                    score++;
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                    Console.ReadLine();
                }
                if (i == numberOfQuestions-1)
                {
                    Console.WriteLine($"Game over.Your final score is {score}. Press any key to go back to the main menu");
                    Console.ReadLine();
                }

            }
            var endTime = DateTime.Now;  // Capture end time
            var totalSeconds = Math.Round((endTime - startTime).TotalSeconds, 2);  // Calculate total time

            Helpers.AddToHistory(score, GameType.Addition, difficulty, totalSeconds);
        }
        internal void RandomGame(string message)
        {
            var divisionNumbers = Helpers.GetDivisionNumbers();
            int numberOfQuestions = Helpers.numberOfQuestions();
            var startTime = DateTime.Now;  // Capture start time
            var difficulty = Helpers.getDifficultyLevel();
           
            var random = new Random();
            var score = 0;

            for (int i = 0; i < numberOfQuestions; i++)
            {
                Console.Clear();
                Console.WriteLine(message);

                // Generate random operation (addition, subtraction, multiplication, or division)
                int operation = random.Next(1, 5);  // 1-4 represents the 4 operations

                int firstNumber;
                int secondNumber;
                if (difficulty == GameDifficulty.Easy)
                {
                    firstNumber = random.Next(1, 9);
                    secondNumber = random.Next(1, 9);
                }
                else if (difficulty == GameDifficulty.Medium)
                {
                    firstNumber = random.Next(10, 50);
                    secondNumber = random.Next(10, 50);
                }
                else
                {
                    firstNumber = random.Next(50, 100);
                    secondNumber = random.Next(50, 100);
                }
                string operationSymbol;
                int result;

                switch (operation)
                {
                    case 1:
                        operationSymbol = "+";
                        result = firstNumber + secondNumber;
                        break;
                    case 2:
                        operationSymbol = "-";
                        result = firstNumber - secondNumber;
                        break;
                    case 3:
                        operationSymbol = "*";
                        result = firstNumber * secondNumber;
                        break;
                    case 4:
                        
                        do
                        {
                             firstNumber = divisionNumbers[0];
                             secondNumber = divisionNumbers[1];
                          
                        } while (secondNumber == 0);
                        operationSymbol = "/";
                        result = firstNumber / secondNumber;
                        break;
                    default:
                        Console.WriteLine("An unexpected error occurred. Defaulting to addition.");
                        operationSymbol ="+";
                        result = firstNumber + secondNumber;
                        break;
                }

                Console.WriteLine($"{firstNumber} {operationSymbol} {secondNumber}");
                var userAnswer = Console.ReadLine();

                while (string.IsNullOrEmpty(userAnswer) || !Int32.TryParse(userAnswer, out _))
                {
                    Console.WriteLine("Your answer needs to be an integer. Try again.");
                    userAnswer = Console.ReadLine();
                }

                if (int.Parse(userAnswer) == result)
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question");
                    Console.ReadLine();
                    score++;
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                    Console.ReadLine();
                }
            }

            var endTime = DateTime.Now;  // Capture end time
            var totalSeconds = Math.Round((endTime - startTime).TotalSeconds, 2);  // Calculate total time
            Helpers.AddToHistory(score, GameType.Random, difficulty, totalSeconds);
        }
    
}

    }

