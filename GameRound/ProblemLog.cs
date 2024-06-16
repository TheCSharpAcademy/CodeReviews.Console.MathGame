
class ProblemLog
{
    public Operation operation;
    public int[] nums;
    public int score;
    public int response;

    public ProblemLog(Operation operation, int[] nums, int response, int score)
    {
        this.operation = operation;
        this.nums = nums;
        this.response = response;
        this.score = score;
    }

}
