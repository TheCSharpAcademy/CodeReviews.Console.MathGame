

namespace CSharp_Study_ConsoleMathGame;

internal class GameMenu
{
    bool gameRunning = true;
    internal void DisplayMenu(string playerName)
    {
        string difficulty = "Easy";
        int numberOfQuestions = 5;

        Console.WriteLine("\n*******************************Math Game Setup*******************************");
        Console.WriteLine($"Difficulty:          {difficulty}");
        Console.WriteLine($"Number of Questions: {numberOfQuestions}");
        Console.WriteLine("To change settings type Yes. To go back to Main Menu type No.");
        string userInput = Console.ReadLine();
        userInput = Helper.TextInputValidation(userInput);
        if (userInput == "yes")
        {
            difficulty = DifficultySelection();
            numberOfQuestions = NumberOfQuestions();
        }


        while (gameRunning == true)
        {
            Console.WriteLine("\n*******************************Game Selection*******************************");
            Console.WriteLine(@"1. Addition Game
2. Subtraction Game
3. Multiplication Game
4. Division Game
5. Random Game
6. View Scores");
            MenuSelection(playerName, difficulty, numberOfQuestions);

        }
    }

    private int NumberOfQuestions()
    {
        Console.Clear();
        Console.WriteLine("\n*******************************Number of Questions*******************************");
        Console.WriteLine("Would you like to change the number of questions? Default is 5.");
        Console.WriteLine("type Yes to change default number of questions or No to continue.");
        string question = Console.ReadLine();
        question = Helper.TextInputValidation(question);
        int numberOfQuestions = 5;


        if (question == "yes")
        {
            Console.WriteLine("How manay questions would you like to be the new default?");
            string userInput = Console.ReadLine();
            userInput = Helper.NumberInputValidation(userInput);
            Console.WriteLine($"The number of questions default has been changed to {userInput}");
            numberOfQuestions = int.Parse(userInput);

        }
        return numberOfQuestions;
    }

    static string DifficultySelection()
    {
        Console.Clear();
        Console.WriteLine("\n*******************************MATH GAME*******************************");
        Console.WriteLine("*******************************Difficulty*******************************");
        Console.WriteLine(@"Type a number to choose a difficulty
1. Easy
2. Normal
3. Hard
4. Impossible");
        string difficulty = Console.ReadLine();
        difficulty = Helper.NumberInputValidation(difficulty);
        string setDifficulty = "Easy";

        switch (difficulty)
        {
            case "1":
                Console.WriteLine("Easy Difficulty");
                setDifficulty = "Easy";
                break;
            case "2":
                Console.WriteLine("Normal Difficulty");
                setDifficulty = "Normal";
                break;
            case "3":
                Console.WriteLine("Hard Difficulty");
                setDifficulty = "Hard";
                break;
            case "4":
                Console.WriteLine("You will regret this");
                setDifficulty = "Impossible";
                break;
        }
        return setDifficulty;
    }

    void MenuSelection(string playerName, string difficulty, int numberOfQuestions)
    {
        Engine engine = new();
        string gameSelection = Console.ReadLine();

        if (gameSelection != null)
        {
            switch (gameSelection)
            {
                case "1":
                    Console.WriteLine("Launching Addition Game");
                    engine.AdditionGame(playerName, difficulty, numberOfQuestions);
                    break;
                case "2":
                    Console.WriteLine("Launching Subtraction Game");
                    engine.SubtractionGame(playerName, difficulty, numberOfQuestions);
                    break;
                case "3":
                    Console.WriteLine("Launching Multiplication Game");
                    engine.MultiplicationGame(playerName, difficulty, numberOfQuestions);
                    break;
                case "4":
                    Console.WriteLine("Launching Division Game");
                    engine.DivisionGame(playerName, difficulty, numberOfQuestions);
                    break;
                case "5":
                    Console.WriteLine("Launching Random Game");
                    engine.RandomGameSelection(playerName, difficulty, numberOfQuestions);
                    break;
                case "6":
                    Helper.ShowHistory();
                    break;
                case "exit":
                    gameRunning = false;
                    break;
                default:
                    Console.WriteLine("Your input should be a number value only. Please try again.");
                    break;

            }

        }
    }
}
