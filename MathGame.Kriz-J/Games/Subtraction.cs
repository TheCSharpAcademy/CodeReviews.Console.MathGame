using MathGame.Kriz_J.Enums;

namespace MathGame.Kriz_J.Games;

public class Subtraction : Game
{
    public Subtraction(ResultKeeper resultKeeper) : base(resultKeeper)
    {
        Settings.GameType = GameType.Subtraction;
    }

    public override void Start()
    {
        while (!Quit)
        {
            PrintMenu(StylizedTitles.Subtraction,
                "Each question will be a subtraction problem between two terms.");

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
            int a, b;

            do
            {
                a = generator.Next(lower, upper);
                b = generator.Next(lower, upper);
            } while (a - b < 0);

            Console.Write($"\t{a} - {b} = ");

            var c = ConsoleHelperMethods.ReadUserInteger();

            if (a - b == c)
                score++;
        }
        var stop = DateTime.Now;

        return timed ? new GameResult(score, TimeNeeded: stop - start) : new GameResult(score);
    }
}