public class MathQuestion
{
    private readonly Operation _operation;
    private readonly Random _rand;
    public int Answer {get; private set;}
    public int FirstNumber {get; private set;}
    public int SecondNumber {get; private set;}
    public string Symbol {get; private set;} = string.Empty;
    public GameSettings Gamesettings {get; private set;} 
    public MathQuestion(Operation operation, Random rand, GameSettings gameSettings)
    {
        _operation = operation;
        _rand = rand;
        Gamesettings = gameSettings;
        GenerateNumbers();
        CalculateAnswer(FirstNumber, SecondNumber);
    }

    private void CalculateAnswer(int a, int b)
    {
        (Answer, Symbol) = _operation switch{
            Operation.Addition => (a + b, "+"),
            Operation.Subtraction => (a - b, "-"),
            Operation.Multiplication => (a * b, "*"),
            Operation.Division => (a / b, "/"),
            _=> throw new ArgumentOutOfRangeException()
        };
    }

    private void GenerateNumbers()
    {
        FirstNumber = _rand.Next(Gamesettings.MinNumber, Gamesettings.MaxNumber + 1);
        SecondNumber = _rand.Next(Gamesettings.MinNumber, Gamesettings.MaxNumber + 1);

        while(_operation == Operation.Division && FirstNumber % SecondNumber != 0)
        {
            FirstNumber = _rand.Next(Gamesettings.MinNumber, Gamesettings.MaxNumber + 1);
            SecondNumber = _rand.Next(Gamesettings.MinNumber, Gamesettings.MaxNumber + 1);
        }

        while(_operation == Operation.Subtraction && Gamesettings.DifficultyLevel != DifficultyLevel.Hard && FirstNumber < SecondNumber)
        {
            FirstNumber = _rand.Next(Gamesettings.MinNumber, Gamesettings.MaxNumber + 1);
        }
    }


}