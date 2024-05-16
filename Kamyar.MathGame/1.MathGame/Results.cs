public class Results
{
    private static List<Result> results = new List<Result>();

    private class Result
    {
        public string Question { get; set; }
        public int ResultValue { get; set; }
        public string Outcome { get; set; }
        public double ElapsedTime { get; set; }

        public Result(string question, int resultValue, string outcome, double elapsedTime)
        {
            Question = question;
            ResultValue = resultValue;
            Outcome = outcome;
            ElapsedTime = elapsedTime;
        }
    }
    public static void ShowResults()
    {
        foreach (var result in results)
        {
            Console.WriteLine($"Question: {result.Question}\t {result.ResultValue}\t Outcome: {result.Outcome} \t Seconds:{result.ElapsedTime}");
        }
    }

    public static void SaveResult(string question, int resultValue, string outcome, double elapsedTime)
    {
        Result result = new Result(question, resultValue, outcome, elapsedTime);
        results.Add(result);
    }
}