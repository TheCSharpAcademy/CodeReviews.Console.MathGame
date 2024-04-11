namespace jcast24.MathGame
{
    class Program
    {
        static void Menu()
        {
            string? input;
            while (true)
            {
                Console.WriteLine("Please choose an option: ");
                Console.WriteLine("(a) Addition");
                Console.WriteLine("(s) Subtraction");
                Console.WriteLine("(d) Division");
                Console.WriteLine("(m) Multiplication");
                        
                input = Console.ReadLine();
                switch (input)
                {
                    case "a":
                        Console.WriteLine("Addition function!");
                        break;
                    case "s":
                        Console.WriteLine("Subtraction function!");
                        break;
                    case "d":
                        Console.WriteLine("Division function!");
                        break;
                    case "m":
                        Console.WriteLine("Multiplication function!");
                        break;
                    default:
                        Console.WriteLine("Please ask again!");
                        break;
                }
            }
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your name: ");
            var name = Console.ReadLine();
            var date = DateTime.UtcNow;
            
            
            Console.WriteLine("Welcome to the Math Game!");
            Menu();
        }

    }
}