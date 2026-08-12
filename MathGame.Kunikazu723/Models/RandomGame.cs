using MathGameRecap.Common;
using static MathGameRecap.Common.Enums;

namespace MathGameRecap.Models
{
    internal class RandomGame : BaseGame
    {
        private static List<BaseGame> AvailableGames {  get; set; } = new List<BaseGame>()
        {
            new AdditionGame(),
            new SubtractionGame(),
            new MultiplicationGame(),
            new DivisionGame(),
        };
        private BaseGame? Game { get; set; }

        internal override GameType Type => Game?.Type ?? GameType.Random;

        internal override (int, int) GenerateOperands(Difficulty difficulty)
        {
            Game = ChooseRandomGame();
            return Game.GenerateOperands(difficulty);
        }

        internal override int PerformOperation(int a, int b)
        {
            if (Game == null)
            {
                Game = ChooseRandomGame();
            }
            return Game.PerformOperation(a, b);
        }

        private static BaseGame ChooseRandomGame()
        {

            return AvailableGames[Helpers.Rng.Next(AvailableGames.Count)]; ;
        }
    }
}
