using System.Numerics;

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
                        Addition();
                        break;
                    case "s":
                        Subtraction();
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

        static void Addition()
        {
            var random = new Random();
            int firstNum = random.Next(1, 9);
            int secondNum = random.Next(1, 9);

            int result = firstNum + secondNum;
            
            Console.WriteLine($"What is the result of {firstNum} + {secondNum}");
            int getResult = Convert.ToInt32(Console.ReadLine());

            if (getResult == result)
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine("Not Correct!");
            }
        }

        static void Subtraction()
        {
            var random = new Random();
            int firstNum = random.Next(1, 9);
            int secondNum = random.Next(1, 9);

            int result = firstNum - secondNum;
            
            Console.WriteLine($"What is the result of {firstNum} - {secondNum}");
            int getResult = Convert.ToInt32(Console.ReadLine());
            
            if (getResult == result)
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine("Not Correct!");
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