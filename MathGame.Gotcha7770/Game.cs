namespace MathGame.Gotcha7770;

public enum MathOperation 
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}

public static class Game
{
    private static readonly Random Random = new Random((int)DateTime.Now.Ticks);
    private static readonly List<GameTurn> _history = new List<GameTurn>();
    public static IReadOnlyCollection<GameTurn> History => _history;

    public static GameTurn NextTurn(MathOperation operation)
    {
        return operation switch
        {
            MathOperation.Addition => Addition.GetNext(Random),
            MathOperation.Subtraction => Subtraction.GetNext(Random),
            MathOperation.Multiplication => Multiplication.GetNext(Random),
            MathOperation.Division => Division.GetNext(Random),
            _ => throw new ArgumentOutOfRangeException(nameof(operation))
        };
    }
    
    public static void SaveAnswer(GameTurn gameTurn, int answer)
    {
        _history.Add(gameTurn with { PlayerAnswer = answer });
    }

    private class Addition
    {
        public static GameTurn GetNext(Random random)
        {
            int x = random.Next(0, 999);
            int y = random.Next(0, 999);
            
            return new GameTurn(x + y, $"{x} + {y}");
        }
    }

    private class Subtraction
    {
        public static GameTurn GetNext(Random random)
        {
            int x = random.Next(0, 999);
            int y = random.Next(0, 999);
            
            return new GameTurn(x - y, $"{x} - {y}");
        }
    }

    private class Multiplication
    {
        public static GameTurn GetNext(Random random)
        {
            int x = random.Next(0, 99);
            int y = random.Next(0, 99);
            
            return new GameTurn(x * y, $"{x} * {y}");
        }
    }

    private class Division
    {
        public static GameTurn GetNext(Random random)
        {
            int x, y;
            do
            {
                x = random.Next(0, 999);
                y = random.Next(1, 99);
            } while ( x < y || x % y != 0);
       
            return new GameTurn(x / y, $"{x} / {y}");
        }
    }
}