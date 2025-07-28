using MathGame.Models;

namespace MathGame;
internal class MainGame
{
    internal (int, GameType) PlayGame(int score, int selectedOp)
    {
        GameEngine gameEngine = new();

        Random range = new Random();
        int num1 = range.Next(1, 100);
        int num2 = range.Next(1, 100);

        if (selectedOp == 4)
        {
            while (num1 % num2 != 0)
            {
                num1 = range.Next(1, 100);
                num2 = range.Next(1, 100);
            }
        }

        int answer = 0;
        string currentGame = "";
        GameType game;
        switch (selectedOp)
        {
            case 1:
                (game, currentGame, answer) = gameEngine.AdditionGame(num1, num2);
                break;
            case 2:
                (game, currentGame, answer) = gameEngine.SubtractionGame(num1, num2);
                break;
            case 3:
                (game, currentGame, answer) = gameEngine.MultiplicationGame(num1, num2);
                break;
            case 4:
                (game, currentGame, answer) = gameEngine.DivisionGame(num1, num2);
                break;
            default:
                throw new InvalidOperationException("Invalid operation selected.");
        }

        Console.Clear();
        Console.WriteLine($"{game} Game");
        Console.Write($"What is {currentGame}: ");

        string userStringAnswer = Console.ReadLine();

        while (string.IsNullOrEmpty(userStringAnswer) || !Int32.TryParse(userStringAnswer, out _))
        {
            Console.WriteLine("Please enter a valid answer: ");
            userStringAnswer = Console.ReadLine();
        }

        int userAnswer = Convert.ToInt32(userStringAnswer);

        if (userAnswer == answer)
        {
            //gameHistory.Add($"{currentGame}: {userAnswer} \n Correct\n");
            Console.WriteLine($"Your answer is correct! Press any key to continue...\n");
            score++;
        }
        else
        {
            Console.WriteLine("Your answer is incorrect! Press any key to continue...\n");
        }
        Console.ReadLine();
        return (score, game);
    }

}
