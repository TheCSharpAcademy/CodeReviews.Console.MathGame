string answer;
int score = 0;
List<int> gameHistory = new List<int>();

List<string[]> questions = new List<string[]>();
questions.Add(new string[] { "15 + 25", "40" });
questions.Add(new string[] { "14 / 7", "2"});
questions.Add(new string[] { "73 - 8", "65"});
questions.Add(new string[] { "33 * 3", "99"});
questions.Add(new string[] { "(3 * 4) / 12", "1"});


while (true)
{
    Console.Clear();
    Console.WriteLine("WELCOME TO MATH GAME!");
    Console.WriteLine("To play, press 1\nTo view game history, press 2\nTo exit, press 3");
    string choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            startGame();       
            break;
        case "2":
            displayGameHistory();
            break;
        case "3":
            Console.Clear();
            Console.WriteLine("Goodbye!");
            Console.WriteLine("Press Enter to exit...");
            Console.ReadKey();
            return;
        default:
            Console.WriteLine("Invalid operation, try again!");
            restartMessage();
            continue;
    }
}

void startGame()
{
    foreach (string[] question in questions)
    {
        Console.Clear();
        Console.WriteLine($"{question[0]} = ?");
        answer = Console.ReadLine();
        if (answer == question[1]) score += 1;
    }

    gameHistory.Add(score);

    Console.Clear();
    Console.WriteLine($"You scored {score} out of 5\n");
    score = 0;
    Console.WriteLine("Game Over!\n");
    restartMessage();
}

void displayGameHistory()
{
    Console.Clear();
    if (gameHistory.Count() == 0)
    {
        Console.WriteLine("No game history to display!\nReturn after playing some games");
        restartMessage();
    }
    else
    {
        for (int i = 0; i < gameHistory.Count(); i++)
        {
            Console.WriteLine($"Game {i + 1} Score: {gameHistory[i]}");
        }
        Console.WriteLine("\n");
        restartMessage();
    }
    
}

void restartMessage()
{
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}



