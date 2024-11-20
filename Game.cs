using mathGame.Natephor;

namespace MathGame;

public class Game
{
    private readonly List<GameRound> _gameRounds = [];
    private Difficulty _difficulty;

    public void Run()
    {
        UserInterface.Greeter();
        DifficultySelect();

        bool playerPlayed;
        do
        {
            playerPlayed = PlayOneRound();
        } while (playerPlayed);

        UserInterface.EndMessage();
    }

    private void DifficultySelect()
    {
        Console.Write("Choose Difficulty (1. Easy, 2. Normal, 3. Hard): ");
        if (int.TryParse(Console.ReadLine(), out var choice))
        {
            _difficulty = choice switch
            {
                1 => Difficulty.Easy,
                3 => Difficulty.Hard,
                _ => Difficulty.Normal
            };
        }
        else
            _difficulty = Difficulty.Normal;
    }

    private bool PlayOneRound()
    {
        string? choice;
        int selection;
        var random = new Random();
        do
        {
            UserInterface.DisplayMenu();
            choice = Console.ReadLine();
        } while (!int.TryParse(choice, out selection) || selection is > 7 or < 1);

        switch (selection)
        {
            case 5:
                selection = random.Next(1, 5);
                break;
            case 6:
                UserInterface.DisplayHistory(_gameRounds);
                return true;
            case 7:
                return false;
        }

        var maxValue = (int)_difficulty;
        var firstNumber = random.Next(0, maxValue);
        var secondNumber = random.Next(0, maxValue);

        var result = 0;
        var question = "";
        var operation = (Operation)selection;
        switch (operation)
        {
            case Operation.Addition:
                result = firstNumber + secondNumber;
                question = $"{firstNumber} + {secondNumber}";
                break;
            case Operation.Subtraction:
                result = secondNumber - firstNumber;
                question = $"{secondNumber} - {firstNumber}";
                break;
            case Operation.Multiplication:
                result = firstNumber * secondNumber;
                question = $"{firstNumber} * {secondNumber}";
                break;
            case Operation.Division:
                secondNumber = random.Next(1, maxValue);
                while (firstNumber % secondNumber != 0)
                {
                    firstNumber = random.Next(0, maxValue);
                    secondNumber = random.Next(1, maxValue);
                }

                result = firstNumber / secondNumber;
                question = $"{firstNumber} / {secondNumber}";
                break;
        }

        int answer;
        string? userInput;
        do
        {
            Console.Write($"{question} = ");
            userInput = Console.ReadLine();
        } while (!int.TryParse(userInput, out answer));

        UserInterface.DisplayRoundResult(question, result, answer);
        _gameRounds.Add(new GameRound(question, result, answer));
        return true;
    }
}

internal enum Operation
{
    Addition = 1,
    Subtraction,
    Multiplication,
    Division,
}

internal enum Difficulty
{
    Easy = 11,
    Normal = 101,
    Hard = 1001
}

public record GameRound(string Question, int Result, int UserAnswer);