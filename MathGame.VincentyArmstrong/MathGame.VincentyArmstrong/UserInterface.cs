namespace MathGame.VincentyArmstrong;

public class UserInterface
{
    private int questions;
    private bool hardMode;
    private List<Game> games = new();
    private bool quit;

    public void Run()
    {
        while (!quit)
        {
            MainMenuDisplay();
            MainMenuInput();
        }
    }

    private static void MainMenuDisplay()
    {
        Console.Clear();
        Console.WriteLine(
        @"
            ---------------------------------------------
            What game would you like to play today? Choose from the options below:
            A - Addition
            S - Subtraction
            M - Multiplication
            D - Division
            H - View History
            Q - Quit the program
            ---------------------------------------------");
    }
   
    private void MainMenuInput()
    {
        switch (Console.ReadLine().Trim().ToLower())
        {
            case "a":
                Setup(GameType.Addition);
                break;
            case "s":
                Setup(GameType.Subtraction);
                break;
            case "m":
                Setup(GameType.Multiplication);
                break;
            case "d":
                Setup(GameType.Division);
                break;
            case "h":
                ViewHistory();
                break;
            case "q":
                Exit();
                break;
            default:
                break;
        }
    }

    private void Setup(GameType gameType)
    {
        GetNumberOfQuestionsFromUser();
        GetDifficultyFromUser();
        Game game = new(gameType, questions, hardMode);
        games.Add(game);
    }

    private void GetNumberOfQuestionsFromUser()
    {
        Console.Clear();
        Console.WriteLine("How many questions do you wish to be asked?");

        var input = Console.ReadLine();
        while (!int.TryParse(input, out questions) || questions <= 0)
        {
            Console.WriteLine("Please enter a whole number larger than zero");
            input = Console.ReadLine();
        }
    }

    private void GetDifficultyFromUser()
    {
        Console.Clear();
        Console.WriteLine("Do you want to play on easy or hard mode?");
        Console.WriteLine("E - Easy");
        Console.WriteLine("H - Hard");

        while (true)
        {
            string difficulty = Console.ReadLine().ToUpper();
            if (difficulty == "H")
            {
                hardMode = true;
                break;
            }
            if (difficulty == "E") break;
            Console.WriteLine("Please select a difficulty");
        }
    }

    private void ViewHistory()
    {
        Console.Clear();
        if (games.Count == 0)
        {
            Console.WriteLine("No games have been played");
            return;
        }
        foreach (Game game in games)
        {
            string difficulty;
            if (game.HardMode) difficulty = "Hard";
            else difficulty = "Easy";
            Console.WriteLine($"Game Type: {game.Type} - Questions: {game.Questions} - Score: {game.Score} - Difficulty: {difficulty}");
        }
        Console.WriteLine("Press any key to return to Main Menu");
        Console.ReadLine();
    }

    public void Exit()
    {
        Console.Clear();
        Console.WriteLine("Program will now exit. Thanks for playing");
        quit = true;
    }
}

