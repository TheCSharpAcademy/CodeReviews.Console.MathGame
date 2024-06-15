class GameRound
{

    public static GameRoundLog Play(Func<ProblemLog>[] playGameDelegates)
    {

        List<ProblemLog> probemLogs = new();
        Random random = new Random();

        DateTime startTime = DateTime.Now;

        for (int i = 0; i < GameConfig.numQuestionsPerGame; i++)
        {
            int randomIndex = random.Next(0, playGameDelegates.Length);
            probemLogs.Add(playGameDelegates[randomIndex]());
        }

        TimeSpan elapsedTime = DateTime.Now - startTime;


        GameRoundLog roundLog = new(probemLogs, elapsedTime.TotalSeconds, GameConfig.difficulty);

        Console.WriteLine($"\nScore: {roundLog.score}, Time taken: {roundLog.timeTaken} seconds");

        return roundLog;
    }


    private static ProblemLog ReadUserResponse(int num1, int num2, string op, int expectedResponse)
    {
        Console.Write($"{num1} {op} {num2} = ");

        int userResponse = Util.ReadNumericalInput();

        return new ProblemLog(op, [num1, num2], userResponse, userResponse == expectedResponse ? (int)GameConfig.difficulty : 0, GameConfig.difficulty);
    }



    public static ProblemLog AdditionGame()
    {
        int num1 = Util.GenerateRandom();
        int num2 = Util.GenerateRandom();

        return ReadUserResponse(num1, num2, "+", num1 + num2);
    }


    public static ProblemLog SubtractionGame()
    {
        int num1 = Util.GenerateRandom();
        int num2 = Util.GenerateRandom();
        ProblemLog log = ReadUserResponse(num1, num2, "-", num1 - num2);

        return log;
    }


    public static ProblemLog MultiplicationGame()
    {
        int num1 = Util.GenerateRandom();
        int num2 = Util.GenerateRandom();
        ProblemLog log = ReadUserResponse(num1, num2, "+", num1 + num2);

        return log;
    }

    public static ProblemLog DivisionGame()
    {
        int num1 = Util.GenerateRandom();
        int num2 = Util.GenerateRandom();
        ProblemLog log = ReadUserResponse(num1 * num2, num2, "/", num1);

        return log;
    }

}