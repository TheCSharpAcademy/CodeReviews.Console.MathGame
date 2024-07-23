using System.Diagnostics;
using MathGame;

List<GameRound> history = [];
GameRound currentRound = new();
bool exit = false;
Clear();

do
{
    DisplayMenu();
    string selection = ReadLine()!;
    Clear();

    switch (selection)
    {
        case "1":
            currentRound.OperatorSign = "+";
            break;
        case "2":
            currentRound.OperatorSign = "-";
            break;
        case "3":
            currentRound.OperatorSign = "*";
            break;
        case "4":
            currentRound.OperatorSign = "/";
            break;
        case "5":
            SetDifficulty(currentRound);
            continue;
        case "6":
            DisplayHistory();
            continue;
        case "0":
            exit = true;
            continue;
        default:
            WriteLine($"Invalid character! Try again..");
            continue;
    }

    currentRound.Calculate();

    WriteLine($"{currentRound.FirstOperand} {currentRound.OperatorSign} {currentRound.SecondOperand} = ??");
    Write("Answer: ");

    Stopwatch stopwatch = new();
    stopwatch.Start();

    currentRound.Answer = GetAnswer(currentRound);

    stopwatch.Stop();
    currentRound.Duration = stopwatch.Elapsed;

    history.Add(currentRound);

    currentRound = new(currentRound._difficulty);
} while (!exit);


static void DisplayMenu()
{
    WriteLine("Choose option:");
    WriteLine("1: Summation");
    WriteLine("2: Subtraction");
    WriteLine("3: Multiplication");
    WriteLine("4: Division");
    WriteLine("5: Select difficulty");
    WriteLine("6: Check previous results");
    WriteLine("0: Quit");
    Write("Selection: ");
}

static void DisplayDifficultyMenu()
{
    Clear();
    WriteLine("Choose difficulty:");
    WriteLine("1: Easy");
    WriteLine("2: Medium");
    WriteLine("3: Hard");
    WriteLine("0: Go back");
    Write("Selection: ");
}

void DisplayHistory()
{
    WriteLine("Results so far: ");
    if (history.Count == 0)
    {
        WriteLine("There are no results yet..");
        return;
    }

    WriteLine($"{"Type",4} | {"Question",12} | {"Answer",7} | {"Result",9} | {"Time Taken",11} | {"Difficulty",11}");
    WriteLine(new string('-', 69));

    foreach (GameRound round in history)
    {
        WriteLine(format: "{0,3}  | {1,12} | {2,7} | {3,9} | {4,11:N2} | {5,11}",
        round.OperatorSign,
        $"{round.FirstOperand} {round.OperatorSign} {round.SecondOperand}",
        round.Answer,
        round.IsCorrect ? "Correct" : "Incorrect",
        round.Duration.TotalSeconds,
        round.Difficulty
        );
    }
    int correctCount = history.FindAll(x => x.IsCorrect == true).Count;
    int totalCount = history.Count;
    WriteLine($"{correctCount} right answer(s) out of {totalCount} total question(s).");
    int percent = (int)(correctCount / (double)totalCount * 100);
    WriteLine($"{percent}% correct.\n");
}

static void SetDifficulty(GameRound round)
{
    DisplayDifficultyMenu();

    while (true)
    {
        switch (ReadLine())
        {
            case "1":
                round.Difficulty = "1";
                break;
            case "2":
                round.Difficulty = "2";
                break;
            case "3":
                round.Difficulty = "3";
                break;
            case "0":
                break;
            default:
                WriteLine($"Invalid character! Try again..");
                continue;
        }
        break;
    }
    WriteLine();
}

static int GetAnswer(GameRound round)
{
    int _answer;
    while (!int.TryParse(ReadLine(), out _answer))
    {
        WriteLine("That is not a whole number..");
        Write("Try again: ");
    }

    if (_answer == round.CorrectResult)
    {
        WriteLine($"Correct!\n");
    }
    else
    {
        WriteLine($"Incorrect!\n");
    }

    return _answer;
}
