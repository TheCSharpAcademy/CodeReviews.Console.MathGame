namespace MathGame;

internal class Program
{
    static void Main(string[] args)
    {
        int num1;
        int num2;
        int userInput;
        int result;
        int roundCount = 0;
        string operation;
        string roundResult = string.Empty;
        bool roundStart;
        bool validDivision = true;

        List<string> rounds = new List<string>();
        Console.WriteLine("Welcome to the Math Game!");
        Console.WriteLine("You will be given a math problem to solve.");
        Console.WriteLine("If you answer correctly, you will proceed to the next round.");
        Console.WriteLine("If you answer incorrectly, you will be shown the correct answer.");
        Console.WriteLine("You can choose to start a new round or exit the game.");

        roundStart = RoundStart(rounds);

        while (roundStart == true)
        {
            operation = GetOperator();

            do
            {
                num1 = Random.Shared.Next(1, 100);
                num2 = Random.Shared.Next(1, 100);
                if (operation == "/")
                {
                    validDivision = (num1 % num2 != 0) ? false : true; // Ensure num1 is divisible by num2
                }
            } while (num1 == num2 || validDivision != true);

            result = MathResult(num1, num2, operation);
            

            bool validAnswer;
            
            do
            {
                Console.WriteLine($"Solve: {num1} {operation} ___ = {result}");
                string input = Console.ReadLine() ?? "No Data Entered";
                userInput = int.TryParse(input, out int parsedInput) ? parsedInput : 0;
                (validAnswer, roundResult) = RoundResult(num2, userInput);
            } while (validAnswer == false);
            roundCount++;

            RecordRound(num1, num2, operation, userInput, result, roundResult, roundCount, rounds);

            roundStart = RoundStart(rounds);
        }
    }

    public static bool RoundStart(List<string> rounds)
    {
        bool roundStart = false;
        Console.WriteLine("1. Start a new round");
        Console.WriteLine("2. View round history");
        Console.WriteLine("3. Exit the game");

        
        string response = Console.ReadLine()?.ToLower() ?? "No Data Entered";
        Console.Clear();
        switch (response)
        {
            case "1":
                return roundStart = true;
            case "2":
                Console.WriteLine("Round History:");
                foreach (var round in rounds)
                {
                    Console.WriteLine(round);
                }
                Console.WriteLine("Press any key to continue...");
                Console.Read();
                return RoundStart(rounds);
            case "3":
                Console.WriteLine("Thank you for playing! Goodbye!");
                return roundStart = false;
            default:
                Console.WriteLine("Invalid input. Please enter '1', '2', or '3'.");
                return RoundStart(rounds);
        }
    }

    public static string GetOperator()
    {
        Console.WriteLine("What operation challenge would you like to solve?");
        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Subtraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");

        string operation = Console.ReadLine()?.ToLower() ?? "No Data Entered";

        switch (operation)
        {
            case "1":
                operation = "+";
                break;
            case "2":
                operation = "-";
                break;
            case "3":
                operation = "*";
                break;
            case "4":
                operation = "/";
                break;
            default:
                Console.WriteLine("Invalid input. Please enter '1', '2', '3', or '4'.");
                return GetOperator();
        }
        return operation;
    }

    public static int MathResult(int num1, int num2, string operation)
    {
        int result = 0;
        switch (operation)
        {
            case "+":
                result = num1 + num2;
                break;
            case "-":
                result = num1 - num2;
                break;
            case "*":
                result = num1 * num2;
                break;
            case "/":
                result = num1 / num2;
                break;
            default:
                Console.WriteLine("Invalid operator.");
                break;
        }
        return result;
    }

    public static (bool validAnswer, string roundResult) RoundResult(int num2, int userInput)
    {
        bool validAnswer;
        string roundResult;
        if (userInput == 0)
        {
            Console.WriteLine("Answer must be a number!  Try again:");
            validAnswer = false;
            roundResult = "Invalid!";
        }
        else if (num2 == userInput)
        {
            Console.WriteLine("Correct!");
            validAnswer = true;
            roundResult = "Correct!";
        }
        else
        {
            Console.WriteLine($"Incorrect!  The right answer is {num2}.");
            validAnswer = true;
            roundResult = "Incorrect!";
        }
        return (validAnswer, roundResult);
    }

    public static List<string> RecordRound(int num1, int num2, string operation, int userInput, int result, string roundResult, int roundCount, List<string> rounds)
    {
        rounds.Add($"Round {roundCount}: {num1} {operation} {num2} = {result}, User input: {userInput}, Result: {roundResult}");
        return rounds;
    }

}


