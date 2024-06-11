using MathGame.Kriz_J.Enums;

namespace MathGame.Kriz_J.Games;

public class Addition : Game
{
    public Addition(ResultKeeper resultKeeper) : base(resultKeeper)
    {
        Settings.GameType = GameType.Addition;
    }

    public override void Start()
    {
        while (!Quit)
        {
            PrintMenu(StylizedTitles.Addition, "Each question will be an addition problem of two terms.");

            ReadAndRouteUserSelection();
        }
    }
}