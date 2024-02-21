namespace MathGame;

public static class UserInputHandler
{
    public static string AskForUserName()
    {
        Console.Write("Please enter your name: ");
        string output = Console.ReadLine();

        return output;
    }
}
