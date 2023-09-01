namespace MathGame.Gotcha7770;

public class GameTurn
{
    public GameTurn(int value, string representation)
    {
        Value = value;
        Representation = representation;
    }

    public int Value { get; }
    public string Representation { get; }
}