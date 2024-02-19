using MathGame.Models;
namespace MathGame
{
    internal class GameEngine
    {
        int numQuestions;
        string? difficulty;
        internal void AdditionGame()
        {
            Menu menu = new Menu();
            string? result;
            numQuestions = Helpers.QuestionsCount();
            difficulty = menu.ChooseDifficulty();
            int number1 = 0;
            int number2 = 0;
            int points = 0;

            for (int i = 0; i < numQuestions; i++)
            {
                int[] Numbers = Helpers.ChangeDifficulty(number1, number2, difficulty);
                Console.Clear();
                number1 = Numbers[0];
                number2 = Numbers[1];
                Console.WriteLine($"Addition Game: {points} points");
                Console.WriteLine($"{number1} + {number2} = ");
                result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (Convert.ToInt32(result) == (number1 + number2))
                {
                    Console.WriteLine("Correct! + 1 point");
                    Console.ReadLine();
                    points++;
                }
                else
                {
                    Console.WriteLine("Incorrect.");
                    Console.ReadLine();
                }
            }

            Console.WriteLine($"The End. You scored {points} points. Press enter to go back to main menu.");
            Console.ReadLine();
            Helpers.AddToHistory(GameType.Addition, points, difficulty);
        }

        internal void SubtractionGame()
        {
            Menu menu = new Menu();
            string? result;
            numQuestions = Helpers.QuestionsCount();
            difficulty = menu.ChooseDifficulty();
            int number1 = 0;
            int number2 = 0;
            int points = 0;

            for (int i = 0; i < numQuestions; i++)
            {
                int[] Numbers = Helpers.ChangeDifficulty(number1, number2, difficulty);
                Console.Clear();
                number1 = Numbers[0];
                number2 = Numbers[1];

                Console.WriteLine($"Subtraction Game: {points} points");
                Console.WriteLine($"{number1} - {number2} = ");
                result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (Convert.ToInt32(result) == (number1 - number2))
                {
                    Console.WriteLine("Correct! + 1 point");
                    Console.ReadLine();
                    points++;
                }
                else
                {
                    Console.WriteLine("Incorrect.");
                    Console.ReadLine();
                }
            }

            Console.WriteLine($"The End. You scored {points} points. Press enter to go back to main menu.");
            Console.ReadLine();
            Helpers.AddToHistory(GameType.Subtraction, points, difficulty);
        }

        internal void MultiplicationGame()
        {
            Menu menu = new Menu();
            string? result;
            numQuestions = Helpers.QuestionsCount();
            difficulty = menu.ChooseDifficulty();
            int number1 = 0;
            int number2 = 0;
            int points = 0;

            for (int i = 0; i < numQuestions; i++)
            {
                int[] Numbers = Helpers.ChangeDifficulty(number1, number2, difficulty);
                Console.Clear();
                number1 = Numbers[0];
                number2 = Numbers[1];

                Console.WriteLine($"Multiplication Game: {points} points");
                Console.WriteLine($"{number1} * {number2} = ");
                result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (Convert.ToInt32(result) == (number1 * number2))
                {
                    Console.WriteLine("Correct! + 1 point");
                    Console.ReadLine();
                    points++;
                }
                else
                {
                    Console.WriteLine("Incorrect.");
                    Console.ReadLine();
                }
            }

            Console.WriteLine($"The End. You scored {points} points. Press enter to go back to main menu.");
            Console.ReadLine();
            Helpers.AddToHistory(GameType.Multiplication, points, difficulty);
        }

