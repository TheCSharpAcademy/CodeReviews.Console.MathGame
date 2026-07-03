using System.Runtime.CompilerServices;

namespace MathGame.Dknx8888;

public class GameHistoryJson
{
    public static string FilePath => GetGameResultsFilePath();
    
    // CallerFilePath gets the path of the source file that called this func
    private static string GetGameResultsFilePath([CallerFilePath] string sourceFilePath = "")
    {
        var sourceDirectory = Path.GetDirectoryName(sourceFilePath)
                              ?? throw new InvalidOperationException("Unable to determine the source file directory.");

        return Path.Combine(sourceDirectory, "game-results.json");
    }
}