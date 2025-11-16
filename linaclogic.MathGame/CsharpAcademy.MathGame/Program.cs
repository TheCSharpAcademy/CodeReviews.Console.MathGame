/*
Requirements (see https://www.thecsharpacademy.com/project/53/math-game)

1. You need to create a game that consists of asking the player what's the result of a
    math question (i.e. 9 x 9 = ?), collecting the input and adding a point in case
    of a correct answer.

2. A game needs to have at least 5 questions.

3. The divisions should result on INTEGERS ONLY and dividends should go from 0 to 100.
    Example: Your app shouldn't present the division 7/2 to the user, since it
    doesn't result in an integer.

4. Users should be presented with a menu to choose an operation

5. You should record previous games in a List and there should be an option in the
    menu for the user to visualize a history of previous games.

6. You don't need to record results on a database. Once the program is closed the
    results will be deleted.
*/

string[] gameNames = ["Addition", "Subtraction", "Multiplication", "Division"];
char[] operatorSymbols = ['+', '-', '*', '/'];

// the lowest and highest numbers to be used in all game types
const int minNumber = 0;
const int maxNumber = 100;
const int questionsPerGame = 5;

List<string> history = [];

MainMenu();

void MainMenu()
{
    bool exit = false;

    int totalPoints = 0;
    int questionsAnswered = 0;

    do
    {
        Console.Clear();
        Console.WriteLine("C# Academy's Math Game - Main Menu");
        Console.WriteLine();
        Console.WriteLine($"Points / Questions answered: {totalPoints} / {questionsAnswered}");
        Console.WriteLine();

        for (int i = 0; i < gameNames.Length; i++)
            Console.WriteLine($"{i+1} - {gameNames[i]}");

        Console.WriteLine();
        Console.WriteLine("H - Show game history");
        Console.WriteLine("Q - Quit the game");
        Console.WriteLine();
        Console.WriteLine("Please choose one of the available options:");

        string? readResult = Console.ReadLine();
        Console.WriteLine();

        if (readResult != null)
        {
            readResult = readResult.Trim().ToLower();
            if (readResult == "q")
            {
                exit = true;
                Environment.Exit(0);
            }
            else if (readResult == "h")
            {
                ShowHistory();
            }
            else if (int.TryParse(readResult, out int menuSelection))
            {
                if ((menuSelection >= 1) && (menuSelection <= 4))
                {
                    totalPoints += PlayGame(menuSelection - 1);
                    questionsAnswered += questionsPerGame;
                }
            }
        }
    } while (!exit);
}


int PlayGame(int gameType)
{
    Console.Clear();

    Random random = new();
    Console.WriteLine($"You are playing {gameNames[gameType]}!");

    int points = 0;

    for (int i = 0; i < questionsPerGame; i++)
    {
        int correctSolution = -1;
        int number1 = -1;
        int number2 = -1;

        switch (gameType)
        {
            case 0:
                // Addition
                // randomize correctSolution to get an even distribution of sums
                correctSolution = random.Next(minNumber, maxNumber + 1);
                number1 = random.Next(minNumber, correctSolution + 1);
                number2 = correctSolution - number1;
                break;
            case 1:
                // Subtraction
                // number2 <= number1 to make sure we get a positive result
                number1 = random.Next(minNumber, maxNumber + 1);
                number2 = random.Next(minNumber, number1 + 1);
                correctSolution = number1 - number2;
                break;
            case 2:
                // Multiplication
                // use truncated square root of maxNumber, to make sure that correctSolution <= maxNumber
                // TODO: currently a lot easier than Addition/Subtraction due to smaller numbers; change?
                number1 = random.Next(minNumber, (int)Math.Sqrt(maxNumber) + 1);
                number2 = random.Next(minNumber, (int)Math.Sqrt(maxNumber) + 1);
                correctSolution = number1 * number2;
                break;
            case 3:
                // Division
                // TODO: implement a better version; this one results in too many  0 / x = ? questions
                number2 = random.Next(minNumber, maxNumber + 1);
                correctSolution = random.Next(minNumber, maxNumber / number2 + 1);
                number1 = number2 * correctSolution;
                break;
        }

        points += AskQuestion(operatorSymbols[gameType], number1, number2, correctSolution);
    }
    RecordHistory(gameType, points);

    Console.WriteLine($"You scored {points} points.");
    WaitForKey();

    return points;
}

int AskQuestion(char operatorSymbol, int number1, int number2, int correctSolution)
{
    Console.WriteLine($"{number1} {operatorSymbol} {number2} = ?");

    int.TryParse(Console.ReadLine(), out int playerSolution);
    if (playerSolution == correctSolution)
        Console.WriteLine($"Correct!");
    else
        Console.WriteLine($"Wrong! The correct solution is {correctSolution}");

    Console.WriteLine();

    return playerSolution == correctSolution ? 1 : 0;
}

void RecordHistory(int gameType, int points)
{
    history.Add($"Game type: {gameNames[gameType]} - Points: {points}");
}

void ShowHistory()
{
    Console.Clear();

    if (history.Count > 0)
    {
        Console.WriteLine("Games played:");
        Console.WriteLine();

        foreach (string historyEntry in history)
            Console.WriteLine(historyEntry);
    }
    else
    {
        Console.WriteLine("You have not played any games yet.");
    }

    WaitForKey();
}

void WaitForKey()
{
    Console.WriteLine();
    Console.WriteLine("Press Enter to continue...");
    Console.ReadLine();
}