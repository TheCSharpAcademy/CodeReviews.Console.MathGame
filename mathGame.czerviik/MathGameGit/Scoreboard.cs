using System;

namespace mathGame.czerviik;

public class Scoreboard
{
	public int Score { get; private set; }
    public int Rounds { get; set; }
	public double AverageTime { get; private set; }
	private List<double> answerTimes;

    public Scoreboard()
	{
        answerTimes = new();
        Score = 0;
		Rounds = 1;
	}

	public void ScoreUp()
	{
		Score++;
	}

	public void ResetScore()
	{
		Score = 0;
	}

	public void AddTime(double timeSpan)
	{	
		answerTimes.Add(timeSpan);
	}

	public double ShowAverageTime()
	{
		CalculateAverageTime(answerTimes);
		return Math.Round(AverageTime,2);
	}

	private void CalculateAverageTime(List<double> answerTimes)
	{
		AverageTime = answerTimes.Any() ? answerTimes.Average():0;
    }

        public void Display()
	{
		Console.WriteLine("Round {0}, score{1}",Rounds,Score);
	}
}