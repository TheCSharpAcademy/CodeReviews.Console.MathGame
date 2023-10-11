using System.Diagnostics;

Console.Title = "SpeedMath";
MainMenu();

// Requirement 2
// Users are presented with a menu with multiple options
// Depending on the difficulty, users are given different operations
static void MainMenu()
{
    Console.WriteLine("Welcome to SpeedMath!");

    List<List<string>> history = new();
    int choice = DisplayMenu();

    do
    {
        if (choice == 1)
        {
            List<string> result = GameLoop(false);
            history.Add(result);
        }
        else if (choice == 2)
        {
            List<string> result = GameLoop(true);
            history.Add(result);
        }
        else if (choice == 3)
        {
            DisplayHistory(history);
        }

        choice = DisplayMenu();
    } while (choice != -1);
}

static int DisplayMenu()
{
    string prompt = "";
    prompt += "Main Menu -- Choose an option:\n";
    prompt += "1. Start Game\n";
    prompt += "2. Start Random Game\n";
    prompt += "3. View previous games\n";

    int choice = ValidateInput(prompt, 1, 3);

    return choice;
}

static void DisplayHistory(List<List<string>> history)
{
    if (history.Count == 0) { return; }

    Console.WriteLine("Previous games:\n");
    for (int i = 0; i < history.Count; i++)
    {
        Console.WriteLine($"{i + 1}. Game {i + 1}");
    }

    string prompt = "Select which game you want to view:";
    int choice = ValidateInput(prompt, 1, history.Count);
    Console.WriteLine($"Game {choice} history:\n");

    for (int i = 0; i < history[choice - 1].Count; i++)
    {
        Console.Write(history[choice - 1][i]);
    }
    Console.WriteLine("\n");
}

// Requirement 1
// The math game contains all four basic operations depending on difficulty
//
// Challenge 2
// A timer tracks how long each game takes, and is then appended to the game's results
static List<string> GameLoop(bool random)
{
    int difficulty = GetDifficulty();
    Question[] questions = GenerateQuestions(difficulty, random);
    List<string> results = new();
    Stopwatch stopwatch = new();

    int currentQuestion = 0;
    int missedQuestions = 0;

    stopwatch.Start();

    while (currentQuestion < questions.Length)
    {
        Console.WriteLine($"Question {currentQuestion + 1}:");

        int leftNumeral = questions[currentQuestion].LeftNumeral;
        int rightNumeral = questions[currentQuestion].RightNumeral;
        string operand = questions[currentQuestion].Operand;
        Console.WriteLine($"{leftNumeral} {operand} {rightNumeral}");

        int answer = GetAnswer(leftNumeral, rightNumeral, operand);
        int guess = GetGuess();

        if (guess == answer)
        {
            Console.WriteLine("Correct!\n");
            results.Add($"{leftNumeral} {operand} {rightNumeral} = {guess} (CORRECT)\n");
            currentQuestion++;
        }
        else
        {
            Console.WriteLine("Incorrect! Keep trying!\n");
            results.Add($"{leftNumeral} {operand} {rightNumeral} = {guess} (INCORRECT)\n");
            missedQuestions++;
        }
    }

    stopwatch.Stop();
    double totalMinutes = stopwatch.Elapsed.Minutes;
    double totalSeconds = stopwatch.Elapsed.Seconds;

    string plural = missedQuestions == 1 ? "question" : "questions";
    string pluralMinute = totalMinutes == 1 ? "minute" : "minutes";
    string pluralSecond = totalSeconds == 1 ? "second" : "seconds";

    results.Add($"Completed with {missedQuestions} missed {plural}!\n");
    results.Add($"Time taken: {totalMinutes} {pluralMinute} and {totalSeconds} {pluralSecond}\n");
    return results;
}

static int GetAnswer(int leftNumeral, int rightNumeral, string operand)
{
    return operand switch
    {
        "+" => leftNumeral + rightNumeral,
        "-" => leftNumeral - rightNumeral,
        "*" => leftNumeral * rightNumeral,
        "/" => leftNumeral / rightNumeral,
        _ => 0,
    };
}

// Requirement 3
// Users are given a menu where they can choose the type
// of operation they want to practice
static string GetOperation()
{
    string prompt = "Choose an operation: \n";
    prompt += "1. Addition\n";
    prompt += "2. Subtraction\n";
    prompt += "3. Multiplication\n";
    prompt += "4. Division\n";

    int operation = ValidateInput(prompt, 1, 4);
    string selectedOperation = operation switch
    {
        1 => "+",
        2 => "-",
        3 => "*",
        4 => "/",
        _ => ""
    };

    return selectedOperation;
}

static string GetRandomOperation()
{
    string[] operations = { "+", "-", "*", "/" };
    var random = new Random();
    return operations[random.Next(0, 4)];
}

