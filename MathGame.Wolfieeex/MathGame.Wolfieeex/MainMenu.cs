namespace MathGame.Wolfieeex;

internal enum GameModes
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
    Random
};

internal enum GameDifficulty
{
    Easy,
    Moderate,
    Hard,
};

internal enum CurrentScreen
{
    Main,
    Difficulty,
    Question,
    PreviousGames,
    InGame,
    Exit
};
internal class MainMenu
{
    // Initiate variables:
    private CurrentScreen currentScreen = CurrentScreen.Main;
    private GameDifficulty gameDifficulty = GameDifficulty.Easy;
    private GameModes gameMode = GameModes.Addition;
    private int questionsCount;

    // Main loop that will run the screen that is currently queued:
    internal void MainMenuFunctionality(string? name, DateTime date)
    {
        bool mainLoop = true;
        while (mainLoop)
        {
            switch (currentScreen)
            {
                case CurrentScreen.Main:
                    EntryMenu(name, date);
                    break;
                case CurrentScreen.Difficulty:
                    DifficultySelection();
                    break;
                case CurrentScreen.Question:
                    QuestionSelection();
                    break;
                case CurrentScreen.PreviousGames:
                    Helpers.DisplayPreviousGames();
                    currentScreen = CurrentScreen.Main;
                    break;
                case CurrentScreen.InGame:
                    GameEngine gameEngine = new GameEngine(name, gameMode, gameDifficulty, questionsCount);
                    gameEngine.RunGame();
                    currentScreen = CurrentScreen.Main;
                    break;
                case CurrentScreen.Exit:
                    mainLoop = false;
                    break;
            }
            Console.Clear();
        }
    }

    // Screens' functionalities:
    private void EntryMenu(string? name, DateTime date)
    {
        // Main menu functionality- show options of game modes available:
        Console.WriteLine($@"Hello {name}! Today is {date}. What mode are you going to play? Choose one of the options listed below:

A - Addition
S - Subtraction
M - Multiplication
D - Division
R - Ranodom Mode
P - Display Previous Games
E - Exit Game");
        Console.Write($"\r{new string('-', Console.BufferWidth)}");
        Console.Write($"\nYour option: ");

        // Read input and decide whether it's valid. If not, retry. If yes, select correct option to proceed to:
        string? userInput = null;
        bool menuSelectionLoop = true;

        // Loop that will be rechecked every time user's input is incorrect:
        while (menuSelectionLoop)
        {
            string[] correctOptions = { "a", "s", "m", "d", "r", "p", "e" };
            Helpers.ReadInput(ref userInput, "You must select one of the options listed above to play the game or exit this application. What would you like to do?: ", correctOptions);

            // If option selected, check if it corresponds to any of the listed above and then run it:
            try
            {
                // Default value of the next screen:
                currentScreen = CurrentScreen.Difficulty;

                switch (userInput.ToLower())
                {
                    case "a":
                        gameMode = GameModes.Addition;
                        break;
                    case "s":
                        gameMode = GameModes.Subtraction;
                        break;
                    case "m":
                        gameMode = GameModes.Multiplication;
                        break;
                    case "d":
                        gameMode = GameModes.Division;
                        break;
                    case "r":
                        gameMode = GameModes.Random;
                        break;
                    case "p":
                        currentScreen = CurrentScreen.PreviousGames;
                        break;
                    case "e":
                        // On game exit:
                        currentScreen = CurrentScreen.Exit;
                        break;
                    default:
                        throw new InvalidOperationException($"\r\"{userInput}\" is not a valid input and failed to be checked correctly in the Helpers.ReadInput method. Code needs to be reviewed: list all correct options in the \"Correct options\" array so they match switch statement options to fix. Application will exit now.");
                }

                // If user chose a correct option, exit main menu loop (queue next screen):
                if (currentScreen != CurrentScreen.Main)
                {
                    menuSelectionLoop = false;
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("\n" + ex.Message);
                Environment.Exit(1);
            }
        }
    }
    private void DifficultySelection()
    {
        // Print difficulty options:
        Console.WriteLine($"You chose to play {gameMode.ToString().ToLower()} game. Please select the difficulty level: ");
        Console.WriteLine($@"
E - Easy
M - Moderate
H - Hard
R - Return to main menu");
        Console.WriteLine($"{new string('-', Console.BufferWidth)}");
        Console.Write("Your selection: ");

        // Main method loop- check continously until valid input inserted by the user:
        bool difficultySelectionLoop = true;
        while (difficultySelectionLoop)
        {
            string? userInput = null;
            string[] options = { "e", "m", "h", "r" };
            Helpers.ReadInput(ref userInput, "Please choose a correct option from those listed above: ", options);

            // If valid, save player's choice of difficulty level:
            try
            {
                currentScreen = CurrentScreen.Question;
                switch (userInput)
                {
                    case "e":
                        gameDifficulty = GameDifficulty.Easy;
                        break;
                    case "m":
                        gameDifficulty = GameDifficulty.Moderate;
                        break;
                    case "h":
                        gameDifficulty = GameDifficulty.Hard;
                        break;
                    case "r":
                        currentScreen = CurrentScreen.Main;
                        return;
                    default:
                        throw new InvalidOperationException($"\r\"{userInput}\" is not a valid input and failed to be checked correctly in the Helpers.ReadInput method. Code needs to be reviewed: list all correct options in the \"options\" array so they match switch statement options to fix. Application will exit now.");
                }

                // Queue change of screen and exit this menu's loop if any valid option selected:
                if (currentScreen != CurrentScreen.Difficulty)
                {
                    difficultySelectionLoop = false;
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("\n" + ex.Message);
                Environment.Exit(1);
            }
        }
    }
    private void QuestionSelection()
    {
        // Initiate variables:
        string? userInput = null;
        string[] options = { "e" };
        int[] numberRange = { 3, 20 };

        // Print difficulty options and exit prompt on the bootm of the console:
        Console.WriteLine($"You chose to play {gameMode.ToString().ToLower()} game on {gameDifficulty.ToString().ToLower()} mode. Please select a number of questions for your game from {numberRange[0]} to {numberRange[1]}: ");
        Console.WriteLine($"{new string('-', Console.BufferWidth)}");
        Console.Write("Your selection: ");
        Helpers.PrintExitPrompt();

        // Default next screen:
        currentScreen = CurrentScreen.InGame;

        // Main method loop- check continously until valid input inserted by the user:
        Helpers.ReadInput(ref userInput, $"Please chose a number of questions for your next game (it must be in range of {numberRange[0]} and {numberRange[1]}): ", options, numberRange);
        
        // Queue next screen:
        bool isNumber = int.TryParse(userInput, out questionsCount);
        if (!isNumber && userInput.ToLower() == "e")
        {
            currentScreen = CurrentScreen.Difficulty;
        }
        else if (isNumber)
        {
            currentScreen = CurrentScreen.InGame;
        }
    }
}
