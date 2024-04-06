using MathGame.BBualdo.enums;

namespace MathGame.BBualdo.Helpers;

internal class OperatorChecker
{
  public static char? CheckOperators(GameTypes gameType)
  {
    char[] operators = { '+', '-', '*', '/' };
    char? currentOperator = null;

    if (gameType == GameTypes.Addition)
      currentOperator = operators[0];
    if (gameType == GameTypes.Subtraction)
      currentOperator = operators[1];
    if (gameType == GameTypes.Multiplication)
      currentOperator = operators[2];
    if (gameType == GameTypes.Division)
      currentOperator = operators[3];
    if (gameType == GameTypes.Random)
    {
      Random random = new Random();
      int index = random.Next(0, 4);
      currentOperator = operators[index];
    }

    return currentOperator;
  }
}