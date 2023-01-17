namespace MathGame;

internal class ExerciseManager
{
    public static List<string> exercises = new();

    internal static void AddToHistory(int gameScore, string gameType)
    {
        exercises.Add($"{DateTime.Now} - {gameType}: {gameScore} pts");
    }

    internal static void StartExerciseRoutine(Operator op, int count)
    {
        int score = 0;
        for (int i = 0; i < count; i++)
        {
            score += RunExerciseAndRetrieveScore(op);
        }
        Console.WriteLine($"Exercise complete! You earnt {score} out of {count}.");
        AddToHistory(score, GetOperatorNameFromEnum(op));
    }

    private static int RunExerciseAndRetrieveScore(Operator op)
    {
        int[] nums = GetTwoRandomNumbers(op);
        int result = GetResult(nums[0], nums[1], op);
        Console.Write($"What is {nums[0]} {GetOperatorFromEnum(op)} {nums[1]}? ");
        int input = UserInput.GetAnswer();
        return ProcessAnswer(result, input);
    }

    private static int ProcessAnswer(int result, int input)
    {
        if (input == result)
        {
            Console.Write("Your answer was correct! Press any key to continue.");
            Console.ReadLine();
            return 1;
        }
        else
        {
            Console.Write($"Sorry, the answer was {result}. Press any key to continue.");
            Console.ReadLine();
            return 0;
        }
    }

    private static int[] GetTwoRandomNumbers(Operator op)
    {
        Random random = new();
        int[] nums = new int[2];

        if (op == Operator.Divide)
        {
            nums = GetDivisionNumbers();
            return nums;
        }

        nums[0] = random.Next(2, 99);
        nums[1] = random.Next(2, 99);
        return nums;
    }

    private static int[] GetDivisionNumbers()
    {
        Random random = new();
        int num1 = random.Next(2, 99);
        int num2 = random.Next(2, 99);
        int[] result = new int[2];

        while (num1 % num2 != 0)
        {
            num1 = random.Next(2, 99);
            num2 = random.Next(2, 99);
        }

        result[0] = num1;
        result[1] = num2;
        return result;
    }

    private static string GetOperatorFromEnum(Operator op)
    {
        return op switch
        {
            Operator.Add => "+",
            Operator.Subtract => "-",
            Operator.Multiply => "*",
            Operator.Divide => "/",
            _ => throw new NotImplementedException()
        };
    }

    private static string GetOperatorNameFromEnum(Operator op)
    {
        return op switch
        {
            Operator.Add => "Addition",
            Operator.Subtract => "Subtraction",
            Operator.Multiply => "Multiplication",
            Operator.Divide => "Division",
            _ => throw new NotImplementedException()
        };
    }

    private static int GetResult(int num1, int num2, Operator op)
    {
        return op switch
        {
            Operator.Add => num1 + num2,
            Operator.Subtract => num1 - num2,
            Operator.Multiply => num1 * num2,
            Operator.Divide => num1 / num2,
            _ => throw new NotImplementedException()
        };
    }

    internal static void PrintHistory()
    {
        Console.Clear();
        Console.WriteLine("Games History");
        Console.WriteLine("---------------------------");
        foreach (string exercise in exercises)
        {
            Console.WriteLine(exercise);
        }
        Console.WriteLine("---------------------------\n");
        Console.WriteLine("Press any key to return to Main Menu");
        Console.ReadLine();
    }
}
public enum Operator
{
    Add,
    Subtract,
    Multiply,
    Divide
}
