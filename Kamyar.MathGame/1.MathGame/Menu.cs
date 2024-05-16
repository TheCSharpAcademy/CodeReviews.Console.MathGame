using System;

public class Menu
{
    private static Random random = new Random(); // Declare Random instance outside the loop

    public static int GetDifficulty()
    {
        while (true)
        {
            string choice = Console.ReadLine()!.ToUpper();
            switch (choice)
            {
                case "E":
                    return 1;
                case "M":
                    return 2;
                case "H":
                    return 3;
                default:
                    Messages.MenuError();
                    break;
            }
        }
    }

    public static int GetNumberOfQuestions()
    {
        int numberOfQuestions;
        bool isValid = false;
        do
        {
            string inputStr = Console.ReadLine()!;
            isValid = int.TryParse(inputStr, out numberOfQuestions) && numberOfQuestions > 0;
            if (!isValid)
            {
                Console.WriteLine("Invalid input. Please enter an integer.");
            }

        } while (!isValid);
        return numberOfQuestions;
    }

    public static string GetQuestionType()
    {
        while (true)
        {
            string choice = Console.ReadLine()!.ToUpper();
            switch (choice)
            {
                case "V":
                case "A":
                case "S":
                case "M":
                case "D":
                    return choice;
                case "R":
                    int randomInt = random.Next(4);
                    string randomChar = randomInt switch
                    {
                        0 => "A",
                        1 => "S",
                        2 => "M",
                        3 => "D",
                        _ => throw new InvalidOperationException("Invalid random number")
                    };
                    return randomChar; // Return random choice
                case "Q":
                    return choice; // Return quit choice
                default:
                    Messages.MenuError();
                    break;
            }
        }
    }
}
