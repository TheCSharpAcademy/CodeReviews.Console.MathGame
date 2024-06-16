class GameRound
{

    public static GameRoundLog Play(Operation[] operations)
    {
        List<ProblemLog> probemLogs = new();
        Random random = new Random();
        DateTime startTime = DateTime.Now;

        for (int i = 0; i < GameConfig.numQuestionsPerGame; i++)
        {
            int randomOperation = random.Next(0, operations.Length);
            ProblemLog problemLog = PlayProblem(operations[randomOperation]);

            probemLogs.Add(problemLog);
        }

        TimeSpan elapsedTime = DateTime.Now - startTime;
        GameRoundLog roundLog = new(probemLogs, elapsedTime.TotalSeconds, GameConfig.difficulty);

        Console.WriteLine($"\nScore: {roundLog.Score}, Time taken: {roundLog.timeTaken} seconds");

        return roundLog;
    }


    private static ProblemLog ReadUserResponse(int num1, int num2, Operation op, int expectedResponse)
    {
        Console.Write($"{num1} {(char)op} {num2} = ");

        int userResponse = Util.ReadNumericalInput();

        return new ProblemLog(op, [num1, num2], userResponse, userResponse == expectedResponse ? (int)GameConfig.difficulty : 0);
    }


    public static ProblemLog PlayProblem(Operation operation)
    {
        int num1 = Util.GenerateRandom();
        int num2 = Util.GenerateRandom();

        switch (operation)
        {
            case Operation.Add:
                return ReadUserResponse(num1, num2, operation, num1 + num2);
            case Operation.Subtract:
                return ReadUserResponse(num1, num2, operation, num1 - num2);
            case Operation.Multiply:
                return ReadUserResponse(num1, num2, operation, num1 * num2);
            case Operation.Divide:
                return ReadUserResponse(num1 * num2, num2, operation, num1);
            default:
                throw new FormatException("Incorrect operation type provided");
        }

    }
}