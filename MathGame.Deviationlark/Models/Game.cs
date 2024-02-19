namespace MathGame.Models;
internal class Game
{
    public int Score {get; set;}

    public string? Difficulty {get; set;}
    
    public GameType Mode {get; set;}
}

internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
    Random
}
  