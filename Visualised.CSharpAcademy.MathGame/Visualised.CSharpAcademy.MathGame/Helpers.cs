using Visualised.CSharpAcademy.MathGame.Models;

namespace Visualised.CSharpAcademy.MathGame;

internal class Helpers
{
    internal static int[] GetDivisibleNumbersBasedOnDifficulty(GameDifficultyLevels gameDifficulty)
    {
        int firstNumber = GetRandomNumberBasedOnDifficulty(gameDifficulty);
        int secondNumber = GetRandomNumberBasedOnDifficulty(gameDifficulty);

        while (firstNumber % secondNumber != 0)
        {
            firstNumber = GetRandomNumberBasedOnDifficulty(gameDifficulty);
            secondNumber = GetRandomNumberBasedOnDifficulty(gameDifficulty);
        }

        int[] result = [firstNumber, secondNumber];
        return result;
    }


    internal static int GetUserIntInput()
    {
        string userInput = Console.ReadLine();
        while (string.IsNullOrEmpty(userInput) || !Int32.TryParse(userInput, out _))
        {
            Console.Write("Invalid input! It can only be an Integer \n"
                + "Try again: ");
            userInput = Console.ReadLine();
        }

        return int.Parse(userInput);
    }

    internal static string GetUserName()
    {
        Console.Write("Please type your name: ");
        string userName = Console.ReadLine();
        while (string.IsNullOrEmpty(userName) || userName.Any(char.IsDigit))
        {
            Console.Write("Name can't be empty or contain numbers! Try again: ");
            userName = Console.ReadLine();
        }

        return userName;
    }

    internal static GameDifficultyLevels GetDifficultyLevel()
    {
        PrintMenuFromEnumType("Select difficulty level", new GameDifficultyLevels());

        string userInput = UppercaseFirst(Console.ReadLine());
        while (!Enum.IsDefined(typeof(GameDifficultyLevels), userInput))
        {
            Console.Write("It's not a valid difficulty level! "
                + "Type the difficulty name. \nTry again: ");
            userInput = UppercaseFirst(Console.ReadLine());
        }

        return Enum.Parse<GameDifficultyLevels>(userInput);
    }

    internal static int GetRandomNumberBasedOnDifficulty(GameDifficultyLevels gameDifficulty)
    {
        var random = new Random();
        switch (gameDifficulty)
        {
            case GameDifficultyLevels.Easy:
                return random.Next(1, 9);
            case GameDifficultyLevels.Medium:
                return random.Next(1, 99);
            case GameDifficultyLevels.Hard:
                return random.Next(1, 999);
            default:
                return random.Next(1, 9);
        }
    }

    internal static int GetNumberOfQuestions()
    {
        Console.Write("How many questions You'd like to answer? \n===> ");
        int numberOfQuestions = GetUserIntInput();

        return numberOfQuestions;
    }

    internal static void PrintCurrentGameResult(int score, TimeSpan elapsedTime)
    {
        Console.WriteLine($"Game over, your score: {score}. \n"
            + "Elapsed Time: {0:m\\:ss} \n"
            + "Press any key to continue.", elapsedTime);

        Console.ReadLine();
    }

    internal static GameType GetRandomGameType()
    {
        var random = new Random();
        Array availableGameTypes = Enum.GetValues(typeof(GameType))
                                       .Cast<GameType>()
                                       .Where(x => x != GameType.Random)
                                       .ToArray(); // We don't want "Random" GameType, it's present only to be stored in Game Results History.

        GameType drawnGameType = (GameType)availableGameTypes.GetValue(random.Next(availableGameTypes.Length));

        return drawnGameType;
    }

    internal static string UppercaseFirst(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return string.Empty;
        }

        return char.ToUpper(input[0]) + input.Substring(1).ToLower();
    }

    internal static void PrintMenuFromEnumType(string question, Enum inputEnum)
    {
        string[] options = Enum.GetNames(inputEnum.GetType());

        Console.WriteLine(question);

        foreach (string option in options)
        {
            Console.WriteLine($"=> {option}");
        }

        Console.Write("\n====> ");
    }

    internal static void PrintMenuFromObjProperties(string question, object inputObj)
    {
        Console.WriteLine(question);

        foreach (var property in inputObj.GetType().GetProperties())
        {
            Console.WriteLine($"=> {property.Name}");
        }

        Console.Write("\n====> ");
    }

    internal static bool IsOrderDirectionValid(string userInput)
    {
        if (string.IsNullOrEmpty(userInput))
            return false;

        if (userInput != "Ascending" && userInput != "Descending")
            return false;

        return true;
    }

    internal static void FailInput()
    {
        Console.WriteLine("Invalid Input!");
        Console.ReadLine();
    }
}