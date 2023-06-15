using System.Diagnostics;

namespace Math_Game__JMS_;

internal class GameLogic
{
    static int score;
    static int pointsEarned;
    static DifficultyStage stage;
    static int difficultyValue = 10;
    static int numberOfGames;

    private static Stopwatch stopwatch;

    static internal string GetName()
    {
        Console.Write("Write your name:");
        var name = Console.ReadLine();

        while (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Name can't be empty!");
            name = Console.ReadLine();
        }
        return name;
    }

    static internal void WelcomeMessage(DateTime date, string? name)
    {
        Console.Clear();
        Console.WriteLine($"Hello, {name}. Today is {date}. Welcome to JMS's Math game!");
        Console.WriteLine("Press any key to continue to menu");
        Console.ReadLine();
    }

    static internal void ShowMenu(List<string> games)
    {
        var gameOn = true;
        do
        {
            Console.Clear();
            Console.Write(@$"Let's play a game. Choose an option from below:
                H - Score history
                A - Addition
                S - Subtraction
                M - Multlipication
                D - Division
                R - Random
                Q - Quit
                 ");
            var MenuOptions = Console.ReadLine();

            switch (MenuOptions.Trim().ToLower())
            {
                case "h":
                    PrintScoreboard(games);
                    Console.ReadLine();
                    break;
                case "a":
                    score = 0;
                    difficultyValue = DifficultyChooser(out stage, out pointsEarned, 10);
                    numberOfGames = NumberOfPlays();
                    Addition(games);
                    EndOfGame();
                    break;
                case "s":
                    score = 0;
                    difficultyValue = DifficultyChooser(out stage, out pointsEarned, 10);
                    numberOfGames = NumberOfPlays();
                    Subtraction(games);
                    EndOfGame();
                    break;
                case "m":
                    score = 0;
                    difficultyValue = DifficultyChooser(out stage, out pointsEarned, 10);
                    numberOfGames = NumberOfPlays();
                    Multiplication(games);
                    EndOfGame();
                    break;
                case "d":
                    score = 0;
                    difficultyValue = DifficultyChooser(out stage, out pointsEarned, 100);
                    numberOfGames = NumberOfPlays();
                    Division(games);
                    EndOfGame();
                    break;
                case "r":
                    score = 0;
                    difficultyValue = DifficultyChooser(out stage, out pointsEarned, 10);
                    numberOfGames = NumberOfPlays();
                    RandomG(games);
                    EndOfGame();
                    break;
                case "q":
                    Console.WriteLine("Goodbye!");
                    gameOn = false;
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Type a valid input! Press any key to reset!");
                    Console.ReadLine();
                    break;
            }
        } while (gameOn);
    }

    static internal void Addition(List<string> games)
    {
        var random = new Random();

        stopwatch = Stopwatch.StartNew();
        for (int i = 0; i < numberOfGames; i++)
        {
            Console.Clear();
            var firstNumber = random.Next(1, difficultyValue);
            var secondNumber = random.Next(1, difficultyValue);

            Console.WriteLine($"{firstNumber} + {secondNumber}");
            Console.Write("Write a number:");
            var userInput = Console.ReadLine();
            userInput = Validation(userInput);

            if (firstNumber + secondNumber == int.Parse(userInput))
            {
                Console.WriteLine("Correct! Press any key to continue");
                Console.ReadLine();
                score = score + pointsEarned;
            }
            else
            {
                Console.WriteLine("Incorrect! Press any key to continue");
                Console.ReadLine();
            }
        }
        games.Add($"{DateTime.Now} - {stage} - {GameType.Addition} - {score}pts - Nº of Games: {numberOfGames} - Timer: {stopwatch.Elapsed}");
    }
    
    static internal void Subtraction(List<string> games)
    {
        var random = new Random();

        stopwatch = Stopwatch.StartNew();
        for (int i = 0; i < numberOfGames; i++)
        {
            Console.Clear();
            var firstNumber = random.Next(1, difficultyValue);
            var secondNumber = random.Next(1, difficultyValue);

            Console.WriteLine($"{firstNumber} - {secondNumber}");
            Console.Write("Write a number:");
            var userInput = Console.ReadLine();
            userInput = Validation(userInput);

            if (firstNumber - secondNumber == int.Parse(userInput))
            {
                Console.WriteLine("Correct! Press any key to continue");
                Console.ReadLine();
                score = score + pointsEarned;
            }
            else
            {
                Console.WriteLine("Incorrect! Press any key to continue");
                Console.ReadLine();
            }
        }
        games.Add($"{DateTime.Now} - {stage} - {GameType.Subtraction} - {score}pts -  Nº of Games: {numberOfGames} - Timer: {stopwatch.Elapsed}");
    }

    static internal void Multiplication(List<string> games)
    {
        var random = new Random();

        stopwatch = Stopwatch.StartNew();
        for (int i = 0; i < numberOfGames; i++)
        {
            Console.Clear();
            var firstNumber = random.Next(1, difficultyValue);
            var secondNumber = random.Next(1, difficultyValue);

            Console.WriteLine($"{firstNumber} x {secondNumber}");
            Console.Write("Write a number:");
            var userInput = Console.ReadLine();
            userInput = Validation(userInput);

            if (firstNumber * secondNumber == int.Parse(userInput))
            {
                Console.WriteLine("Correct! Press any key to continue");
                Console.ReadLine();
                score = score + pointsEarned;
            }
            else
            {
                Console.WriteLine("Incorrect! Press any key to continue");
                Console.ReadLine();
            }
        }
        games.Add($"{DateTime.Now} - {stage} - {GameType.Multiplication} - {score}pts -  Nº of Games: {numberOfGames} - Timer: {stopwatch.Elapsed}");
    }

    static internal void Division(List<string> games)
    {
        var random = new Random();

        stopwatch = Stopwatch.StartNew();
        for (int i = 0; i < numberOfGames; i++)
        {
            Console.Clear();
            int firstNumber = random.Next(1, difficultyValue);
            int secondNumber = random.Next(1, difficultyValue);

            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(1, difficultyValue);
                secondNumber = random.Next(1, difficultyValue);
            }

            Console.WriteLine($"{firstNumber} / {secondNumber}");
            Console.Write("Write a number:");
            var userInput = Console.ReadLine();
            userInput = Validation(userInput);

            if (firstNumber / secondNumber == int.Parse(userInput))
            {
                Console.WriteLine("Correct! Press any key to continue");
                Console.ReadLine();
                score = score + pointsEarned;
            }
            else
            {
                Console.WriteLine("Incorrect! Press any key to continue");
            }
        }
        games.Add($"{DateTime.Now} - {stage} - {GameType.Division} - {score}pts -  Nº of Games: {numberOfGames} - Timer: {stopwatch.Elapsed}");
    }

