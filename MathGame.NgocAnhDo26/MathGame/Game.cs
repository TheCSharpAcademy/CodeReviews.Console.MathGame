using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    internal abstract class Game
    {
        protected int _difficulty { get; set; }
        protected int _numOfQuestions { get; set; }

        public Game(int difficulty, int numOfQuestions)
        {
            _difficulty = difficulty;
            _numOfQuestions = numOfQuestions;
        }

        public abstract int Start();

    }

    class AdditionGame : Game
    {
        public AdditionGame(int difficulty, int numOfQuestions) : base(difficulty, numOfQuestions) { }

        public override int Start()
        {
            int score = 0;
            var dice = new Random();
            int firstNumber, secondNumber;
            int power = (int)Math.Pow(_difficulty, _difficulty);

            for (int i = 0; i < _numOfQuestions; ++i)
            {
                firstNumber = dice.Next(1, 11) * power;
                secondNumber = dice.Next(1, 11) * power;

                Menu.history.Add($"{firstNumber} + {secondNumber}");

                Console.WriteLine($"\nQuestion: {firstNumber} + {secondNumber}?");
                Console.Write("Your answer: ");

                int answer;
                if (!int.TryParse(Console.ReadLine(), out answer))
                {
                    Console.WriteLine("Invalid answer input! You failed this one!!!");
                    continue;
                }

                if (answer == firstNumber + secondNumber)
                {
                    Console.WriteLine($"Correct!");
                    score++;
                }
                else
                    Console.WriteLine($"Incorrect! The answer is {firstNumber + secondNumber}!");
            }

            return score;
        }
    }
    class SubtractionGame : Game
    {
        public SubtractionGame(int difficulty, int numOfQuestions) : base(difficulty, numOfQuestions) { }
        public override int Start()
        {
            int score = 0;
            var dice = new Random();
            int firstNumber, secondNumber;
            int power = (int)Math.Pow(_difficulty, _difficulty);

            for (int i = 0; i < _numOfQuestions; ++i)
            {
                firstNumber = dice.Next(1, 11) * power;
                secondNumber = dice.Next(0, firstNumber);

                Menu.history.Add($"{firstNumber} - {secondNumber}");

                Console.WriteLine($"\nQuestion: {firstNumber} - {secondNumber}?");
                Console.Write("Your answer: ");

                int answer;
                if (!int.TryParse(Console.ReadLine(), out answer))
                {
                    Console.WriteLine("Invalid answer input! You failed this one!!!");
                    continue;
                }

                if (answer == firstNumber - secondNumber)
                {
                    Console.WriteLine($"Correct!");
                    score++;
                }
                else
                    Console.WriteLine($"Incorrect! The answer is {firstNumber - secondNumber}!");
            }

            return score;
        }
    }

    class MultiplyGame : Game
    {
        public MultiplyGame(int difficulty, int numOfQuestions) : base(difficulty, numOfQuestions) { }

        public override int Start()
        {
            int score = 0;
            var dice = new Random();
            int firstNumber, secondNumber;
            int power = (int)Math.Pow(_difficulty, _difficulty - 1);

            for (int i = 0; i < _numOfQuestions; ++i)
            {
                firstNumber = dice.Next(1, 11) * power;
                secondNumber = dice.Next(1, 11) * power;

                Menu.history.Add($"{firstNumber} * {secondNumber}");

                Console.WriteLine($"\nQuestion: {firstNumber} * {secondNumber}?");
                Console.Write("Your answer: ");

                int answer;
                if (!int.TryParse(Console.ReadLine(), out answer))
                {
                    Console.WriteLine("Invalid answer input! You failed this one!!!");
                    continue;
                }

                if (answer == firstNumber * secondNumber)
                {
                    Console.WriteLine($"Correct!");
                    score++;
                }
                else
                    Console.WriteLine($"Incorrect! The answer is {firstNumber * secondNumber}!");
            }

            return score;
        }
    }

    class DivisionGame : Game
    {
        public DivisionGame(int difficulty, int numOfQuestions) : base(difficulty, numOfQuestions) { }

        public override int Start()
        {
            int score = 0;
            var dice = new Random();
            int firstNumber, secondNumber;

            for (int i = 0; i < _numOfQuestions; ++i)
            {
                do
                {
                    firstNumber = dice.Next(0, 25) * _difficulty;
                } while (firstNumber % 2 != 0 && firstNumber % 3 != 0 && firstNumber % 5 != 0 && firstNumber % 7 != 0);
                
                do
                {
                    secondNumber = dice.Next(1, firstNumber + 1);
                } while (firstNumber % secondNumber != 0);

                Menu.history.Add($"{firstNumber} / {secondNumber}");

                Console.WriteLine($"\nQuestion: {firstNumber} / {secondNumber}?");
                Console.Write("Your answer: ");

                int answer;
                if (!int.TryParse(Console.ReadLine(), out answer))
                {
                    Console.WriteLine("Invalid answer input! You failed this one!!!");
                    continue;
                }

                if (answer == firstNumber / secondNumber)
                {
                    Console.WriteLine($"Correct!");
                    score++;
                }
                else
                    Console.WriteLine($"Incorrect! The answer is {firstNumber / secondNumber}!"); 
            }

            return score;
        }
    }

    class RandomGame : Game
    {
        public RandomGame(int difficulty, int numOfQuestions) : base(difficulty, numOfQuestions) { }

        public override int Start()
        {
            int score = 0;
            var dice = new Random();

            Console.WriteLine("\nRandom Game - Difficulty Level UNKNOWN");

            var questionsRemain = _numOfQuestions;

            for (int i = 0; i < _numOfQuestions; ++i)
            {
                var difficulty = dice.Next(1, 5);
                var mode = dice.Next(1, 5);

                switch (mode)
                {
                    case 1:
                        score += new AdditionGame(difficulty, 1).Start();
                        break;
                    case 2:
                        score += new SubtractionGame(difficulty, 1).Start();
                        break;
                    case 3:
                        score += new MultiplyGame(difficulty, 1).Start();
                        break;
                    case 4:
                        score += new DivisionGame(difficulty, 1).Start();
                        break;
                }
            }

            return score;
        }
    }
}
