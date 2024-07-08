using MathGame.CSA.Enums;

namespace MathGame.CSA.Models;

public class GameSettings
{
  //initialized after collecting user choices
  public Operation InitialOperation { get; set; }
  public Difficulty DifficultySetting { get; set; }
  public bool IsRandom { get; set; }
  public int NumberOfQuestions { get; set; }
  public int Correct { get; private set; }
  public int Incorrect { get; set; }
  
  public GameSettings(
    Operation initialOperation, Difficulty difficultySetting,
    bool isRandom, int numberOfQuetsions)
  {
    InitialOperation = initialOperation;
    DifficultySetting = difficultySetting;
    IsRandom = isRandom;
    NumberOfQuestions = numberOfQuetsions;
    Correct = 0;
    Incorrect = 0;
  }
  public GameSettings(Difficulty difficultySetting, bool isRandom, int numberOfQuetsions)
  {
    InitialOperation = GlobalConfig.RandomOperation();
    DifficultySetting = difficultySetting;
    IsRandom = isRandom;
    NumberOfQuestions = numberOfQuetsions;
    Correct = 0;
    Incorrect = 0;
  }
  public void Increment()
  {
    Correct++;
  }
  public void Decrement()
  {
    Incorrect++;
  }
  public int QuestionsAnswered()
  {
    return Correct + Incorrect;
  }
  public double PercentCorrect()
  {
    if (NumberOfQuestions == 0)
    {
      return 0;
    }
    return (double)Correct/QuestionsAnswered() * 100;
  }

}
