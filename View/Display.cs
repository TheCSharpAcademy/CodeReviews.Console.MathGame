namespace Math_Game.View
{
    internal class Display
    {
        internal static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Math Game!");
            Console.WriteLine("--------------------------");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("A - Addition");
            Console.WriteLine("S - Subtraction");
            Console.WriteLine("M - Multiplication");
            Console.WriteLine("D - Division");
            Console.WriteLine("V - View History");
            Console.WriteLine("Q - Quit");
            Console.WriteLine("--------------------------");


        }

        internal static void Start(string? option)
        {
            switch (option)
            {
                case "A":
                    Console.WriteLine("5 + 5");
                    Console.ReadLine();
                    break;
                case "S":
                    Console.WriteLine("5 - 5");
                    Console.ReadLine();
                    break;
                case "M":
                    Console.WriteLine("5 * 5");
                    Console.ReadLine();
                    break;
                case "D":
                    Console.WriteLine("5 / 5");
                    Console.ReadLine();
                    break;
                case "V":
                    Console.WriteLine("History");
                    Console.ReadLine();
                    break;
                case "Q":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please enter a letter from above.");
                    Console.WriteLine("Press enter to try again...");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
