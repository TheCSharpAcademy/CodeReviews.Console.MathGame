
class ProblemLog
{
    public string operation { get; }
    public int[] nums { get; }
    public int score { get; }
    public int response { get; }

    public ProblemLog(string operation, int[] nums, int response, int score, Difficulty difficulty)
    {
        this.operation = operation;
        this.nums = nums;
        this.response = response;
        this.score = score;
    }

}
