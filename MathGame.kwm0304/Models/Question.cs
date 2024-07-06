using MathGame.CSA.Enums;
using MathGame.CSA;
namespace MathGame.CSA.Models;

public class Question
{
  public string? QuestionText { get; set; }
  public int FirstNumber { get; set; }
  public int SecondNumber { get; set; }
  public int Answer { get; set; }
  public Operation QuestionOperation { get; set; }
  public Difficulty QuestionDifficulty { get; set; }
  public Question(Operation operation, Difficulty difficulty)
  {
    QuestionOperation = operation;
    QuestionDifficulty = difficulty;
    GenerateQuestionParams();
  }
  private void GenerateQuestionParams()
  {
    //easy: 10, medium: 20, hard: 100
    int difficultyVar = (int)QuestionDifficulty;

    if (QuestionOperation == Operation.Division)
    {
      SecondNumber = GlobalConfig.random.Next(1, 11);
      int tempFirst = GlobalConfig.random.Next(1, difficultyVar);
      FirstNumber = tempFirst * SecondNumber; 
      Answer = FirstNumber / SecondNumber;
      QuestionText = $"What is {FirstNumber} / {SecondNumber}";
    }
    else if (QuestionOperation == Operation.Subtraction)
    {
      FirstNumber = GlobalConfig.random.Next(2, difficultyVar);
      SecondNumber = GlobalConfig.random.Next(1, FirstNumber);
      Answer = FirstNumber - SecondNumber;
      QuestionText = $"What is {FirstNumber} - {SecondNumber}?";
    }
    else
    {
      FirstNumber = GlobalConfig.random.Next(1, difficultyVar);
      SecondNumber = GlobalConfig.random.Next(1, difficultyVar);
      Answer = QuestionOperation == Operation.Addition ? FirstNumber + SecondNumber : FirstNumber * SecondNumber;
      string operationSymbol = QuestionOperation == Operation.Addition ? "+" : "*";
      QuestionText = $"What is {FirstNumber} {operationSymbol} {SecondNumber}?";
    }
  }
}
