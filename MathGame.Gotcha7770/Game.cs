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

    public static string GetExample(MathOperation operation)
    {
        return operation switch
        {
            MathOperation.Addition => Addition.GetNext(Random),
            // MathOperation.Subtraction => Subtraction.GetNext(Random),
            // MathOperation.Multiplication => Multiplication.GetNext(Random),
            // MathOperation.Division => Division.GetNext(Random),
            _ => throw new ArgumentOutOfRangeException(nameof(operation))
        };
    }
    
    public class Addition
    {
        public static string GetNext(Random random)
        {
            int x = random.Next(0, 999);
            int y = random.Next(0, 999);
            return $"{x} + {y}";
        }
    }
}