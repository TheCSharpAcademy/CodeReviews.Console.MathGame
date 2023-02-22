namespace OhshieMathGame.InfiniteGameModeSettings;

public class EquationLengthConfiguration
{
    private static int _tempVariables = 2;
    
    //used to save changes
    public static void SaveOperatorConfiguration()
    {
        GameController.AmountOfVariables = _tempVariables;
    }
    // method to adjust length of equation. Also checks if user entered something that is not a number.
    public static void LengthOfEquation()
    {
        Console.Clear();
        Console.WriteLine("How many variables do you want to have in the equation?\n" +
                          "Number must be 2 or more");
        while (true)
        {
            _tempVariables  = int.Parse(Console.ReadLine());
            if (_tempVariables >= 2)
            {
                break;  
            }
            Console.WriteLine("Either you entered number below 2, or not a number at all.");
        }
    }
}