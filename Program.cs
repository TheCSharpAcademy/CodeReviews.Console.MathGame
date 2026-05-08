
using System.Diagnostics;

MathGameLogic mathGame = new();
Random random = new Random();
int firstNumber;
int secondNumber;
int userMenuSelection;
int score = 0;
bool gameOver = false;

DifficultyLevel difficultyLevel = DifficultyLevel.Easy;

while (!gameOver)
{
    userMenuSelection = GetUserMenuSelection(mathGame);
    firstNumber = random.Next(1, 101);
    secondNumber = random.Next(1, 101);

    switch (userMenuSelection)
    {
        case 1:
            score += await PerformOperation(mathGame, firstNumber, secondNumber, '+', difficultyLevel);
            break;

        case 2:
            score += await PerformOperation(mathGame, firstNumber, secondNumber, '-', difficultyLevel);
            break;

        case 3:
            score += await PerformOperation(mathGame, firstNumber, secondNumber, '*', difficultyLevel);
            break;

        case 4:
            score += await PerformOperation(mathGame, firstNumber, secondNumber, '/', difficultyLevel);
            break;

        case 5:
            int numberOfQuestions = 99;
            Console.WriteLine("Please enter the number of question you want to attempt");
            while (!int.TryParse(Console.ReadLine(), out numberOfQuestions))
            {
                Console.WriteLine("Please enter the number of question you want to attempt");
            }
            while (numberOfQuestions > 0)
            {
                int randomOperation = random.Next(1, 5);
                if (randomOperation == 1)
                {
                    firstNumber = random.Next(1, 101);
                    secondNumber = random.Next(1, 101);
                    score += await PerformOperation(mathGame, firstNumber, secondNumber, '+', difficultyLevel);
                }
                else if (randomOperation == 2)
                {
                    firstNumber = random.Next(1, 101);
                    secondNumber = random.Next(1, 101);
                    score += await PerformOperation(mathGame, firstNumber, secondNumber, '-', difficultyLevel);
                }
                else if (randomOperation == 3)
                {
                    firstNumber = random.Next(1, 101);
                    secondNumber = random.Next(1, 101);
                    score += await PerformOperation(mathGame, firstNumber, secondNumber, '*', difficultyLevel);
                }
                else
                {
                    firstNumber = random.Next(1, 101);
                    secondNumber = random.Next(1, 101);
                    while (firstNumber % secondNumber != 0)
                    {
                        firstNumber = random.Next(1, 101);
                        secondNumber = random.Next(1, 101);

                    }
                }
                score += await PerformOperation(mathGame, firstNumber, secondNumber, '/', difficultyLevel);
                numberOfQuestions--;
            }
            break;
        case 6:
            Console.WriteLine("Game History:\n");
            foreach (var operation in mathGame.GameHistory)
            {
                Console.WriteLine($"{operation}");
            }
            break;
        case 7:
            difficultyLevel = ChangeDifficulty();
            DifficultyLevel difficultyEnum = (DifficultyLevel)difficultyLevel;
            Enum.IsDefined(typeof(DifficultyLevel), difficultyEnum);
            Console.WriteLine($"Difficulty chosen {difficultyLevel}");
            break;
        case 8:
            gameOver = true;
            Console.WriteLine($"Your score is:{score}");
            break;
    }

}


static DifficultyLevel ChangeDifficulty()
{
    int userSelection = 0;
    Console.WriteLine("Enter a difficulty level");
    Console.WriteLine("1) Easy");
    Console.WriteLine("2) Medium");
    Console.WriteLine("3) Hard");

    while (!int.TryParse(Console.ReadLine(), out userSelection) || (userSelection < 1 || userSelection > 3))
    {
        Console.WriteLine("Enter a valid option 1-3");
    }
    switch (userSelection)
    {
        case 1:
            return DifficultyLevel.Easy;

        case 2:
            return DifficultyLevel.Medium;

        case 3:
            return DifficultyLevel.Hard;

    }
    return DifficultyLevel.Easy;
}

static void DisplayMathGameQuestion(int firstNumber, int secondNumber, char operation)
{
    Console.WriteLine($"{firstNumber} {operation} {secondNumber}=??");
}

static int GetUserMenuSelection(MathGameLogic mathGame)
{
    int selection = -1;
    mathGame.ShowMenu();
    while (selection < 1 || selection > 8)
    {
        while (!int.TryParse(Console.ReadLine(), out selection))
        {
            Console.WriteLine("Enter a valid option 1-8");
        }
    }
    return selection;
}
static async Task<int?> GetUserResponse(DifficultyLevel difficultyLevel)
{
    int response = 0;
    int timeout = (int)difficultyLevel;
    Stopwatch sw = Stopwatch.StartNew();

    // Avviamo il compito di lettura
    var getUserInputTask = Task.Run(() => Console.ReadLine());

    // Aspettiamo la gara tra input e tempo
    var completedTask = await Task.WhenAny(getUserInputTask, Task.Delay(timeout * 1000));

    if (completedTask == getUserInputTask)
    {
        sw.Stop();
        string? result = await getUserInputTask; // Recuperiamo l'input

        if (!string.IsNullOrWhiteSpace(result) && int.TryParse(result, out response))
        {
            Console.WriteLine($"Tempo impiegato: {sw.Elapsed:mm\\:ss\\.fff}");
            return response;
        }
    }

    // Se arriviamo qui, il tempo è scaduto o l'input era pessimo
    Console.WriteLine("\nTempo scaduto!");
    return null;
}

static int ValidateResult(int result, int? userResponse)
{
    Console.WriteLine($"DEBUG: Computer si aspetta {result}, Tu hai scritto {userResponse}");
    if (result == userResponse)
    {
        Console.WriteLine("You answered correctly: +5 points");
        return 5;
    }
    else
    {
        Console.WriteLine($"You answered wrong. Correct answer was {result} ");
    }
    return 0;
}

static async Task<int> PerformOperation(MathGameLogic mathGame, int firstNumber, int secondNumber, char operation, DifficultyLevel difficulty)
{
    int result;
    int? userResponse;
    DisplayMathGameQuestion(firstNumber, secondNumber, operation);
    result = mathGame.MathOperation(firstNumber, secondNumber, operation);
    userResponse = await GetUserResponse(difficulty);

    return ValidateResult(result, userResponse);
}
public enum DifficultyLevel
{
    Easy = 45,
    Medium = 30,
    Hard = 15
}



