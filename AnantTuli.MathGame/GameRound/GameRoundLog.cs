
class GameRoundLog
{
    public List<ProblemLog> problemLogs;

    public double timeTaken;

    public Difficulty difficulty;

    public int Score
    {
        get
        {
            return problemLogs.Sum((log) => log.score);
        }
    }

    public GameRoundLog(List<ProblemLog> problems, double timeTaken, Difficulty difficulty)
    {
        this.problemLogs = problems;
        this.timeTaken = timeTaken;
        this.difficulty = difficulty;
    }

}
