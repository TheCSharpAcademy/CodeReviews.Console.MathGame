/*
REQUIREMENTS

You need to create a game that consists of asking the player what's the result of a math question (i.e. 9 x 9 = ?), collecting the input and adding a point in case of a correct answer.

A game needs to have at least 5 questions.

The divisions should result on INTEGERS ONLY and dividends should go from 0 to 100. Example: Your app shouldn't present the division 7/2 to the user, since it doesn't result in an integer.

Users should be presented with a menu to choose an operation

You should record previous games in a List and there should be an option in the menu for the user to visualize a history of previous games.

You don't need to record results on a database. Once the program is closed the results will be deleted.

----------------------------------------------------------------

CHALLENGES

Try to implement levels of difficulty.

Add a timer to track how long the user takes to finish the game.

Create a 'Random Game' option where the players will be presented with questions from random operations

To follow the DRY Principle, try using just one method for all games. Additionally, double check your project and try to find opportunities to achieve the same functionality with less code, avoiding repetition when possible.
*/

using System.Diagnostics;

Diffculty selectedDifficulty = Diffculty.Easy;
bool keepPlaying = true;
Random random = new Random();
var history = new List<string>();

while (keepPlaying)
{
    Console.Clear();
    Console.WriteLine("Welcome to the Math Game! Please select an option below to continue:");
    Console.WriteLine("1 - Addition");
    Console.WriteLine("2 - Subtraction");
    Console.WriteLine("3 - Multiplication");
    Console.WriteLine("4 - Division");
    Console.WriteLine("5 - Random");
    Console.WriteLine("6 - Select Difficulty");
    Console.WriteLine("7 - Show History");
    Console.WriteLine("0 - Exit");
    Console.Write("Select an option: ");

    string? userInput = Console.ReadLine();

    switch (userInput)
    {
        case "0":
            keepPlaying = false;
            break;
        case "1":
            PlayGame(Operation.Addition);
            break;
        case "2":
            PlayGame(Operation.Subtraction);
            break;
        case "3":
            PlayGame(Operation.Multiplication);
            break;
        case "4":
            PlayGame(Operation.Division);
            break;
        case "5":
            PlayGame(Operation.Random);
            break;
        case "6":
            ChangeDifficulty();
            break;
        case "7":
            ShowHistory();
            break;
        default:
            Console.WriteLine("Invalid input. Please try again.");
            continue;
    }
}

void PlayGame(Operation selectedOperation)
{
    Console.Clear();
    Console.WriteLine($"Starting {selectedOperation} game on {selectedDifficulty} difficulty...");
    int score = 0;
    int maxNumber = selectedDifficulty == Diffculty.Easy ? 10 : selectedDifficulty == Diffculty.Medium ? 50 : 100;

    var stopwatch = Stopwatch.StartNew();

    for (int i = 1; i <= 5; i++)
    {
        Operation currentOperation = selectedOperation == Operation.Random ? (Operation)random.Next(0, 4) : selectedOperation;
        int num1 = random.Next(0, maxNumber + 1);
        int num2 = random.Next(0, maxNumber + 1);
        int answer = 0;
        string operationSymbol = "";

        if (currentOperation == Operation.Division)
        {
            if (num2 == 0)
            {
                num2 = 1;
            }

            while (num1 % num2 != 0)
            {
                num2 = random.Next(1, maxNumber + 1);
            }

            answer = num1 / num2;
            operationSymbol = "/";
        }
        else
        {
            switch (currentOperation)
            {
                case Operation.Addition:
                    answer = num1 + num2;
                    operationSymbol = "+";
                    break;
                case Operation.Subtraction:
                    answer = num1 - num2;
                    operationSymbol = "-";
                    break;
                case Operation.Multiplication:
                    answer = num1 * num2;
                    operationSymbol = "*";
                    break;
            }
        }

        Console.WriteLine($"Question {i}: {num1} {operationSymbol} {num2} = ?");
        string? userAnswerInput = Console.ReadLine();
        if (int.TryParse(userAnswerInput, out int userAnswer) && userAnswer == answer)
        {
            Console.WriteLine("Correct!");
            score++;
        }
        else
        {
            Console.WriteLine($"Wrong! The correct answer is {answer}");
        }
    }

    stopwatch.Stop();
    var timeSpan = stopwatch.Elapsed;
    string formatetdTime = $"{(int)timeSpan.TotalMinutes} min {timeSpan.Seconds} sec";
    Console.WriteLine($"\nGame Over! Score: {score}. Time taken: {formatetdTime}. Press Enter to continue");
    history.Add($"{selectedOperation} ({selectedDifficulty}) Score: {score}/5. Time taken: {formatetdTime}");
    Console.ReadLine();
}

void ChangeDifficulty()
{
    Console.Clear();
    Console.WriteLine("Select difficulty");
    Console.WriteLine("1 - Easy (Numbers go from 0 - 10)");
    Console.WriteLine("2 - Medium (Numbers go from 0 - 50)");
    Console.WriteLine("3 - Hard (Numbers go from 0 - 100)");
    Console.Write("Select an option: ");

    string? userInput = Console.ReadLine();

    switch (userInput)
    {
        case "1":
            selectedDifficulty = Diffculty.Easy;
            break;
        case "2":
            selectedDifficulty = Diffculty.Medium;
            break;
        case "3":
            selectedDifficulty = Diffculty.Hard;
            break;
        default:
            Console.WriteLine($"Invalid input. Keeping current difficulty {selectedDifficulty}");
            break;
    }
}

void ShowHistory()
{
    Console.Clear();
    Console.WriteLine("Game History:");

    if (history.Count == 0)
    {
        Console.WriteLine("No games played.");
    }
    else
    {
        foreach (var item in history)
        {
            Console.WriteLine(item);
        }
    }
    Console.ReadLine();
}

enum Diffculty
{
    Easy, Medium, Hard
}

enum Operation
{
    Addition, Subtraction, Multiplication, Division, Random
}