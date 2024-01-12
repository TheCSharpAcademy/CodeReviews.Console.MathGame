using System.Numerics;

namespace MathGame;

struct Sum : IOperation {
    public string GetOperationName() => "Sum";

    public string RenderAsText(BigInteger a, BigInteger b) => $"{a} + {b}";

    public BigInteger Operate(BigInteger a, BigInteger b) {
        return a + b;
    }
}