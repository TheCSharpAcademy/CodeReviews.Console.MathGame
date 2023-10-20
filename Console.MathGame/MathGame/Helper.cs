namespace MathGame;

public class Helper
{
	public static List<Operation> GetAllOperations()
	{
		return new List<Operation>(){
			new Operation("+", "Addition"),
			new Operation("-", "Subtraction"),
			new Operation("*", "Multiplication"),
			new Operation("/", "Division"),
		};
	}
}
