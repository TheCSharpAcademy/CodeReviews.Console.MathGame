class Program
{
    
    public static void Main(string[] args)
    {


        bool doUserStillWantToPlay = true;

        Console.Clear();
        Console.WriteLine("Welcome to Math Game. \nAvailable commands: -Score -Menu\nDo you want to play?\nType 'yes' if so. If not, type 'exit'");

        while (doUserStillWantToPlay)
        {
            switch (Console.ReadLine())
            {
                case "yes":
                    StartGame();
                    break;
                case "exit":
                    doUserStillWantToPlay = false;
                    break;
                default:
                    Console.WriteLine("Invalid answer! Type yes or no.");
                    break;
            }
        }

    }

    public static void StartGame()
    {
        List<Operation> previousGames = new();
        Operation sum = new();
        Operation substraction = new Operation();
        Operation multiplication = new Operation();
        Operation division = new Operation();
        Random rnd = new();
        int Score = 0;
        int a = rnd.Next(1, 100);
        int b = rnd.Next(1, 100);
        string symbol = "";

        Console.WriteLine("\nMath Game is a game in which you can choose one of the 4 basic operations, and you will have to solve a calc with that operation.");
        Console.WriteLine("\nChoose a math operation");
        Console.WriteLine("\nAddition (Type A)");
        Console.WriteLine("Substraction (Type S)");
        Console.WriteLine("Multiplication (Type M)");
        Console.WriteLine("Division (Type D)");

        switch (Console.ReadLine())
        {
            case "A":
                symbol = "+";
                CreateAndShowCalc(sum, symbol);
                CheckResultAndAwardScore(sum);
                break;
            case "S":
                symbol = "-";
                CreateAndShowCalc(substraction, symbol);
                CheckResultAndAwardScore(substraction);
                break;
            case "M":
                symbol = "*";
                CreateAndShowCalc(multiplication, symbol);
                CheckResultAndAwardScore(multiplication);
                break;
            case "D":
                symbol = "/";
                createAndShowCalc(division, symbol);
                CheckResultAndAwardScore(division);
                break;
            case "Score":
                ShowScore();
                break;
            case "Menu":
                StartGame();
                break;
            default:
                break;

        }

        void UpdateStats(Operation operation)
        {
            previousGames.Add(operation);
        }

        void ShowScore()
        {
            if (previousGames.Count != 0)
            {
                foreach (var items in previousGames)
                {
                    Console.Clear();
                    Console.WriteLine("-------SCORE-------");
                    Console.WriteLine($"Solved: {items.Calc}");
                    Console.WriteLine($"Result: {items.Result}");
                    Console.WriteLine($"Score: {Score}");
                    Console.WriteLine("-------SCORE-------");
                }
            }
            else
            {
                Console.WriteLine("\nYou don't have any score.\n");
            }

        }

        void CreateAndShowCalc(Operation operation, string operator_)
        {
            int Calculate (int a, int b)
            {
                switch (operator_)
                {
                    case "+":
                        return a + b;
                    case "-":
                        if ((a - b) == 0 || (a - b) < 0)
                        {
                            do
                            {
                                a = rnd.Next(1, 100);
                                b = rnd.Next(1, 100);
                            } while ((a - b) == 0 || (a - b) < 0);
                        }
                        return a - b;
                    case "*":
                        return a * b;
                    case "/":
                        if (a % b != 0 || a == 1 || b == 1 || a == b)
                        {
                            do
                            {
                                a = rnd.Next(1, 100);
                                b = rnd.Next(1, 100);
                            } while (a % b != 0 || a == 1 || b == 1 || a == b);
                        }
                        return a / b;
                    default:
                        throw new ArgumentException($"\nInvalid operator: \n{operator_}\n");
                }
                
            }
            operation.Result = Calculate(a,b);
            operation.Calc = ($"{a} {operator_} {b}");
            Console.WriteLine($"\nYou have 15 seconds to solve this operation: \n{operation.Calc}\n");

        }
        void CheckResultAndAwardScore(Operation operation)
        {
            string userInput = Console.ReadLine();
            if (userInput == $"{operation.Result}")
            {
                Console.WriteLine("Nice.");
                UpdateStats(operation);
                Score++;
                do
                {
                    a = rnd.Next(1, 100);
                    b = rnd.Next(1, 100);
                } while ((a + b) == operation.Result);
                CreateAndShowCalc(operation, symbol);
                CheckResultAndAwardScore(operation);
                
            }
            else if (userInput == "Score")
            {
                ShowScore();
                CreateAndShowCalc(operation, symbol);
                CheckResultAndAwardScore(operation);
            }
            else if (userInput == "Menu")
            {
                StartGame();
            }
            else
            {
                Console.WriteLine($"\nWrong. It was {operation.Result}\n. \nDo you still want to play? Type 'yes' or 'no'\n.");
                Score--;
                string wantsToPlay = "";

                while (wantsToPlay != "yes" || wantsToPlay != "no")
                {
                    wantsToPlay = Console.ReadLine();

                    if (wantsToPlay == "yes")
                    {
                        //This line of code changes the values of 'a' and 'b' once the user chooses to play again.
                        a = rnd.Next(1, 100);
                        b = rnd.Next(1, 100);
                        CreateAndShowCalc(operation, symbol);
                        CheckResultAndAwardScore(operation);
                    }
                    else if (wantsToPlay == "no")
                    {
                        StartGame();
                    } 
                    else if (wantsToPlay == "Menu")
                    {
                        StartGame();
                    }
                    else if (wantsToPlay == "Score")
                    {
                        ShowScore();
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Type 'yes' or 'no'.\n");
                    }
                }
            }
        }

        if (Console.ReadLine() == "Score")
        {
            ShowScore();
        }

        if (Console.ReadLine() == "Menu")
        {
            StartGame();
        }

    }

    class Operation
    {
        public int Result { get; set; }
        public string Calc { get; set; }
        public int Score { get; set; }

    }
}
