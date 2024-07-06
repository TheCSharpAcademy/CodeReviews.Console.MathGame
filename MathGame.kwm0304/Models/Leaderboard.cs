using System.Text.Json;

namespace MathGame.CSA.Models;

public class Leaderboard
{
  public static List<LeaderboardEntry> Entries { get; private set; } = LoadEntries();
  private const string leaderboardFile = "leaderboard.json";
  public Leaderboard() { }
  public static void AddEntry(LeaderboardEntry entry)
  {
    Entries.Add(entry);
    SaveEntry();
  }

  public static List<LeaderboardEntry> GetByHighScore()
  {
    return Entries.OrderByDescending(e => e.EntryScore).ToList();
  }
  public static void SaveEntry()
  {
    JsonSerializerOptions options = new()
    {
      WriteIndented = true
    };
    try
    {
      string jsonGames = JsonSerializer.Serialize(Entries, options);
      File.WriteAllText(leaderboardFile, jsonGames);
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message);
    }
  }
  public static List<LeaderboardEntry> LoadEntries()
  {
    if (File.Exists(leaderboardFile))
    {
      string jsonGames = File.ReadAllText(leaderboardFile);
      return JsonSerializer.Deserialize<List<LeaderboardEntry>>(jsonGames) ?? new List<LeaderboardEntry>();
    }
    return new List<LeaderboardEntry>();
  }
}
