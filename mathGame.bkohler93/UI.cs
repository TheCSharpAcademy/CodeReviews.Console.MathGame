namespace mathGame.bkohler93;

public static class UI
{
    public static int MenuSelection(string menuTitle, string[] options)
    {
        while (true)
        {
            Console.WriteLine(menuTitle);
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"\t'{i + 1}' - {options[i]}");
            }

            string? userInput = Console.ReadLine();

            bool isValidInt = int.TryParse(userInput, out int selectionInt);
            bool selectionWithinRange = selectionInt > 0 && selectionInt <= options.Length;

            if (!isValidInt || !selectionWithinRange)
            {
                DisplayConfirmation("Invalid option selection");
                continue;
            }
            else
            {
                return selectionInt;
            }
        }
    }

    public static void DisplayConfirmation(string message)
    {
        Console.WriteLine(message + "... Press 'enter' to continue");
        Console.ReadLine();
    }

    public static int GetIntSelection(string message, int minValue = int.MinValue, int maxValue = int.MaxValue)
    {
        while (true)
        {
            Console.WriteLine(message);
            string? userInput = Console.ReadLine();

            bool isValidInt = int.TryParse(userInput, out int selectionInt);

            if (!isValidInt || selectionInt < minValue || selectionInt > maxValue)
            {
                DisplayConfirmation("Invalid option selected");
                continue;
            }
            else
            {
                return selectionInt;
            }
        }
    }
}
