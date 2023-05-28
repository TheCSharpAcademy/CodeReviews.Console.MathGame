namespace MathGame.VincentyArmstrong;

public static class Utilities
{
    public static int[] GetDevisors(int number)
    {
        List<int> devisors = new();
        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
            {
                devisors.Add(i);
            }
        }
        return devisors.ToArray();
    }
}