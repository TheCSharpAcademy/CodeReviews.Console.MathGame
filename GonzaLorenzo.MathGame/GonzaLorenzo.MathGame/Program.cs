using System.Numerics;

Console.WriteLine("Welcome to the Math Game, please type your name.");

string name = GetName();
var date = DateTime.UtcNow;

List<string> games = new();
int gameNumber = 0;

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
        5 - Random Game
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
                AdditionGame();
                break;

            case "2":
                SubstractionGame();
                break;

            case "3":
                MultiplicationGame();
                break;

            case "4":
                DivisionGame();
                break;

            case "5":
                RandomGame();
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

void AdditionGame()
{
    Console.Clear();
    Console.WriteLine("Addition game selected");

    string difficulty = ChooseDifficulty();

    int randomMinNumber = 0;
    int randomMaxNumber = 0;
    int scoreValue = 0;

    switch (difficulty)
    {
        case "easy":
            randomMinNumber = 1;
            randomMaxNumber = 10;
            scoreValue = 1;
            break;

        case "medium":
            randomMinNumber = 10;
            randomMaxNumber = 100;
            scoreValue = 2;
            break;

        case "hard":
            randomMinNumber = 100;
            randomMaxNumber = 1000;
            scoreValue = 3;
            break;
    }

    int questions = ChooseNumberOfQuestions();

    Console.Clear();
    Console.WriteLine("Let's start the game.");

    var random = new Random();

    int firstNumber = 0;
    int secondNumber = 0;

    int score = 0;

    for (int i = 0; i < questions; i++)
    {
        Console.Clear();
        firstNumber = random.Next(randomMinNumber, randomMaxNumber);
        secondNumber = random.Next(randomMinNumber, randomMaxNumber);

        Console.WriteLine($"Question {i + 1}. What is {firstNumber} + {secondNumber}");

        string result = Console.ReadLine();
        bool isValid = false;

        while (!isValid)
        {
            if (!int.TryParse(result, out int validResult))
            {
                Console.WriteLine($"Invalid input. What is {firstNumber} + {secondNumber}");
                result = Console.ReadLine();
            }
            else
            {
                isValid = true;
            }
        }

        if (int.Parse(result) == firstNumber + secondNumber)
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

    AddToHistory("Addition", difficulty, questions, score);
    Console.WriteLine($"Game over. Your final score is {score}. Press enter to go back to the menu.");
    Console.ReadLine();
}

void SubstractionGame()
{
    Console.Clear();
    Console.WriteLine("Substraction game selected");

    string difficulty = ChooseDifficulty();

    int randomMinNumber = 0;
    int randomMaxNumber = 0;
    int scoreValue = 0;

    switch (difficulty)
    {
        case "easy":
            randomMinNumber = 1;
            randomMaxNumber = 10;
            scoreValue = 1;
            break;

        case "medium":
            randomMinNumber = 10;
            randomMaxNumber = 100;
            scoreValue = 2;
            break;

        case "hard":
            randomMinNumber = 100;
            randomMaxNumber = 1000;
            scoreValue = 3;
            break;
    }

    int questions = ChooseNumberOfQuestions();

    Console.Clear();
    Console.WriteLine("Let's start the game.");

    var random = new Random();

    int firstNumber = 0;
    int secondNumber = 0;

    int score = 0;

    for (int i = 0; i < questions; i++)
    {
        Console.Clear();
        firstNumber = random.Next(randomMinNumber, randomMaxNumber);
        secondNumber = random.Next(randomMinNumber, randomMaxNumber);

        Console.WriteLine($"Question {i + 1}. What is {firstNumber} - {secondNumber}");

        string result = Console.ReadLine();
        bool isValid = false;

        while (!isValid)
        {
            if (!int.TryParse(result, out int validResult))
            {
                Console.WriteLine($"Invalid input. What is {firstNumber} - {secondNumber}");
                result = Console.ReadLine();
            }
            else
            {
                isValid = true;
            }
        }

        if (int.Parse(result) == firstNumber - secondNumber)
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

    AddToHistory("Substraction", difficulty, questions, score);
    Console.WriteLine($"Game over. Your final score is {score}. Press enter to go back to the menu.");
    Console.ReadLine();
}

void MultiplicationGame()
{
    Console.Clear();
    Console.WriteLine("Multiplication game selected");

    string difficulty = ChooseDifficulty();

    int randomMinNumber = 0;
    int randomMaxNumber = 0;
    int scoreValue = 0;

    switch (difficulty)
    {
        case "easy":
            randomMinNumber = 1;
            randomMaxNumber = 10;
            scoreValue = 1;
            break;

        case "medium":
            randomMinNumber = 10;
            randomMaxNumber = 100;
            scoreValue = 2;
            break;

        case "hard":
            randomMinNumber = 100;
            randomMaxNumber = 1000;
            scoreValue = 3;
            break;
    }

    int questions = ChooseNumberOfQuestions();

    Console.Clear();
    Console.WriteLine("Let's start the game.");

    var random = new Random();

    int firstNumber = 0;
    int secondNumber = 0;

    int score = 0;

    for (int i = 0; i < questions; i++)
    {
        Console.Clear();
        firstNumber = random.Next(randomMinNumber, randomMaxNumber);
        secondNumber = random.Next(randomMinNumber, randomMaxNumber);

        Console.WriteLine($"Question {i + 1}. What is {firstNumber} * {secondNumber}");

        string result = Console.ReadLine();
        bool isValid = false;

        while (!isValid)
        {
            if (!int.TryParse(result, out int validResult))
            {
                Console.WriteLine($"Invalid input. What is {firstNumber} * {secondNumber}");
                result = Console.ReadLine();
            }
            else
            {
                isValid = true;
            }
        }

        if (int.Parse(result) == firstNumber * secondNumber)
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

    AddToHistory("Multiplication", difficulty, questions, score);
    Console.WriteLine($"Game over. Your final score is {score}. Press enter to go back to the menu.");
    Console.ReadLine();
}

void DivisionGame()
{
    Console.Clear();
    Console.WriteLine("Division game selected");

    string difficulty = ChooseDifficulty();

    int randomMinDividend = 0;
    int randomMaxDividend = 0;

    int randomMinDivisor = 0;
    int randomMaxDivisor = 0;

    int scoreValue = 0;

    switch (difficulty)
    {
        case "easy":
            randomMinDividend = 10;
            randomMaxDividend = 100;

            randomMinDivisor = 1;
            randomMaxDivisor = 10;
            scoreValue = 1;
            break;

        case "medium":
            randomMinDividend = 100;
            randomMaxDividend = 1000;

            randomMinDivisor = 1;
            randomMaxDivisor = 10;
            scoreValue = 2;
            break;

        case "hard":
            randomMinDividend = 100;
            randomMaxDividend = 1000;

            randomMinDivisor = 10;
            randomMaxDivisor = 100;
            scoreValue = 3;
            break;
    }

    int questions = ChooseNumberOfQuestions();

    Console.Clear();
    Console.WriteLine("Let's start the game.");

    var random = new Random();

    int dividend = 0;
    int divisor = 0;

    int score = 0;

    for (int i = 0; i < questions; i++)
    {
        Console.Clear();

        int[] divisionNumbers = GetDivisionNumbers(randomMinDividend, randomMaxDividend, randomMinDivisor, randomMaxDivisor);

        dividend = divisionNumbers[0];
        divisor = divisionNumbers[1];

        Console.WriteLine($"Question {i + 1}. What is {dividend} / {divisor}");

        string result = Console.ReadLine();
        bool isValid = false;

        while (!isValid)
        {
            if (!int.TryParse(result, out int validResult))
            {
                Console.WriteLine($"Invalid input. What is {dividend} / {divisor}");
                result = Console.ReadLine();
            }
            else
            {
                isValid = true;
            }
        }

        if (int.Parse(result) == dividend / divisor)
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

    AddToHistory("Division", difficulty, questions, score);
    Console.WriteLine($"Game over. Your final score is {score}. Press enter to go back to the menu.");
    Console.ReadLine();
}

int[] GetDivisionNumbers(int randomMinDividend, int randomMaxDividend, int randomMinDivisor, int randomMaxDivisor)
{
    var random = new Random();

    int dividend = random.Next(randomMinDividend, randomMaxDividend);
    int divisor = random.Next(randomMinDivisor, randomMaxDivisor);

    int[] result = new int[2];

    while(dividend % divisor != 0)
    {
        dividend = random.Next(randomMinDividend, randomMaxDividend);
        divisor = random.Next(randomMinDivisor, randomMaxDivisor);
    }

    result[0] = dividend;
    result[1] = divisor;

    return result;
}

void AddToHistory(string gameMode, string difficulty, int questions, int score)
{
    gameNumber++;

    games.Add($@"{DateTime.Now} - Game {gameNumber}
    Game mode: {gameMode}
    Difficulty: {difficulty}
    Number of questions: {questions}
    
    Final score: {score}
    ");
}

void ViewGamesHistory()
{
    Console.Clear();

    Console.WriteLine("Games History");
    Console.WriteLine("--------------------------------\n");
    foreach (var game in games)
    {
        Console.WriteLine(game);
    }
    Console.WriteLine("---------------------------------\n");

    Console.WriteLine("Press enter to go back to the menu.");
    Console.ReadLine();
}

string ChooseDifficulty()
{
    Console.WriteLine("Please choose your difficulty. Easy, medium or hard.");

    string validDifficulty = "";

    while (validDifficulty == "")
    {
        string difficulty = Console.ReadLine();

        switch (difficulty.Trim().ToLower())
        {
            case "easy":
                Console.WriteLine("Easy difficulty selected");
                validDifficulty = "easy";
                break;

            case "medium":
                Console.WriteLine("Medium difficulty selected");
                validDifficulty = "medium";
                break;

            case "hard":
                Console.WriteLine("Hard difficulty selected");
                validDifficulty = "hard";
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