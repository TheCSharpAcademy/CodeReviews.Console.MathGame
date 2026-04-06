using System.Timers;

Random rand = new Random();int second = 0;

Game();

void Game()
{
    string[] mainMenuChoices = { "New Game", "Game History", "Exit" };
    string mainMenuChoice = "";
    List<string> previousGames = new List<string>();

    while (true)
    {
        MenuDisplay(mainMenuChoices);
        mainMenuChoice = UserInputReading();

        switch (mainMenuChoice)
        {
            case "new game":
                NewGame(previousGames);
                break;
            case "game history":
                GameHistory(previousGames);
                break;
            case "exit":
                Console.WriteLine("See you next time! (Press Enter to exit.)");
                Console.ReadLine();
                return;
            default:
                InvalidOption();
                break;
        }
    }
}

void MenuDisplay(string[] menuChoices)
{
    Console.Clear();

    Console.WriteLine("Please enter one of the following choices:");
    foreach(string choice in menuChoices)
    {
        Console.WriteLine($"  - {choice}");
    }
}

string UserInputReading()
{
    string? readInput;
    string verifiedInput = "";

    readInput = Console.ReadLine();
    if (readInput != null)
    {
        verifiedInput = readInput.ToLower().Trim();
        return verifiedInput;
    }

    return "";
}

void NewGame(List<string> previousGames)
{
    string[] newGameChoices = { "Addition", "Subtraction", "Multiplication", "Division", "Random Operation", "Main Menu" };

    while (true)
    {
        MenuDisplay(newGameChoices);
        string newGameChoice = UserInputReading();
        string mathOperator = "";
        string operation = "";

        switch (newGameChoice)
        {
            case "addition":
                mathOperator = "+";
                operation = "Addition";
                break;
            case "subtraction":
                mathOperator = "-";
                operation = "Subtraction";
                break;
            case "multiplication":
                mathOperator = "*";
                operation = "Multiplication";
                break;
            case "division":
                mathOperator = "/";
                operation = "Division";
                break;
            case "random operation":
                operation = "Random operation";
                break;
            case "main menu":
                return;
            default:
                InvalidOption();
                continue;
        }
        LevelDifficultyMenu(mathOperator, previousGames, operation);
    }
}

void LevelDifficultyMenu(string mathOperator, List<string> previousGames, string operation)
{
    string[] difficultyLevels = { "Easy", "Normal", "Hard", "Operation Choice Menu" };
    string userChoice;
    string difficulty = "";

    while (true)
    {
        MenuDisplay(difficultyLevels);
        userChoice = UserInputReading();

        switch (userChoice)
        {
            case "easy":
            case "normal":
            case "hard":
                difficulty = userChoice;
                break;
            case "operation choice menu":
                return;
            default:
                InvalidOption();
                continue;
        }
        MathOperation(mathOperator, difficulty, previousGames, operation);
    }
}
void GameHistory(List<string> previousGames)
{
    Console.Clear();
    foreach (string previousGame in previousGames)
    {
        Console.WriteLine(previousGame);
    }
    Console.WriteLine("\n(Press Enter to return to the Main Menu)");
    Console.ReadLine();
}

void MathOperation (string mathOperator, string difficulty, List<string> previousGames, string operation)
{
    System.Timers.Timer timer = new System.Timers.Timer(1000);

    int score = 0;
    string gameLogStart = "";

    timer.Start();
    timer.Elapsed += OnTimedEvent;

    for (int i = 0; i < 5; i++)
    {
        if (operation.Equals("Random operation"))
        {
            mathOperator = OperatorGenerator();
            gameLogStart = $"{operation}\t";
        }
        else
        {
            gameLogStart = $"{operation}\t\t";
        }

        int[] numbers = NumbersGenerator(mathOperator, difficulty);
        int result = ResultCalculation(numbers, mathOperator);
        int userInput;

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Score: {score}\n");
            Console.WriteLine($"{numbers[0]} {mathOperator} {numbers[1]} = ?");

            if (!int.TryParse(UserInputReading(), out userInput))
            {
                Console.WriteLine("Please enter a valid number. (Press Enter to continue)");
                Console.ReadLine();
                continue;
            }    

            if (userInput == result)
            {
                score++;
                Console.WriteLine("Correct ! (Press Enter to continue)");
            }
            else
            {
                Console.WriteLine("Wrong... (Press Enter to continue)");
            }

            Console.ReadLine();
            break;
        }

    }

    timer.Stop();
    timer.Dispose();

    Console.WriteLine($"Your final score: {score} / 5 | Your time : {second} sec. (Press Enter to continue)");
    Console.ReadLine();

    previousGames.Add($"{gameLogStart} | Difficulty: {difficulty} | Score: {score} | Time : {second} ");

    second = 0;
}

string OperatorGenerator()
{
    int randomNum = rand.Next(0, 4);

    switch (randomNum)
    {
        case 0:
            return "+";
        case 1:
            return "-";
        case 2:
            return "*";
        default:
            return "/";
    }
}

void OnTimedEvent(Object? source, ElapsedEventArgs e)
{
    second += 1;
}

int[] NumbersGenerator(string mathOperator, string difficulty)
{
    int[] numbers = {0, 0};
    bool resultIsInt = false;

    int max = difficulty == "easy" ? 10 : difficulty == "normal" ? 51 : 101;

    do
    {
        if (mathOperator == "/")
            numbers[0] = rand.Next(0, 101);
        else
            numbers[0] = rand.Next(0, max);

        do
        {
            numbers[1] = rand.Next(0, max);
        } while (mathOperator == "/" && numbers[1] == 0);

        if (mathOperator == "/")
            resultIsInt = numbers[0] % numbers[1] == 0;

    } while (!resultIsInt && mathOperator == "/");

    return numbers;
}

int ResultCalculation(int[]numbers, string mathOperator)
{
    int result = 0;
    switch (mathOperator)
    {
        case "+":
            result = numbers[0] + numbers[1];
            break;
        case "-":
            result = numbers[0] - numbers[1];
            break;
        case "*":
            result = numbers[0] * numbers[1];
            break;
        case "/":
            result = numbers[0] / numbers[1];
            break;
    }

    return result;
}

void InvalidOption ()
{
    Console.WriteLine("Please enter a valid option. (Press Enter to return to the previous Menu.)");
    Console.ReadLine();
}