using MathGame.Models;

namespace MathGame
{
    internal class GameEngine
    {
        internal void AdditionGame(string message)
        {
            var random = new Random();
            var score = 0;
            int firstNumber;
            int secondNumber;

            var difficulty = Helpers.SetDifficulty();
            int questions = Helpers.NumberOfQuestions();

            if (difficulty == "Easy")
            {
                for (int i = 0; i < questions; i++)
                {
                    Console.Clear();
                    Console.WriteLine(message);

                    firstNumber = random.Next(1, 9);
                    secondNumber = random.Next(1, 9);
                    int answer = firstNumber + secondNumber;

                    Console.WriteLine($"What is {firstNumber} + {secondNumber}?");
                    var result = Console.ReadLine();

                    result = Helpers.ValidateResult(result);

                    if (int.Parse(result) == answer)
                    {
                        Console.WriteLine("Correct!");
                        score++;

                        Console.WriteLine("Press any key for the next question.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Incorrect.");

                        Console.WriteLine("Press any key for the next question.");
                        Console.ReadLine();
                    }

                    Helpers.GameOver(i, questions, score);
                }
            }
            if (difficulty == "Medium")
            {
                for (int i = 0; i < questions; i++)
                {
                    Console.Clear();
                    Console.WriteLine(message);

                    firstNumber = random.Next(1, 99);
                    secondNumber = random.Next(1, 99);
                    int answer = firstNumber + secondNumber;

                    Console.WriteLine($"What is {firstNumber} + {secondNumber}?");
                    var result = Console.ReadLine();

                    result = Helpers.ValidateResult(result);

                    if (int.Parse(result) == answer)
                    {
                        Console.WriteLine("Correct!");
                        score++;

                        Console.WriteLine("Press any key for the next question.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Incorrect.");

                        Console.WriteLine("Press any key for the next question.");
                        Console.ReadLine();
                    }

                    Helpers.GameOver(i, questions, score);
                }
            }
            else if (difficulty == "Hard")
            {
                for (int i = 0; i < questions; i++)
                {
                    Console.Clear();
                    Console.WriteLine(message);

                    firstNumber = random.Next(1, 999);
                    secondNumber = random.Next(1, 999);
                    int answer = firstNumber + secondNumber;

                    Console.WriteLine($"What is {firstNumber} + {secondNumber}?");
                    var result = Console.ReadLine();

                    result = Helpers.ValidateResult(result);

                    if (int.Parse(result) == answer)
                    {
                        Console.WriteLine("Correct!");
                        score++;

                        Console.WriteLine("Press any key for the next question.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Incorrect.");

                        Console.WriteLine("Press any key for the next question.");
                        Console.ReadLine();
                    }

                    Helpers.GameOver(i, questions, score);
                }
            }

            Helpers.AddToHistory(score, difficulty, questions, GameType.Addition);
        }

        internal void SubtractionGame(string message)
        {
            var random = new Random();
            var score = 0;
            int firstNumber;
            int secondNumber;

            var difficulty = Helpers.SetDifficulty();
            int questions = Helpers.NumberOfQuestions();

            if (difficulty == "Easy")
            {
                for (int i = 0; i < questions; i++)
                {
                    Console.Clear();
                    Console.WriteLine(message);

                    firstNumber = random.Next(1, 9);
                    secondNumber = random.Next(1, 9);
                    int answer = firstNumber - secondNumber;

                    Console.WriteLine($"What is {firstNumber} - {secondNumber}?");
                    var result = Console.ReadLine();

                    result = Helpers.ValidateResult(result);

                    if (int.Parse(result) == answer)
                    {
                        Console.WriteLine("Correct!");
                        score++;

                        Console.WriteLine("Press any key for the next question.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Incorrect.");

                        Console.WriteLine("Press any key for the next question.");
                        Console.ReadLine();
                    }

                    Helpers.GameOver(i, questions, score);
                }
            }
            if (difficulty == "Medium") 
            {
                for (int i = 0; i < questions; i++)
                {
                    Console.Clear();
                    Console.WriteLine(message);

                    firstNumber = random.Next(1, 99);
                    secondNumber = random.Next(1, 99);
                    int answer = firstNumber - secondNumber;

                    Console.WriteLine($"What is {firstNumber} - {secondNumber}?");
                    var result = Console.ReadLine();

                    result = Helpers.ValidateResult(result);

                    if (int.Parse(result) == answer)
                    {
                        Console.WriteLine("Correct!");
                        score++;

                        Console.WriteLine("Press any key for the next question.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Incorrect.");

                        Console.WriteLine("Press any key for the next question.");
                        Console.ReadLine();
                    }

                    Helpers.GameOver(i, questions, score);
                }
            }
            else if (difficulty == "Hard")
            {
                for (int i = 0; i < questions; i++)
                {
                    Console.Clear();
                    Console.WriteLine(message);

                    firstNumber = random.Next(1, 999);
                    secondNumber = random.Next(1, 999);
                    int answer = firstNumber - secondNumber;

                    Console.WriteLine($"What is {firstNumber} - {secondNumber}?");
                    var result = Console.ReadLine();

                    result = Helpers.ValidateResult(result);

                    if (int.Parse(result) == answer)
                    {
                        Console.WriteLine("Correct!");
                        score++;

                        Console.WriteLine("Press any key for the next question.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Incorrect.");

                        Console.WriteLine("Press any key for the next question.");
                        Console.ReadLine();
                    }

                    Helpers.GameOver(i, questions, score);
                }
            }


            Helpers.AddToHistory(score, difficulty, questions, GameType.Subtraction);
        }

