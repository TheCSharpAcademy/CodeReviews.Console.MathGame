namespace MathGame;

public static class UserInputHandler
{
    public static string AskForUserName()
    {
        string output;
        do
        {
            Console.Write("Please enter your name: ");
            output = Console.ReadLine();

            Console.Clear();

        } while (String.IsNullOrEmpty(output));
        

        return output;
    }

    public static int GetAnswer()
    {
        bool isValidNumber;
        int output;

        string answer = Console.ReadLine();
        isValidNumber = int.TryParse(answer, out output);

        while (isValidNumber == false)
        {
            Console.Write("Please enter a valid number: ");
            answer = Console.ReadLine();
            isValidNumber = int.TryParse(answer, out output);
        }

        return output;
    }
}
