class Score
{
    private int score;

    public void IncrementScore()
    {
        score++;
    }

    public int GetScore()
    {
        return score;
    }

    public void ResetScore()
    {
         score = 0;
    }
}