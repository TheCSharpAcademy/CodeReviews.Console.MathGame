namespace MathGame.Cactus;

class Score
{
    private DateTime _date;
    private int _typeScore;
    private int _score;
    private string _type;

    public Score(DateTime date, string type, int typeScore, int score)
    {
        _date = date;
        _type = type;
        _typeScore = typeScore;
        _score = score;
    }

    public DateTime Date
    {
        get { return _date; }
        set { _date = value; }
    }

    public int GetTypeScore()
    { return _typeScore; }

    public void SetTypeScore(int value)
    { _typeScore = value; }

    public int GetScore()
    { return _score; }

    public void SetScore(int value)
    { _score = value; }

    public string Type
    {
        get { return _type; }
        set { _type = value; }
    }
}