using MathGame.UserInput;

namespace MathGame.Services;

public class GameController
{
    private Input _input = new Input();
    private Dictionary<string, string> _additionQuestions = new()
    {
        { "5 + 7", "12" },
        { "6 + 8", "14" },
        { "2 + 9", "11" }
    };

    private Dictionary<string, string> _subtractionQuestions = new()
    {
        { "15 - 7", "8" },
        { "16 - 8", "8" },
        { "12 - 9", "3" }
    };

    private Dictionary<string, string> _multiplicationQuestions = new()
    {
        { "5 * 7", "35" },
        { "6 * 8", "42" },
        { "2 * 9", "18" }
    };

    private Dictionary<string, string> _divisionQuestions = new()
    {
        { "15 / 3", "5" },
        { "16 / 4", "4" },
        { "27 / 9", "3" }
    };

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
                    PlayGameRound(Operation.Addition, _additionQuestions);
                    break;
                case (int)Operation.Subtraction:
                    PlayGameRound(Operation.Subtraction, _subtractionQuestions);
                    break;
                case (int)Operation.Multiplication:
                    PlayGameRound(Operation.Multiplication, _multiplicationQuestions);
                    break;
                case (int)Operation.Division:
                    PlayGameRound(Operation.Division, _divisionQuestions);
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

    private void PlayGameRound(Operation operation, Dictionary<string, string> questions)
    {
        string answer;
        int count = 0, score = 0;

        foreach (var question in questions)
        {
            Console.WriteLine(question.Key);
            answer = _input.GetInput();

            if (answer == question.Value)
            {
                Console.WriteLine("Correct!");
                score++;
            }
            else
            {
                Console.WriteLine("Wrong!");
                Console.WriteLine($"The answer was {question.Value} ");
            }

            Console.WriteLine("Press Enter to continue: ");
            Console.ReadLine();
            count++;
        }

        Console.WriteLine($"Your total score was {score} out of {count}");
        _gameHistory.Add($"Game: {operation} - Score: {score}");
        Console.WriteLine("Press Enter to continue: ");
        Console.ReadLine();
    }
}
