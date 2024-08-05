namespace MathGame;

public enum Options 
{ 
    Unknown = 0, 
    Addition = 1, 
    Subtraction = 2, 
    Multiplication = 3, 
    Division = 4, 
    RandomOperation = 5, 
    NumberOfGames = 6, 
    History = 7, 
    Difficulty = 8, 
    Quit = 9, 
}
public enum Difficulty { Easy = 1, Medium = 2, Hard = 3 }
internal class Game
{
    List<GameRecord> history = new List<GameRecord>();
    int idRecord = 1;

    // Default Difficulty
    Difficulty difficulty = Difficulty.Medium;

    // Calculate the time the user spends playing
    DateTime init;
    DateTime end;

    // Default Number of Games
    int maxGames = 5;

    bool continueRunning = true;

    public Game() { }

    public void Run()
    {
        while (continueRunning)
        {
            Options optionSelected = UserInterface.ShowMenu();

            continueRunning = HandleOption(optionSelected);
        }
    }

    private bool HandleOption(Options optionSelected)
    {
        switch (optionSelected)
        {
            case Options.NumberOfGames:
                maxGames = UserInterface.ShowNumberOfGames();
                break;
            case Options.History:
                UserInterface.ShowHistory(history);
                break;
            case Options.Difficulty:
                difficulty = UserInterface.ShowDifficultyOptions();
                break;
            case Options.RandomOperation:
                PerformMathOperation(optionSelected);
                break;
            case Options.Quit:
                return false;
            default:
                PerformMathOperation(optionSelected);
                break;
        }

        return true;
    }

    private void PerformMathOperation(Options optionSelected)
    {
        int hits = 0;
        init = DateTime.Now;

        for (int i = 0; i < maxGames; i++)
        {
            Options operationToDisplay = (optionSelected == Options.RandomOperation) ? GetRandomOperation() : optionSelected;

            Operation operation = operationToDisplay switch
            {
                Options.Addition => new Addition(difficulty),
                Options.Subtraction => new Subtraction(difficulty),
                Options.Multiplication => new Multiplication(difficulty),
                Options.Division => new Division(difficulty),
                _ => throw new Exception($"The option {Enum.GetName(typeof(Options), optionSelected)} isn't valid")
            };
            if (InputValidator.OperationValidator(operation, UserInterface.ShowOperation(operation))) hits++;
        }

        end = DateTime.Now;

        GameRecord gameRecord = new GameRecord(idRecord++, maxGames, hits, (end - init).Seconds, optionSelected);

        UserInterface.DisplayResult(gameRecord);

        history.Add(gameRecord);
    }

    private Options GetRandomOperation()
    {
        int random = GlobalRandom.Instance.Next(1, 5);
        return (Options)random;
    }
}
