/*
    Intentionally tried to stick to concepts taught in the foundational C# course on FreeCodeCamp.
    I did use Records to keep things DRY and I used Console.SetCursorPosition() for a better CLI experience.
*/

const int NUMBER_OF_QUESTIONS = 5;
DifficultyLevel[] DIFFICULTIES =
[
    new DifficultyLevel("Easy", Multiplier: 1, MaxAnswer: 10, MaxDivisor: 10),
    new DifficultyLevel("Medium", Multiplier: 5, MaxAnswer: 25, MaxDivisor: 12),
    new DifficultyLevel("Hard", Multiplier: 10, MaxAnswer: 50, MaxDivisor: 20)
];
OperatorInfo[] OPERATORS =
[
    new OperatorInfo('+', "Addition"),
    new OperatorInfo('-', "Subtraction"),
    new OperatorInfo('*', "Multiplication"),
    new OperatorInfo('/', "Division")
];

List<List<QuestionAttempt>> gameHistory = [];
int currentDifficultyIndex = 0;

RunApp();

void RunApp()
{
    bool running = true;

    do
    {
        Console.Clear();
        DisplayMenu();

        Console.Write("Please select an option: ");
        string? option = Console.ReadLine();

        switch (option)
        {
            // 1. Play
            case "1":
                var mathOperator = SelectMathOperator();
                var questions = GenerateQuestionCollection(mathOperator);
                PlayGame(questions);
                break;

            // 2. Change Difficulty
            case "2":
                ChangeDifficulty();
                break;

            // 3. View History
            case "3":
                ViewHistory();
                break;

            // 3. Exit
            case "4":
                Console.WriteLine("\nThank you for playing!\n");
                running = false;
                break;

            default:
                Console.WriteLine("\nInvalid option. Please try again.");
                break;
        }

        if (running)
        {
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
    while (running);
}

void DisplayMenu()
{
    Console.Clear();
    Console.WriteLine("Welcome to the Math Game!");
    Console.WriteLine("1. Play");
    Console.WriteLine($"2. Change Difficulty (Current: {DIFFICULTIES[currentDifficultyIndex].Name})");
    Console.WriteLine("3. View History");
    Console.WriteLine("4. Exit");
}

// TODO: This function does too much, consider refactoring into smaller functions
char SelectMathOperator()
{
    char chosenOperator;
    bool running = true;

    do
    {
        Console.Clear();
        Console.WriteLine("Choose a math operation to test yourself with:");

        // Display options from the OPERATORS list
        for (int i = 0; i < OPERATORS.Length; i++)
        {
            // example: "3. * (Multiplication)"
            Console.WriteLine($"{i + 1}. {OPERATORS[i].Symbol} ({OPERATORS[i].Name})");
        }
        Console.WriteLine($"{OPERATORS.Length + 1}. ? (Random)");

        Console.Write("Please select an option: ");
        string? userInput = Console.ReadLine();

        if (int.TryParse(userInput, out int choice))
        {
            // Valid Choice
            if (choice >= 1 && choice <= OPERATORS.Length)
            {
                chosenOperator = OPERATORS[choice - 1].Symbol;
                running = false;
            }

            // The random operator option is always the last one, so we can check if the choice is equal to OPERATORS.Count + 1
            else if (choice == OPERATORS.Length + 1)
            {
                chosenOperator = '?';
                running = false;
            }

            // If the input is a number but not within the valid range, we can set chosenOperator to '\0' to trigger the invalid option message
            else
            {
                chosenOperator = '\0';
            }
        }

        // If the input is not a number, we can also set chosenOperator to '\0' to trigger the invalid option message
        else
        {
            chosenOperator = '\0';
        }

        if (chosenOperator == '\0')
        {
            Console.WriteLine("\nInvalid option. Please try again.");
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
    while (running);

    return chosenOperator;
}

void PlayGame(List<(string question, int answer)> questions)
{
    List<QuestionAttempt> currentGameHistory = [];

    Console.Clear();
    Console.WriteLine("Great.. let's play!\n");

    for (int i = 0; i < questions.Count; i++)
    {
        (string question, int answer) = questions[i];
        bool validInput = false;
        DateTime startTime = DateTime.Now;

        while (!validInput)
        {

            ResetLines(rows: 3, cols: 100);
            Console.WriteLine($"Question #{i + 1}");
            Console.Write($"What is the result of {question} ? ");

            validInput = int.TryParse(Console.ReadLine(), out int guess);

            if (!validInput)
            {
                Console.Write("Error. Please only enter integers...");
                Console.ReadKey();

                ResetLines(rows: 2, cols: 100);
            }

            else
            {
                bool isCorrect = guess == answer;
                string difficult = DIFFICULTIES[currentDifficultyIndex].Name;
                TimeSpan timeTaken = DateTime.Now - startTime;

                currentGameHistory.Add(new QuestionAttempt(difficult, question, answer, guess, isCorrect, timeTaken));
            }

            Console.WriteLine();
        }
    }
    gameHistory.Add(currentGameHistory);
}

void ChangeDifficulty()
{
    bool running = true;

    do
    {
        Console.Clear();
        Console.WriteLine("Select Difficulty Level:");

        for (int i = 0; i < DIFFICULTIES.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {DIFFICULTIES[i].Name}");
        }

        Console.Write("Please select an option: ");
        string? userInput = Console.ReadLine();

        if (int.TryParse(userInput, out int choice) && choice >= 1 && choice <= DIFFICULTIES.Length)
        {
            currentDifficultyIndex = choice - 1;
            Console.WriteLine($"\nDifficulty set to {DIFFICULTIES[currentDifficultyIndex].Name}.");
            running = false;
        }
        else
        {
            Console.WriteLine("\nInvalid option. Please try again.");
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
    while (running);
}

List<(string question, int answer)> GenerateQuestionCollection(char mathOperator)
{
    List<(string question, int answer)> questions = [];

    for (int i = 0; i < NUMBER_OF_QUESTIONS; i++)
    {
        char currentOperator = GetOperatorForQuestion(mathOperator);
        (int x, int y, int answer) = GenerateQuestion(currentOperator);

        var questionText = $"{x} {currentOperator} {y}";
        questions.Add((questionText, answer));
    }

    return questions;
}

char GetOperatorForQuestion(char mathOperator)
{
    if (mathOperator == '?')
    {
        return OPERATORS[Random.Shared.Next(OPERATORS.Length)].Symbol;
    }
    return mathOperator;
}

(int x, int y, int answer) GenerateQuestion(char mathOperator)
{
    int x, y, answer;
    var difficulty = DIFFICULTIES[currentDifficultyIndex];

    if (mathOperator == '/')
    {
        answer = Random.Shared.Next(2, difficulty.MaxAnswer + 1);
        y = Random.Shared.Next(2, difficulty.MaxDivisor + 1);
        x = y * answer;
    }

    else
    {
        x = Random.Shared.Next(1, 11 * difficulty.Multiplier);
        y = Random.Shared.Next(1, 11 * difficulty.Multiplier);

        // INFO: Using Func instead of switch expression would help keep it DRY
        answer = mathOperator switch
        {
            '+' => x + y,
            '-' => x - y,
            '*' => x * y,
            _ => throw new ArgumentException($"Unexpected operator received: {mathOperator}", nameof(mathOperator))
        };
    }

    return (x, y, answer);
}

void ViewHistory()
{
    Console.Clear();
    Console.WriteLine("Game History\n");

    if (gameHistory.Count == 0)
    {
        Console.WriteLine("No games played yet.\n");
        return;
    }

    for (int i = 0; i < gameHistory.Count; i++)
    {
        string difficulty = gameHistory[i][0].Difficulty;
        var totalTimeTaken = TimeSpan.Zero;

        foreach (var attempt in gameHistory[i])
        {
            totalTimeTaken += attempt.Time;
        }

        Console.WriteLine($"Game #{i + 1} | Difficulty: {difficulty} | Time: {totalTimeTaken.TotalSeconds:N2} seconds");
        Console.WriteLine($"{"Question",-10}{"Answer",10}{"Guess",10}{"Correct",12}{"Time (s)",12}");

        foreach (QuestionAttempt attempt in gameHistory[i])
        {
            Console.WriteLine($"{attempt.Question,-10}{attempt.Answer,10}{attempt.Guess,10}{attempt.IsCorrect,12}{attempt.Time.TotalSeconds,12:N2}");
        }

        Console.WriteLine();
    }
}

// TODO: Remove magic numbers?
void ResetLines(int rows, int cols)
{
    Console.SetCursorPosition(0, 2);

    for (int i = 0; i < rows; i++)
    {
        Console.WriteLine(new string(' ', cols));
    }
    Console.SetCursorPosition(0, 2);
}

record OperatorInfo(char Symbol, string Name);
record QuestionAttempt(string Difficulty, string Question, int Answer, int Guess, bool IsCorrect, TimeSpan Time);
record DifficultyLevel(string Name, int Multiplier, int MaxAnswer, int MaxDivisor);