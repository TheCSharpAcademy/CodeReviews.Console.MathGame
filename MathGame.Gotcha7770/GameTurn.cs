namespace MathGame.Gotcha7770;

public record GameTurn(int Value, string Expression)
{
    public int PlayerAnswer { get; init; }

    public override string ToString()
    {
        return $"Example: {Expression}, Players answer: {PlayerAnswer}, Correct value: {Value}";
    }
}