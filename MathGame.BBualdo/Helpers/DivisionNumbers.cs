namespace MathGame.BBualdo.Helpers;

internal class DivisionNumbers
{
  public static int[] GetDivisionNumbers(int maxValue)
  {
    Random random = new Random();
    int num1 = random.Next(1, maxValue);
    int num2 = random.Next(1, maxValue);

    while (num1 % num2 != 0)
    {
      num2 = random.Next(1, maxValue);
    }

    return [num1, num2];
  }
}
