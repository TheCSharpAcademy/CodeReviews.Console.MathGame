namespace MathGame.Models;

internal class Equasion
{
    public int A { get; set; }
    public int B { get; set; }
    public char Sign { get; private set; }
    public int Result => GetResult();

    internal Equasion(string gameType)
    {
        Sign = gameType switch
        {
            "Addition" => '+',
            "Subtraction" => '-',
            "Multiplication" => '*',
            "Division" => '/',
            "Random" => RandomSign(),
            _ => throw new NotImplementedException(),
        }; ;
    }

    private char RandomSign()
    {
        var random = Random.Shared.Next(1, 5);
        return random switch
        {
            1 => '+',
            2 => '-',
            3 => '*',
            4 => '/',
            _ => throw new NotImplementedException(),
        };
    }

    private int GetResult()
    {
        return Sign switch
        {
            '+' => A + B,
            '-' => A - B,
            '*' => A * B,
            '/' => A / B,
            _ => throw new NotImplementedException(),
        };
    }
}

