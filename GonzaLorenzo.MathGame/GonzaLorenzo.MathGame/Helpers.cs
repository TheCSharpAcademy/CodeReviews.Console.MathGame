namespace GonzaLorenzo.MathGame;

internal class Helpers
{
    public static List<Game> games = new();
    public static int gameNumber = 0;

    internal static void AddToHistory(GameMode gameMode, Difficulty difficulty, int questions, int score, TimeSpan timeTaken)
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

    internal static void ViewGamesHistory()
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
        Time taken: {game.Time.TotalSeconds:F2} seconds
        ");
        }
        Console.WriteLine("---------------------------------\n");

        Console.WriteLine("Press enter to go back to the menu.");
        Console.ReadLine();
    }
}
