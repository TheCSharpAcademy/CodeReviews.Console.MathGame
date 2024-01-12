using System.Numerics;

namespace MathGame;

struct Multiplication : IOperation {
    public string GetOperationName() => "Multiplication";

    public string RenderAsText(BigInteger a, BigInteger b) => $"{a} * {b}";

    public BigInteger Operate(BigInteger a, BigInteger b) {
        return a * b;
    }
}