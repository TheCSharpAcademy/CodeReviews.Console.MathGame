namespace MathGameUI;

public static class Menu
{
    public static void ShowMenu()
    {
        bool shouldGameContinue = true;

        Console.WriteLine("\nPress any key to show the Menu.");
        Console.ReadLine();
        Console.Clear();

        do
        {
            Console.WriteLine(@"Please select the game you would like to play or any other option:
+    Addition
-    Subtraction
*    Multiplication
/    Division
H -  Game History
Q -  Quit");

            Console.WriteLine();

            string selection = Console.ReadLine();

            Console.Clear();

            switch (selection.Trim().ToLower())
            {
                case "+":
                    break;
                case "-":
                    break;
                case "*":
                    break;
                case "/":
                    break;
                case "h":
                    break;
                case "q":
                    Console.WriteLine("Thanks for playing. \nExiting game ...");
                    shouldGameContinue = false;
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again.\n");
                    break;
            }

        } while (shouldGameContinue);
    }
}
