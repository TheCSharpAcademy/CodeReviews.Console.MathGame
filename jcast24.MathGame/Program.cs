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
                        Division();
                        break;
                    case "m":
                        Multiplication();
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
            
            Console.WriteLine($"What is the result of {firstNum} + {secondNum}?");
            int getResult = Convert.ToInt32(Console.ReadLine());

            if (getResult == result)
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine("Incorrect!");
            }
        }

        static void Subtraction()
        {
            var random = new Random();
            int firstNum = random.Next(1, 9);
            int secondNum = random.Next(1, 9);

            int result = firstNum - secondNum;
            
            Console.WriteLine($"What is the result of {firstNum} - {secondNum}?");
            int getResult = Convert.ToInt32(Console.ReadLine());
            
            if (getResult == result)
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine("Incorrect!");
            }
        }

        static int[] GetDivisionNumbers()
        {
            var random = new Random();
            int firstNum = random.Next(0, 99);
            int secondNum = random.Next(0, 99);

            while (firstNum % secondNum != 0)
            {
                firstNum = random.Next(0, 99);
                secondNum = random.Next(0, 99);
            }
            
            var result = new int[2];
            
            result[0] = firstNum;
            result[1] = secondNum;

            return result;
        }

        static void Division()
        {
            var result = GetDivisionNumbers();
            var answer = result[0] / result[1];

            Console.WriteLine($"What is the result of {result[0]} / {result[1]}?");
            int getResult = Convert.ToInt32(Console.ReadLine());

            if (answer == getResult)
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine("Incorrect!");
            }
        }
        

        static void Multiplication()
        {
            var random = new Random();
            int firstNum = random.Next(1, 9);
            int secondNum = random.Next(1, 9);

            int result = firstNum * secondNum;
            
            Console.WriteLine($"What is the result of {firstNum} * {secondNum}?");
            int getResult = Convert.ToInt32(Console.ReadLine());
            if (getResult == result)
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine("Incorrect!");
            }
            
        }
        
        static void Main(string[] args)
        {
            // Console.WriteLine("Please enter your name: ");
            // var name = Console.ReadLine();
            // var date = DateTime.UtcNow;
            Console.WriteLine("Welcome to the Math Game!");
            Menu();
        }

    }
}