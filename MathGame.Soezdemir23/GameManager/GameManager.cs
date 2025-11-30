using System.Globalization;
using mathgame.GameModes;
using mathgame.Model;

namespace mathgame.GameManager;

/// <summary>
/// Manages the main game flow, including menus, gameplay, and highscore persistence.
/// </summary>
public class GameManager
{
    /// <summary>
    /// List of all players who have played the game.
    /// </summary>
    private static List<Player> players = new List<Player>();
    
    /// <summary>
    /// Indicates whether the game is currently running.
    /// </summary>
    private static bool GameIsRunning = true;

    /// <summary>
    /// Initializes a new instance of the GameManager class.
    /// Loads existing highscores, displays the main menu, and saves highscores on exit.
    /// </summary>
    public GameManager()
    {
        LoadGame();
        MainMenu();
        SaveHighscore(players);
    }

    /// <summary>
    /// Displays the main menu and handles user navigation between game options.
    /// Allows the user to play the game, view highscores, or quit.
    /// </summary>
    private static void MainMenu()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("Welcome to the math game");
            Console.WriteLine("Choose one of the options by numbers shown:");
            Console.WriteLine("1. Play the game");
            Console.WriteLine("2. Highscore");
            Console.WriteLine("3. Quit the game");
            //intercepts the entry of the key so it doesn't show on the screen
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
            char input = keyInfo.KeyChar;
            switch (input)
            {
                case '1':
                    PlayGame();
                    break;
                case '2':
                    ShowHighscore(players);
                    break;
                case '3':
                    SaveHighscore(players);
                    ExitGame();
                    break;
            }
            Console.ReadKey();
        }
    }

    /// <summary>
    /// Prompts the user to select a math operation and starts the corresponding game mode.
    /// Creates a new Player instance, executes the selected game, and adds the result to the players list.
    /// </summary>
    private static void PlayGame()
    {
        Console.Clear();
        Console.WriteLine("Choose an operation (press a number key):");
        Console.WriteLine("1. Multiplication");
        Console.WriteLine("2. Division");
        Console.WriteLine("3. Addition");
        Console.WriteLine("4. Subtraction");
        ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
        char input = keyInfo.KeyChar;

        Console.Clear();
        switch (input)
        {
            case '1':
                players.Add(new MultiplicationGame().Play(new Player()));
                GameEnd(players.Last());
                break;
            case '2':
                players.Add(new DivisionGame().Play(new Player()));
                GameEnd(players.Last());
                break;
            case '3':
                players.Add(new AdditionGame().Play(new Player()));
                GameEnd(players.Last());
                break;
            case '4':
                players.Add(new SubtractionGame().Play(new Player()));
                GameEnd(players.Last());
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// Saves current highscore from the last loaded highscore text file with the new players
    /// Overwrites the previous content with this one as a csv
    /// </summary>
    private static void SaveHighscore(List<Player> players)
    {
        using StreamWriter writer = new StreamWriter("Highscore.txt", false); // false = overwrite
        foreach (var player in players)
        {
            // save them as name, points, date
            writer.WriteLine($"{player.GetName()}, {player.GetPoints()}, {player.GetDate()}, {player.GetMinutesTaken()}:{(player.GetSecondsTaken() > 0 ? player.GetSecondsTaken().ToString("D2") : "00")}");
        }

    }
 /// <summary>
 /// Loads existing highscore data from a text file.
 /// Creates the highscore file if it doesn't exist.
 /// </summary>
    private static void LoadGame()
    {
        string currentDir = Directory.GetCurrentDirectory();
        Console.WriteLine(currentDir);

        bool exists = File.Exists("Highscore.txt");
        if (exists == false)
        {
            // could have used File.WriteAllText, but that's not clear cut as file.Create
            File.Create("Highscore.txt");
        }
        else
        {
            List<string> highscore = File.ReadAllLines("Highscore.txt").ToList();

            // the second line is the content of the table, separated by comma
            foreach (var line in highscore)
            {
                if (line.Contains(','))
                {
                    string[] playerstats = line.Split(',');
                    if (
                        !DateTime.TryParseExact(
                            playerstats[2].Trim(),
                            "yyyy-MM-ddTHH:mm:ss",
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.None,
                            out DateTime parsedDate
                        )
                    )
                    {
                        throw new ArgumentException(
                            "Invalid date format for Player in Method Loadgame"
                        );
                    }
                    players.Add(new Player(playerstats[0], playerstats[1], parsedDate));
                }
            }
            Console.WriteLine($"The file was succesfully loaded: {players.Count} entries.");
        }
        
    }

/// <summary>
/// When game ends, asks the user to enter name. Is anonymous by default
/// Inserts name, points, date and time it took to finish the game mode
/// </summary>
    private static void GameEnd(Player player)
    {
        Console.WriteLine("What's your name? (Press Enter to stay anonymous)");
        string name = Console.ReadLine() ?? "Anonymous";
        player.SetName(String.IsNullOrWhiteSpace(name) ? "Anonymous" : name);

        while (true)
        {
            Console.WriteLine($"Is \"{player.GetName()}\" correct?");
            Console.WriteLine("[Y]es [N]o");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.KeyChar == 'Y' || key.KeyChar == 'y')
                break;
            else if (key.KeyChar == 'N' || key.KeyChar == 'n')
            {
                Console.WriteLine(
                    "\nPlease enter your name (or press Enter to stay anonymous):"
                );
                name = Console.ReadLine() ?? "Anonymous";
                player.SetName(String.IsNullOrWhiteSpace(name) ? "Anonymous" : name);
            }
        }
        Console.WriteLine("Game over! Thank you for playing.");
        // Optionally: Show highscore or update leaderboard here
    }

    /// <summary>
    /// shows highscore by using the currently loaded players List
    /// </summary>
    private static void ShowHighscore(List<Player> players)
    {
        Console.Clear();
        Console.WriteLine("\t\t---HighScore---");
        Console.WriteLine("Name:\tPoints:\tDate:\t\t\tTime Taken:");
        Console.WriteLine("-----------------------------------------------------");

        if (players.Count == 0)
        {
            Console.WriteLine("\tNo entries in the table");
        }
        else
        {
            foreach (var player in players)
            {
                Console.WriteLine($"{player.GetName()}\t{player.GetPoints()}\t{player.GetDate()}\t{player.GetMinutesTaken()}:{player.GetSecondsTaken()}");
            }
        }
        Console.WriteLine("Press any key to return...");
    }
    ///<summary>
    /// Game stops, everyone goes home.
    /// </summary>
    private static void ExitGame()
    {
        Console.Clear();
        Console.WriteLine("Thanks for playing!");
        Thread.Sleep(500);
        Environment.Exit(exitCode: 0);
    }
}
