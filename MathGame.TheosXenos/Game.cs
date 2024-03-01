public static class Game
{
    public static List<string> History { get; set; } = [];

    public static void Multiplication()
    {
        var questionOperator = "*";
        var rng = new Random();
        int a = rng.Next(0, 100);
        int b = rng.Next(0, 100);
        int correctAnswer = a * b;

        WriteQuestion(a, b, questionOperator);
        var userAnswer = GetUserAnswer();
        CheckUserAnswer(userAnswer, correctAnswer);
        AddToHistory(a, b, questionOperator, correctAnswer, userAnswer);
    }

    public static void Division()
    {
        var questionOperator = "/";
        var rng = new Random();
        int a;
        int b;
        int correctAnswer;

        do
        {
            a = rng.Next(0, 100);
            b = rng.Next(1, 100);

            correctAnswer = a / b;
        } while (a % b != 0);

        WriteQuestion(a, b, questionOperator);
        var userAnswer = GetUserAnswer();
        CheckUserAnswer(userAnswer, correctAnswer);
        AddToHistory(a, b, questionOperator, correctAnswer, userAnswer);
    }

    public static void Addition()
    {
        var questionOperator = "+";
        var rng = new Random();
        int a = rng.Next(0, 100);
        int b = rng.Next(0, 100);
        int correctAnswer = a + b;

        WriteQuestion(a, b, questionOperator);
        var userAnswer = GetUserAnswer();
        CheckUserAnswer(userAnswer, correctAnswer);
        AddToHistory(a, b, questionOperator, correctAnswer, userAnswer);
    }

    public static void Subtraction()
    {
        var questionOperator = "-";
        var rng = new Random();
        int a = rng.Next(0, 100);
        int b = rng.Next(0, 100);
        int correctAnswer = a - b;

        WriteQuestion(a, b, questionOperator);
        var userAnswer = GetUserAnswer();
        CheckUserAnswer(userAnswer, correctAnswer);
        AddToHistory(a, b, questionOperator, correctAnswer, userAnswer);
    }

    private static void CheckUserAnswer(int userAnswer, int correctAnswer)
    {
        Console.WriteLine(userAnswer != correctAnswer
            ? $"Your answer {userAnswer} is not correct. The correct answer is {correctAnswer}."
            : $"Your answer {userAnswer} is correct.");
    }

    private static void AddToHistory(int a, int b, string questionOperator, int correctAnswer, int userAnswer)
    {
        History.Add($"{a} {questionOperator} {b} = ?\t{userAnswer}\t\t{correctAnswer}");
    }

    private static void WriteQuestion(int a, int b, string questionOperator)
    {
        Console.Clear();
        Console.WriteLine($"What is {a} {questionOperator} {b}?");
        Console.Write("Your answer: ");
    }

    private static int GetUserAnswer()
    {
        while (true)
        {
            var result = int.TryParse(Console.ReadLine(), out int userAnswer);

            if (!result)
            {
                Console.Write("Your answer is not a number.\nPlease try again: ");
            }

            return userAnswer;
        }
    }

    public static bool AskReturnToMenu()
    {
        Console.Write("Go back to the menu? [Y/n] ");
        var userChoice = Console.ReadLine();

        return userChoice?.ToLower() != "y" && userChoice?.ToLower() == "n";
    }

    public static string? ShowMenu()
    {
        Console.Clear();

        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Practice *");
        Console.WriteLine("2. Practice /");
        Console.WriteLine("3. Practice +");
        Console.WriteLine("4. Practice -");
        Console.WriteLine("5. Show History");
        Console.WriteLine("6. Exit");

        Console.Write("\nYour choice: ");
        return Console.ReadLine();
    }

    public static void ShowHistory()
    {
        Console.Clear();

        Console.WriteLine("Question\tYour answer\tCorrect Answer");
        foreach (var row in History)
        {
            Console.WriteLine(row);
        }

        Console.WriteLine("\nPress a key to go back to the menu.");
        Console.ReadKey();
    }
}
