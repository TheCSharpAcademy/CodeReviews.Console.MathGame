using System.Diagnostics;
using Math_Game_lib.Model;

namespace Math_Game_lib
{
    internal class GameEngine
    {
        internal void Addition()
        {
            Console.Clear();
            Console.WriteLine("Addition game");

            int numberOfQuestions = Helpers.NumberOfQuestions();

            int[] numbers = Helpers.ChooseGameLevel(numberOfQuestions, 'a', out GameDifficulty difficulty);

            Stopwatch stopwatch = Stopwatch.StartNew(); // start a stopwatch

            int score = Helpers.CheckAnswer(numbers, 'a');

            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;

            Helpers.FillGameDetails(score, numberOfQuestions, GameType.Addition, difficulty, elapsedTime);
        }

        internal void Subtraction()
        {
            Console.Clear();
            Console.WriteLine("Subtraction game");

            int numberOfQuestions = Helpers.NumberOfQuestions();

            int[] numbers = Helpers.ChooseGameLevel(numberOfQuestions, 'a', out GameDifficulty difficulty);

            Stopwatch stopwatch = Stopwatch.StartNew(); // start a stopwatch

            int score = Helpers.CheckAnswer(numbers, 's');

            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;

            Helpers.FillGameDetails(score, numberOfQuestions, GameType.Subtraction, difficulty, elapsedTime);
        }

        internal void Multiplication()
        {
            Console.Clear();
            Console.WriteLine("Multiplication game");

            int numberOfQuestions = Helpers.NumberOfQuestions();

            int[] numbers = Helpers.ChooseGameLevel(numberOfQuestions, 'a', out GameDifficulty difficulty);

            Stopwatch stopwatch = Stopwatch.StartNew(); // start a stopwatch


            int score = Helpers.CheckAnswer(numbers, 'm');


            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;

            Helpers.FillGameDetails(score, numberOfQuestions, GameType.Multiplication, difficulty, elapsedTime);
        }

        internal void Division()
        {
            Console.Clear();
            Console.WriteLine("Division game");

            int numberOfQuestions = Helpers.NumberOfQuestions();

            int[] numbers = Helpers.ChooseGameLevel(numberOfQuestions, 'd', out GameDifficulty difficulty);

            Stopwatch stopwatch = Stopwatch.StartNew(); // start a stopwatch

            int score = Helpers.CheckDivisionAnswer(numbers);

            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;

            Helpers.FillGameDetails(score, numberOfQuestions, GameType.Division, difficulty, elapsedTime);
        }

        internal void RandomGame()
        {
            Random random = new Random();
            int gameChoice = random.Next(1, 4);

            switch (gameChoice)
            {
                case 1:
                    Addition();
                    break;

                case 2:
                    Subtraction();
                    break;

                case 3:
                    Multiplication();
                    break;

                case 4:
                    Division();
                    break;
            }
        }
    }
}
