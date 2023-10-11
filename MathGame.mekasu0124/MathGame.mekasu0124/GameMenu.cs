namespace MathGame.mekasu0124;

public class GameMenu
{
    public static void ShowMenu(string username, DateTime date)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        
        List<string> menuOptions = new()
        {
            "A) Addition",
            "S) Subtraction",
            "M) Multiplication",
            "D) Division",
            "R) Random Game",
            "P) Previous Games",
            "Q) Quit Game"
        };

        foreach (string line in menuOptions)
        {
            Console.WriteLine(line);
        }
        
        Console.Write("\nWhat Game Would You Like To Play: ");
        
        string game = Console.ReadLine().ToLower();
        game = Helpers.ValidateMenuChoice(game);

        GameEngine gameEngine = new();

        if (game == "Addition")
        {
            string difficulty = GetDifficulty();
            string numOfQues = GetNumberOfQuestions();
            int numOfQuestions = Convert.ToInt32(numOfQues);
            
            Console.Clear();
            Console.WriteLine($"Username: {username}");
            Console.WriteLine($"Todays Date: {date}");
            Console.WriteLine($"Total Questions: {numOfQuestions}");
            Console.WriteLine($"Game Type: {game}");
            Console.WriteLine($"Selected Difficulty: {difficulty}\n");
            Console.WriteLine("\nStarting Game...");
            
            Thread.Sleep(3000);
            Console.Clear();
                    
            gameEngine.StartAddGame(username, date, numOfQuestions, difficulty);
        }
        else if (game == "Subtraction")
        {
            string difficulty = GetDifficulty();
            string numOfQues = GetNumberOfQuestions();
            int numOfQuestions = Convert.ToInt32(numOfQues);
            
            Console.Clear();
            Console.WriteLine($"Username: {username}");
            Console.WriteLine($"Todays Date: {date}");
            Console.WriteLine($"Total Questions: {numOfQuestions}");
            Console.WriteLine($"Selected Difficulty: {difficulty}\n");
            Console.WriteLine("\nStarting Game...");
            
            Thread.Sleep(3000);
            Console.Clear();
                    
            gameEngine.StartSubGame(username, date, numOfQuestions, difficulty);
        }
        else if (game == "Multiplication")
        {
            string difficulty = GetDifficulty();
            string numOfQues = GetNumberOfQuestions();
            int numOfQuestions = Convert.ToInt32(numOfQues);
            
            Console.Clear();
            Console.WriteLine($"Username: {username}");
            Console.WriteLine($"Todays Date: {date}");
            Console.WriteLine($"Total Questions: {numOfQuestions}");
            Console.WriteLine($"Selected Difficulty: {difficulty}\n");
            Console.WriteLine("\nStarting Game...");
            
            Thread.Sleep(3000);
            Console.Clear();

            gameEngine.StartMultGame(username, date, numOfQuestions, difficulty);
        }
        else if (game == "Division")
        {
            string difficulty = GetDifficulty();
            string numOfQues = GetNumberOfQuestions();
            int numOfQuestions = Convert.ToInt32(numOfQues);
            
            Console.Clear();
            Console.WriteLine($"Username: {username}");
            Console.WriteLine($"Todays Date: {date}");
            Console.WriteLine($"Total Questions: {numOfQuestions}");
            Console.WriteLine($"Selected Difficulty: {difficulty}\n");
            Console.WriteLine("\nStarting Game...");
            
            Thread.Sleep(3000);
            Console.Clear();

            gameEngine.StartDivGame(username, date, numOfQuestions, difficulty);
        }
        else if (game == "Previous Games")
        {
            PreviousGames.ShowGames(username, date);
        }
        else if (game == "Quit Game")
        {
            Console.WriteLine("Exiting Game....");
            Environment.Exit(0);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[Error] Couldn't Determine Game Type");
            Console.WriteLine("If This Error Persists, Contact Support.");
            ShowMenu(username, date);
        }
    }

    private static string GetDifficulty()
    {
        Console.Clear();
        
        List<string> difficultyOptions = new()
        {
            "E) Easy",
            "M) Medium",
            "H) Hard"
        };

        foreach (string line in difficultyOptions)
        {
            Console.WriteLine(line);
        }
        
        Console.Write("\nWhat Difficulty Would You Like To Play: ");

        string chosenDifficulty = Console.ReadLine().ToLower();
        chosenDifficulty = Helpers.ValidateDifficultyChoice(chosenDifficulty);

        return chosenDifficulty;
    }

    private static string GetNumberOfQuestions()
    {
        Console.Clear();
        
        Console.Write("Total Number Of Questions To Answer: ");

        string numOfQues = Console.ReadLine();
        numOfQues = Helpers.ValidateNumOfQuestionsInput(numOfQues);

        return numOfQues;
    }
}