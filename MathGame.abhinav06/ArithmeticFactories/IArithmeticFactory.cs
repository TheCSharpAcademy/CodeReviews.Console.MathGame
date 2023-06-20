using MathGame.Entities;

namespace MathGame.ArithmeticFactories;

interface IArithmeticFactory
{
    Question GenerateQuestion();
}
