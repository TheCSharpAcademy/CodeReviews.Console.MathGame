using MathGame;
MathGameSession gameSession = new();
DisplayMenu();
void DisplayMenu()
{
  int userAnswer=0;
  string menuChoice = "";
  while (menuChoice != "6")
  {
    Console.WriteLine("Menu\n====");
    Console.WriteLine("1. Addition");
    Console.WriteLine("2. Subtraction");
    Console.WriteLine("3. Multiplication");
    Console.WriteLine("4. Division");
    Console.WriteLine("5. View History");
    Console.WriteLine("6. Exit");
    menuChoice = Console.ReadLine();
    MenuChoice(menuChoice);
  }
  void MenuChoice(string menuChoice)
  {

    switch (menuChoice)
    {
      case "1":
        // Addition game
        for (int i = 0; i < 5; i++)
        {
          Console.WriteLine(gameSession.AskQuestion("addition"));
          gameSession.CheckAnswer();
        }
        gameSession.GameNumber++;
        gameSession.GameHistory.Add($"Game: {gameSession.GameNumber};Score: {gameSession.Score}");
        gameSession.Score = 0;
        break;

      case "2":
        // Subtraction game
        for (int i = 0; i < 5; i++)
        {
          Console.WriteLine(gameSession.AskQuestion("substraction"));
          gameSession.CheckAnswer();
        }
        gameSession.GameNumber++;
        gameSession.GameHistory.Add($"Game: {gameSession.GameNumber};Score: {gameSession.Score}");
        gameSession.Score = 0;
        break;

      case "3":
        // Multiplication game
        for (int i = 0; i < 5; i++)
        {
          Console.WriteLine(gameSession.AskQuestion("multiplication"));
          gameSession.CheckAnswer();
        }
        gameSession.GameNumber++;
        gameSession.GameHistory.Add($"Game: {gameSession.GameNumber};Score: {gameSession.Score}");
        gameSession.Score = 0;
        break;

      case "4":
        // Division 
        for (int i = 0; i < 5; i++)
        {
          Console.WriteLine(gameSession.AskQuestion("division"));
          gameSession.CheckAnswer();
        }
        gameSession.GameNumber++;
        gameSession.GameHistory.Add($"Game: {gameSession.GameNumber};Score: {gameSession.Score}");
        gameSession.Score = 0;
        break;

      case "5":
        foreach (var list in gameSession.GameHistory)
        {
          Console.WriteLine(list);
        }
        break;

      case "6":
        Console.WriteLine("Goodbye!");
        break;

      default:
        Console.WriteLine("Invalid choice, try again.");
        break;
    }
  }
}

