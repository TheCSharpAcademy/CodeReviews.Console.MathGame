namespace MathGame.Models;

internal class Game
{
    //private int _score; //backing field
    //public int Score //public property
    //{
    //    get { return _score; }
    //    set { _score = value; }
    //}4
    public DateTime Date { get; set; }
    public int Score { get; set; }
    public GameType Type { get; set; }
    public Difficulty difficultyType {  get; set; }
}
internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}
internal enum Difficulty
{
    Easy,
    Medium,
    Hard
}