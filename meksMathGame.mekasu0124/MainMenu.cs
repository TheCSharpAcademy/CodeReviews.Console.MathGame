using MeksMathGame;

class MainMenu
{
    public int tries = 3;

    public void InputInvalid(string error)
    {
        if (tries > 0)
        {
            tries--;
            Console.WriteLine("\n" + error + " " + tries + " Tries Left.");
        }
        else
        {
            Console.WriteLine("\nMaximum Number Attempts Reached. Exiting Program.");
            Thread.Sleep(2000);
            Environment.Exit(0);
        }
    }

    public void OperationInvalid(string error)
    {
        if (tries > 0)
        {
            tries--;
            Console.WriteLine("\n" + error + " " + tries + " Tries Left.");
        }
        else
        {
            Console.WriteLine("\nMaximum Number Attempts Reached. Exiting Program.");
            Thread.Sleep(2000);
            Environment.Exit(0);
        }
    }

    public void DifficultySelection()
    {
        Console.ForegroundColor = ConsoleColor.White;

        List<string> gameDiffs = new()
        {
            "easy",
            "medium",
            "hard"
        };

        foreach (string text in gameDiffs)
        {
            Console.WriteLine(text);
        };

        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("\nPlease Select A Difficulty: ");

        string userSelectedDiff = "";

        for (int i = 0; i < 3; i++)
        {
            userSelectedDiff = Console.ReadLine();

            if (gameDiffs.Contains(userSelectedDiff))
            {
                break;
            }
            else
            {
                InputInvalid("Enter Either easy, medium, or hard");
            }
        }

        Console.WriteLine("\nDifficulty: " + userSelectedDiff);
        Thread.Sleep(2000);

        GameSelection(userSelectedDiff);
    }

    public void GameSelection(string difficulty)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\n");

        List<string> gameTypes = new()
        {
            "Addition",
            "Subtraction",
            "Multiplication",
            "Division"
        };

        foreach (string text in gameTypes)
        {
            Console.WriteLine(text);
        };

        Console.Write("\nPlease Select A Game To Play: ");

        string userSelectedGame = "";

        for (int i = 0; i < 3; i++)
        {
            userSelectedGame = Console.ReadLine();

            if (gameTypes.Contains(userSelectedGame, StringComparer.OrdinalIgnoreCase))
            {
                break;
            }
            else
            {
                Console.WriteLine("Enter A Game Choice: addition, subtraction, multiplication" +
                    " Or division.");
            }
        }

        Console.WriteLine("\nDifficulty: " + difficulty + "\nGame: " + userSelectedGame);
        Thread.Sleep(2000);

        GetDesiredQuestions(difficulty, userSelectedGame.ToLower());
    }

    public void GetDesiredQuestions(string difficulty, string userSelectedGame)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("\nPlease Enter The Amount Of Questions You'd Like To Answer (1-100): ");

        int numOfQuestions = 0;

        for (int i = 0; i < 3; i++)
        {
            if (!int.TryParse(Console.ReadLine(), out numOfQuestions))
            {
                Console.WriteLine("Enter An Integer, or Whole Number For Your Choice.");
            }
            else if (numOfQuestions < 1 || numOfQuestions > 100)
            {
                Console.WriteLine("Enter A Number Between 1 and 100");
            }
            else
            {
                break;
            }
        }

        Console.WriteLine("\nDifficulty: " + difficulty + "\nGame: " + userSelectedGame + "\nQuestions: " + numOfQuestions);
        Thread.Sleep(2000);
        LaunchGameScreen(difficulty, userSelectedGame, numOfQuestions);
    }

    public void LaunchGameScreen(string difficulty, string game, int numOfQuest)
    {
        switch (game)
        {
            case "addition":
                Console.WriteLine("\nLaunching Addition Game.");
                Thread.Sleep(2000);
                Console.Clear();

                AdditionGame addGame = new();
                addGame.StartGame(difficulty, numOfQuest);
                break;

            case "subtraction":
                Console.WriteLine("\nLaunching Subtraction Game.");
                Thread.Sleep(2000);
                Console.Clear();
                break;

            case "multiplication":
                Console.WriteLine("\nLaunching Multiplication Game.");
                Thread.Sleep(2000);
                Console.Clear();
                break;

            case "division":
                Console.WriteLine("\nLaunching Division Game.");
                Thread.Sleep(2000);
                Console.Clear();
                break;

            default:
                for (int i = 0; i < 3; i++)
                {
                    OperationInvalid("Operation Failed To Launch Game. Trying Again.");
                }
                break;
        }
    }
}