        internal void DivisionGame()
        {
            Menu menu = new Menu();
            string? result;
            numQuestions = Helpers.QuestionsCount();
            difficulty = menu.ChooseDifficulty();
            int points = 0;

            for (int i = 0; i < numQuestions; i++)
            {
                int[] Numbers = Helpers.DivisionNumbers(difficulty);
                int number1 = Numbers[0];
                int number2 = Numbers[1];
                Console.Clear();

                Console.WriteLine($"Division Game: {points} points");
                Console.WriteLine($"{number1} / {number2} = ");
                result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (Convert.ToInt32(result) == (number1 / number2))
                {
                    Console.WriteLine("Correct! + 1 point");
                    Console.ReadLine();
                    points++;
                }
                else
                {
                    Console.WriteLine("Incorrect.");
                    Console.ReadLine();
                }
            }

            Console.WriteLine($"The End. You scored {points} points. Press enter to go back to main menu.");
            Console.ReadLine();
            Helpers.AddToHistory(GameType.Division, points, difficulty);
        }

        internal void RandomGame()
        {
            Menu menu = new Menu();
            numQuestions = Helpers.QuestionsCount();
            difficulty = menu.ChooseDifficulty();
            Random random = new Random();
            int number1 = 0;
            int number2 = 0;
            int points = 0;
            string? result;
            for (int i = 0; i < numQuestions; i++)
            {
                int rng = random.Next(0, 5);
                if (rng == 1)
                {
                    int[] Numbers = Helpers.ChangeDifficulty(number1, number2, difficulty);
                    Console.Clear();
                    number1 = Numbers[0];
                    number2 = Numbers[1];
                    Console.WriteLine($"Addition Game: {points} points");
                    Console.WriteLine($"{number1} + {number2} = ");
                    result = Console.ReadLine();

                    result = Helpers.ValidateResult(result);

                    if (Convert.ToInt32(result) == (number1 + number2))
                    {
                        Console.WriteLine("Correct! + 1 point");
                        Console.ReadLine();
                        points++;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect.");
                        Console.ReadLine();
                    }

                }
                else if (rng == 2)
                {
                    int[] Numbers = Helpers.ChangeDifficulty(number1, number2, difficulty);
                    Console.Clear();
                    number1 = Numbers[0];
                    number2 = Numbers[1];

                    Console.WriteLine($"Subtraction Game: {points} points");
                    Console.WriteLine($"{number1} - {number2} = ");
                    result = Console.ReadLine();
                    result = Helpers.ValidateResult(result);

                    if (Convert.ToInt32(result) == (number1 - number2))
                    {
                        Console.WriteLine("Correct! + 1 point");
                        Console.ReadLine();
                        points++;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect.");
                        Console.ReadLine();
                    }
                }
                else if (rng == 3)
                {
                    int[] Numbers = Helpers.ChangeDifficulty(number1, number2, difficulty);
                    Console.Clear();
                    number1 = Numbers[0];
                    number2 = Numbers[1];

                    Console.WriteLine($"Multiplication Game: {points} points");
                    Console.WriteLine($"{number1} * {number2} = ");
                    result = Console.ReadLine();

                    result = Helpers.ValidateResult(result);

                    if (Convert.ToInt32(result) == (number1 * number2))
                    {
                        Console.WriteLine("Correct! + 1 point");
                        Console.ReadLine();
                        points++;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect.");
                        Console.ReadLine();
                    }
                }
                else
                {
                    int[] Numbers = Helpers.DivisionNumbers(difficulty);
                    number1 = Numbers[0];
                    number2 = Numbers[1];
                    Console.Clear();

                    Console.WriteLine($"Division Game: {points} points");
                    Console.WriteLine($"{number1} / {number2} = ");
                    result = Console.ReadLine();

                    result = Helpers.ValidateResult(result);

                    if (Convert.ToInt32(result) == (number1 / number2))
                    {
                        Console.WriteLine("Correct! + 1 point");
                        Console.ReadLine();
                        points++;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect.");
                        Console.ReadLine();
                    }
                }
            }
            Console.WriteLine($"The End. You scored {points} points. Press enter to go back to main menu.");
            Console.ReadLine();
            Helpers.AddToHistory(GameType.Random, points, difficulty);
        }
    }
}