static int GetGuess()
{
    string prompt = "Enter your guess: \n";
    int guess = ValidateInput(prompt, -10001, 10001);
    return guess;
}

static Question[] GenerateQuestions(int difficulty, bool random = false)
{
    int questionLength = GetQuestionLength();
    Question[] questions = new Question[questionLength];

    // Difficulty + 1 because Random() is non-inclusive
    string operation = "";
    if (!random) { operation = GetOperation(); }

    for (int i = 0; i < questionLength; i++)
    {
        Question question;
        if (random) { question = CreateNewQuestion(difficulty, GetRandomOperation()); }
        else { question = CreateNewQuestion(difficulty, operation); }
        questions[i] = question;
    }

    return questions;
}

// Requirement 2
// Generate the dividend first, which can range from 0 to 100
// Division should only ever produce whole numbers (integers)
static Question CreateNewQuestion(int difficulty, string operation)
{
    Question question = new();
    var rand = new Random();
    if (operation == "/")
    {
        int dividend = rand.Next(0, 101);
        int divisor = rand.Next(1, 101);

        while (dividend % divisor != 0 || !CheckDivision(difficulty, dividend, divisor) || dividend < divisor) 
        { 
            divisor = rand.Next(1, 101);
            dividend = rand.Next(0, 101);
        } // Only create whole quotients

        question.LeftNumeral = dividend;
        question.RightNumeral = divisor;
    }
    else
    {
        int leftNumber = rand.Next(0, 101);
        int rightNumber = rand.Next(0, 101);

        while (!CheckDifficulty(difficulty, leftNumber, rightNumber))
        {
            leftNumber = rand.Next(0, 101);
            rightNumber = rand.Next(0, 101);
        }

        question.LeftNumeral = leftNumber;
        question.RightNumeral = rightNumber;
    }

    question.Operand = operation;
    return question;
}

// Challenge 1 - Implement levels of difficulty
// Difficulty 1 only allows multiples of 5, or 10
// Difficulty 2 disables 0, 1, and 5, and duplicate numbers, results > 7
// Difficulty 3 disables 0, 1, 2, and any multiple of 5, duplicate numbers, results < 3
static bool CheckDivision(int difficulty, int dividend, int divisor)
{
    if (difficulty == 1)
    {
        if (dividend % 5 != 0) 
        {
            return false;
        }
        else if (divisor % 5 != 0)
        {
            return false;
        }
    }
    else if (difficulty == 2)
    {
        int[] forbiddenNumbers = { 0, 1, 5 };
        if (forbiddenNumbers.Contains(divisor) || 
            forbiddenNumbers.Contains(dividend) ||
            dividend == divisor ||
            dividend / divisor > 7)
        {
            return false;
        }
    }
    else if (difficulty == 3)
    {
        int[] forbiddenNumbers = { 0, 1, 2, 5 };
        if (forbiddenNumbers.Contains(divisor) ||
            forbiddenNumbers.Contains(dividend) || 
            divisor % 5 == 0 ||
            dividend % 5 == 0 ||
            dividend == divisor ||
            dividend / divisor < 3)
        {
            return false;
        }
    }

    return true;
}

static bool CheckDifficulty(int difficulty, int leftNumber, int rightNumber)
{
    if (difficulty == 1)
    {
        if (leftNumber > 10 ||
            rightNumber > 10)
        {
            return false;
        }
    }
    else if (difficulty == 2)
    {
        if (leftNumber > 15 || rightNumber > 15) 
        { 
            return false; 
        }
    }
    else
    {
        if (leftNumber < 3 || rightNumber < 3)
        {
            return false;
        }
    }

    return true;
}

static int GetDifficulty()
{
    string prompt = "";
    prompt += "Levels of difficulty:\n";
    prompt += "1: Beginner (Addition and Subtraction)\n";
    prompt += "2: Intermediate (Includes Multiplication)\n";
    prompt += "3: Advanced (Includes Multiplication and Division)\n";

    int difficulty = ValidateInput(prompt, 1, 3);
    return difficulty;
}

// Challenge 3 - Let users choose the number of questions
static int GetQuestionLength()
{
    string prompt = "How many questions do you want?: \n";
    int questionLength = ValidateInput(prompt, 1, 100);
    return questionLength;
}

static int ValidateInput(string prompt, int minInput, int maxInput)
{
    int output;
    while (true)
    {
        Console.WriteLine(prompt);
        string input = Console.ReadLine() ?? "";

        if (int.TryParse(input, out output))
        {
            if (output >= minInput && output <= maxInput)
            {
                break;
            }
        }
    }
    return output;
}

class Question
{
    public int LeftNumeral { get; set; }
    public int RightNumeral { get; set; }
    public string Operand { get; set; } = "";
}
