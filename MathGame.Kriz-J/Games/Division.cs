using MathGame.Kriz_J.Enums;

namespace MathGame.Kriz_J.Games;

public class Division : Game
{
    public Division(ResultKeeper resultKeeper) : base(resultKeeper)
    {
        Settings.GameType = GameType.Division;
    }

    public override void Start()
    {
        while (!Quit)
        {
            PrintMenu(StylizedTitles.Division,
                "Each question will be a division problem between two factors.");

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
            } while (a % b != 0);

            Console.Write($"\t{a} / {b} = ");

            var c = ConsoleHelperMethods.ReadUserInteger();

            if (a / b == c)
                score++;
        }
        var stop = DateTime.Now;

        return timed ? new GameResult(score, TimeNeeded: stop - start) : new GameResult(score);
    }
}