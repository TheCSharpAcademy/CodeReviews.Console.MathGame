using MathGameLibrary.Data;
using MathGameLibrary.Logic;
using MathGameLibrary.Player;
using System.Diagnostics;

WelcomeUser();
Player player = new()
{
    PlayerName = GetPlayerName()
};

bool play = true;
while (play)
{
    PlayRound(player);

    Console.Write("Hit Enter to continue...");
    Console.ReadLine();

    play = MenuSelect(MenuChoice(player));
}
Console.WriteLine($"Thanks for playing, {player.PlayerName}!");
Console.ReadLine();


void DisplayGameHistory(Player player)
{
    Console.Clear();
    foreach (Game game in player.GameHistory)
    {
        Console.Write($"Game {player.GameHistory.IndexOf(game) + 1}  ");
        Console.Write($"Operation: {game.GameType} ");
        Console.Write($"[{game.GameDifficulty}] ");
        Console.WriteLine($"Time: {game.GameTime:mm\\:ss}");
        Console.Write($"{game.CorrectAnswers} of {game.NumberOfQuestions} correct. ");
        Console.WriteLine($"Game score: {game.Score:p0}");
        Console.WriteLine();
    }
    Console.WriteLine($"Number of games played: {player.GameHistory.Count}");
    Console.WriteLine($"Overall Score: {player.Score:p0}");
    Console.WriteLine();
    Console.Write("Hit Enter to continue...");
    Console.ReadLine();
}

static void WelcomeUser()
{
    Console.Clear();
    Console.WriteLine();
    Console.WriteLine("Welcome to Math Game v2");
    Console.WriteLine("Designed and developed by Corey Jordan, 2023");
    Console.WriteLine();
}

static string GetPlayerName()
{
    string name = string.Empty;
    Console.Write("Please enter your name, player: ");

    while (name == string.Empty)
    {
        name = Console.ReadLine()!;
        if (name == string.Empty)
        {
            Console.WriteLine("I'm sorry, I didn't quite catch that.");
            Console.Write("PLease eneter your name: ");
        }
    }
    Console.Clear();
    return name;
}

Difficulty GetDifficulty()
{
    string[] menuChoices = new[] { "1", "2", "3" };
    string choice = string.Empty;

    while (menuChoices.Contains(choice) == false)
    {
        Console.WriteLine("Choose a difficulty level:");
        Console.WriteLine("    1: Easy");
        Console.WriteLine("    2: Normal");
        Console.WriteLine("    3: Hard");
        choice = Console.ReadLine()!;
    }

    Console.Clear();
    return choice switch
    {
        "1" => Difficulty.Easy,
        "3" => Difficulty.Hard,
        _ => Difficulty.Normal
    };
}

static Operator GetGameMode(Player player)
{
    string[] options = new[] { "1", "2", "3", "4", "5" };
    string choice;

    do
    {
        Console.WriteLine($"{player.PlayerName}, Choose from the following game types:");
        Console.WriteLine($"    1: {Operator.Add}");
        Console.WriteLine($"    2: {Operator.Subtract}");
        Console.WriteLine($"    3: {Operator.Multiply}");
        Console.WriteLine($"    4: {Operator.Divide}");
        Console.WriteLine($"    5: {Operator.Random}");
        choice = Console.ReadLine()!;

        if (!options.Contains(choice))
        {
            Console.WriteLine();
            Console.WriteLine("Sorry, that's not an option. Please try again.");
        }
    } while (options.Contains(choice) == false);

    Console.Clear();
    return choice switch
    {
        "2" => Operator.Subtract,
        "3" => Operator.Multiply,
        "4" => Operator.Divide,
        "5" => Operator.Random,
        _ => Operator.Add
    };
}

void PlayRound(Player player)
{
    Operator gameType = GetGameMode(player);
    Difficulty gameDifficulty = GetDifficulty();
    Console.Write("How many questions for this round? ");
    int numberOfQuestions = GetNumberFromPlayer(player);

    Game round = new()
    {
        GameType = gameType,
        GameDifficulty = gameDifficulty,
        NumberOfQuestions = numberOfQuestions,
    };
    Stopwatch timer = Stopwatch.StartNew();
    for (int i = 0; i < round.NumberOfQuestions; i++)
    {
        Console.Write(round.GenerateProblem());
        int guessNumber = GetNumberFromPlayer(player);
        bool isCorrect = round.CheckGuess(guessNumber);
        DisplayResult(isCorrect, player, round);
    }
    timer.Stop();
    round.GameTime = timer.Elapsed;
    DisplayScore(round);
    player.GameHistory.Add(round);
}

int GetNumberFromPlayer(Player player)
{
    int playerNumber;
    string input = Console.ReadLine()!;
    while (int.TryParse(input, out playerNumber) == false)
    {
        Console.Write($"Sorry {player.PlayerName}, that's not a valid number. Please try again: ");
        input = Console.ReadLine()!;
    }
    return playerNumber;
}

void DisplayResult(bool isCorrect, Player player, Game round)
{
    if (isCorrect)
    {
        Console.WriteLine("Correct!");
    }
    else
    {
        Console.WriteLine($"Sorry {player.PlayerName}, the correct answer is {round.GetAnswer()}");
    }
    Console.WriteLine();
}

void DisplayScore(Game round)
{
    Console.Write($"{round.CorrectAnswers} out of {round.NumberOfQuestions} correct. ");
    Console.WriteLine($"Score: {round.Score:p0} Time: {round.GameTime:mm\\:ss}");
}

string MenuChoice(Player player)
{
    string[] menuChoices = new[] { "1", "2", "3" };
    string choice;

    Console.Clear();
    do
    {
        Console.WriteLine($"{player.PlayerName}, Do you want to:");
        Console.WriteLine("    1: View Game History");
        Console.WriteLine("    2: Play Again");
        Console.WriteLine("    3: Quit");
        choice = Console.ReadLine()!;
    } while (menuChoices.Contains(choice) == false);

    return choice;
}

bool MenuSelect(string choice)
{
    bool keepPlaying = false;
    if (choice == "1")
    {
        DisplayGameHistory(player);
        keepPlaying = MenuSelect(MenuChoice(player));
    }
    else if (choice == "2")
    {
        keepPlaying = true;
    }
    return keepPlaying;
}