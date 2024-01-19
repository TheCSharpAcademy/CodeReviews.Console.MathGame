//My attempt at the math game project found on C# Academy.
//Contains games for the 4 basic operations and a random mode that uses all 4.

//Initialize variables.
Random random = new();

int firstNumber, secondNumber, questionCount, score;
int questionLimit = 5;
int lowerRange = 2;
int upperRange = 24;
int calculationResult = 0;
int gamesPlayed = 0;

string? readResult;
string operationLabel = "";
string separator = "".PadLeft(25, '-');

string[] gameResults = new string[20];

TimeSpan startTime;
TimeSpan endTime;
int timeTaken;

bool validInput;
bool programRunning = true;
bool gameRunning;
bool randomMode;

MainMenu();

void MainMenu()
{
    do
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

        do
        {
            validInput = true;

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
        } while (!validInput);
    } while (programRunning);
}

void GameScreen(string operation)
{
    questionCount = 0;
    score = 0;

    startTime = DateTime.Now.TimeOfDay;

    randomMode = operation == "random";
    gameRunning = true;

    Console.Clear();

    do
    {
        Console.WriteLine("Math Game Collection");
        GetNumbers();

        if (randomMode)
        {
            Console.WriteLine("Random Mode");

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
        }
        else
        {
            Console.WriteLine($"{operationLabel} Game");
        }

        Console.WriteLine(separator);
        CalculateAnswer(operation);
        Console.WriteLine($"{firstNumber} {operation} {secondNumber} = ?");

        validInput = false;
        do
        {
            readResult = Console.ReadLine();
            if (readResult != null && Int32.TryParse(readResult, out int answer))
            {
                validInput = true;

                if (answer == calculationResult)
                {
                    Console.Write("Correct! ");
                    score++;
                }
                else
                {
                    Console.Write("Incorrect! ");
                }

                questionCount++;

                Console.WriteLine($"{firstNumber} {operation} {secondNumber} = {calculationResult}\nScore: {score}/{questionCount}");
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();

                if (questionCount == questionLimit)
                {
                    endTime = DateTime.Now.TimeOfDay;
                    timeTaken = (int)(endTime - startTime).TotalSeconds;

                    SaveScore(randomMode ? "R" : operation);

                    gameRunning = false;
                    gamesPlayed++;

                    Console.WriteLine(separator);
                    Console.WriteLine($"Game Over! Final Score: {score}/{questionCount}. Time: {timeTaken}s");
                    Console.WriteLine("Press Enter to return to Menu.");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        } while (!validInput);

        Console.Clear();

    } while (gameRunning);
}

void GetNumbers()
{
    firstNumber = random.Next(lowerRange, upperRange);
    secondNumber = random.Next(lowerRange, upperRange);
}

void CalculateAnswer(string operation)
{
    switch (operation)
    {
        case "+":
            operationLabel = "Addition";
            calculationResult = firstNumber + secondNumber;
            break;
        case "-":
            operationLabel = "Subtraction";
            calculationResult = firstNumber - secondNumber;
            break;
        case "x":
            operationLabel = "Multiplication";
            calculationResult = firstNumber * secondNumber;
            break;
        case "/":
            operationLabel = "Division";
            bool wholeNumber = false;
            do
            {
                if (firstNumber % secondNumber == 0 && firstNumber != secondNumber)
                {
                    calculationResult = firstNumber / secondNumber;
                    wholeNumber = true;
                }
                else
                {
                    GetNumbers();
                }
            } while (!wholeNumber);
            break;
    }
}

void SaveScore(string operation)
{
    if (gamesPlayed < 9)
    {
        gameResults[gamesPlayed] = $" {gamesPlayed + 1} |  {operation}   |  {score}/{questionCount}  |  {timeTaken}";
    }
    else if (gamesPlayed >= 9)
    {
        gameResults[gamesPlayed] = $" {gamesPlayed + 1}|  {operation}   |  {score}/{questionCount}  |  {timeTaken}";
    }
}

void GameHistory()
{
    Console.Clear();
    Console.WriteLine(
@$"Math Game Collection
Game History
{separator}
 # | Type | Score | Time(secs) ");

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