namespace MathGame.CSA.Models;

public class LeaderboardEntry
{
  public int EntryScore { get; set; }
  public string Initials { get; set; }
  public DateTime EntryDate { get; set; }
  public string EntryDifficulty { get; set; }
  public TimeSpan TimeTaken { get; set; }
  public bool Completed { get; set; }

  public LeaderboardEntry(int entryScore, string initials, string entryDifficulty, TimeSpan timeTaken, bool completed)
  {
    EntryScore = entryScore;
    Initials = initials;
    EntryDate = DateTime.Today;
    EntryDifficulty = entryDifficulty;
    TimeTaken = timeTaken;
    Completed = completed;
  }
}
