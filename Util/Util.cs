class Util
{
    /*
        Generate a random number within a range, based on difficulty.
    */
    public static int GenerateRandom()
    {
        Random random = new Random();

        int lowerBound = (int)Math.Pow(10, (double)GameConfig.difficulty - 1);
        int upperBound = (int)Math.Pow(10, (double)GameConfig.difficulty);

        return random.Next(lowerBound, upperBound);
    }

    private static void PrintRoundLog(GameRoundLog log, int gameNumber)
    {
        Console.WriteLine($"Game {gameNumber}");
        Console.WriteLine($"\tScore:\t{log.Score}");
        Console.WriteLine($"\tTime taken\t{log.timeTaken}  seconds");
        Console.WriteLine($"\tDifficulty: {log.difficulty}");


        string[] cols = ["Correct", "Problem", "Response"];

        string header = string.Join("\t\t", cols);

        Console.WriteLine("\t\t" + header);

        foreach (ProblemLog problem in log.problemLogs)
        {
            string correct = problem.score > 0 ? "Y" : "N";


            Console.WriteLine(
                "\t\t" +
                string.Join("\t\t", [correct, string.Join((char)problem.operation, problem.nums), problem.response])
            );
        }
    }

    public static void PrintLogs(List<GameRoundLog> logs)
    {
        Console.WriteLine("\n\t\tGame History");

        for (int i = 0; i < logs.Count; i++)
        {
            PrintRoundLog(logs[i], i + 1);
        }

    }

    public static int ReadNumericalInput()
    {
        while (true)
        {
            string? input = Console.ReadLine();

            bool isValidInteger = int.TryParse(input, out int converted);

            if (isValidInteger)
            {
                return converted;
            }

            Console.WriteLine("\n\tPlease enter a valid number");
        }
    }

}