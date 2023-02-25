namespace OhshieMathGame.InfiniteGameModeSettings;

public class EquationLengthConfiguration
{
    public static int TempVariables = 2;

    // method to adjust length of equation. Also checks if user entered something that is not a number.
    public static void LengthOfEquation()
    {
        Console.Clear();
        Console.WriteLine("How many variables do you want to have in the equation?\n" +
                          "Number must be 2 or more");
        while (true)
        {
            TempVariables  = int.Parse(Console.ReadLine());
            if (TempVariables >= 2)
            {
                return;  
            }
            Console.WriteLine("Either you entered number below 2, or not a number at all.");
        }
    }
}