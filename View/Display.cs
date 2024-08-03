namespace Math_Game.View
{
    internal class Display
    {
        internal string? Option { get; set; }

        internal void Menu()
        {
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

            Option = Console.ReadLine()?.ToUpper();
        }

        internal void Start()
        {
            switch (Option)
            {
                case "A":
                    Console.WriteLine("5 + 5");
                    break;
                case "S":
                    Console.WriteLine("5 - 5");
                    break;
                case "M":
                    Console.WriteLine("5 * 5");
                    break;
                case "D":
                    Console.WriteLine("5 / 5");
                    break;
                case "V":
                    Console.WriteLine("History");
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
