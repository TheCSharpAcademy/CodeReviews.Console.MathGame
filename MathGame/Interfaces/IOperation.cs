using System.Numerics;

namespace MathGame;

internal interface IOperation {
    public string GetOperationName() => "???";
    public string RenderAsText(BigInteger a, BigInteger b) => "a ? b";
    public BigInteger Operate(BigInteger a, BigInteger b) => -1;
}