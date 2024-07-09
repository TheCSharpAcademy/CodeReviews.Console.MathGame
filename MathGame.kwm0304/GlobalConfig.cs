using MathGame.CSA.Enums;

namespace MathGame.CSA;

public static class GlobalConfig
{
    public static Random random = new();
    public static List<Operation> OperationsList = new List<Operation>
    {
      Operation.Addition,
      Operation.Subtraction,
      Operation.Multiplication,
      Operation.Division
    };
    public static List<Difficulty> DifficultyList = new List<Difficulty>
    {
      Difficulty.Easy,
      Difficulty.Medium,
      Difficulty.Hard
    };
    public static Operation RandomOperation()
    {
      int index = random.Next(OperationsList.Count);
      return OperationsList[index];
    }
}
