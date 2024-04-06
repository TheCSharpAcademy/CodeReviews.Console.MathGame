namespace MathGame.BBualdo;

internal class GameConsole
{
  public static void ShowTitle()
  {
    Console.WriteLine("------ Math Game ------");
  }

  public static void ShowMenu()
  {
    Console.WriteLine("");
    Console.WriteLine(@"Welcome! Select one of the options from below:

        V - View History
        A - Play Addition
        S - Play Subtraction
        M - Play Multiplication
        D - Play Division
        R - Play with Random Operations
        Q - Quit Game
");
  }

  public static void ShowDifficulties()
  {
    Console.WriteLine("");
    Console.WriteLine(@"Select difficulty level:

        E - Easy,
        M - Medium,
        H - Hard
");
  }

  public static void ShowMessage(string message)
  {
    Console.WriteLine("");
    Console.WriteLine(message);
    Console.WriteLine("");
  }

  public static void ShowError(string message)
  {
    Console.WriteLine("");
    Console.WriteLine($"Error: {message}");
    Console.WriteLine("");
  }
}