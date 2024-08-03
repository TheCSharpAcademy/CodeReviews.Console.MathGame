using Math_Game.Helpers;

namespace Math_Game.View
{
    internal class Display
    {
        internal static void Welcome()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Math Game!");
            Console.Write("Please enter your name: ");
        }

        internal static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Menu");
            Console.WriteLine("--------------------------");
            Console.WriteLine("A - Addition");
            Console.WriteLine("S - Subtraction");
            Console.WriteLine("M - Multiplication");
            Console.WriteLine("D - Division");
            Console.WriteLine("V - View History");
            Console.WriteLine("C - Change Name");
            Console.WriteLine("Q - Quit");
            Console.WriteLine("--------------------------");
            Console.Write("What would you like to do? ");


        }

        internal static void Start(Types? type, int x, int y)
        {
            Console.Clear();
            switch (type)
            {
                case Types.Addition:
                    Console.WriteLine($"{x} + {y}");
                    break;
                case Types.Subtraction:
                    Console.WriteLine($"{x} - {y}");
                    break;
                case Types.Multiplication:
                    Console.WriteLine($"{x} * {y}");
                    break;
                case Types.Division:
                    Console.WriteLine($"{x} / {y}");
                    break;
            }
        }

        internal static void Start(string? option)
        {
            switch (option)
            {
                case "C":
                    Console.Write("Please enter your new name: ");
                    break;
                case "V":
                    Console.Clear();
                    break;
                case "Q":
                    break;
                default:
                    Console.WriteLine("Your input was invalid. Please enter a letter from above");
                    Console.WriteLine("Press enter to try again...");
                    Console.ReadLine();
                    break;
            }
        }

        internal static void ViewHistory<T>(List<T> games)
        {
            foreach (T game in games)
            {
                Console.WriteLine(game);
            }
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }

        internal static void Answer()
        {
            Console.WriteLine("Invalid answer, press enter to try again...");
        }
    }
}
