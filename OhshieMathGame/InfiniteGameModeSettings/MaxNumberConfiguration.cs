namespace OhshieMathGame.InfiniteGameModeSettings;

public class MaxNumberConfiguration
{
    private static int _tempMaxNumber = 11;
    
    public static void SaveOperatorConfiguration()
    {
        GameController.MaxNumber = _tempMaxNumber;
    }
    
    // method to adjust how big numbers can be in equations
    public static void AdjustMaximumAllowedNumber()
    {
        Console.Clear();
        Console.WriteLine("Enter maximum possible number allowed in equation\n" +
                          "Number must not be 0");
        while (true)
        {
            _tempMaxNumber = int.Parse(Console.ReadLine());
            if (_tempMaxNumber != 0)
            {
                break;
            }
            Console.WriteLine("Either you entered 0, or not a number at all.");
            
            // need this adjustment as "random" range does not include actuall last number in range

            _tempMaxNumber += 1;
        }
    }
}