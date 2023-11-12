namespace Mathgame;

public class Game
{
    List<GameLog> Games = new List<GameLog> { };

    public void Run()
    {
        while (true)
        {
            showMenu();
            string command = getUserInput("Enter a number: ");

            switch (command)
            {
                case "1":
                    processAddition();
                    break;
                case "2":
                    processSubstraction();
                    break;
                case "3":
                    processMultiplication();
                    break;
                case "4":
                    processDivision();
                    break;
                case "5":
                    printLogs();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid input.Try again");
                    break;
            }
        }
    }

    private void printLogs()
    {
        Console.WriteLine("Previous games");
        Console.WriteLine("---------");
        foreach (var gameLog in Games)
        {
            Console.WriteLine(gameLog);
        }
        Console.WriteLine("---------");
    }

    string getUserInput(string message)
    {
        string input = string.Empty;
        do
        {
            Console.Write(message);
            input = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Not valid input.Try again.");
            }

        } while (string.IsNullOrEmpty(input));

        return input;
    }

    void showMenu()
    {
        Console.WriteLine("\nMain Menu");
        Console.WriteLine("---------\n");
        Console.WriteLine("What would you like to do?\n");
        Console.WriteLine("Type 1 for addition");
        Console.WriteLine("Type 2 for subtraction");
        Console.WriteLine("Type 3 for multiplication");
        Console.WriteLine("Type 4 for division");
        Console.WriteLine("Type 5 to print previous games");
        Console.WriteLine("Type 0 to Close Application");
        Console.WriteLine("---------------------------\n");
    }

    void processAddition()
    {
        Random random = new Random();
        int firstNumber = random.Next(0, 101);
        int secondNumber = random.Next(0, 101);
        int result = firstNumber + secondNumber;

        Console.WriteLine($"What is the result of this addition: {firstNumber} + {secondNumber} = ?");
        int userInput = Convert.ToInt32(Console.ReadLine());

        if (userInput == result)
        {
            Console.WriteLine("Correct!");
        }
        else
        {
            Console.WriteLine($"Wrong answer! The correct answer is: {result}");
        }

        Games.Add(new GameLog
        {
            FirstNumber = firstNumber,
            SecondNumber = secondNumber,
            Result = userInput,
            CorrectResult = result,
            GameOperator = "+"
        });

    }

    void processSubstraction()
    {
        Random random = new Random();
        int firstNumber = random.Next(0, 101);
        int secondNumber = random.Next(0, 101);
        int result = firstNumber - secondNumber;

        Console.WriteLine($"What is the result of this substraction: {firstNumber} - {secondNumber} = ?");
        int userInput = Convert.ToInt32(Console.ReadLine());

        if (userInput == result)
        {
            Console.WriteLine("Correct!");
        }
        else
        {
            Console.WriteLine($"Wrong answer! The correct answer is: {result}");
        }

        Games.Add(new GameLog
        {
            FirstNumber = firstNumber,
            SecondNumber = secondNumber,
            Result = userInput,
            CorrectResult = result,
            GameOperator = "-"
        });

    }

    void processMultiplication()
    {
        Random random = new Random();
        int firstNumber = random.Next(0, 101);
        int secondNumber = random.Next(0, 101);
        int result = firstNumber * secondNumber;

        Console.WriteLine($"What is the result of this multiplication: {firstNumber} * {secondNumber} = ?");
        int userInput = Convert.ToInt32(Console.ReadLine());

        if (userInput == result)
        {
            Console.WriteLine("Correct!");
        }
        else
        {
            Console.WriteLine($"Wrong answer! The correct answer is: {result}");
        }

        Games.Add(new GameLog
        {
            FirstNumber = firstNumber,
            SecondNumber = secondNumber,
            Result = userInput,
            CorrectResult = result,
            GameOperator = "*"
        });

    }

    void processDivision()
    {
        Random random = new Random();
        int firstNumber = random.Next(0, 101);
        int secondNumber = random.Next(1, 101);
        int result = firstNumber / secondNumber;

        while (firstNumber % secondNumber != 0)
        {
            firstNumber = random.Next(0, 101);
            secondNumber = random.Next(1, 101);
            result = firstNumber / secondNumber;
        }

        Console.WriteLine($"What is the result of this division: {firstNumber} / {secondNumber} = ?");
        int userInput = Convert.ToInt32(Console.ReadLine());

        if (userInput == result)
        {
            Console.WriteLine("Correct!");
        }
        else
        {
            Console.WriteLine($"Wrong answer! The correct answer is: {result}");
        }

        Games.Add(new GameLog
        {
            FirstNumber = firstNumber,
            SecondNumber = secondNumber,
            Result = userInput,
            CorrectResult = result,
            GameOperator = "/"
        });

    }
}

