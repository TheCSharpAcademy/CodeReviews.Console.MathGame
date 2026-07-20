namespace MathGame.Louis_dub;

internal class Operation(int id, string game, string mode, string score)
{
    public int Id { get; set; } = id;
    public string Game { get; set; } = game;
    public string Mode { get; set; } = mode;
    public string Score { get; set; } = score;
}