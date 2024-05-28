using MathGame.Kriz_J.Enums;

namespace MathGame.Kriz_J.Games;

public class Multiplication : Game
{
    public Multiplication(ResultKeeper resultKeeper) : base(resultKeeper)
    {
        Settings.GameType = GameType.Multiplication;
    }

    public override void Start()
    {
        while (!Quit)
        {
            PrintMenu(StylizedTitles.Multiplication,
                "Each question will be a multiplication problem between two factors.");

            ReadAndRouteUserSelection();
        }
    }

    protected override GameResult GameLogic(int nrOfQuestions, bool timed)
    {
        var score = 0;
        var generator = new Random();
        var lower = Settings.NumberLimits.Lower;
        var upper = Settings.NumberLimits.Upper;

        var start = DateTime.Now;
        for (int i = 0; i < nrOfQuestions; i++)
        {
            var a = generator.Next(lower, upper);
            var b = generator.Next(lower, upper);

            Console.Write($"\t{a} * {b} = ");

            var c = ConsoleHelperMethods.ReadUserInteger();

            if (a * b == c)
                score++;
        }
        var stop = DateTime.Now;

        return timed ? new GameResult(score, TimeNeeded: stop - start) : new GameResult(score);
    }
}