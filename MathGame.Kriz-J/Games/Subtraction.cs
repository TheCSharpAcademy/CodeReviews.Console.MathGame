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
}