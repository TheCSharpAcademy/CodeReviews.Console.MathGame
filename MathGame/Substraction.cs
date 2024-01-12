using System.Numerics;

namespace MathGame;

struct Substraction : IOperation {
    public string GetOperationName() => "Substraction";

    public string RenderAsText(BigInteger a, BigInteger b) => $"{a} - {b}";

    public BigInteger Operate(BigInteger a, BigInteger b) {
        return a - b;
    }
}