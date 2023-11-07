using MathGameV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MathGame
{
    internal class Engine
    {
        internal static List<GameModel> gameScores = new List<GameModel>();
        internal void GenerateMainMenu()
        {
            Console.Clear();
            bool isGameRunning = true;

            do
            {
                Console.WriteLine(@"
    ------------------------
    This is a math game.
    ------------------------
    Press a key to play:
    A - addition
    S - subtraction
    M - multiplication
    D - division
    V - view history of games
    Q - quit
    -----------------------");

                string userInput = Console.ReadLine();
                if (userInput.ToLower() == "a")
                {
                    AdditionGame();
                }
                else if (userInput.ToLower() == "s")
                {
                    SubtractionGame();
                }
                else if (userInput.ToLower() == "m")
                {
                    MultiplicationGame();
                }
                else if (userInput.ToLower() == "d")
                {
                    DivisionGame();
                }
                else if (userInput.ToLower() == "v")
                {
                    PrintGamesHistory();
                }
                else if (userInput.ToLower() == "q")
                {
                    Console.WriteLine("Bye.");
                    isGameRunning = false;
                }
            } while (isGameRunning == true);
        }

        internal void DivisionGame()
        {
            Console.Clear();
            Console.WriteLine(@"
------------------------
This is a division game. (5 correct answers)
------------------------
");
            Random random = new Random();

            bool isValidInput;
            int exerciceCounter = 0;
            int userAnswerInteger = 0;
            int score = 0;
            int attempts = 0;

            do
            {
                bool isCorrectAnswer = false;
                int firstRandomNumber, secondRandomNumber;
                do
                {
                    firstRandomNumber = random.Next(1, 101);
                    secondRandomNumber = random.Next(1, 101);
                } while (firstRandomNumber % secondRandomNumber != 0);
                do
                {
                    Console.WriteLine($"{firstRandomNumber} / {secondRandomNumber} = ");
                    do
                    {
                        isValidInput = int.TryParse(Console.ReadLine(), out userAnswerInteger);
                        if (isValidInput == false)
                        {
                            Console.WriteLine("------------------------");
                            Console.WriteLine("Invalid input, please enter a number.");
                            Console.WriteLine("------------------------");
                        }
                    } while (isValidInput == false);

                    attempts++;

                    if (userAnswerInteger == firstRandomNumber / secondRandomNumber)
                    {
                        Console.WriteLine("------------------------");
                        Console.WriteLine("Correct! Press any key to continue.");
                        Console.WriteLine("------------------------");
                        isCorrectAnswer = true;
                        exerciceCounter++;
                        score++;
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("------------------------");
                        Console.WriteLine("Wrong! Press any key to try again.");
                        Console.WriteLine("------------------------");
                        Console.ReadLine();
                    }
                } while (isCorrectAnswer == false);
            } while (exerciceCounter < 5);

            // add game info to List gameScores
            gameScores.Add(new GameModel { TimeStamp = DateTime.Now, ScoreOfGame = score, AttemptsOfGame = attempts, TypeOfGame = "division" });

            Console.WriteLine($"You had {score} correct answers out of {attempts} attempts.");
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadLine();
            Console.Clear();
        }

        internal void AdditionGame()
        {
            Console.Clear();
            Console.WriteLine(@"
------------------------
This is an addition game. (5 correct answers)
------------------------
");
            Random random = new Random();

            bool isValidInput;
            int exerciceCounter = 0;
            int userAnswerInteger = 0;
            int score = 0;
            int attempts = 0;

            do
            {
                bool isCorrectAnswer = false;
                int firstRandomNumber = random.Next(1, 11);
                int secondRandomNumber = random.Next(1, 11);
                do
                {
                    Console.WriteLine($"{firstRandomNumber} + {secondRandomNumber} = ");
                    do
                    {
                        isValidInput = int.TryParse(Console.ReadLine(), out userAnswerInteger);
                        if (isValidInput == false)
                        {
                            Console.WriteLine("------------------------");
                            Console.WriteLine("Invalid input, please enter a number.");
                            Console.WriteLine("------------------------");
                        }
                    } while (isValidInput == false);

                    attempts++;

                    if (userAnswerInteger == firstRandomNumber + secondRandomNumber)
                    {
                        Console.WriteLine("------------------------");
                        Console.WriteLine("Correct! Press any key to continue.");
                        Console.WriteLine("------------------------");
                        isCorrectAnswer = true;
                        exerciceCounter++;
                        score++;
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("------------------------");
                        Console.WriteLine("Wrong! Press any key to try again.");
                        Console.WriteLine("------------------------");
                        Console.ReadLine();
                    }
                } while (isCorrectAnswer == false);
            } while (exerciceCounter < 5);

            // add game info to List gameScores
            gameScores.Add(new GameModel { TimeStamp = DateTime.Now, ScoreOfGame = score, AttemptsOfGame = attempts, TypeOfGame = "addition" });

            Console.WriteLine($"You had {score} correct answers out of {attempts} attempts.");
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadLine();
            Console.Clear();
        }
        internal void SubtractionGame()
        {
            Console.Clear();
            Console.WriteLine(@"
------------------------
This is a subtraction game. (5 correct answers)
------------------------
");
            Random random = new Random();

            bool isValidInput;
            int exerciceCounter = 0;
            int userAnswerInteger = 0;
            int score = 0;
            int attempts = 0;

            do
            {
                bool isCorrectAnswer = false;
                int firstRandomNumber = random.Next(1, 11);
                int secondRandomNumber = random.Next(1, 11);
                do
                {
                    Console.WriteLine($"{firstRandomNumber} - {secondRandomNumber} = ");
                    do
                    {
                        isValidInput = int.TryParse(Console.ReadLine(), out userAnswerInteger);
                        if (isValidInput == false)
                        {
                            Console.WriteLine("------------------------");
                            Console.WriteLine("Invalid input, please enter a number.");
                            Console.WriteLine("------------------------");
                        }
                    } while (isValidInput == false);

                    attempts++;

                    if (userAnswerInteger == firstRandomNumber - secondRandomNumber)
                    {
                        Console.WriteLine("------------------------");
                        Console.WriteLine("Correct! Press any key to continue.");
                        Console.WriteLine("------------------------");
                        isCorrectAnswer = true;
                        exerciceCounter++;
                        score++;
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("------------------------");
                        Console.WriteLine("Wrong! Press any key to try again.");
                        Console.WriteLine("------------------------");
                        Console.ReadLine();
                    }
                } while (isCorrectAnswer == false);
            } while (exerciceCounter < 5);

            // add game info to List gameScores
            gameScores.Add(new GameModel { TimeStamp = DateTime.Now, ScoreOfGame = score, AttemptsOfGame = attempts, TypeOfGame = "subtraction" });

            Console.WriteLine($"You had {score} correct answers out of {attempts} attempts.");
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadLine();
            Console.Clear();
        }
        internal void MultiplicationGame()
        {
            Console.Clear();
            Console.WriteLine(@"
------------------------
This is a multiplication game. (5 correct answers)
------------------------
");
            Random random = new Random();

            bool isValidInput;
            int exerciceCounter = 0;
            int userAnswerInteger = 0;
            int score = 0;
            int attempts = 0;

            do
            {
                bool isCorrectAnswer = false;
                int firstRandomNumber = random.Next(1, 11);
                int secondRandomNumber = random.Next(1, 11);
                do
                {
                    Console.WriteLine($"{firstRandomNumber} * {secondRandomNumber} = ");
                    do
                    {
                        isValidInput = int.TryParse(Console.ReadLine(), out userAnswerInteger);
                        if (isValidInput == false)
                        {
                            Console.WriteLine("------------------------");
                            Console.WriteLine("Invalid input, please enter a number.");
                            Console.WriteLine("------------------------");
                        }
                    } while (isValidInput == false);

                    attempts++;

                    if (userAnswerInteger == firstRandomNumber * secondRandomNumber)
                    {
                        Console.WriteLine("------------------------");
                        Console.WriteLine("Correct! Press any key to continue.");
                        Console.WriteLine("------------------------");
                        isCorrectAnswer = true;
                        exerciceCounter++;
                        score++;
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("------------------------");
                        Console.WriteLine("Wrong! Press any key to try again.");
                        Console.WriteLine("------------------------");
                        Console.ReadLine();
                    }
                } while (isCorrectAnswer == false);
            } while (exerciceCounter < 5);

            // add game info to List gameScores
            gameScores.Add(new GameModel { TimeStamp = DateTime.Now, ScoreOfGame = score, AttemptsOfGame = attempts, TypeOfGame = "multiplication" });

            Console.WriteLine($"You had {score} correct answers out of {attempts} attempts.");
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadLine();
            Console.Clear();
        }
        internal void PrintGamesHistory()
        {
            Console.Clear();
            foreach (GameModel game in gameScores)
            {
                Console.WriteLine($"{game.TimeStamp} - {game.TypeOfGame} - {game.ScoreOfGame} out of {game.AttemptsOfGame}.");
            }
            Console.WriteLine("------------------------");
            Console.WriteLine();
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
