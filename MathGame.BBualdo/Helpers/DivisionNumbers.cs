namespace MathGame.BBualdo.Helpers;

internal class DivisionNumbers
{
  public static int[] GetDivisionNumbers(int maxValue)
  {
    Random random = new Random();
    int num1 = random.Next(1, maxValue / 10);
    int num2 = random.Next(1, maxValue / 10);

    while (num1 % num2 != 0)
    {
      num2 = random.Next(1, maxValue / 10);
    }

    return [num1, num2];
  }
}
