using System.Timers;

Random rand = new Random();int second = 0;

game();

void game()
{
    string[] mainMenuChoices = { "New Game", "Game History", "Exit" };
    string mainMenuChoice = "";
    List<string> previousGames = new List<string>();

    while (true)
    {
        menuDisplay(mainMenuChoices);
        mainMenuChoice = userInputReading();

        switch (mainMenuChoice)
        {
            case "new game":
                newGame(previousGames);
                break;
            case "game history":
                gameHistory(previousGames);
                break;
            case "exit":
                Console.WriteLine("See you next time! (Press Enter to exit.)");
                Console.ReadLine();
                return;
            default:
                invalidOption();
                break;
        }
    }
}

void menuDisplay(string[] menuChoices)
{
    Console.Clear();

    Console.WriteLine("Please enter one of the following choices:");
    foreach(string choice in menuChoices)
    {
        Console.WriteLine($"  - {choice}");
    }
}

string userInputReading()
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

void newGame(List<string> previousGames)
{
    string[] newGameChoices = { "Addition", "Subtraction", "Multiplication", "Division", "Random Operation", "Main Menu" };

    while (true)
    {
        menuDisplay(newGameChoices);
        string newGameChoice = userInputReading();
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
                invalidOption();
                continue;
        }
        levelDifficultyMenu(mathOperator, previousGames, operation);
    }
}

void levelDifficultyMenu(string mathOperator, List<string> previousGames, string operation)
{
    string[] difficultyLevels = { "Easy", "Normal", "Hard", "Operation Choice Menu" };
    string userChoice;
    string difficulty = "";

    while (true)
    {
        menuDisplay(difficultyLevels);
        userChoice = userInputReading();

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
                invalidOption();
                continue;
        }
        mathOperation(mathOperator, difficulty, previousGames, operation);
    }
}
void gameHistory(List<string> previousGames)
{
    Console.Clear();
    foreach (string previousGame in previousGames)
    {
        Console.WriteLine(previousGame);
    }
    Console.WriteLine("\n(Press Enter to return to the Main Menu)");
    Console.ReadLine();
}

void mathOperation (string mathOperator, string difficulty, List<string> previousGames, string operation)
{
    System.Timers.Timer timer = new System.Timers.Timer(1000);

    int score = 0;
    string gameLogStart = "";

    timer.Start();
    timer.Elapsed += onTimedEvent;

    for (int i = 0; i < 5; i++)
    {
        if (operation.Equals("Random operation"))
        {
            mathOperator = operatorGenerator();
            gameLogStart = $"{operation}\t";
        }
        else
        {
            gameLogStart = $"{operation}\t\t";
        }

        int[] numbers = numbersGenerator(mathOperator, difficulty);
        int result = resultCalculation(numbers, mathOperator);
        int userInput;

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Score: {score}\n");
            Console.WriteLine($"{numbers[0]} {mathOperator} {numbers[1]} = ?");

            if (!int.TryParse(userInputReading(), out userInput))
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

string operatorGenerator()
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

void onTimedEvent(Object? source, ElapsedEventArgs e)
{
    second += 1;
}

int[] numbersGenerator(string mathOperator, string difficulty)
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

int resultCalculation(int[]numbers, string mathOperator)
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

void invalidOption ()
{
    Console.WriteLine("Please enter a valid option. (Press Enter to return to the previous Menu.)");
    Console.ReadLine();
}