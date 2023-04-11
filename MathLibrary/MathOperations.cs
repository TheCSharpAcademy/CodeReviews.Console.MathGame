namespace MathLibrary;

public static class MathOperations
{
	public static int Add(int x, int y) => x + y;
	public static int Subtact(int x, int y) => x - y;
	public static int Multiply(int x, int y) => x * y;
	public static int Divide(int x, int y)
	{
		if (y == 0)
		{
			return 0;
		}
		double z = x / y;
		return (int)Math.Round(z);
	}
}
