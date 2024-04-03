using GonzaLorenzo.MathGame;

Console.WriteLine("Welcome to the Math Game, please type your name.");

string name = GetName();
var date = DateTime.UtcNow;

List<Game> games = new();
int gameNumber = 0;

var random = new Random();

int firstNumber = 0;
int secondNumber = 0;

int randomMinNumber = 0;
int randomMaxNumber = 0;

int randomMinDividend = 0;
int randomMaxDividend = 0;

int randomMinDivisor = 0;
int randomMaxDivisor = 0;

GameMenu(name);

void GameMenu(string name)
{
    bool isGameOn = true;

    do
    {
        Console.Clear();

        Console.WriteLine(@$"Hello {name.Trim()}. What game would you like to play today? Choose from the options below:
        1 - Addition
        2 - Substraction
        3 - Multiplication
        4 - Division
        5 - Random
        6 - View games history.
        7 - Quit the program");

        string gameSelected = Console.ReadLine();

        do
        {
            if (string.IsNullOrEmpty(gameSelected))
            {
                Console.WriteLine("Please choose the game you would like to play.");
                gameSelected = Console.ReadLine();
            }
        } while (string.IsNullOrEmpty(gameSelected));

        switch (gameSelected)
        {
            case "1":
                SetGameMode(GameMode.Addition);
                break;

            case "2":
                SetGameMode(GameMode.Substraction);
                break;

            case "3":
                SetGameMode(GameMode.Multiplication);
                break;

            case "4":
                SetGameMode(GameMode.Division);
                break;

            case "5":
                SetGameMode(GameMode.Random);
                break;

            case "6":
                ViewGamesHistory();
                break;

            case "7":
                isGameOn = false;
                break;

            default:
                Console.WriteLine("Please choose the game you would like to play.");
                break;
        }
    } while (isGameOn);
}

string GetName()
{
    string name = Console.ReadLine();

    do
    {
        if (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Please type your name.");
            name = Console.ReadLine();
        }
    } while (string.IsNullOrEmpty(name));

    name = char.ToUpper(name[0]) + name.Substring(1);

    return name;
}

void MathGame(GameMode gameMode)
{
    Difficulty difficulty = ChooseDifficulty();
    int scoreValue = GetScoreValue(difficulty);
    SetNumbersRange(difficulty);
    string operation = SetOperation(gameMode);

    int questions = ChooseNumberOfQuestions();

    Console.Clear();
    Console.WriteLine("Let's start the game.");
    DateTime startTime = DateTime.Now;

    int score = 0;

    for (int i = 0; i < questions; i++)
    {
        Console.Clear();

        if (gameMode == GameMode.Random)
        {
            operation = SetOperation(gameMode);
        }

        GetRandomNumbers(operation);

        Console.WriteLine($"Question {i + 1}. What is {firstNumber} {operation} {secondNumber}");

        string result = Console.ReadLine();
        bool isValid = false;

        while (!isValid)
        {
            if (!int.TryParse(result, out int validResult))
            {
                Console.WriteLine($"Invalid input. What is {firstNumber} {operation} {secondNumber}");
                result = Console.ReadLine();
            }
            else
            {
                isValid = true;
            }
        }

        if (CheckResults(int.Parse(result), operation, firstNumber, secondNumber))
        {
            score += scoreValue;

            if (i == questions - 1)
            {
                Console.WriteLine("Your answer was correct!");
                continue;
            }

            Console.WriteLine("Your answer was correct! Press enter for the next question.");
            Console.ReadLine();
        }
        else
        {
            if (i == questions - 1)
            {
                Console.WriteLine("Your answer was incorrect.");
                continue;
            }

            Console.WriteLine("Your answer was incorrect. Press enter key for the next question.");
            Console.ReadLine();
        }
    }

    DateTime endTime = DateTime.Now;
    TimeSpan timeTaken = endTime - startTime;
    AddToHistory(gameMode, difficulty, questions, score, timeTaken);
    Console.WriteLine($"Game over. Your final score is {score}. Press enter to go back to the menu.");
    Console.ReadLine();
}

void SetGameMode(GameMode gameMode)
{
    GameMode selectedMode = GameMode.Addition;

    switch (gameMode)
    {
        case GameMode.Addition:
            Console.Clear();
            Console.WriteLine("Addition game selected");
            selectedMode = GameMode.Addition;
            break;

        case GameMode.Substraction:
            Console.Clear();
            Console.WriteLine("Substraction game selected");
            selectedMode = GameMode.Substraction;
            break;

        case GameMode.Multiplication:
            Console.Clear();
            Console.WriteLine("Multiplication game selected");
            selectedMode = GameMode.Multiplication;
            break;

        case GameMode.Division:
            Console.Clear();
            Console.WriteLine("Division game selected");
            selectedMode = GameMode.Division;
            break;

        case GameMode.Random:
            Console.Clear();
            Console.WriteLine("Random game selected");
            selectedMode = GameMode.Random;
            break;
    }

    MathGame(selectedMode);
}

string SetOperation(GameMode gameMode)
{
    string operation = "";

    if (gameMode != GameMode.Random)
    {
        switch (gameMode)
        {
            case GameMode.Addition:
                operation = "+";
                break;

            case GameMode.Substraction:
                operation = "-";
                break;

            case GameMode.Multiplication:
                operation = "*";
                break;

            case GameMode.Division:
                operation = "/";
                break;
        }
    }
    else
    {
        switch (random.Next(1, 5))
        {
            case 1:
                operation = "+";
                break;

            case 2:
                operation = "-";
                break;

            case 3:
                operation = "*";
                break;

            case 4:
                operation = "/";
                break;
        }
    }



    return operation;
}

bool CheckResults(int result, string operation, int firstNumber, int secondNumber)
{
    switch (operation)
    {
        case "+":
            return result == firstNumber + secondNumber;

        case "-":
            return result == firstNumber - secondNumber;

        case "*":
            return result == firstNumber * secondNumber;

        case "/":
            return result == firstNumber / secondNumber;

        default:
            throw new ArgumentException("Invalid operation");
    }
}

void SetNumbersRange(Difficulty difficulty)
{
    switch (difficulty)
    {
        case Difficulty.Easy:
            randomMinNumber = 1;
            randomMaxNumber = 10;

            randomMinDividend = 10;
            randomMaxDividend = 100;

            randomMinDivisor = 2;
            randomMaxDivisor = 10;
            break;

        case Difficulty.Medium:
            randomMinNumber = 10;
            randomMaxNumber = 100;
            randomMinDividend = 100;
            randomMaxDividend = 1000;

            randomMinDivisor = 2;
            randomMaxDivisor = 10;
            break;

        case Difficulty.Hard:
            randomMinNumber = 100;
            randomMaxNumber = 1000;
            randomMinDividend = 100;
            randomMaxDividend = 1000;

            randomMinDivisor = 10;
            randomMaxDivisor = 100;
            break;
    }
}

int GetScoreValue(Difficulty difficulty)
{
    int scoreValue = 0;

    switch (difficulty)
    {
        case Difficulty.Easy:
            scoreValue = 1;
            break;

        case Difficulty.Medium:
            scoreValue = 2;
            break;

        case Difficulty.Hard:
            scoreValue = 3;
            break;
    }

    return scoreValue;
}

void GetRandomNumbers(string operation)
{
    if (operation != "/")
    {
        firstNumber = random.Next(randomMinNumber, randomMaxNumber);
        secondNumber = random.Next(randomMinNumber, randomMaxNumber);
    }
    else
    {
        firstNumber = random.Next(randomMinDividend, randomMaxDividend);
        secondNumber = random.Next(randomMinDivisor, randomMaxDivisor);

        while (firstNumber % secondNumber != 0)
        {
            firstNumber = random.Next(randomMinDividend, randomMaxDividend);
            secondNumber = random.Next(randomMinDivisor, randomMaxDivisor);
        }
    }
}

void AddToHistory(GameMode gameMode, Difficulty difficulty, int questions, int score, TimeSpan timeTaken)
{
    gameNumber++;

    games.Add(new Game
    {
        ID = gameNumber,
        Date = DateTime.Now,
        Mode = gameMode,
        Difficulty = difficulty,
        Questions = questions,
        Score = score,
        Time = timeTaken
    });
}

void ViewGamesHistory()
{
    Console.Clear();

    Console.WriteLine("Games History");
    Console.WriteLine("--------------------------------\n");
    foreach (var game in games)
    {
        Console.WriteLine($@"{game.Date} - Game {game.ID}
        Game mode: {game.Mode}
        Difficulty: {game.Difficulty}
        Number of questions: {game.Questions}
    
        Final score: {game.Score}
        Time taken: {game.Time.TotalSeconds} seconds
        ");
    }
    Console.WriteLine("---------------------------------\n");

    Console.WriteLine("Press enter to go back to the menu.");
    Console.ReadLine();
}

Difficulty ChooseDifficulty()
{
    Console.WriteLine("Please choose your difficulty. Easy, medium or hard.");

    Difficulty validDifficulty = Difficulty.Easy;
    bool validInput = false;

    while (!validInput)
    {
        string difficulty = Console.ReadLine();

        switch (difficulty.Trim().ToLower())
        {
            case "easy":
                Console.WriteLine("Easy difficulty selected");
                validDifficulty = Difficulty.Easy;
                validInput = true;
                break;

            case "medium":
                Console.WriteLine("Medium difficulty selected");
                validDifficulty = Difficulty.Medium;
                validInput = true;
                break;

            case "hard":
                Console.WriteLine("Hard difficulty selected");
                validDifficulty = Difficulty.Hard;
                validInput = true;
                break;

            default:
                Console.WriteLine("Invalid input. Please choose your difficulty.Easy, medium or hard.");
                break;
        }

    }

    return validDifficulty;
}

int ChooseNumberOfQuestions()
{
    Console.WriteLine("Please choose the number of questions from 1 to 10.");

    bool isValid = false;
    int numberOfQuestions = 0;

    while (!isValid)
    {
        string? input = Console.ReadLine();

        if (!int.TryParse(input, out numberOfQuestions) || numberOfQuestions < 1 || numberOfQuestions > 10)
        {
            Console.WriteLine("Invalid input. Please choose the number of questions from 1 to 10.");
        }
        else
        {
            isValid = true;
            numberOfQuestions = int.Parse(input);
        }
    }

    return numberOfQuestions;
}