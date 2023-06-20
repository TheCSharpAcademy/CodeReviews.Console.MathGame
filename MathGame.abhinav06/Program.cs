using MathGame;
using MathGame.Entities;
using Sharprompt;

List<HistoryRecord> records = new();
Start();

void Start()
{
    Helpers.WriteUsingTypeWriter("Hello there!");
    Helpers.DisplayTable(records);
    Helpers.WriteUsingTypeWriter("Use arrow keys to navigate through the menu.");
    Console.WriteLine();

    var operation = Prompt.Select<Operation>("Pick the poison of your choice");

    if (operation == Operation.RandomOperation)
        ConductRandomOperationQuiz();

    else ConductStandardQuiz(operation);
}

void ConductRandomOperationQuiz()
{
    Console.Clear();
    var startTime = DateTime.Now;
    var score = QuizManager.StartRandom();
    var endTime = DateTime.Now;

    Console.Clear();
    Console.WriteLine((score > 5 ? "Awesome!" : "Good try.") + $" You survived {score} " + (score == 1 ? "time." : "times."));
    records.Add(new HistoryRecord
    {
        Date = DateTime.Now,
        Difficulty = Level.Hard,
        GameType = Operation.RandomOperation,
        Duration = endTime - startTime,
        Score = score
    });

    RedirectToStart();
}

void ConductStandardQuiz(Operation operation)
{
    var difficulty = Prompt.Select<Level>("Now, select your dose");
    Console.Clear();

    var startTime = DateTime.Now;
    var score = QuizManager.StartQuiz(operation, difficulty);
    var endTime = DateTime.Now;

    Console.Clear();
    ShowEndScreen(operation, difficulty, score, endTime - startTime);
}

void ShowEndScreen(Operation operation, Level difficulty, int score, TimeSpan duration)
{
    Helpers.WriteUsingTypeWriter($"You scored {score}! " + GetCompliment(score, difficulty));
    records.Add(new HistoryRecord
    {
        Date = DateTime.Now,
        Difficulty = difficulty,
        GameType = operation,
        Duration = duration,
        Score = score
    });

    RedirectToStart();
}

void RedirectToStart()
{
    Helpers.WriteUsingTypeWriter("Press any key to continue...");
    Console.ReadKey();
    Console.Clear();
    Start();
}

static string GetCompliment(int score, Level difficulty) => score switch
{
    10 => "Genius! Keep it up. " + (difficulty != Level.Hard ? "Why not try a harder level next time?" : ""),
    > 9 => "Splendid! You're almost there.",
    > 8 => "Brilliant! That's a really good score.",
    > 6 => "Awesome! You can do better.",
    > 4 => "Good. Practice harder!",
    _ => "Try to get a better score next time!",
};