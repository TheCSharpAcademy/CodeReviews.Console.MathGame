using MathGameRecap.Common;
using static MathGameRecap.Common.Enums;
using static MathGameRecap.Common.Helpers;
namespace MathGameRecap.Models
{
    internal class DivisionGame : BaseGame
    {
        internal override Enums.GameType Type => Enums.GameType.Divide;

        internal override (int, int) GenerateOperands(Difficulty difficulty)
        {
            // Easy - single digit numbers
            // Medium - doulbe digit nominator single digit denominator
            // Hard - double digit division

            int quotient = Rng.Next(0, 100);
            int denominatorMultiple = Rng.Next(1, 100);

            //int a;
            //int b;

            switch (difficulty)
            {
                case Difficulty.Easy:
                    quotient = Rng.Next(0, 5);
                    denominatorMultiple = Rng.Next(1, 10);
                    break;
                case Difficulty.Medium:
                    quotient = Rng.Next(0, 10);
                    denominatorMultiple = Rng.Next(1, 10);
                    break;
                case Difficulty.Hard:
                    quotient = Rng.Next(1, 50);
                    denominatorMultiple = Rng.Next(1, 100);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            int nominator = quotient * denominatorMultiple;

            return (nominator, denominatorMultiple);
        }

        internal override int PerformOperation(int a, int b) => a / b;

        private int GenerateDenominator(int a)
        {
            if (a == 0)
            {
                return 1;
            }

            var availableDenominators = new List<int>();
            for (int i = 1; i <= a; i++) 
            {
                if (a % i == 0)
                {
                    availableDenominators.Add(i);
                }
            }

            int randomIndex = Helpers.Rng.Next(availableDenominators.Count);

            return availableDenominators[randomIndex];
        }
    }
}
