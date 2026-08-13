class MathGame
{
    private static List<string> history = new List<string>();

    public static void Main(String[] args)
    {
        ShowMenu();
    }

    static void ShowMenu()
    {
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Choose a game, enter the number of the desired option");
            Console.WriteLine("1.- Addition.");
            Console.WriteLine("2.- Subtraction.");
            Console.WriteLine("3.- Multiplication.");
            Console.WriteLine("4.- Division.");
            Console.WriteLine("5.- History.");
            Console.WriteLine("6.- Exit.");

            string selection = Console.ReadLine() ?? "";

            switch (selection)
            {
                case "1":
                    Addition();
                    Console.WriteLine("\nPress Enter to return to the menu...");
                    Console.ReadLine();
                    break;
                case "2":
                    Subtraction();
                    Console.WriteLine("\nPress Enter to return to the menu...");
                    Console.ReadLine();
                    break;
                case "3":
                    Multiplication();
                    Console.WriteLine("\nPress Enter to return to the menu...");
                    Console.ReadLine();
                    break;
                case "4":
                    Division();
                    Console.WriteLine("\nPress Enter to return to the menu...");
                    Console.ReadLine();
                    break;
                case "5":
                    MatchHistory();
                    Console.WriteLine("\nPress Enter to return to the menu...");
                    Console.ReadLine();
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Choose 1-6.");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;
            }
        }
    }

    private static void MatchHistory()
    {
        Console.Clear();

        if(history.Count == 0)
        {
            Console.WriteLine("There are no results. Please, play a game and try again");
            return;
        } 

        foreach (var item in history)
        {
            Console.WriteLine(item);
        }
    }

    private static void Division()
    {
        Console.Clear();
        Random random = new Random();
        int points = 0;

        for (int i = 1; i <= 5; i++)
        {
            int divisor = random.Next(1, 11);
            int quotient = random.Next(1, 11);
            int dividend = quotient * divisor;
            Console.WriteLine($"Question number {i}:");
            Console.WriteLine($"What is the result of the Division --> {dividend} / {divisor}");
            Console.WriteLine("Enter the result: ");

            if (int.TryParse(Console.ReadLine(), out int result))
            {
                if (result == quotient)
                {
                    Console.WriteLine("Correct!");
                    points++;
                }
                else
                {
                    Console.WriteLine($"Incorrect, the answer was: {quotient}");
                }
            }
            else
            {
                Console.WriteLine("The value entered is not a number, you lose a question");
            }
        }
        // Add points to match history
        history.Add($"The accumulated points in this Division game are: {points} -- Game Date: {DateTime.Now}");
    }

    private static void Multiplication()
    {
        Console.Clear();
        Random random = new Random();
        int points = 0;

        for (int i = 1; i <= 5; i++)
        {
            int num1 = random.Next(1, 101);
            int num2 = random.Next(1, 101);
            int multiply = num1 * num2;
            Console.WriteLine($"Question number {i}:");
            Console.WriteLine($"What is the result of the Multiplication --> {num1} * {num2}");
            Console.WriteLine("Enter the result: ");

            if (int.TryParse(Console.ReadLine(), out int result))
            {
                if (result == multiply)
                {
                    Console.WriteLine("Correct!");
                    points++;
                }
                else
                {
                    Console.WriteLine($"Incorrect, the answer was: {multiply}");
                }
            }
            else
            {
                Console.WriteLine("The value entered is not a number, you lose a question");
            }
        }
        // Add points to match history
        history.Add($"The accumulated points in this Multiplication game are: {points} -- Game Date: {DateTime.Now}");
    }

    private static void Subtraction()
    {
        Console.Clear();
        Random random = new Random();
        int points = 0;

        for (int i = 1; i <= 5; i++)
        {
            int num1 = random.Next(1, 101);
            // implemented so the subtraction is never negative
            int num2 = random.Next(1, num1 + 1);
            int subtract = num1 - num2;
            Console.WriteLine($"Question number {i}:");
            Console.WriteLine($"What is the result of the Subtraction --> {num1} - {num2}");
            Console.WriteLine("Enter the result: ");

            if (int.TryParse(Console.ReadLine(), out int result))
            {
                if (result == subtract)
                {
                    Console.WriteLine("Correct!");
                    points++;
                }
                else
                {
                    Console.WriteLine($"Incorrect, the answer was: {subtract}");
                }
            }
            else
            {
                Console.WriteLine("The value entered is not a number, you lose a question");
            }
        }
        // Add points to match history
        history.Add($"The accumulated points in this Subtraction game are: {points} -- Game Date: {DateTime.Now}");
    }

    private static void Addition()
    {
        Console.Clear();
        Random random = new Random();
        int points = 0;

        for (int i = 1; i <= 5; i++)
        {
            int num1 = random.Next(1, 101);
            int num2 = random.Next(1, 101);
            int sum = num1 + num2;
            Console.WriteLine($"Question number {i}:");
            Console.WriteLine($"What is the result of the Addition --> {num1} + {num2}");
            Console.WriteLine("Enter the result: ");

            if (int.TryParse(Console.ReadLine(), out int result))
            {
                if (sum == result)
                {
                    Console.WriteLine("Correct!");
                    points++;
                }
                else
                {
                    Console.WriteLine($"Incorrect, the answer was: {sum}");
                }
            }
            else
            {
                Console.WriteLine("The value entered is not a number, you lose a question");
            }
        }
        // Add points to match history
        history.Add($"The accumulated points in this Addition game are: {points} -- Game Date: {DateTime.Now}");
    }
}