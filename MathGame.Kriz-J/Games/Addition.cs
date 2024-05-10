namespace MathGame.Kriz_J.GameSections;

public class Addition : Game
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

        var score = GameLogic(Settings.NumberOfQuestions);

        GameOverPresentation(score);
    }

    protected override void TimedGame()
    {
        GameHelperMethods.GameCountDown();

        var start = DateTime.Now;
        var score = GameLogic(Settings.NumberOfQuestions);
        var stop = DateTime.Now;

        GameOverPresentation(score, stop - start);
    }

    protected override void CustomGame()
    {
        SetNumberOfQuestions();

        GameHelperMethods.GameCountDown();

        var score = GameLogic(Settings.NumberOfQuestions);

        GameOverPresentation(score);
    }

    private void GameOverPresentation(int score, TimeSpan? duration = null)
    {
        PrintScore(score);

        if (duration is not null)
        {
            Console.Write($"\tTime: {duration:mm\\:ss\\.fff}");
        }
        
        Console.Write("\t\t\t. . . Press any key to go back.");
        Console.ReadKey();
    }

    private int GameLogic(int nrOfQuestions)
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

        return score;
    }
}