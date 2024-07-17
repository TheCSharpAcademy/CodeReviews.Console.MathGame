using MyFirstProgram.Models;
using System.Diagnostics;


namespace MyFirstProgram
{
    internal class GameEngine
    {
        internal void DivisionGame(string message)
        {
            var score = 0;

            Console.WriteLine("Would you like to play easy mode, or hard mode? Hard mode consists of a greater range of operands. Answer 'e' or 'h'");
            var easyOrHard = Console.ReadLine().Trim().ToLower();

            string[] validInput = ["e", "h", "E", "H"];

            while (!validInput.Contains(easyOrHard))
            {
                Console.WriteLine("You must choose a valid difficulty level");
                easyOrHard = Console.ReadLine().Trim().ToLower();
            }

            Console.Clear();

            Console.WriteLine("How many questions would you like this game to consist of?");
            var questions = Console.ReadLine();
            questions = Helpers.ValidateResult(questions);
  
            Stopwatch timer = new Stopwatch();
            timer.Start();


            for (int i = 0; i < int.Parse(questions); i++)
            {
                Console.Clear();
                Console.WriteLine(message);

                var divisionNumbers = Helpers.GetDivisionNumbers();

                if (easyOrHard == "h")
                {
                    divisionNumbers = Helpers.GetHardDivisionNumbers();
                }

                var firstNumber = divisionNumbers[0];
                var secondNumber = divisionNumbers[1];

                Console.WriteLine($"{firstNumber} / {secondNumber}");
                
                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber / secondNumber)
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                    Console.ReadLine();
                }

                if (i == int.Parse(questions) - 1)
                {
                    timer.Stop();
                    string elapsedTime = String.Format("{0:00}:{1:00}", timer.Elapsed.Minutes, timer.Elapsed.Seconds);
                    Console.WriteLine($"Game over. Your final score is {score}. It took you {elapsedTime} to complete this game. Press any key to go back to the main menu");
                    Console.ReadLine();
                }
            }

