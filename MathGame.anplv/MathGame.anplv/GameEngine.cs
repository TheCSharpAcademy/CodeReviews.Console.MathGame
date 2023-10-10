using MathGame.anplv.Models;
using System;

namespace MathGame.anplv
{
    internal class GameEngine
    {
        internal void AdditionGame(string message, DateTime dateTime)
        {
            string gameTime = "00 minutes 00 seconds";
            var score = 0;
            var level = Helpers.GetLevel();
            level = Helpers.ValidateLevel(level);

            var amountQuestions = Helpers.GetAmountQuestions();
            amountQuestions = (Helpers.ValidateResult(amountQuestions));

            for (int i = 0; i < int.Parse(amountQuestions); i++)
            {
                var numbers = Helpers.GetNumbers("Addition", level);
                Console.Clear();
                Console.WriteLine(message);

                Console.WriteLine($"{numbers[0]} + {numbers[1]}");
                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);
                         
                if (int.Parse(result) == numbers[0] + numbers[1])
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question");
                    Console.ReadLine();
                    score++;
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect! Type any key for the next question");
                    Console.ReadLine();
                }
                if (i == int.Parse(amountQuestions) - 1)
                {
                    gameTime = Helpers.GetDateDifference(dateTime);
                    Console.WriteLine($"Game over. Your final score is {score} from {amountQuestions}. You completed it in {gameTime}. Press any key to go back to the main menu");
                    Console.ReadLine();
                }
            }

            Helpers.AddToHistory(score, GameType.Addition, gameTime);



        }

        internal void SubtractionGame(string message, DateTime dateTime)
        {
            string gameTime = "00 minutes 00 seconds";
            var score = 0;
            var level = Helpers.GetLevel();
            level = Helpers.ValidateLevel(level);

            var amountQuestions = Helpers.GetAmountQuestions();
            amountQuestions = (Helpers.ValidateResult(amountQuestions));

            for (int i = 0; i < int.Parse(amountQuestions); i++)
            {
                var numbers = Helpers.GetNumbers("Subtraction", level);
                Console.Clear();
                Console.WriteLine(message);

                Console.WriteLine($"{numbers[0]} - {numbers[1]}");
                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == numbers[0] - numbers[1])
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question");
                    Console.ReadLine();
                    score++;
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect! Type any key for the next question");
                    Console.ReadLine();
                }
                if (i == int.Parse(amountQuestions) - 1) 
                {
                    gameTime = Helpers.GetDateDifference(dateTime);
                    Console.WriteLine($"Game over. Your final score is {score} from {amountQuestions}.You completed it in {gameTime}. Press any key to go back to the main menu");
                    Console.ReadLine();
                }
            }

            Helpers.AddToHistory(score, GameType.Subtraction, gameTime);
        }

        internal void MultiplicationGame(string message, DateTime dateTime)
        {
            string gameTime = "00 minutes 00 seconds";
            var score = 0;
            var level = Helpers.GetLevel();
            level = Helpers.ValidateLevel(level);

            var amountQuestions = Helpers.GetAmountQuestions();
            amountQuestions = (Helpers.ValidateResult(amountQuestions));

            for (int i = 0; i < int.Parse(amountQuestions); i++)
            {
                var numbers = Helpers.GetNumbers("Multiplication", level);
                Console.Clear();
                Console.WriteLine(message);

                Console.WriteLine($"{numbers[0]} * {numbers[1]}");
                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == numbers[0] * numbers[1])
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question");
                    Console.ReadLine();
                    score++;
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect! Type any key for the next question");
                    Console.ReadLine();
                }
                if (i == int.Parse(amountQuestions) - 1)
                {
                    gameTime = Helpers.GetDateDifference(dateTime);
                    Console.WriteLine($"Game over. Your final score is {score} from {amountQuestions}. You completed it in {gameTime}. Press any key to go back to the main menu");
                    Console.ReadLine();

                };
            }

            Helpers.AddToHistory(score, GameType.Multiplication, gameTime);
        }


        internal void DivisionGame(string message, DateTime dateTime)
        {
            string gameTime = "00 minutes 00 seconds";
            var score = 0;
            var level = Helpers.GetLevel();
            level = Helpers.ValidateLevel(level);

            var amountQuestions = Helpers.GetAmountQuestions();
            amountQuestions = (Helpers.ValidateResult(amountQuestions));
            for (int i = 0; i < int.Parse(amountQuestions); i++)
            {
                var numbers = Helpers.GetNumbers("Division", level);
                Console.Clear();
                Console.WriteLine(message);

                Console.WriteLine($"{numbers[0]} / {numbers[1]}");
                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == numbers[0] / numbers[1])
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question");
                    Console.ReadLine();
                    score++;
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect! Type any key for the next question");
                    Console.ReadLine();
                }
                if (i == int.Parse(amountQuestions) - 1)
                {
                    gameTime = Helpers.GetDateDifference(dateTime);
                    Console.WriteLine($"Game over. Your final score is {score} from {amountQuestions}. You completed it in {gameTime}. Press any key to go back to the main menu");
                    Console.ReadLine();
                }
            }

            Helpers.AddToHistory(score, GameType.Division, gameTime);
        }

        internal void RandomGame()
        {
            var random = new Random();
            var randomNumber = random.Next(4);

            switch (randomNumber)
            {
                case 0:
                    AdditionGame("Addiction game", Helpers.GetDate());
                    break;
                case 1:
                    SubtractionGame("Subtraction game", Helpers.GetDate());
                    break;
                case 2:
                    MultiplicationGame("Multiplication game", Helpers.GetDate());
                    break;
                case 3:
                    DivisionGame("Division game", Helpers.GetDate());
                    break;
            }
        }



    }
}
