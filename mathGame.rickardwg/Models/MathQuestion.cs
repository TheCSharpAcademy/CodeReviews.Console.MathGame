using MathGame.Enums;

namespace MathGame.Models;

internal class MathQuestion
{
    internal int LeftOperand { get; set; }
    internal int RightOperand { get; set; }
    internal Operation Operation { get; set; }
    internal int CorrectAnswer { get; set; }
}
