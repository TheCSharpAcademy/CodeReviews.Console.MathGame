
using System.Diagnostics;  


List<Game> gameHistory = [];
int gameCount = 0;

Console.WriteLine("Welcome to the Math Quiz Game!");

while (true) {
    Console.Clear();
    Console.WriteLine("1: Start a new game");
    Console.WriteLine("2: View game history");
    Console.WriteLine("3: Exit");
    Console.Write("Enter your choice (1-3): ");

    var selectedChoice = Console.ReadLine();

    if (selectedChoice != null)
    {
        if (int.TryParse(selectedChoice, out int choice))
        {
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    StartGame(++gameCount);
                    break;
                case 2:
                    Console.Clear();
                    ShowHistory();
                    break;
                case 3:
                    Console.WriteLine("Thank you for playing! Goodbye!");
                    return;
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number between 1 and 3.\n"); continue;
        }
    }
}



void StartGame(int gameCount)
{
    const int NUMBER_OF_GAMES = 5;

    int score = 0;
    int operation;
    int difficulty;


    Console.WriteLine("Please select an operation");
    Console.WriteLine("1: multiplication");
    Console.WriteLine("2: division");
    Console.WriteLine("3: addition");
    Console.WriteLine("4: subtraction");
    Console.WriteLine("5: random");
    Console.Write("Enter your choice (1-5): ");

    do
    {
        var selectedOperation = Console.ReadLine();
        if (selectedOperation != null)
        {
            if (int.TryParse(selectedOperation, out operation))
            {
                break;
            }

            Console.Write("That's invalid. Enter your choice (1-5): ");
        }
    }
    while (true);

    Console.Clear();
    Console.WriteLine("Please select difficulty level");
    Console.WriteLine("1: easy");
    Console.WriteLine("2: difficult");
    Console.Write("Enter your choice (1-2): ");

    do
    {
        var selectedDifficulty = Console.ReadLine();
        if (selectedDifficulty != null)
        {
            if (int.TryParse(selectedDifficulty, out difficulty) && difficulty < 3)
            {
                break;
            }

            Console.Write("That's invalid. Enter your choice (1-2): ");
        }
    }
    while (true);

    Console.Clear();
    Stopwatch stopwatch = Stopwatch.StartNew();

    for (int i = 0; i < NUMBER_OF_GAMES; i++)
    {
        
        int answer = 0;
        int userAnswer = 0;

        answer = AskUser((Operations)operation, (Difficulty)difficulty);
        
        do
        {
            var userResponse = Console.ReadLine();
            if (userResponse != null)
            {
                if (int.TryParse(userResponse, out userAnswer))
                {
                    break;
                }
                Console.Write("That's invalid. Please enter a number: ");
            }
        }
        while (true);

        if (userAnswer == answer)
        {
            Console.WriteLine("Correct!\n");
            score++;
        }
        else
        {
            Console.WriteLine($"Incorrect. The correct answer is {answer}.\n");
        }
    }

    stopwatch.Stop();

    Console.WriteLine($"You completed the quiz in {stopwatch.Elapsed.TotalSeconds:F2} seconds.");
    Console.WriteLine($"Your final score is {score} out of {NUMBER_OF_GAMES}.");

    gameHistory.Add(new Game(gameCount, (Operations)operation, (Difficulty)difficulty , $"{score}/{NUMBER_OF_GAMES}", $"{stopwatch.Elapsed.TotalSeconds:F2}"));

    PressAnyKeyToContinue();

}

void PressAnyKeyToContinue()
{
    Console.WriteLine("\n===========================================================");
    Console.WriteLine("Press any key to continue...");
    Console.ReadLine();
}

int AskUser(Operations operation, Difficulty difficulty)
{
    int maxNumber = difficulty == Difficulty.easy ? 11 : 101;

    Random random = new Random();
    int num1 = random.Next(1, maxNumber);
    int num2 = random.Next(1, maxNumber);
    int answer = 0;

    switch (operation)
    {
        case Operations.multiplication:
            answer = num1 * num2;
            Console.Write($"What is {num1} * {num2}? ");
            break;
        case Operations.division:
            num1 = random.Next(1, 101);
            while (num1 % num2 != 0)
            {
                num1 = random.Next(1, 101);
                num2 = random.Next(1, maxNumber);
            }
            answer = num1 / num2;
            Console.Write($"What is {num1} / {num2}? ");
            break;
        case Operations.addition:
            answer = num1 + num2;
            Console.Write($"What is {num1} + {num2}? ");
            break;
        case Operations.subtraction:
            answer = num1 - num2;
            Console.Write($"What is {num1} - {num2}? ");
            break;
        case Operations.random:
            int randomOperation = random.Next(1, 5);
            return AskUser((Operations)randomOperation, difficulty);
    }

    return answer;
}

void ShowHistory()
    {
    if (gameHistory.Count == 0)
    {
        Console.WriteLine("\n===========================================================");
        Console.WriteLine("\nNo game history available.");

        PressAnyKeyToContinue();

        return;
    }

    Console.WriteLine("\n===========================================================");
    Console.WriteLine("\nGame History:\n");
    Console.WriteLine("Game\tOperation\tDifficulty\tScore\tDuration (s)");
    Console.WriteLine("-------------------------------------------------------------");

    foreach (var game in gameHistory)
    {
        Console.WriteLine($"{game.GameNumber}\t{game.Operation,-14}\t{game.Difficulty,-9}\t{game.Score}\t{game.TimeCompleted}");
    }
    
    PressAnyKeyToContinue();
}

public enum Operations
{
    multiplication = 1,
    division = 2,
    addition = 3,
    subtraction = 4,
    random = 5
};

public enum Difficulty
{
    easy = 1,
    difficult = 2
};

public record Game(int GameNumber,Operations Operation,Difficulty Difficulty, string Score, string TimeCompleted);

