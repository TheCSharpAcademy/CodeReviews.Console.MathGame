using System.Diagnostics;
using MathGame;

MathGameLogic mathGame = new MathGameLogic();
Random random = new Random();

int userMenuSelection;
int firstNumber = 0;
int secondNumber = 0;
int score = 0;
bool gameOver = false;

DifficultyLevel difficultyLevel = DifficultyLevel.Easy;
while (!gameOver)
{
    userMenuSelection = GetMenuSelection(mathGame);

    firstNumber = random.Next(1, 101);
    secondNumber = random.Next(1, 101);

    switch (userMenuSelection)
    {
        case 1:
            score += await performOperation(mathGame, firstNumber, secondNumber, score, '+', difficultyLevel);
            break;
        case 2:
            score += await performOperation(mathGame, firstNumber, secondNumber, score, '-', difficultyLevel);
            break;
        case 3:
            score = await performOperation(mathGame, firstNumber, secondNumber, score, '*', difficultyLevel);
            break;
        case 4:
            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(1, 101);
                secondNumber = random.Next(1, 101);
            }
            score = await performOperation(mathGame, firstNumber, secondNumber, score, '/', difficultyLevel);
            break;
        case 5:
            int numberOfOperation = 99;
            Console.WriteLine("Enter the num of quetions you want to attempt");
            while (!int.TryParse(Console.ReadLine(), out numberOfOperation))
            {
                Console.WriteLine("Enter a valid number");
            }

            while (numberOfOperation > 0)
            {
                Console.ResetColor();
                int randomOperation = random.Next(1, 5);
                
                firstNumber = random.Next(1, 101);
                secondNumber = random.Next(1, 101);

                switch (randomOperation)
                {
                    case 1:
                        score += await performOperation(mathGame, firstNumber, secondNumber, score, '+', difficultyLevel);
                        break;
                    case 2:
                        score += await performOperation(mathGame, firstNumber, secondNumber, score, '-', difficultyLevel);
                        break;
                    case 3:
                        score = await performOperation(mathGame, firstNumber, secondNumber, score, '*', difficultyLevel);
                        break;
                    case 4:
                        while (firstNumber % secondNumber != 0)
                        {
                            firstNumber = random.Next(1, 101);
                            secondNumber = random.Next(1, 101);
                        }
                        score = await performOperation(mathGame, firstNumber, secondNumber, score, '/', difficultyLevel);
                        break;
                }

                numberOfOperation--;
            }
            break;
        case 6:
            Console.ResetColor();
            Console.WriteLine("GAME HISTORY \n");
            foreach (string previousQuetion in mathGame.GameHistory) Console.WriteLine(previousQuetion);
            break;
        case 7:
            Console.ResetColor();
            difficultyLevel = ChangeDifficulty();
            DifficultyLevel difficultyEnum = (DifficultyLevel)difficultyLevel;
            Enum.IsDefined(typeof(DifficultyLevel), difficultyEnum);
            Console.WriteLine($"Your new difficulty leavel is {difficultyLevel}");
            break;
        case 8:
            gameOver = true;
            break;
    }
}
static DifficultyLevel ChangeDifficulty()
{
    int userSelection = 0;

    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("Enter difficulty level.");
    Console.WriteLine("1. Easy");
    Console.WriteLine("2. Medium");
    Console.WriteLine("3. Hard");

    while (!int.TryParse(Console.ReadLine(), out userSelection) || userSelection < 1 || userSelection > 3)
    {
        Console.WriteLine("Enter either 1 or 2 or 3");
    }

    return userSelection switch
    {
        1 => DifficultyLevel.Easy,
        2 => DifficultyLevel.Medium,
        3 => DifficultyLevel.Hard,
    };
}

static void DisplayMathGameQuestion(int firstNumber, int secondNumber, char operation)
{
    Console.WriteLine($"{firstNumber} {operation} {secondNumber} = ??");
}

static int GetMenuSelection(MathGameLogic mathGame)
{
    int selection = -1;
    mathGame.ShowMenu();

    while (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > 8)
    {
        Console.WriteLine("Valid option is from 1-8");
    }

    return selection;
}

static async Task<int?> GetUserResponse(DifficultyLevel difficulty)
{
    int response = 0;
    int timeOut = (int)difficulty;

    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();

    Task<string?> getUserInputTask = Task.Run(() => Console.ReadLine());

    try
    {
        string? result = await Task.WhenAny(getUserInputTask, Task.Delay(timeOut * 1000)) == getUserInputTask
            ? getUserInputTask.Result
            : null;
        stopwatch.Stop();

        if (result != null && int.TryParse(result, out response))
        {
            Console.WriteLine($"User responded in {stopwatch.ElapsedMilliseconds * 1000} second");
        }
        else
        {
            throw new OperationCanceledException();
        }
    }
    catch (OperationCanceledException e)
    {
        Console.WriteLine("Time is up!");
        return null;
    }

    return response;
}

static int ValidateResult(int? result, int? userResponse, int score)
{
    if (result == userResponse)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{userResponse} is indeed the correct answer. You earned 5 points");
        score += 5;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{userResponse} is Wrong!");
    }

    return score;
}

static async Task<int> performOperation(MathGameLogic mathGame, int firstNumber, int secondNumber, int score, char operation, DifficultyLevel difficulty)
{
    int? result;
    int? userResponse;
    DisplayMathGameQuestion(firstNumber, secondNumber, operation);
    result = mathGame.MathOperation(firstNumber, secondNumber, operation);
    userResponse = await GetUserResponse(difficulty);
    score += ValidateResult(result, userResponse, score);
    return score;
}

public enum DifficultyLevel
{
    Easy = 45,
    Medium = 30,
    Hard = 15,
}