namespace MathGame.Kriz_J.Games;

internal class RandomOperation(List<GameResult> scoreKeeper) : Game(scoreKeeper)
{
    protected override void Loop()
    {
        while (!Quit)
        {
            PrintMenu(
                StylizedTitles.Random,
                "Each question will be a random operation between two numbers.",
                Settings.Difficulty,
                Settings.Mode);

            if (Settings.Mode is Mode.Custom)
                Settings.NumberOfQuestions = 10;

            ReadAndRouteUserSelection();
        }
    }

    protected override void StandardGame()
    {
        GameCountDown();

        var result = GameLogic(Settings.NumberOfQuestions);
        result.Save(scoreKeeper, Settings, "Random");

        GameOverPresentation(result);
    }

    protected override void TimedGame()
    {
        GameCountDown();

        var start = DateTime.Now;
        var result = GameLogic(Settings.NumberOfQuestions);
        var stop = DateTime.Now;
        result.Save(scoreKeeper, Settings, "Random", stop - start);

        GameOverPresentation(result);
    }

    protected override void CustomGame()
    {
        SetNumberOfQuestions();

        GameCountDown();

        var result = GameLogic(Settings.NumberOfQuestions);
        result.Save(scoreKeeper, Settings, "Random");

        GameOverPresentation(result);
    }

    protected override GameResult GameLogic(int nrOfQuestions)
    {
        var score = 0;
        var generator = new Random();
        var lower = Settings.IntegerBounds.Lower;
        var upper = Settings.IntegerBounds.Upper;

        for (int i = 0; i < nrOfQuestions; i++)
        {
            int a, b;

            do
            {
                a = generator.Next(lower, upper);
                b = generator.Next(lower, upper);
            } while (a % b != 0);

            Console.Write($"\t{a} / {b} = ");

            var c = ConsoleHelperMethods.ReadUserInteger();

            if (a / b == c)
                score++;
        }

        return new GameResult(score);
    }

    private char RandomizeOperations()
    {
        return new Random().Next(1, 4) switch
        {
            1 => '+',
            2 => '-',
            3 => '*',
            4 => '/',
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private delegate void LoadMethods(char operation)
    {

    }

    private delegate bool OperatorExecution(int a, int b, int c);
    
    private static bool ValidAddition(int a, int b, int c) => a + b == c;
    
    private static bool ValidSubtraction(int a, int b, int c) => a - b == c;

    private static bool SubtractionLessThanZero(int a, int b, int c) => a - b < 0;
    
    private static bool ValidMultiplication(int a, int b, int c) => a * b == c;
    
    private static bool ValidDivision(int a, int b, int c) => a / b == c;
    private static bool DivisionHasRemainder(int a, int b, int c) => a % b != 0;
}