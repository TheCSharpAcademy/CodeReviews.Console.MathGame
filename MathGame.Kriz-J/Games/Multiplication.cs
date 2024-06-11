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
            PrintMenu(StylizedTitles.Multiplication, "Each question will be a multiplication problem between two factors.");

            ReadAndRouteUserSelection();
        }
    }
}