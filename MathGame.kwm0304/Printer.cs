using MathGame.CSA.Enums;
using MathGame.CSA.Models;
using Spectre.Console;

namespace MathGame.CSA;

public class Printer
{
  //will print all console statements, if using ansi will return value
  public static void PrintHeader()
  {
    AnsiConsole.WriteLine(@"
.___  ___.      ___   .___________. __    __       _______      ___      .___  ___.  _______ 
|   \/   |     /   \  |           ||  |  |  |     /  _____|    /   \     |   \/   | |   ____|
|  \  /  |    /  ^  \ `---|  |----`|  |__|  |    |  |  __     /  ^  \    |  \  /  | |  |__   
|  |\/|  |   /  /_\  \    |  |     |   __   |    |  | |_ |   /  /_\  \   |  |\/|  | |   __|  
|  |  |  |  /  _____  \   |  |     |  |  |  |    |  |__| |  /  _____  \  |  |  |  | |  |____ 
|__|  |__| /__/     \__\  |__|     |__|  |__|     \______| /__/     \__\ |__|  |__| |_______|
                                                                                             
");
  }
  public static bool PrintRandomPrompt()
  {
    string isRandom = AnsiConsole.Prompt(
      new SelectionPrompt<string>()
      .Title("[yellow]Do you want to randomize operations throughout the game?[/]")
      .AddChoices("Yes", "No")
    );
    return isRandom == "Yes";
  }
  public static int PrintNumberOfQuestionsPrompt()
  {
    int numberOfQuestions = AnsiConsole.Prompt(
      new TextPrompt<int>("[green]How many questions do you want the game to be?[/]")
      .Validate(input =>
      {
        return input > 0
        ? ValidationResult.Success()
        : ValidationResult.Error("[red]Input must be a number[/]");
      })
    );
    return numberOfQuestions;
  }
  public static void PrintProgressBar(int numQuestions, int currentScore)
  {
    var chart = new BarChart()
    .Width(60)
    .Label("[green]Math Game[/]")
    .CenterLabel()
    .WithMaxValue(numQuestions)
    .AddItem("Percent", currentScore , Color.Green);
    AnsiConsole.Write(chart);
  }

  public static string PrintMainMenuOptions()
  {
    string option = AnsiConsole.Prompt(
      new SelectionPrompt<string>()
      .AddChoices("Play", "Leaderboard")
    );
    return option;
  }
  public static Operation PrintOperationPrompt()
  {
    Operation operation = AnsiConsole.Prompt(
      new SelectionPrompt<Operation>()
      .Title("[green]Choose an operation for the game:[/]")
      .AddChoices(GlobalConfig.OperationsList)
    );
    return operation;
  }
  public static Difficulty PrintDifficultyPrompt()
  {
    Difficulty difficulty = AnsiConsole.Prompt(
      new SelectionPrompt<Difficulty>()
      .Title("[blue]Choose a difficulty level:[/]")
      .AddChoices(GlobalConfig.DifficultyList)
    );
    return difficulty;
  }

  public static int PrintQuestion(string questionText)
  {
    int userAttempt = AnsiConsole.Prompt(
      new TextPrompt<int>($"[green]{questionText}[/]")
      .Validate(input =>
      {
        return input > 0
        ? ValidationResult.Success()
        : ValidationResult.Error("[red]Input must be a number[/]");
      })
    );
    return userAttempt;
  }
  public static void PrintGameOver(int correct, int total)
  {
    AnsiConsole.WriteLine(@"
  _______      ___      .___  ___.  _______      ______   ____    ____  _______ .______      
 /  _____|    /   \     |   \/   | |   ____|    /  __  \  \   \  /   / |   ____||   _  \     
|  |  __     /  ^  \    |  \  /  | |  |__      |  |  |  |  \   \/   /  |  |__   |  |_)  |    
|  | |_ |   /  /_\  \   |  |\/|  | |   __|     |  |  |  |   \      /   |   __|  |      /     
|  |__| |  /  _____  \  |  |  |  | |  |____    |  `--'  |    \    /    |  |____ |  |\  \----.
 \______| /__/     \__\ |__|  |__| |_______|    \______/      \__/     |_______|| _| `._____|
                                                                                             
");
    AnsiConsole.MarkupLine($"[blue]Score: {correct}/{total}[/]");
  }
  public static string PrintInitialsPrompt()
  {
    string response = AnsiConsole.Prompt(
      new TextPrompt<string>("[green]Enter your initials (Up to 3 letters)[/]")
    .Validate(initials =>
    {
      return initials.Length > 3 || string.IsNullOrEmpty(initials)
      ? ValidationResult.Error("[red]Initials must be 3 letters.")
      : ValidationResult.Success();
    }
    ));
    return response;
  }

  public static void PrintLeaderboard()
  {
    Console.Clear();
    List<LeaderboardEntry> leaderboard = Leaderboard.GetByHighScore();
    if (leaderboard != null && leaderboard.Count != 0)
    {
      var table = new Table();
      table.Title(@"
 __       _______     ___       _______   _______ .______      .______     ______        ___      .______       _______  
|  |     |   ____|   /   \     |       \ |   ____||   _  \     |   _  \   /  __  \      /   \     |   _  \     |       \ 
|  |     |  |__     /  ^  \    |  .--.  ||  |__   |  |_)  |    |  |_)  | |  |  |  |    /  ^  \    |  |_)  |    |  .--.  |
|  |     |   __|   /  /_\  \   |  |  |  ||   __|  |      /     |   _  <  |  |  |  |   /  /_\  \   |      /     |  |  |  |
|  `----.|  |____ /  _____  \  |  '--'  ||  |____ |  |\  \----.|  |_)  | |  `--'  |  /  _____  \  |  |\  \----.|  '--'  |
|_______||_______/__/     \__\ |_______/ |_______|| _| `._____||______/   \______/  /__/     \__\ | _| `._____||_______/ 
                                                                                                                         
").Centered().Expand();
      table.Border(TableBorder.Rounded);
      table.Centered();
      table.AddColumns("Score", "Player", "Date", "Difficulty", "Time", "Completed").Centered();
      foreach (LeaderboardEntry entry in leaderboard)
      {
        table.AddRow(entry.EntryScore.ToString() + "%", entry.Initials, entry.EntryDate.ToString(), entry.EntryDifficulty, entry.TimeTaken.TotalSeconds.ToString(), entry.Completed.ToString());
      }
      AnsiConsole.Write(table);
    }
    else
    {
      AnsiConsole.WriteLine("No entries to display");
    }
    AnsiConsole.WriteLine("**Press any key to return home**");
    Console.ReadKey(true);
    Console.Clear();
  }
}