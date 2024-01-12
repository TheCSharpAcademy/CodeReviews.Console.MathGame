using System.Numerics;

namespace MathGame;

struct Division : IOperation {
    public string GetOperationName() => "Division";
    public string RenderAsText(BigInteger a, BigInteger b) => $"{a} / {b}";

    public BigInteger Operate(BigInteger a, BigInteger b) {
        return a / b;
    }
}