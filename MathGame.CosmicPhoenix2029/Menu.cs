namespace MathGame;
public class Menu
{
    //initialMenu
    public static string HomeMenu()
    {
        Console.WriteLine("Please select an option from the list below:\n"
            + "1. Start a new game\n"
            + "2. View your previous games\n"
            + "3. Press any key to exit");

        string response = Console.ReadLine();
        return response;
    }

    public static string GetGameMode()
    {
        string[] validOptions = { "A", "S", "M", "D", "R" };
        string response;

        do
        {
            Console.WriteLine($"Welcome to my maths game! Please enter an option from the list below:\n"
              + "A - Addition\n"
              + "S - Subtraction\n"
              + "M - Multiplication\n"
              + "D - Division\n"
              + "R - Random");
            response = Console.ReadLine()!.ToUpper();
            Console.Clear();
        }
        while (!(validOptions.Contains(response)));

        return response;
    }

    public static string GetDifficulty()
    {
        string[] validOptions = { "E", "M", "H" };
        string difficulty;
        do
        {
            Console.WriteLine($"Please select a difficulty:\n"
            + "E - Easy (2 numbers)\n"
            + "M - Medium (3 numbers)\n"
            + "H - Hard (4 numbers)");

            difficulty = Console.ReadLine()!.ToUpper();
            Console.Clear();
        }
        while (!(validOptions.Contains(difficulty)));

        return difficulty;
    }

    public static int GetNumberOfQuestions()
    {
        bool convertedToInt = false;
        int numOfQuestions = 0;
        //loop through until a valid number is entered:
        while ((!convertedToInt) || (numOfQuestions <= 0))
        {
            Console.WriteLine("How many questions would you like to answer?");
            convertedToInt = int.TryParse(Console.ReadLine(), out numOfQuestions);
            Console.Clear();
        }

        return numOfQuestions;
    }
}