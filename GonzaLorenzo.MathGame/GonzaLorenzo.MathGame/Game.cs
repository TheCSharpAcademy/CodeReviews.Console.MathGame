namespace GonzaLorenzo.MathGame;

internal class Game
{
    public int ID {  get; set; } 
    public DateTime Date { get; set; }
    public Difficulty Difficulty { get; set; }
    public int Questions { get; set; }
    public int Score { get; set; }
    public TimeSpan Time { get; set; }
    public GameMode Mode { get; set; }
}

internal enum GameMode
{
    Addition,
    Substraction,
    Multiplication,
    Division,
    Random
}

internal enum Difficulty
{
    Easy,
    Medium,
    Hard
}
