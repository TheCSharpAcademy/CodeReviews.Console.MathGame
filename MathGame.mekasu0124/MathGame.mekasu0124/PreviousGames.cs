namespace MathGame.mekasu0124;

public class PreviousGames
{
    public static List<GameModel> Games = new();
    
    public static void ShowGames(string username, DateTime date)
    {
        Console.Clear();
        Console.WriteLine("Previous Games");

        foreach (GameModel game in Games)
        {
            Console.WriteLine($"Date: {game.Date}\n- Username: {game.Username}\n- Game: {game.GameType} - {game.Difficulty}\n- Score: {game.Score}/{game.Total}\n- Time Played: {game.TotalTime}");
        }
        
        Console.WriteLine("\nPress Any Key To Go Back To Main Menu");
        Console.ReadLine();
        GameMenu.ShowMenu(username, date);
    }

    public static bool SaveGame(GameModel newGame)
    {
        try
        {
            Games.Add(newGame);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}