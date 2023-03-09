namespace MathGame.chad1082;

internal class Helpers
{
    private static List<string> gameList = new();
    internal static void ShowScores()
    {
        Console.Clear();
        Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
        foreach (var game in gameList)
        {
            Console.WriteLine(game);
        }
        Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
        Console.WriteLine("Press Enter to return to main menu");
        Console.ReadLine();
    }


    internal static void AddGameScore(int score, string gameName)
    {
        gameList.Add($"{DateTime.Now} - {gameName}: {score} points.");
    }

    internal static int[] GetDivisionNumbers()
    {
        var random = new Random();

        int firstNumber = random.Next(1, 100); ;
        int secondNumber = random.Next(1, 100); ;

        while (firstNumber % secondNumber != 0)
        {
            firstNumber = random.Next(1, 100);
            secondNumber = random.Next(1, 100);
        }

        var result = new int[2];

        result[0] = firstNumber;
        result[1] = secondNumber;

        return result;
    }

}

enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}
