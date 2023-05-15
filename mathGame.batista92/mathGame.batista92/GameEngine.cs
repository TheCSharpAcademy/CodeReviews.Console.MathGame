using mathGame.batista92.Models;

namespace mathGame.batista92;

internal class GameEngine
{
    int score = 0;
    bool isRandomGame = false;
    Random random = new Random();
    internal void AdditionGame(string msg, int numberOfQuestions)
    {        
        for (int i = 0; i < numberOfQuestions; i++)
        {
            Console.Clear();
            Console.WriteLine(msg);

            int firstNumber = random.Next(1, 9);
            int secondNumber = random.Next(1, 9);

            Console.WriteLine($"{firstNumber} + {secondNumber}");
            var result = Console.ReadLine();
            result = Helpers.ValidadeResult(result);

            if (int.Parse(result) == firstNumber + secondNumber)
            {
                Console.WriteLine("You answer was correct! Type any key for next question");
                score++;
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Your answer war incorrect. Type any key for next question");
                Console.ReadKey();
            }
        }
        if (!isRandomGame)
        {
            Helpers.GameOver(score, GameType.Addition);
            score = 0;
        }
    }

    internal void SubtractionGame(string msg, int numberOfQuestions)
    {
        for (int i = 0; i < numberOfQuestions; i++)
        {
            Console.Clear();
            Console.WriteLine(msg);

            int firstNumber = random.Next(1, 9);
            int secondNumber = random.Next(1, 9);

            Console.WriteLine($"{firstNumber} - {secondNumber}");
            var result = Console.ReadLine();
            result = Helpers.ValidadeResult(result);

            if (int.Parse(result) == firstNumber - secondNumber)
            {
                Console.WriteLine("You answer was correct! Type any key for next question");
                score++;
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Your answer war incorrect. Type any key for next question");
                Console.ReadKey();
            }
        }

        if (!isRandomGame)
        {
            Helpers.GameOver(score, GameType.Subtraction);
            score = 0;
        }
    }

    internal void MultiplicationGame(string msg, int numberOfQuestions)
    {
        for (int i = 0; i < numberOfQuestions; i++)
        {
            Console.Clear();
            Console.WriteLine(msg);

            int firstNumber = random.Next(1, 9);
            int secondNumber = random.Next(1, 9);

            Console.WriteLine($"{firstNumber} * {secondNumber}");
            var result = Console.ReadLine();
            result = Helpers.ValidadeResult(result);

            if (int.Parse(result) == firstNumber * secondNumber)
            {
                Console.WriteLine("You answer was correct! Type any key for next question");
                score++;
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Your answer war incorrect. Type any key for next question");
                Console.ReadKey();
            }
        }
        if (!isRandomGame)
        {
            Helpers.GameOver(score, GameType.Multuplication);
            score = 0;
        }
    }

    internal void DivisionGame(string msg, int numberOfQuestions)
    {
        for (int i = 0; i < numberOfQuestions; i++)
        {
            Console.Clear();
            Console.WriteLine(msg);

            var divisionNumbers = Helpers.GetDivisionNumbers();
            int firstNumber = divisionNumbers[0];
            int secondNumber = divisionNumbers[1];

            Console.WriteLine($"{firstNumber} / {secondNumber}");
            var result = Console.ReadLine();
            result = Helpers.ValidadeResult(result);

            if (int.Parse(result) == firstNumber / secondNumber)
            {
                Console.WriteLine("You answer was correct! Type any key for next question");
                score++;
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Your answer war incorrect. Type any key for next question");
                Console.ReadKey();
            }
        }
        if (!isRandomGame)
        {
            Helpers.GameOver(score, GameType.Division);
            score = 0;
        }
    }

    internal void RandomGame(string msg, int numberOfQuestions)
    {
        isRandomGame = true;
        for (int i = 0; i < numberOfQuestions; i++)
        {
            var gameType = random.Next(1, 5);

            if (gameType == 1)
                AdditionGame(msg, 1);

            if (gameType == 2)
                SubtractionGame(msg, 1);

            if (gameType == 3)
                MultiplicationGame(msg, 1);

            if (gameType == 4)
                DivisionGame(msg, 1);
        }

        Helpers.GameOver(score, GameType.Random);
        
        score = 0;
        isRandomGame = false;
    }
}
