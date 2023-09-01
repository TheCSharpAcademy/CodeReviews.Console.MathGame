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

    public static Example GetExample(MathOperation operation)
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
    
    public class Addition
    {
        public static Example GetNext(Random random)
        {
            int x = random.Next(0, 999);
            int y = random.Next(0, 999);
            
            return new Example(x + y, $"{x} + {y}");
        }
    }
    
    public class Subtraction
    {
        public static Example GetNext(Random random)
        {
            int x = random.Next(0, 999);
            int y = random.Next(0, 999);
            
            return new Example(x - y, $"{x} - {y}");
        }
    }

    public class Multiplication
    {
        public static Example GetNext(Random random)
        {
            int x = random.Next(0, 99);
            int y = random.Next(0, 99);
            
            return new Example(x * y, $"{x} * {y}");
        }
    }

    public class Division
    {
        public static Example GetNext(Random random)
        {
            int x, y;
            do
            {
                x = random.Next(0, 999);
                y = random.Next(1, 99);
            } while ( x > y && x % y == 0);
       
            return new Example(x / y, $"{x} / {y}");
        }
    }
}