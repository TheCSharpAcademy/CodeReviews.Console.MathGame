using MathGame.Kriz_J.Enums;

namespace MathGame.Kriz_J.Games;

public class RandomOperation : Game
{
    public RandomOperation(ResultKeeper resultKeeper) : base(resultKeeper)
    {
        Settings.GameType = GameType.Random;
    }

    public override void Start()
    {
        while (!Quit)
        {
            PrintMenu(StylizedTitles.Random,
                "Each question will be a random operation between two numbers.");

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
            var operatorSwitch = new OperatorSwitch(Settings.GameType);
            
            int a, b;
            do
            {
                a = generator.Next(lower, upper);
                b = generator.Next(lower, upper);
            } while (operatorSwitch.NumberGeneratorConditionDelegate(a, b));

            Console.Write($"\t{a} {operatorSwitch.Operator} {b} = ");

            var c = ConsoleHelperMethods.ReadUserInteger();

            if (operatorSwitch.OperatorConditionDelegate(a, b, c))
                score++;
        }
        var stop = DateTime.Now;

        return timed ? new GameResult(score, TimeNeeded: stop - start) : new GameResult(score);
    }
}