public class Game
{
    public int Score { get; set; }
    public List<Question> Games { get; set; }
    public Operation GameType { get; set; }
    public DateTime dateTime { get; set; }

    public Game(Operation gameType)
    {
        GameType = gameType;
        dateTime = DateTime.Now;
        Games = new List<Question>();
    }

    public override string ToString()
    {
        return $"{dateTime}: GameType: {GameType} | Score: {Score}/5"; // TODO max questions as a prop
    }
}