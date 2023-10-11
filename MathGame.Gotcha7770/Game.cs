namespace MathGame.Gotcha7770;

public enum MathOperation 
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}

public class Game
{
    private readonly Random _random = new Random((int)DateTime.Now.Ticks);
    private readonly List<GameTurn> _history = new List<GameTurn>();
    public IReadOnlyCollection<GameTurn> History => _history;

    public GameTurn NextTurn(MathOperation operation)
    {
        return operation switch
        {
            MathOperation.Addition => GetAddition(_random),
            MathOperation.Subtraction => GetSubtraction(_random),
            MathOperation.Multiplication => GetMultiplication(_random),
            MathOperation.Division => GetDivision(_random),
            _ => throw new ArgumentOutOfRangeException(nameof(operation))
        };
    }

    public void SaveAnswer(GameTurn gameTurn, int answer)
    {
        _history.Add(gameTurn with { PlayerAnswer = answer });
    }

    private GameTurn GetAddition(Random random)
    {
        int x = random.Next(0, 999);
        int y = random.Next(0, 999);

        return new GameTurn(x + y, $"{x} + {y}");
    }

    private GameTurn GetSubtraction(Random random)
    {
        int x, y;
        do
        {
            x = random.Next(0, 999);
            y = random.Next(0, 999);
        } while (x < y);

        return new GameTurn(x - y, $"{x} - {y}");
    }

    private GameTurn GetMultiplication(Random random)
    {
        int x = random.Next(0, 99);
        int y = random.Next(0, 99);

        return new GameTurn(x * y, $"{x} * {y}");
    }

    private GameTurn GetDivision(Random random)
    {
        int x, y;
        do
        {
            x = random.Next(0, 999);
            y = random.Next(1, 99);
        } while (x < y || x % y != 0);

        return new GameTurn(x / y, $"{x} / {y}");
    }
}