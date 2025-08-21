using MyFirstProgram.Models;

namespace MyFirstProgram
{
    internal class GameEngine
    {
        bool validNumber;

        internal void AdditionGame(int lowerLimit, int upperLimit, DifficultyLevel difficulty)
        {
            Console.Clear();
            Console.WriteLine("Addition game selected");
            Random random = new Random();
            int firstNumber;
            int secondNumber;
            int score = 0;
            for (int i = 0; i < 5; i++)
            {
                firstNumber = random.Next(lowerLimit, upperLimit);
                secondNumber = random.Next(lowerLimit, upperLimit);
                do
                {
                    Console.WriteLine($"\n{firstNumber} + {secondNumber}");
                    Console.Write("Guess: ");
                    string readInput = Console.ReadLine();
                    validNumber = int.TryParse(readInput, out int guessedNumber);
                    if (!validNumber)
                    {
                        Console.WriteLine("Your input is not valid. Please enter a number");
                    }
                    else
                    {
                        int result = firstNumber + secondNumber;
                        if (guessedNumber == result)
                        {
                            Console.WriteLine("You guessed it correct. Type any key for the next question");
                            score++;
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Your guess was incorrect. Type any key for the next question");
                            Console.ReadLine();
                        }
                    }

                } while (validNumber == false);
            }

            Helpers.AddToHistory(score, GameType.Addition, difficulty);

            Console.WriteLine($"\nYou scored {score} out of five. Press any key...");
            Console.ReadLine();
        }

        internal void SubtractionGame(int lowerLimit, int upperLimit, DifficultyLevel difficulty)
        {
            Console.Clear();
            Console.WriteLine("Subtraction game selected");
            Random random = new Random();
            int firstNumber;
            int secondNumber;
            int score = 0;
            for (int i = 0; i < 5; i++)
            {
                firstNumber = random.Next(lowerLimit, upperLimit);
                secondNumber = random.Next(lowerLimit, upperLimit);
                do
                {
                    Console.WriteLine($"\n{firstNumber} - {secondNumber}");
                    Console.Write("Guess: ");
                    string readInput = Console.ReadLine();
                    validNumber = int.TryParse(readInput, out int guessedNumber);
                    if (!validNumber)
                    {
                        Console.WriteLine("Your input is not valid. Please enter a number");
                    }
                    else
                    {
                        int result = firstNumber - secondNumber;
                        if (guessedNumber == result)
                        {
                            Console.WriteLine("You guessed it correct. Type any key for the next question");
                            score++;
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Your guess was incorrect. Type any key for the next question");
                            Console.ReadLine();
                        }
                    }
                } while (validNumber == false);
            }

            Helpers.AddToHistory(score, GameType.Subtraction, difficulty);

            Console.WriteLine($"\nYou scored {score} out of five. Press any key...");
            Console.ReadLine();
        }

        internal void MultiplicationGame(int lowerLimit, int upperLimit, DifficultyLevel difficulty)
        {
            Console.Clear();
            Console.WriteLine("Multiplication game selected");
            Random random = new Random();
            int firstNumber;
            int secondNumber;
            int score = 0;
            for (int i = 0; i < 5; i++)
            {
                firstNumber = random.Next(lowerLimit, upperLimit);
                secondNumber = random.Next(lowerLimit, upperLimit);
                do
                {
                    Console.WriteLine($"\n{firstNumber} * {secondNumber}");
                    Console.Write("Guess: ");
                    string readInput = Console.ReadLine();
                    validNumber = int.TryParse(readInput, out int guessedNumber);
                    if (!validNumber)
                    {
                        Console.WriteLine("Your input is not valid. Please enter a number");
                    }
                    else
                    {
                        int result = firstNumber * secondNumber;
                        if (guessedNumber == result)
                        {
                            Console.WriteLine("You guessed it correct. Type any key for the next question");
                            score++;
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Your guess was incorrect. Type any key for the next question");
                            Console.ReadLine();
                        }
                    }

                } while (validNumber == false);
            }

            Helpers.AddToHistory(score, GameType.Multiplication, difficulty);

            Console.WriteLine($"\nYou scored {score} out of five. Press any key...");
            Console.ReadLine();
        }

        internal void DivisionGame(int lowerLimit, int upperLimit, DifficultyLevel difficulty)
        {
            Console.Clear();
            Console.WriteLine("Division game selected");
            Random random = new Random();
            int firstNumber;
            int secondNumber;
            int score = 0;
            for (int i = 0; i < 5; i++)
            {
                firstNumber = random.Next(lowerLimit, upperLimit);
                secondNumber = random.Next(lowerLimit, upperLimit);
                do
                {
                    Console.WriteLine($"\n{firstNumber} / {secondNumber}");
                    Console.Write("Guess: ");
                    string readInput = Console.ReadLine();
                    validNumber = int.TryParse(readInput, out int guessedNumber);
                    if (!validNumber)
                    {
                        Console.WriteLine("Your input is not valid. Please enter a number");
                    }
                    else
                    {
                        int result = firstNumber / secondNumber;
                        if (guessedNumber == result)
                        {
                            Console.WriteLine("You guessed it correct. Type any key for the next question");
                            score++;
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Your guess was incorrect. Type any key for the next question");
                            Console.ReadLine();
                        }
                    }

                } while (validNumber == false);
            }

            Helpers.AddToHistory(score, GameType.Division, difficulty);

            Console.WriteLine($"\nYou scored {score} out of five. Press any key...");
            Console.ReadLine();
        }
    }
}
