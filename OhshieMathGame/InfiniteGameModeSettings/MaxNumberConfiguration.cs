namespace OhshieMathGame.InfiniteGameModeSettings;

public class MaxNumberConfiguration
{
    public static int TempMaxNumber = 11;

    // method to adjust how big numbers can be in equations
    public static void AdjustMaximumAllowedNumber()
    {
        Console.Clear();
        Console.WriteLine("Enter maximum possible number allowed in equation\n" +
                          "Number must be above 0");
        while (true)
        {
            TempMaxNumber = int.Parse(Console.ReadLine());
            // need this adjustment as "random" range does not include actuall last number in range
            TempMaxNumber += 1;
            if (TempMaxNumber > 0)
            {
                return;
            }
            Console.WriteLine("Either you entered number that equals or below 0, or not a number at all.");
        }
    }
}