    static internal void RandomG(List<string> games)
    {
        var random = new Random();
        int numberOfGamesSpecial = numberOfGames;
        stopwatch = Stopwatch.StartNew();
        for (int i = 0; i < numberOfGamesSpecial; i++)
        {
            numberOfGames = 1;
            Console.Clear();
            var randomModeSelector = random.Next(1,5);
            switch(randomModeSelector)
            {
                case 1:
                    Addition(games);
                    break;
                case 2:
                    Subtraction(games);
                    break;
                case 3:
                    Multiplication(games);
                    break;
                case 4:
                    difficultyValue = 100;
                    Division(games);
                    break;
            }
        }

        games.Add($"{DateTime.Now} - {stage} - {GameType.Random} - {score}pts - Nº of Games: {numberOfGames} - Timer: {stopwatch.Elapsed}");
    }

    static string? Validation(string userInput)
    {
        while (string.IsNullOrEmpty(userInput) || !int.TryParse(userInput, out _))
        {
            Console.WriteLine("The input was invalid. Type an integer!");
            userInput = Console.ReadLine();
        }
        return userInput;
    }

    static internal void PrintScoreboard(List<string> games)
    {
        Console.Clear();
        Console.WriteLine("Scoreboard:");
        Console.WriteLine("--------------------------------------");
        foreach (var game in games)
        {
            Console.WriteLine(game);
        }
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("Press any key to return to menu");
    }

    static int DifficultyChooser(out DifficultyStage stage, out int pointsEarned, int difficultyValue) 
    {
        Console.Clear();
        Console.Write(@$"Choose a difficulty:
                E - Easy
                I - Intermediate
                H - Hard
                 ");
        var difficulty = Console.ReadLine();

        switch (difficulty.Trim().ToLower())
        {
            case "e":
                stage = DifficultyStage.Easy;
                difficultyValue = 1 * difficultyValue;
                pointsEarned = 1;
                break;
            case "i":
                stage = DifficultyStage.Intermediate;
                difficultyValue = 5 * difficultyValue;
                pointsEarned = 2;
                break;
            case "h":
                stage = DifficultyStage.Hard;
                difficultyValue = 10 * difficultyValue;
                pointsEarned = 3;
                break;
            default:
                Console.WriteLine("Type a valid input! Press any key to reset!");
                Console.ReadLine();
                stage = DifficultyStage.Easy;
                pointsEarned = 0;
                break;
        }
        return difficultyValue;
    }

    static void EndOfGame()
    {
        stopwatch.Stop();
        Console.WriteLine($"End of Game. Your score is {score}");
        Console.WriteLine($"Total time taken: {stopwatch.Elapsed}");
        Console.ReadLine();
    }

    static int NumberOfPlays()
    {
        Console.Write("Write a number to pick how many games you want to play:");
        string numberOfGames = Console.ReadLine();
        while (string.IsNullOrEmpty(numberOfGames) || !int.TryParse(numberOfGames, out _) || int.Parse(numberOfGames) <= 0)
        {
            Console.WriteLine("The input was invalid. Type an integer!");
            numberOfGames = Console.ReadLine();
        }
        return int.Parse(numberOfGames);
    }

    enum GameType
    {
        Addition,
        Subtraction,
        Multiplication,
        Random,
        Division
    }

    enum DifficultyStage
    {
        Easy,
        Intermediate,
        Hard,
        //EasyTimed,
        //MediumTimed,
        //HardTimed
    }
} 
