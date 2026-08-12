using MathGameRecap.Common;
using static MathGameRecap.Common.Enums;
namespace MathGameRecap.Models
{
    internal class AdditionGame : BaseGame
    {
        internal override GameType Type { get; } = GameType.Add;

        internal override (int, int) GenerateOperands(Difficulty difficulty)
        {
            int a;
            int b;
            switch (difficulty)
            {
                case Difficulty.Easy:
                    a = Helpers.Rng.Next(1, 10);
                    b = Helpers.Rng.Next(1, 10);
                    break;
                case Difficulty.Medium:
                    a = Helpers.Rng.Next(10, 101);
                    b = Helpers.Rng.Next(1, 10);
                    break;
                case Difficulty.Hard:
                    a = Helpers.Rng.Next(1, 100);
                    b = Helpers.Rng.Next(1, 100);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return (a, b);
        }

        internal override int PerformOperation(int a, int b) => a + b;
        
    }
}
