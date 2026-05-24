class MathGame
{
    // Stores the points of previously played games
    private static readonly List<int> previousGames = [];

    private static readonly Random random = new((int)DateTime.Now.Ticks);

    static void Main()
    {
        bool exit = false;

        PrintMenu();

        do
        {
            var userInput = Console.ReadLine();

            if (!int.TryParse(userInput, out int userInputInt))
            {
                userInputInt = -1;
            }

            switch (userInputInt)
            {
                case 1:
                    ChooseOperation();
                    break;
                case 2:
                    PrintPreviousGames();
                    break;
                case 3:
                    exit = true;
                    break;
                default:
                    Console.Clear();
                    PrintMenu(true);
                    break;
            }

        } while (!exit);
    }

    static void PrintMenu(bool tryAgain = false)
    {
        Console.WriteLine("1.Start Game");
        Console.WriteLine("2. Previous Games");
        Console.WriteLine("3. Exit");
        Console.WriteLine();

        if (tryAgain)
        {
            Console.WriteLine("Not a valid input. Please try again.");
        }
    }

    static void PrintPreviousGames()
    {
        Console.Clear();

        if (previousGames.Count == 0)
        {
            Console.WriteLine("No games played yet");

        }
        for (int i = 0; i < previousGames.Count; i++)
        {
            Console.WriteLine($"Game {i + 1}: {previousGames[i]} points");
        }

        Console.WriteLine("\nEnter any key to continue..");
        Console.ReadKey();

        Console.Clear();
        PrintMenu();
    }

    static void ChooseOperation()
    {
        string operationName;

        Console.Clear();
        PrintOperations();

        while (true)
        {
            var userOperation = Console.ReadLine();

            if (!int.TryParse(userOperation, out int userOperationInt))
            {
                userOperationInt = -1;
            }

            operationName = GetOperationName(userOperationInt);

            if (operationName == "Bad")
            {
                Console.Clear();
                PrintOperations(true);
                continue;
            }

            break;
        }

        if (operationName == "Back")
        {
            Console.Clear();
            PrintMenu();
        }
        else
        {
            StartGame(operationName);
        }
    }

    static void PrintOperations(bool tryAgain = false)
    {
        Console.WriteLine("Choose an operation:");
        Console.WriteLine("1.Addition");
        Console.WriteLine("2.Subtraction");
        Console.WriteLine("3.Multiplication");
        Console.WriteLine("4.Division");
        Console.WriteLine("5.Random");
        Console.WriteLine("6.Back");

        if (tryAgain)
        {
            Console.WriteLine("Not a valid input. Please try again.");
        }
    }

    static string GetOperationName(int userOperationInt)
    {
        string operationName = userOperationInt switch
        {
            1 => "Addition",
            2 => "Subtraction",
            3 => "Multiplication",
            4 => "Division",
            5 => "Random",
            6 => "Back",
            _ => "Bad",
        };
        return operationName;
    }

    static void StartGame(string operationName)
    {
        int points = 0;

        for (int i = 0; i < 5; i++)
        {
            int result = GetResult(operationName);

            int userResult = GetUserResult();

            if (result == userResult)
            {
                points += 1;
            }
        }
        Console.WriteLine($"\nPoints: {points}/5");

        previousGames.Add(points);

        Console.WriteLine("Enter any key to continue..");
        Console.ReadKey();

        Console.Clear();
        PrintMenu();
    }

    static int GetUserResult()
    {
        while (true)
        {
            var userResult = Console.ReadLine();

            if (!int.TryParse(userResult, out int userResultInt))
            {
                Console.WriteLine("Not a valid input. Please try again.");
                continue;
            }

            return userResultInt;
        }
    }

    static int GetResult(string operationName)
    {
        int maxX = 10;
        int maxY = 10;
        int x, y;

        if (operationName == "Division")
        {
            maxX = 100;
            y = random.Next(1, maxY + 1);

            while (true)
            {
                x = random.Next(0, maxX + 1);

                if (x % y == 0)
                {
                    break;
                }
            }
        }
        else
        {
            x = random.Next(0, maxX + 1);
            y = random.Next(0, maxY + 1);
        }

        switch (operationName)
        {
            case "Addition":
                Console.Write($"\nWhat is the result of {x,2} + {y,2}\t= ");
                return x + y;
            case "Subtraction":
                Console.Write($"\nWhat is the result of {x,2} - {y,2}\t= ");
                return x - y;
            case "Multiplication":
                Console.Write($"\nWhat is the result of {x,2} * {y,2}\t= ");
                return x * y;
            case "Division":
                Console.Write($"\nWhat is the result of {x,2} / {y,2}\t= ");
                return x / y;
            case "Random":
                string[] validOperations = ["Addition", "Subtraction", "Multiplication", "Division"];

                int randomOperationIdx = random.Next(0, 4);
                operationName = validOperations[randomOperationIdx];

                return GetResult(operationName);
            default:
                return x + y;
        }
    }
}