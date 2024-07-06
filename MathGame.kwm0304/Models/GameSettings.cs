using MathGame.CSA.Enums;

namespace MathGame.CSA.Models;

public class GameSettings
{
  //initialized after collecting user choices
  public Operation InitialOperation { get; set; }
  public Difficulty DifficultySetting { get; set; }
  public bool IsRandom { get; set; }
  public int NumberOfQuestions { get; set; }
  public int QuestionsAnswered { get; private set; } = 0;
  public GameSettings(
    Operation initialOperation, Difficulty difficultySetting,
    bool isRandom, int numberOfQuetsions)
  {
    InitialOperation = initialOperation;
    DifficultySetting = difficultySetting;
    IsRandom = isRandom;
    NumberOfQuestions = numberOfQuetsions;
  }
  public GameSettings(Difficulty difficultySetting, bool isRandom, int numberOfQuetsions)
  {
    InitialOperation = GlobalConfig.RandomOperation();
    DifficultySetting = difficultySetting;
    IsRandom = isRandom;
    NumberOfQuestions = numberOfQuetsions;
  }
  public void Increment()
  {
    QuestionsAnswered++;
  }

}
