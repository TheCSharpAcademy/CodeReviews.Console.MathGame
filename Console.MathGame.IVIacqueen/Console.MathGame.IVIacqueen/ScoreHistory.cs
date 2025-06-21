using MathGame.Models;

internal static class ScoreHistory
{
    // Score history for all the games played
    internal static List<Game> currentScores = new List<Game>()
    {
        /*new Game { Mode = GameMode.Addition, Score = 5, NumberOfProblems = 10, Time = 35, Difficulty = GameDifficulty.Easy },
        new Game { Mode = GameMode.Multiplication, Score = 2, NumberOfProblems = 10, Time = 30, Difficulty = GameDifficulty.Medium },
        new Game { Mode = GameMode.Division, Score = 4, NumberOfProblems = 10, Time = 24, Difficulty = GameDifficulty.Hard },
        new Game { Mode = GameMode.Subtraction, Score = 7, NumberOfProblems = 10, Time = 20, Difficulty = GameDifficulty.Medium },
        new Game { Mode = GameMode.Addition, Score = 10, NumberOfProblems = 10, Time = 5, Difficulty = GameDifficulty.Hard },
        new Game { Mode = GameMode.Multiplication, Score = 2, NumberOfProblems = 10, Time = 18, Difficulty = GameDifficulty.Easy },
        new Game { Mode = GameMode.Division, Score = 3, NumberOfProblems = 10, Time = 21, Difficulty = GameDifficulty.Hard },
        new Game { Mode = GameMode.Subtraction, Score = 6, NumberOfProblems = 10, Time = 60, Difficulty = GameDifficulty.Easy },
        new Game { Mode = GameMode.Addition, Score = 8, NumberOfProblems = 10, Time = 100, Difficulty = GameDifficulty.Medium },
        new Game { Mode = GameMode.Multiplication, Score = 1, NumberOfProblems = 10, Time = 87, Difficulty = GameDifficulty.Medium },
        new Game { Mode = GameMode.Subtraction, Score = 0, NumberOfProblems = 10, Time = 74, Difficulty = GameDifficulty.Hard },
        new Game { Mode = GameMode.Division, Score = 2, NumberOfProblems = 10, Time = 8, Difficulty = GameDifficulty.Easy },
        new Game { Mode = GameMode.Subtraction, Score = 9, NumberOfProblems = 10, Time = 13, Difficulty = GameDifficulty.Easy },*/
    };

    // Store score in the list of games user has played
    internal static void AddToHistory(GameMode mode, int finalScore, int numberOfProblems, GameDifficulty difficulty, int seconds)
    {
        currentScores.Add(new Game
        {
            Mode = mode,
            Score = finalScore,
            NumberOfProblems = numberOfProblems,
            Difficulty = difficulty,
            Time = seconds
        });
    }

    // Displays score history
    internal static void CheckHistory()
    {
        Console.Clear();

        // Checks if the user has played the game before
        if (currentScores.Count > 0)
        {
            Console.WriteLine("Game Mode".PadRight(18) + "Score".PadRight(14) + "Difficulty".PadRight(18) + "Time");
            Console.WriteLine("-------------------------------------------------------------");
            foreach (Game game in currentScores)
            {
                Console.WriteLine($"{game.Mode,-14} : {game.Score,2} out of {game.NumberOfProblems} | {game.Difficulty,10} | {game.Time,4} seconds ");        // Temporay numbers for formatting
            }
        }
        else
        {
            Console.WriteLine("You have not played the game yet!");
        }

        // Pause message to let the user see their previous scores
        Console.WriteLine("\nPress enter to go back to the main menu");
        Console.ReadLine();
    }
}
