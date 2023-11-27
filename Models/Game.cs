namespace Branch_Console;

internal class Game
{
    internal int UserScore { get; set; }
    internal int RunScore { get; set; }
    internal DateTime Date { get; set; }
    internal OperationType Type { get; set; }
    internal Difficulty Difficulty { get; set; }
    internal int Questions { get; set; }

    public override string ToString()
    {
        return $"{Date} : User Session Score: {UserScore} - Run Type: {Type}: {RunScore} pts";
    }
}
