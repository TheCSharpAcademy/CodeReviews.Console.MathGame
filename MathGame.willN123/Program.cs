//My attempt at the math game project found on C# Academy.
//Contains games for the 4 basic operations and a random mode that uses all 4.

//Initialize variables.
Random random = new();

int firstNumber, secondNumber, questionCount, score, timeTaken;
int questionLimit = 5;
int lowerRange = 2;
int upperRange = 24;
int gamesPlayed = 0;
double calculationResult = 0;
double answer = 0;

string? readResult;
string operationLabel = "";
string separator = "".PadLeft(25, '-');
string outcomeText;
string[] gameResults = new string[50];

TimeSpan startTime, endTime;

bool validInput, gameRunning, randomMode;
bool programRunning = true;

MainMenu();

void MainMenu()
{
    do
    {
        DisplayMainMenuOptions();

        do
        {
            validInput = true;
            ChooseMainMenuOption();
        } while (!validInput);
    } while (programRunning);
}

void GameScreen(string operation)
{
    GameSetup(operation);

    SetOperationLabel(operation);

    GameLoop(operation);
}

void Settings()
{
    do
    {
        validInput = false;

        Console.Clear();
        Console.WriteLine(
@$"Math Game Collection
Settings
{separator}
1. Difficulty
2. Questions per round
3. Clear game history
4. Back to Menu");

        readResult = Console.ReadLine();
        Console.Clear();

        if (readResult != null)
        {
            switch (readResult)
            {
                case "1":
                    SetDifficulty();
                    break;
                case "2":
                    SetQuestions();
                    break;
                case "3":
                    ClearHistory();
                    break;
                case "4":
                    validInput = true;
                    break;
                default:
                    Console.WriteLine("Invalid input. Please enter a number from 1-4.");
                    break;
            }
        }
    } while (!validInput);
}

void GameHistory()
{
    Console.Clear();
    Console.WriteLine(
@$"Math Game Collection
Game History
{separator}");
    Console.WriteLine("   #\t|  Type\t| Score\t| Time(secs)");

    foreach (string game in gameResults)
    {
        if (game != null)
        {
            Console.WriteLine(game);
        }
    }

    Console.WriteLine(separator);
    Console.WriteLine("Press Enter to return to menu.");
    Console.ReadLine();
}

//Used in MainMenu() -
void DisplayMainMenuOptions()
{
    Console.Clear();
    Console.WriteLine(
@$"Math Game Collection
Menu
{separator}
1. Addition
2. Subtraction
3. Multiplication
4. Division
5. Random Mode
6. Game History
7. Settings
8. Exit
(Type a number and press Enter to choose)");
}

void ChooseMainMenuOption()
{
    readResult = Console.ReadLine();

    if (readResult != null)
    {
        switch (readResult)
        {
            case "1":
                GameScreen("+");
                break;
            case "2":
                GameScreen("-");
                break;
            case "3":
                GameScreen("x");
                break;
            case "4":
                GameScreen("/");
                break;
            case "5":
                GameScreen("random");
                break;
            case "6":
                GameHistory();
                break;
            case "7":
                Settings();
                break;
            case "8":
                Console.WriteLine("Exiting game.");
                programRunning = false;
                break;
            default:
                Console.WriteLine("Invalid input. Please enter a number from 1-8.");
                validInput = false;
                break;
        }
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a number from 1-8.");
        validInput = false;
    }
}

//Used in GameScreen() -
void GameLoop(string operation)
{
    do
    {
        questionCount++;

        DisplayGameHeader();

        if (randomMode)
        {
            operation = PickRandomOperation(operation);
        }

        GetNumbers(operation);

        Console.WriteLine($"{firstNumber} {operation} {secondNumber} = ?");

        CalculateCorrectAnswer(operation);

        GetUserAnswer();

        SetAnswerText();

        IncreaseScore();

        DisplayAnswerResult(operation);

        if (questionCount == questionLimit)
        {
            GetTime();

            SaveScore(randomMode ? "R" : operation);

            DisplayScore();

            EndCurrentGame();
        }

        Console.Clear();
    } while (gameRunning);
} //Most of program happens here.

void GameSetup(string operation)
{
    questionCount = 0;
    score = 0;

    startTime = DateTime.Now.TimeOfDay;

    randomMode = operation == "random";
    gameRunning = true;

    Console.Clear();
}

void SetOperationLabel(string operation)
{
    switch (operation)
    {
        case "+":
            operationLabel = "Addition";
            break;
        case "-":
            operationLabel = "Subtraction";
            break;
        case "x":
            operationLabel = "Multiplication";
            break;
        case "/":
            operationLabel = "Division";
            break;
        case "random":
            operationLabel = "Random";
            break;
    }
}

void DisplayGameHeader()
{
    Console.WriteLine(@$"Math Game Collection
{operationLabel} Game
{separator}");
}

void GetNumbers(string operation)
{
    if (operation == "/")
    {
        do
        {
            firstNumber = random.Next(lowerRange, upperRange);
            secondNumber = random.Next(lowerRange, upperRange);
        } while (firstNumber % secondNumber != 0 && firstNumber != secondNumber);
    }
    else
    {
        firstNumber = random.Next(lowerRange, upperRange);
        secondNumber = random.Next(lowerRange, upperRange);
    }
}

string PickRandomOperation(string operation)
{
    int pickOperation = random.Next(0, 4);

    switch (pickOperation)
    {
        case 0:
            operation = "+";
            break;
        case 1:
            operation = "-";
            break;
        case 2:
            operation = "x";
            break;
        case 3:
            operation = "/";
            break;
    }

    return operation;
}

void CalculateCorrectAnswer(string operation)
{
    switch (operation)
    {
        case "+":
            calculationResult = firstNumber + secondNumber;
            break;
        case "-":
            calculationResult = firstNumber - secondNumber;
            break;
        case "x":
            calculationResult = firstNumber * secondNumber;
            break;
        case "/":
            calculationResult = firstNumber / secondNumber;
            break;
    }
}

void GetUserAnswer()
{
    validInput = false;

    do
    {
        readResult = Console.ReadLine();
        if (readResult != null && Double.TryParse(readResult, out answer))
        {
            validInput = true;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    } while (!validInput);
}

void SetAnswerText()
{
    if (answer == calculationResult)
    {
        outcomeText = "Correct!";
    }
    else
    {
        outcomeText = "Incorrect!";
    }
}

void IncreaseScore()
{
    if (answer == calculationResult)
        score++;
}

void DisplayAnswerResult(string operation)
{
    Console.WriteLine($"{outcomeText} {firstNumber} {operation} {secondNumber} = {calculationResult}\nScore: {score}/{questionCount}");
    Console.WriteLine("Press Enter to continue.");
    Console.ReadLine();
}

void GetTime()
{
    endTime = DateTime.Now.TimeOfDay;
    timeTaken = (int)(endTime - startTime).TotalSeconds;
}

void SaveScore(string operation)
{
    gameResults[gamesPlayed] = $"   {gamesPlayed + 1}\t|   {operation}\t|  {score}/{questionCount}\t|  {timeTaken}";
}

void DisplayScore()
{
    Console.WriteLine(separator);
    Console.WriteLine($"Game Over! Final Score: {score}/{questionCount}. Time: {timeTaken}s");
}

void EndCurrentGame()
{
    gameRunning = false;
    gamesPlayed++;
    Console.WriteLine("Press Enter to return to Menu.");
    Console.ReadLine();
}

//Used in Settings() -
void SetDifficulty()
{
    Console.WriteLine(
$@"Math Game Collection
Difficulty
{separator}
1. Easy
2. Medium
3. Hard");

    do
    {
        validInput = true;
        readResult = Console.ReadLine();

        if (readResult != null)
        {
            switch (readResult)
            {
                case "1":
                    upperRange = 24;
                    Console.WriteLine("Difficulty set to \"Easy\"");
                    break;
                case "2":
                    upperRange = 48;
                    Console.WriteLine("Difficulty set to \"Medium\"");
                    break;
                case "3":
                    upperRange = 96;
                    Console.WriteLine("Difficulty set to \"Hard\"");
                    break;
                default:
                    validInput = false;
                    Console.WriteLine("Invalid input. Please enter a number from 1-3.");
                    break;
            }
        }
    } while (!validInput);

    validInput = false;
    Console.WriteLine("Press Enter to return to settings.");
    Console.ReadLine();
}

void SetQuestions()
{
    Console.WriteLine(
@$"Math Game Collection
Questions per round
{separator}
Enter the number of questions per round.");

    do
    {
        readResult = Console.ReadLine();

        if (readResult != null && Int32.TryParse(readResult, out questionLimit))
        {
            validInput = true;

            Console.WriteLine($"Questions set to {questionLimit}");
            Console.WriteLine("Press Enter to return to settings.");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a positive number.");
        }
    } while (!validInput);

    validInput = false;
}

void ClearHistory()
{
    Console.WriteLine(
@$"Math Game Collection
Clear game history
{separator}
Clear game history? (y/n)");

    do
    {
        readResult = Console.ReadLine();

        if (readResult != null)
        {
            switch (readResult.ToLower())
            {
                case "y":
                    gameResults = new string[20];
                    gamesPlayed = 0;
                    validInput = true;

                    Console.WriteLine("Deleting game history.");
                    Console.WriteLine("Press Enter to return to settings.");
                    Console.ReadLine();
                    break;
                case "n":
                    validInput = true;

                    Console.WriteLine("Keeping game history.");
                    Console.WriteLine("Press Enter to return to settings.");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Invalid input. Please enter \"y\" or \"n\".");
                    break;
            }
        }
    } while (!validInput);

    validInput = false;
}