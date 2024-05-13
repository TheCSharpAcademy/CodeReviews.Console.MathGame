namespace MathGame.Kriz_J.Games;

public class Addition(List<GameResult> scoreKeeper) : Game(scoreKeeper)
{
    protected override void Loop()
    {
        while (!Quit)
        {
            PrintMenu(
                StylizedTitles.Addition,
                "Each question will be an addition problem of two terms.",
                Settings.Difficulty,
                Settings.Mode);
            Settings.NumberOfQuestions = 10;
            ReadAndRouteUserSelection();
        }
    }

    protected override void StandardGame()
    {
        GameCountDown();

        var gameResult = GameLogic(Settings.NumberOfQuestions);
        SaveScoreRecord(gameResult);

        GameOverPresentation(gameResult);
    }

    protected override void TimedGame()
    {
        GameCountDown();

        var start = DateTime.Now;
        var scoreRecord = GameLogic(Settings.NumberOfQuestions);
        var stop = DateTime.Now;
        SaveScoreRecord(scoreRecord, stop - start);

        GameOverPresentation(scoreRecord);
    }

    protected override void CustomGame()
    {
        SetNumberOfQuestions();
        
        GameCountDown();

        var scoreRecord = GameLogic(Settings.NumberOfQuestions);
        SaveScoreRecord(scoreRecord);

        GameOverPresentation(scoreRecord);
    }

    private void GameOverPresentation(GameResult gameResult)
    {
        PrintScore(gameResult.Score);

        if (gameResult.TimeNeeded is not null)
        {
            Console.Write($"\tTime: {gameResult.TimeNeeded:mm\\:ss\\.fff}");
        }
        
        Console.Write("\t\t\t. . . Press any key to go back.");
        Console.ReadKey();
    }
    
    private GameResult GameLogic(int nrOfQuestions)
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

        return new GameResult(score);
    }

    private void SaveScoreRecord(GameResult gameResult, TimeSpan? duration = null)
    {
        gameResult.Game = "Addition";
        gameResult.Difficulty = Settings.Difficulty;
        gameResult.Mode = Settings.Mode;
        gameResult.NumberOfQuestions = Settings.NumberOfQuestions;
        gameResult.TimeNeeded = duration;
        ScoreKeeper.Add(gameResult);
    }
}