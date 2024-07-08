using System.Diagnostics;
using MathGame.CSA.Enums;
using MathGame.CSA.Models;

namespace MathGame.CSA;

public class GameLoop
{
  private static GameSettings? settings;
  private static Question? newQuestion;
  private static readonly Stopwatch timer = new();
  //StartGame 
  public static void DisplayMainMenu()
  {
    Printer.PrintHeader();
    string response = Printer.PrintMainMenuOptions();
    if (response == "Leaderboard")
    {
      Printer.PrintLeaderboard();
    }
    else
    {
      Run();
    }
  }
  public static void Run()
  {
    settings = GetGameSettings();
    timer.Restart();
    timer.Start();
    while (settings.QuestionsAnswered < settings.NumberOfQuestions)
    {
      int userAttempt = DisplayNextQuetsion();
      if (!CheckAnswer(userAttempt, newQuestion!.Answer))
      {
        GameOver();
        return;
      }
    }
    GameOver();
  }

  private static int DisplayNextQuetsion()
  {
    Console.Clear();
    Printer.PrintProgressBar(settings!.NumberOfQuestions, settings.QuestionsAnswered);
    GenerateQuestion();
    return Printer.PrintQuestion(newQuestion?.QuestionText!);
  }

  private static bool CheckAnswer(int attempt, int answer)
  {
    if (attempt == answer)
    {
      settings!.Increment();
      return true;
    }
    return false;
  }

  private static void GameOver()
  {
    timer.Stop();
    TimeSpan time = timer.Elapsed;
    Console.Clear();
    bool completed = settings!.QuestionsAnswered == settings.NumberOfQuestions;
    Printer.PrintGameOver(settings.QuestionsAnswered);
    string initials = Printer.PrintInitialsPrompt();
    LeaderboardEntry newEntry = new(settings.QuestionsAnswered, initials, settings.DifficultySetting.ToString(), time, completed);
    Leaderboard.AddEntry(newEntry);
    Thread.Sleep(1000);
    Console.Clear();
    Printer.PrintLeaderboard();
  }

  private static Question GenerateQuestion()
  {
    if (!settings!.IsRandom)
    {
      newQuestion = new Question(settings.InitialOperation, settings.DifficultySetting);
    }
    else
    {
      Operation randomOperation = GlobalConfig.RandomOperation();
      newQuestion = new Question(randomOperation, settings.DifficultySetting);
    }
    return newQuestion;
  }

  public static GameSettings GetGameSettings()
  {
    Console.Clear();
    Difficulty gameDifficulty = Printer.PrintDifficultyPrompt();
    bool isGameRandom = Printer.PrintRandomPrompt();
    int numberOfQuestions = Printer.PrintNumberOfQuestionsPrompt();
    if (!isGameRandom)
    {
      Operation gameOperation = Printer.PrintOperationPrompt();
      settings = new GameSettings(gameOperation, gameDifficulty, isGameRandom, numberOfQuestions);
    }
    else
    {
      settings = new GameSettings(gameDifficulty, isGameRandom, numberOfQuestions);
    }
    return settings;
  }
}