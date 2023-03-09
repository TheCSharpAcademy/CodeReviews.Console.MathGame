namespace MathGame.chad1082;

internal class GameEngine
{
    internal void AdditionGame(string v)
    {
        Console.Clear();
        Console.WriteLine(v);

        var random = new Random();

        int firstNumber;
        int secondNumber;

        int score = 0;

        for (int i = 1; i < 5; i++)
        {
            Console.WriteLine($"Round {i}");

            firstNumber = random.Next(1, 11);
            secondNumber = random.Next(1, 11);

            int correctAnswer = firstNumber + secondNumber;

            int playerAnswer;
            bool answerParsed;
            do
            {
                Console.WriteLine($"What is {firstNumber} + {secondNumber} ?");
                answerParsed = int.TryParse(Console.ReadLine(), out playerAnswer);
                if (answerParsed)
                {
                    if (playerAnswer == correctAnswer)
                    {
                        Console.WriteLine($"The answer {playerAnswer} is correct! Well done!\nPress the enter key to continue");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine($"You answered {playerAnswer}, the correct answer was {correctAnswer}! Try Again!\nPress the enter key to continue");
                    }
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Please enter your answer in a numeric format");
                }
            } while (!answerParsed);
        }

        Helpers.AddGameScore(score, "Addition");
        Console.WriteLine($"You scored: {score} out of 4!");
        Console.WriteLine("Press Enter to return to the main menu.");
        Console.ReadLine();

    }

    internal void SubtractionGame(string v)
    {
        Console.Clear();
        Console.WriteLine(v);

        var random = new Random();

        int firstNumber;
        int secondNumber;

        int score = 0;

        for (int i = 1; i < 5; i++)
        {
            Console.WriteLine($"Round {i}");

            firstNumber = random.Next(1, 11);
            secondNumber = random.Next(1, 11);

            int correctAnswer = firstNumber - secondNumber;

            int playerAnswer;
            bool answerParsed;
            do
            {
                Console.WriteLine($"What is {firstNumber} - {secondNumber} ?");
                answerParsed = int.TryParse(Console.ReadLine(), out playerAnswer);
                if (answerParsed)
                {
                    if (playerAnswer == correctAnswer)
                    {
                        Console.WriteLine($"The answer {playerAnswer} is correct! Well done!\nPress the enter key to continue");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine($"You answered {playerAnswer}, the correct answer was {correctAnswer}! Try Again!\nPress the enter key to continue");
                    }
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Please enter your answer in a numeric format");
                }
            } while (!answerParsed);


        }
        Helpers.AddGameScore(score, "Subtraction");
        Console.WriteLine($"You scored: {score} out of 4!");
        Console.WriteLine("Press Enter to return to the main menu.");
        Console.ReadLine();


    }

    internal void MultiplicationGame(string v)
    {
        Console.Clear();
        Console.WriteLine(v);

        var random = new Random();

        int firstNumber;
        int secondNumber;

        int score = 0;

        for (int i = 1; i < 5; i++)
        {
            Console.WriteLine($"Round {i}");

            firstNumber = random.Next(1, 11);
            secondNumber = random.Next(1, 11);

            int correctAnswer = firstNumber * secondNumber;

            int playerAnswer;
            bool answerParsed;
            do
            {
                Console.WriteLine($"What is {firstNumber} x {secondNumber} ?");
                answerParsed = int.TryParse(Console.ReadLine(), out playerAnswer);
                if (answerParsed)
                {
                    if (playerAnswer == correctAnswer)
                    {
                        Console.WriteLine($"The answer {playerAnswer} is correct! Well done!\nPress the enter key to continue");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine($"You answered {playerAnswer}, the correct answer was {correctAnswer}! Try Again!\nPress the enter key to continue");
                    }
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Please enter your answer in a numeric format");
                }
            } while (!answerParsed);

        }
        Helpers.AddGameScore(score, "Multiplication");
        Console.WriteLine($"You scored: {score} out of 4!");
        Console.WriteLine("Press Enter to return to the main menu.");
        Console.ReadLine();
    }

    internal void DivisionGame(string v)
    {
        Console.Clear();
        Console.WriteLine(v);

        int firstNumber;
        int secondNumber;

        int score = 0;

        for (int i = 1; i < 5; i++)
        {
            Console.WriteLine($"Round {i}");

            var gameNumbers = Helpers.GetDivisionNumbers();

            firstNumber = gameNumbers[0];
            secondNumber = gameNumbers[1];

            int correctAnswer = firstNumber / secondNumber;

            int playerAnswer;
            bool answerParsed;
            do
            {
                Console.WriteLine($"What is {firstNumber} / {secondNumber} ?");
                answerParsed = int.TryParse(Console.ReadLine(), out playerAnswer);
                if (answerParsed)
                {
                    if (playerAnswer == correctAnswer)
                    {
                        Console.WriteLine($"The answer {playerAnswer} is correct! Well done!\nPress the enter key to continue");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine($"You answered {playerAnswer}, the correct answer was {correctAnswer}! Try Again!\nPress the enter key to continue");
                    }
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Please enter your answer in a numeric format");
                }
            } while (!answerParsed);

        }
        Helpers.AddGameScore(score, "Division");
        Console.WriteLine($"You scored: {score} out of 4!");
        Console.WriteLine("Press Enter to return to the main menu.");
        Console.ReadLine();

    }


}
