using MathGame.Services;
using MathGame.UserInput;

namespace MathGame.Controllers;

public class GameController
{
    private Input _input = new Input();
    private Calculator _calculator = new Calculator();

    List<string> _gameHistory = new();

    private void Menu()
    {
        Console.Clear();
        Console.WriteLine("0 to EndGame");
        Console.WriteLine("1 to Play Addition Games");
        Console.WriteLine("2 to Play Subtraction Games");
        Console.WriteLine("3 to Play Multiplication Games");
        Console.WriteLine("4 to Play Division Games");
        Console.WriteLine("5 to View History");
        Console.WriteLine("\nSelect your choice");
    }

    public void Play()
    {
        Menu();
        var choice = _input.GetChoice();

        while (choice != 0)
        {
            switch (choice)
            {
                case (int)Operation.Addition:
                    PlayGameRound(Operation.Addition);
                    break;
                case (int)Operation.Subtraction:
                    PlayGameRound(Operation.Subtraction);
                    break;
                case (int)Operation.Multiplication:
                    PlayGameRound(Operation.Multiplication);
                    break;
                case (int)Operation.Division:
                    PlayGameRound(Operation.Division);
                    break;
                case (int)Operation.History:
                    ViewHistory();
                    break;
                default:
                    DisplayInvalidChoiceError();
                    break;
            }

            Menu();
            choice = _input.GetChoice();
        }
    }

    private void ViewHistory()
    {
        Console.Clear();
        foreach (var game in _gameHistory)
        {
            Console.WriteLine(game);
        }

        Console.WriteLine("Press Enter to continue");
        Console.ReadLine();
    }

    private static void DisplayInvalidChoiceError()
    {
        Console.WriteLine("Error! Invalid Choice!");
        Console.WriteLine("Press Enter to continue");
        Console.ReadLine();
    }

    private void PlayGameRound(Operation operation)
    {
        int count = 0, score = 0;

        for (int i = 0; i < 10; i++)
        {
            var numA = Random.Shared.Next(1, 10);
            var numB = Random.Shared.Next(1, 10);
            if (operation == Operation.Division)
            {
                numA = Random.Shared.Next(10, 100);
                numB = Random.Shared.Next(1, 10);

                while ((double)numA / numB != numA / numB)
                {
                    numA = Random.Shared.Next(10, 100);
                    numB = Random.Shared.Next(1, 10);
                }
            }

            var question = CreateQuestion(numA, numB, operation);

            var answer = _calculator.Calculate(numA, numB, operation);
            Console.WriteLine(question);
            var userAnswer = _input.GetInput();

            if (userAnswer == answer.ToString())
            {
                Console.WriteLine("Correct!");
                score++;
            }
            else
            {
                Console.WriteLine("Wrong!");
                Console.WriteLine($"The answer was {answer}");
            }

            Console.WriteLine("Press Enter to continue: ");
            Console.ReadLine();
            count++;
        }

        Console.WriteLine($"Your total score was {score} out of {count}");
        _gameHistory.Add($"Game - {operation} - Score: {score} out of {count}");
        Console.WriteLine("Press Enter to continue: ");
        Console.ReadLine();
    }

    private string CreateQuestion(int numA, int numB, Operation operation)
    {
        switch (operation)
        {
            case Operation.Addition:
                return $"{numA} + {numB}";
            case Operation.Subtraction:
                return $"{numA} - {numB}";
            case Operation.Multiplication:
                return $"{numA} * {numB}";
            case Operation.Division:
                return $"{numA} / {numB}";
            default:
                return "No question";
        }
    }
}
