using MathGameLibrary.Models;

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

    public static Difficulty GetGameDifficulty()
    {
        do
        {
            Console.WriteLine(@"Please select the Game Difficulty:
1. Easy
2. Medium
3. Hard");

            Console.WriteLine();

            string selection = Console.ReadLine();

            Console.Clear();

            switch (selection.Trim())
            {
                case "1":
                    return Difficulty.Easy;
                case "2":
                    return Difficulty.Medium;
                case "3":
                    return Difficulty.Hard;
                default:
                    Console.WriteLine("Invalid input. Please try again.\n");
                    break;
            }

        } while (true);
    }
}
