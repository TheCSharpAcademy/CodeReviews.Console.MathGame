using MathGame.Model;
using MathGame.View;

namespace MathGame.Controller;

internal class Game : Utility
{
    private int numberOfQuestions;

    internal int NumberOfQuestions
    {
        get => 5;
    }
    internal int RoundScore { get; set; }
    internal int DifficultyLevel { get; set; }

    internal void StartGame()
    {
        string? userName = string.Empty;
        while (true)
        {
            userName = ReadFromConsole("Enter Your Name: ");
            if (!string.IsNullOrEmpty(userName)) break;
        }
        while (true)
        {
            Menu.DisplayMenu(userName, out int userChoice, out int difficultyLevel/*, this*/);
            DifficultyLevel = difficultyLevel;
            Selection(userChoice);
        }
    }

    internal void Selection(int userChoice)
    {
        switch (userChoice)
        {
            case 1:
                Action<int> addition = Addition;
                QuestionLoop(addition, Operations.Addition);
                break;
            case 2:
                Action<int> subtraction = Subtraction;
                QuestionLoop(subtraction, Operations.Subtraction);
                break;
            case 3:
                Action<int> multiply = Multiplication;
                QuestionLoop(multiply, Operations.Multiplication);
                break;
            case 4:
                Action<int> divide = Division;
                QuestionLoop(divide, Operations.Division);
                break;
            case 5:
                QuestionLoop(Random, Operations.Random);
                break;   
            case 6:
                Menu.DisplayGameHistory(this);
                break;
            case 7:
                Environment.Exit(0);
                break;
        }
    }

    //Loop math operations
    private void QuestionLoop(Action<int> action, Operations operations)
    {
        DateTime startTime = DateTime.Now;
        Utility utility = new Utility();
        utility.MyTimeList.Add(startTime);

        Console.WriteLine($"{operations} Questions:\n");
        for (int i = 0; i < NumberOfQuestions; i++) { action(i); }
        CreateGamesHistory(RoundScore, operations);

        Console.WriteLine($"Game Over! Correct guess: {RoundScore}/{NumberOfQuestions}\n");
        RoundScore = 0;
        Console.Write("Press Enter to go back to main menu.");
        
        var key = Console.ReadKey();
        if (key.Key == ConsoleKey.Enter) return;
    }

    //Math Operations
    /*private void Addition()
    {
        var (num1, num2) = NumberGenerator(); //using tuples
        int sum = num1 + num2;
        Console.Write($"{num1} + {num2} = ");

        string userInput = ReadInput();
        Console.WriteLine(Judgement(userInput, sum));

        if (Judgement(userInput, sum) == "Correct!") counter++;
    }*/
    private void Random(int x)
    {
        Random random = new Random();

        int num1 = NumberGenerator(DifficultyLevel, out int num2);
        char[] array = { '+', '-', '*', '/' };

        int randomIndex = random.Next(0, 4);
        int randomOps = 0;

        switch (randomIndex)
        {
            case 0: randomOps = num1 + num2; break;
            case 1: randomOps = num1 - num2; break;
            case 2: randomOps = num1 * num2; break;
            case 3:
                {
                    List<int> numList = GetDivision(DifficultyLevel);
                    randomOps = numList[1] / numList[0];
                    num1 = numList[1];
                    num2 = numList[0];
                } break;
        }
        string message = Validation($"{x + 1}. {num1} {array[randomIndex]} {num2} = ", num1, num2, randomOps);
        if (Judgement(message, randomOps) == "Correct!") RoundScore++;
    }
    private void Addition(int x)
    {
        int num1 = NumberGenerator(DifficultyLevel, out int num2);
        int sum = num1 + num2;
        string message = Validation($"{x + 1}. {num1} + {num2} = ", num1, num2, sum);
        if (Judgement(message, sum) == "Correct!") RoundScore++;
    }
    private void Subtraction(int x)
    {
        int num1 = NumberGenerator(DifficultyLevel, out int num2);
        int diff = num1 - num2;
        string message = Validation($"{x + 1}. {num1} - {num2} = ", num1, num2, diff);
        if (Judgement(message, diff) == "Correct!") RoundScore++;
    }
    private void Multiplication(int x)
    {
        int num1 = NumberGenerator(DifficultyLevel, out int num2);
        int multiply = num1 * num2;
        string message = Validation($"{x + 1}. {num1} * {num2} = ", num1, num2, multiply);
        if (Judgement(message, multiply) == "Correct!") RoundScore++;
    }
    private void Division(int x)
    {
        List<int> numList = GetDivision(DifficultyLevel);
        int division = numList[1] / numList[0];
        string message = Validation($"{x + 1}. {numList[1]} / {numList[0]} = ", numList[1], numList[0], division);
        if (Judgement(message, division) == "Correct!") RoundScore++;
    }
}


