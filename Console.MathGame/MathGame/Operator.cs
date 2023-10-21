namespace MathGame;

public class Operator
{
	public string Symbol { get; set; }
	public string Name { get; set; }

	public Operator(string symbol, string name)
	{
		Symbol = symbol;
		Name = name;
	}
}
