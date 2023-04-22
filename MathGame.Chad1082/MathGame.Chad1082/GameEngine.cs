namespace MathGame.chad1082;

internal class GameEngine
{
    internal void StartGame(GameType gameType)
    {
        Console.Clear();
        Console.WriteLine($"{gameType} Game\nAll answers should be whole numbers!\n");

        int firstNumber;
        int secondNumber;

        int score = 0;

        for (int i = 1; i < 5; i++)
        {
            Console.WriteLine($"Round {i}");

            var gameNumbers = Helpers.GetNumbers(gameType);

            firstNumber = gameNumbers[0];
            secondNumber = gameNumbers[1];

            int playerAnswer;
            bool answerParsed;
            do
            {
                int correctAnswer = GenerateAnswer(firstNumber, secondNumber, gameType);
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
        Helpers.AddGameScore(score, gameType);
        Console.WriteLine($"You scored: {score} out of 4!");
        Console.WriteLine("Press Enter to return to the main menu.");
        Console.ReadLine();
    }

    private int GenerateAnswer(int firstNumber, int secondNumber, GameType gameType)
    {
        int answer = 0;
        switch (gameType)
        {
            case GameType.Addition:
                Console.WriteLine($"What is {firstNumber} + {secondNumber} ?");
                answer = firstNumber + secondNumber;
                break;
            case GameType.Subtraction:
                Console.WriteLine($"What is {firstNumber} - {secondNumber} ?");
                answer = firstNumber - secondNumber;
                break;
            case GameType.Multiplication:
                Console.WriteLine($"What is {firstNumber} x {secondNumber} ?");
                answer = firstNumber * secondNumber;
                break;
            case GameType.Division:
                Console.WriteLine($"What is {firstNumber} / {secondNumber} ?");
                answer = firstNumber / secondNumber;
                break;
        }
        return answer;
    }
}