            Helpers.AddToHistory(score, GameType.Division);
        }

        internal void MultiplicationGame(string message)
        { 
            var random = new Random();
            var score = 0;

            int firstNumber;
            int secondNumber;

            Console.WriteLine("Would you like to play easy mode, or hard mode? Hard mode consists of a greater range of operands. Answer 'e' or 'h'");
            var easyOrHard = Console.ReadLine().Trim().ToLower();

            string[] validInput = ["e", "h", "E", "H"];

            while (!validInput.Contains(easyOrHard))
            {
                Console.WriteLine("You must choose a valid difficulty level");
                easyOrHard = Console.ReadLine().Trim().ToLower();
            }

            Console.Clear();

            Console.WriteLine("How many questions would you like this game to consist of?");
            var questions = Console.ReadLine();
            questions = Helpers.ValidateResult(questions);

            Stopwatch timer = new Stopwatch();
            timer.Start();

            for (int i = 0; i < int.Parse(questions); i++)
            {
                Console.Clear();
                Console.WriteLine(message);

                if (easyOrHard == "e")
                {
                    firstNumber = random.Next(1, 9);
                    secondNumber = random.Next(1, 9);
                }
                else
                {
                    firstNumber = random.Next(1, 42);
                    secondNumber = random.Next(1, 42);
                }

                Console.WriteLine($"{firstNumber} * {secondNumber}");
                
                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber * secondNumber)
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                    Console.ReadLine();
                }

                if (i == int.Parse(questions) - 1)
                {
                    timer.Stop();
                    string elapsedTime = String.Format("{0:00}:{1:00}", timer.Elapsed.Minutes, timer.Elapsed.Seconds);
                    Console.WriteLine($"Game over. Your final score is {score}. It took you {elapsedTime} to complete this game. Press any key to go back to the main menu");
                    Console.ReadLine();
                }
            }

            Helpers.AddToHistory(score, GameType.Multiplication);
        }

        internal void SubtractionGame(string message)
        {
            var random = new Random();
            var score = 0;

            int firstNumber;
            int secondNumber;

            Console.WriteLine("Would you like to play easy mode, or hard mode? Hard mode consists of a greater range of operands. Answer 'e' or 'h'");
            var easyOrHard = Console.ReadLine().Trim().ToLower();

            string[] validInput = ["e", "h", "E", "H"];

            while (!validInput.Contains(easyOrHard))
            {
                Console.WriteLine("You must choose a valid difficulty level");
                easyOrHard = Console.ReadLine().Trim().ToLower();
            }

            Console.Clear();

            Console.WriteLine("How many questions would you like this game to consist of?");
            var questions = Console.ReadLine();
            questions = Helpers.ValidateResult(questions);

            Stopwatch timer = new Stopwatch();
            timer.Start();

            for (int i = 0; i < int.Parse(questions); i++)
            {
                Console.Clear();
                Console.WriteLine(message);

                if (easyOrHard == "e")
                {
                    firstNumber = random.Next(1, 9);
                    secondNumber = random.Next(1, 9);
                }
                else
                {
                    firstNumber = random.Next(1, 42);
                    secondNumber = random.Next(1, 42);
                };

                Console.WriteLine($"{firstNumber} - {secondNumber}");

                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber - secondNumber)
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                    Console.ReadLine();
                }

                if (i == int.Parse(questions) - 1)
                {
                    timer.Stop();
                    string elapsedTime = String.Format("{0:00}:{1:00}", timer.Elapsed.Minutes, timer.Elapsed.Seconds);
                    Console.WriteLine($"Game over. Your final score is {score}. It took you {elapsedTime} to complete this game. Press any key to go back to the main menu");
                    Console.ReadLine();
                }
            }

            Helpers.AddToHistory(score, GameType.Subtraction);
        }

        internal void AdditionGame(string message)
        {
            var random = new Random();
            var score = 0;

            int firstNumber;
            int secondNumber;

            Console.WriteLine("Would you like to play easy mode, or hard mode? Hard mode consists of a greater range of operands. Answer 'e' or 'h'");
            var easyOrHard = Console.ReadLine().Trim().ToLower();

            string[] validInput = ["e", "h", "E", "H"];

            while (!validInput.Contains(easyOrHard))
            {
                Console.WriteLine("You must choose a valid difficulty level");
                easyOrHard = Console.ReadLine().Trim().ToLower();
            }

            Console.Clear(); 

            Console.WriteLine("How many questions would you like this game to consist of?");
            var questions = Console.ReadLine();
            questions = Helpers.ValidateResult(questions);

            Stopwatch timer = new Stopwatch();
            timer.Start();


            for (int i = 0; i < int.Parse(questions); i++)
            {
                Console.Clear();
                Console.WriteLine(message);

                if (easyOrHard == "e")
                {
                    firstNumber = random.Next(1, 9);
                    secondNumber = random.Next(1, 9);
                }
                else
                {
                    firstNumber = random.Next(1, 42);
                    secondNumber = random.Next(1, 42);
                }


                Console.WriteLine($"{firstNumber} + {secondNumber}");
                
                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber + secondNumber)
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                    Console.ReadLine();
                }

                if (i == int.Parse(questions) - 1)
                {
                    timer.Stop();
                    string elapsedTime = String.Format("{0:00}:{1:00}", timer.Elapsed.Minutes, timer.Elapsed.Seconds);
                    Console.WriteLine($"Game over. Your final score is {score}. It took you {elapsedTime} to complete this game. Press any key to go back to the main menu");
                    Console.ReadLine();
                }
            }

            Helpers.AddToHistory(score, GameType.Addition);
        }

        internal void RandomGame(string message)
        {
            var score = 0;
            var random = new Random();
            
            string[] operators = ["division", "multiplication", "subtraction", "addition"];

            Console.WriteLine("Would you like to play easy mode, or hard mode? Hard mode consists of a greater range of operands. Answer 'e' or 'h'");
            var easyOrHard = Console.ReadLine().Trim().ToLower();

            string[] validInput = ["e", "h", "E", "H"];

            while (!validInput.Contains(easyOrHard))
            {
                Console.WriteLine("You must choose a valid difficulty level");
                easyOrHard = Console.ReadLine().Trim().ToLower();
            }

            Console.Clear();

            Console.WriteLine("How many questions would you like this game to consist of?");
            var questions = Console.ReadLine();
            questions = Helpers.ValidateResult(questions);

            Stopwatch timer = new Stopwatch();
            timer.Start();

            for (int i = 0; i < int.Parse(questions); i++)
            {
                Console.Clear();
                Console.WriteLine(message);
                
                var randomOperator = random.Next(0, 4);
                
                if (randomOperator == 0)
                {
                    var divisionNumbers = Helpers.GetDivisionNumbers();

                    if (easyOrHard == "h")
                    {
                        divisionNumbers = Helpers.GetHardDivisionNumbers();
                    }

                    var firstNumber = divisionNumbers[0];
                    var secondNumber = divisionNumbers[1];

                    Console.WriteLine($"{firstNumber} / {secondNumber}");

                    var result = Console.ReadLine();
                    result = Helpers.ValidateResult(result);

                    if (int.Parse(result) == firstNumber / secondNumber)
                    {
                        Console.WriteLine("Your answer was correct! Type any key for the next question");
                        score++;
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                        Console.ReadLine();
                    }
                }
                else if (randomOperator == 1)
                {
                    int firstNumber;
                    int secondNumber;

                    if (easyOrHard == "e")
                    {
                        firstNumber = random.Next(1, 9);
                        secondNumber = random.Next(1, 9);
                    }
                    else
                    {
                        firstNumber = random.Next(1, 42);
                        secondNumber = random.Next(1, 42);
                    }

                    Console.WriteLine($"{firstNumber} * {secondNumber}");

                    var result = Console.ReadLine();
                    result = Helpers.ValidateResult(result);

                    if (int.Parse(result) == firstNumber * secondNumber)
                    {
                        Console.WriteLine("Your answer was correct! Type any key for the next question");
                        score++;
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                        Console.ReadLine();
                    }
                }
                else if (randomOperator == 2)
                {
                    int firstNumber;
                    int secondNumber;

                    if (easyOrHard == "e")
                    {
                        firstNumber = random.Next(1, 9);
                        secondNumber = random.Next(1, 9);
                    }
                    else
                    {
                        firstNumber = random.Next(1, 42);
                        secondNumber = random.Next(1, 42);
                    }

                    Console.WriteLine($"{firstNumber} - {secondNumber}");

                    var result = Console.ReadLine();
                    result = Helpers.ValidateResult(result);

                    if (int.Parse(result) == firstNumber - secondNumber)
                    {
                        Console.WriteLine("Your answer was correct! Type any key for the next question");
                        score++;
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                        Console.ReadLine();
                    }
                }
                else if (randomOperator == 3)
                {
                    int firstNumber;
                    int secondNumber;

                    if (easyOrHard == "e")
                    {
                        firstNumber = random.Next(1, 9);
                        secondNumber = random.Next(1, 9);
                    }
                    else
                    {
                        firstNumber = random.Next(1, 42);
                        secondNumber = random.Next(1, 42);
                    }

                    Console.WriteLine($"{firstNumber} + {secondNumber}");

                    var result = Console.ReadLine();
                    result = Helpers.ValidateResult(result);

                    if (int.Parse(result) == firstNumber + secondNumber)
                    {
                        Console.WriteLine("Your answer was correct! Type any key for the next question");
                        score++;
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                        Console.ReadLine();
                    }
                }

                if (i == int.Parse(questions) - 1)
                {
                    timer.Stop();
                    string elapsedTime = String.Format("{0:00}:{1:00}", timer.Elapsed.Minutes, timer.Elapsed.Seconds);
                    Console.WriteLine($"Game over. Your final score is {score}. It took you {elapsedTime} to complete this game. Press any key to go back to the main menu");
                    Console.ReadLine();
                }
            }

            Helpers.AddToHistory(score, GameType.Random);
        }
    }
}
