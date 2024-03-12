namespace ConsoleMathsGame.Models;

internal class Game
{
	public int Score { get; set; }
	public DateTime Date { get; set; }
	public GameType Type { get; set; }	
	public Difficulty Difficulty { get; set; }
	public string? Elapsed {  get; set; }
	public int Rounds { get; set; }
}

internal enum GameType { Addition, Subtraction, Multiplication, Division }
internal enum Difficulty { Easy, Medium, Difficult }
