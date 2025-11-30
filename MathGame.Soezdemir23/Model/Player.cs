namespace mathgame.Model;

/// <summary>
/// Represents a player in the math game with their score, name, date, and time taken.
/// </summary>
public class Player
{
    private readonly string date;
    private int points;
    private string name = string.Empty;

    private int minutesTaken;
    private int secondsTaken;

    /// <summary>
    /// Initializes a new instance of the <see cref="Player"/> class with the current date and time.
    /// </summary>
    public Player()
    {
        date = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Player"/> class with specified name, points, and date.
    /// </summary>
    /// <param name="name">The player's name.</param>
    /// <param name="points">The player's points as a string.</param>
    /// <param name="date">The date associated with the player's game.</param>
    /// <exception cref="ArgumentException">Thrown when points cannot be parsed as an integer.</exception>
    public Player(string name, string points, DateTime date)
    {
        if (!int.TryParse(points, out this.points))
        {
            throw new ArgumentException("Invalid points, is the highscore file tampered with?");
        }
        this.name = name;
        this.date = date.ToString("yyyy-MM-ddTHH:mm:ss");
    }

    /// <summary>
    /// Gets the date associated with the player.
    /// </summary>
    /// <returns>The date in ISO 8601 format.</returns>
    public string GetDate() => date;

    /// <summary>
    /// Gets the player's name.
    /// </summary>
    /// <returns>The player's name.</returns>
    public string GetName() => name;

    /// <summary>
    /// Sets the player's name.
    /// </summary>
    /// <param name="name">The name to set for the player.</param>
    public void SetName(string name) => this.name = name;

    /// <summary>
    /// Increases the player's points by one.
    /// </summary>
    public void GainPoint() => points++;

    /// <summary>
    /// Decreases the player's points by one, ensuring it doesn't go below zero.
    /// </summary>
    /// <returns>The updated points value.</returns>
    public int LosePoint()
    {
        int current = points;
        points = Math.Max(0, points - 1);
        return current;
    }

    /// <summary>
    /// Gets the player's current points.
    /// </summary>
    /// <returns>The current points value.</returns>
    public int GetPoints() => points;

    /// <summary>
    /// Returns a string representation of the player including name, score, date, and time taken.
    /// </summary>
    /// <returns>A formatted string with player information.</returns>
    public override string ToString()
    {
        return $"Name: {name}, Score: {points}, Date: {date}, Time Taken: {minutesTaken}:{(secondsTaken > 0 ? secondsTaken.ToString("D2") : "00")}";
    }

    /// <summary>
    /// Gets the minutes taken by the player.
    /// </summary>
    /// <returns>The minutes taken.</returns>
    internal int GetMinutesTaken()=>minutesTaken;

    /// <summary>
    /// Gets the seconds taken by the player.
    /// </summary>
    /// <returns>The seconds taken.</returns>
    internal int GetSecondsTaken()=>secondsTaken;

    /// <summary>
    /// Sets the time taken by the player to complete the game.
    /// </summary>
    /// <param name="minutes">The minutes taken.</param>
    /// <param name="seconds">The seconds taken.</param>
    internal void SetTimeTaken(int minutes, int seconds)
    {
        this.minutesTaken = minutes;
        this.secondsTaken = seconds;
    }
}