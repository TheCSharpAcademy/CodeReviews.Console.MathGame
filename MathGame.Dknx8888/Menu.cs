namespace MathGame.Dknx8888;

public class Menu
{
    private Difficulty _difficulty = Difficulty.Easy;

    // NOTE: This is an expression-bodied property, using => not =
    private string DifficultyDisplay => _difficulty switch
    {
        Difficulty.Easy => "Easy",
        Difficulty.Medium => "Medium",
        Difficulty.Hard => "Hard",
        _ => throw new ArgumentOutOfRangeException()
    };
    
    public void ShowMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to A Simple Math Game!");
            Console.WriteLine($"\nCurrently selected difficulty: {DifficultyDisplay}\n");
            Console.WriteLine("Press choose one of the options below (1-4):");
            Console.WriteLine("1. Start");
            Console.WriteLine("2. View Game History");
            Console.WriteLine("3. Choose Difficulty");
            Console.WriteLine("4. Quit");

            var input = Console.ReadLine()?.Trim();

            switch (input)
            {
                case "1":
                    ShowGameModes();
                    break;
                
                case "2":
                    // ...
                    break;
                
                case "3":
                    DifficultyMenu();
                    break;
                
                case "4":
                    Console.WriteLine("\nGoodbye!");
                    return;
            }
        }
    }

    private void ShowGameModes()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Choose one of the modes below (1-6):");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Random");
            Console.WriteLine("6. Go Back");
        
            var gameModeInput = Console.ReadLine()?.Trim();

            // Go back (exit the while loop)
            if (gameModeInput == "6")
            {
                return;
            }

            GameMode? gameMode = gameModeInput switch
            {
                "1" => GameMode.Addition,
                "2" => GameMode.Subtraction,
                "3" => GameMode.Multiplication,
                "4" => GameMode.Division,
                "5" => GameMode.Random,
                _ => null
            };
            
            // Nothing ever happens.
            if (gameMode is null)
            {
                continue;
            }
            
            // Starts game here (so .Value here is needed because gameMode is nullable)
            var gameSession = new GameSession(gameMode.Value, _difficulty);
            gameSession.Start();
        }
    }

    private void DifficultyMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Currently Selected Difficulty: {DifficultyDisplay}\n");
            Console.WriteLine("Please select one of the difficulties below (1-3): ");
            Console.WriteLine("1. Easy (1 digit operations) - Default");
            Console.WriteLine("2. Medium (1 digit number and 2 digit number operations)");
            Console.WriteLine("3: Hard (2 digit number operations)");
            Console.WriteLine("4: Go Back");
            
            var difficultyInput = Console.ReadLine()?.Trim();

            if (difficultyInput == "4")
            {
                break;
            }
            
            _difficulty = difficultyInput switch
            {
                "1" => Difficulty.Easy,
                "2" => Difficulty.Medium,
                "3" => Difficulty.Hard,
                _ => _difficulty // Invalid keeps the selected one
            };
        }
    }
}