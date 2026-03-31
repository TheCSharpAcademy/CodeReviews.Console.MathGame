namespace MathGame.Models;

internal class Score(DateTime dateTime,  Type type,  int points)
{
    internal Type Type { get; set; }
    internal int Points { get; set; }
    internal DateTime Date { get; set; }
}

internal enum Type
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
}