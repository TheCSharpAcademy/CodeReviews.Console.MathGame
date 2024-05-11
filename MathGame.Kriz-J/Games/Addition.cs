namespace MathGame.Kriz_J.Games;

public class Addition(List<ScoreRecord> scoreKeeper) : Game(scoreKeeper)
{
    protected override void Loop()
    {
        while (!Quit)
        {
            PrintMenu(
                StylizedTexts.Addition,
                "Each question will be an addition problem of two terms.",
                Settings.Difficulty,
                Settings.Mode);
            ReadAndRouteUserSelection();
        }
    }

    protected override void StandardGame()
    {
        GameHelperMethods.GameCountDown();

        var scoreRecord = GameLogic(Settings.NumberOfQuestions);
        SaveScoreRecord(scoreRecord);

        GameOverPresentation(scoreRecord);
    }

    protected override void TimedGame()
    {
        GameHelperMethods.GameCountDown();

        var start = DateTime.Now;
        var scoreRecord = GameLogic(Settings.NumberOfQuestions);
        var stop = DateTime.Now;
        SaveScoreRecord(scoreRecord, stop - start);

        GameOverPresentation(scoreRecord);
    }

    protected override void CustomGame()
    {
        SetNumberOfQuestions();
        
        GameHelperMethods.GameCountDown();

        var scoreRecord = GameLogic(Settings.NumberOfQuestions);
        SaveScoreRecord(scoreRecord);

        GameOverPresentation(scoreRecord);
    }

    private void GameOverPresentation(ScoreRecord scoreRecord)
    {
        PrintScore(scoreRecord.Score);

        if (scoreRecord.TimeNeeded is not null)
        {
            Console.Write($"\tTime: {scoreRecord.TimeNeeded:mm\\:ss\\.fff}");
        }
        
        Console.Write("\t\t\t. . . Press any key to go back.");
        Console.ReadKey();
    }
    
    private ScoreRecord GameLogic(int nrOfQuestions)
    {
        var score = 0;
        var generator = new Random();
        var lower = Settings.IntegerBounds.Lower;
        var upper = Settings.IntegerBounds.Upper;

        for (int i = 0; i < nrOfQuestions; i++)
        {
            var a = generator.Next(lower, upper);
            var b = generator.Next(lower, upper);

            Console.Write($"\t{a} + {b} = ");

            var c = ConsoleHelperMethods.ReadUserInteger();

            if (a + b == c)
                score++;
        }

        return new ScoreRecord(score);
    }

    private void SaveScoreRecord(ScoreRecord scoreRecord, TimeSpan? duration = null)
    {
        scoreRecord.Game = "Addition";
        scoreRecord.Difficulty = Settings.Difficulty;
        scoreRecord.Mode = Settings.Mode;
        scoreRecord.NumberOfQuestions = Settings.NumberOfQuestions;
        scoreRecord.TimeNeeded = duration;
        ScoreKeeper.Add(scoreRecord);
    }
}