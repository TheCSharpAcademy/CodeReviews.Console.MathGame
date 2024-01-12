using System.Numerics;

namespace MathGame;

struct Round {
    public IOperation PlayedOperation { get; set; }
    public BigInteger LeftOperand { get; set; }
    public BigInteger RightOperand { get; set; }
    public BigInteger ComputedResult { get; set; }
    public bool Won { get; set; } // False == lost.
}