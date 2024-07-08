using System.Diagnostics;
using MathGame.CSA.Enums;
using MathGame.CSA.Models;
using MathGame.kwm0304.Models;

namespace MathGame.CSA;

public class GameLoop
{
  private static GameSettings? settings;
  private static Question? newQuestion;
  private static readonly GameTimer timer = new();
  private static double percent;
  //StartGame 
  public static void OnStart()
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
    timer.Start();
    HandleGameLoop();
    GameOver();
  }
  private static void HandleGameLoop()
  {
    while (settings!.QuestionsAnswered() < settings.NumberOfQuestions)
    {
      int userAttempt = DisplayNextQuetsion();
      CheckAnswer(userAttempt, newQuestion!.Answer);
    }
  }
  private static void GenerateQuestion()
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
  private static int DisplayNextQuetsion()
  {
    Console.Clear();
    Printer.PrintProgressBar(settings!.NumberOfQuestions, settings.Correct);
    GenerateQuestion();
    return Printer.PrintQuestion(newQuestion?.QuestionText!);
  }
  private static void CheckAnswer(int attempt, int answer)
  {
    if (attempt == answer)
    {
      settings!.Increment();
    }
    else
    {
      settings!.Decrement();
    }
  }
  private static void GameOver()
  {
    timer.Stop();
    TimeSpan time = timer.ElapsedTime;
    Console.Clear();
    bool completed = settings!.QuestionsAnswered() == settings.NumberOfQuestions;
    Printer.PrintGameOver(settings!.Correct, settings.NumberOfQuestions);
    string initials = Printer.PrintInitialsPrompt();
    AddEntryToLeaderboard(initials, time, completed);
    Thread.Sleep(1000);
    Console.Clear();
    Printer.PrintLeaderboard();
  }
  private static void AddEntryToLeaderboard(string initials, TimeSpan time, bool completed)
  {
    percent = settings!.PercentCorrect();
    LeaderboardEntry newEntry = new(percent, initials, settings!.DifficultySetting.ToString(), time, completed);
    Leaderboard.AddEntry(newEntry);
  }
}