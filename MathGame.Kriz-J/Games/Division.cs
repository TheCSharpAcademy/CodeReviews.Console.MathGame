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
            if (NewGame)
            {
                PrintMenu(StylizedTitles.Division, "Each question will be a division problem between two factors.");
            }

            ReadAndRouteUserSelection();
        }
    }
}