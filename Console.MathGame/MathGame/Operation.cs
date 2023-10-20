namespace MathGame;

public class Operation
{
	public string Symbol { get; set; }
	public string Name { get; set; }

	public Operation(string symbol, string name)
	{
		Symbol = symbol;
		Name = name;
	}
}