        internal void MultiplicationGame(string message)        
        {
            var random = new Random();
            var score = 0;
            int firstNumber;
            int secondNumber;

            var difficulty = Helpers.SetDifficulty();
            int questions = Helpers.NumberOfQuestions();

            if (difficulty == "Easy")
            {
                for (int i = 0; i < questions; i++)
                {
                    Console.Clear();
                    Console.WriteLine(message);

                    firstNumber = random.Next(1, 10);
                    secondNumber = random.Next(1, 10);
                    int answer = firstNumber * secondNumber;

                    Console.WriteLine($"What is {firstNumber} * {secondNumber}?");
                    var result = Console.ReadLine();

                    result = Helpers.ValidateResult(result);

                    if (int.Parse(result) == answer)
                    {
                        Console.WriteLine("Correct!");
                        score++;

                        Console.WriteLine("Press any key for the next question.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Incorrect.");

                        Console.WriteLine("Press any key for the next question.");
                        Console.ReadLine();
                    }

                    Helpers.GameOver(i, questions, score);
                }
            }
            if (difficulty == "Medium")
            {
                for (int i = 0; i < questions; i++)
                {
                    Console.Clear();
                    Console.WriteLine(message);

                    firstNumber = random.Next(1, 20);
                    secondNumber = random.Next(1, 20);
                    int answer = firstNumber * secondNumber;

                    Console.WriteLine($"What is {firstNumber} * {secondNumber}?");
                    var result = Console.ReadLine();

                    result = Helpers.ValidateResult(result);

                    if (int.Parse(result) == answer)
                    {
                        Console.WriteLine("Correct!");
                        score++;

                        Console.WriteLine("Press any key for the next question.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Incorrect.");

                        Console.WriteLine("Press any key for the next question.");
                        Console.ReadLine();
                    }

                    Helpers.GameOver(i, questions, score);
                }
            }
            else if (difficulty == "Hard")
            {
                for (int i = 0; i < questions; i++)
                {
                    Console.Clear();
                    Console.WriteLine(message);

                    firstNumber = random.Next(1, 50);
                    secondNumber = random.Next(1, 50);
                    int answer = firstNumber * secondNumber;

                    Console.WriteLine($"What is {firstNumber} * {secondNumber}?");
                    var result = Console.ReadLine();

                    result = Helpers.ValidateResult(result);

                    if (int.Parse(result) == answer)
                    {
                        Console.WriteLine("Correct!");
                        score++;

                        Console.WriteLine("Press any key for the next question.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Incorrect.");

                        Console.WriteLine("Press any key for the next question.");
                        Console.ReadLine();
                    }

                    Helpers.GameOver(i, questions, score);
                }
            }

            

            Helpers.AddToHistory(score, difficulty, questions, GameType.Multiplication);
        }

        internal void DivisionGame(string message)
        {
            var score = 0;

            var difficulty = Helpers.SetDifficulty();
            int questions = Helpers.NumberOfQuestions();

            for (int i = 0; i < questions; i++)
            {
                Console.Clear();
                Console.WriteLine(message);

                var divisionNumbers = Helpers.GetDivisionNumbers(difficulty);
                var answer = divisionNumbers[0] / divisionNumbers[1];

                Console.WriteLine($"What is {divisionNumbers[0]} / {divisionNumbers[1]}?");
                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == answer)
                {
                    Console.WriteLine("Correct!");
                    score++;

                    Console.WriteLine("Press any key for the next question.");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Incorrect");

                    Console.WriteLine("Press any key for the next question.");
                    Console.ReadLine();
                }

                Helpers.GameOver(i, questions, score);
            }

            Helpers.AddToHistory(score, difficulty, questions, GameType.Division);
        }
    }
}
