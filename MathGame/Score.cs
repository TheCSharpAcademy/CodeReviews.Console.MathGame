namespace MathGame
{
    public class Score
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public int CorrectResult { get; set; }
        public int UserResult { get; set; }
        public string Operation { get; set; }
        public char Operator { get; set; }
        public string? Win { get; set; }
        public string Time { get; set; }

        public static List<Score> scores = new List<Score>();

        public static void AddScores(int number1, int number2, string operation, string win, int correctResult, char operators, string time, int userResult)
        {
            scores.Add(new Score
            {
                Number1 = number1,
                Number2 = number2,
                Operation = operation,
                CorrectResult = correctResult,
                Win = win,
                Operator = operators,
                Time = time,
                UserResult = userResult
            });
        }

        public static void ShowScores()
        {
            Console.Clear();

            if (scores.Count == 0)
            {
                Console.WriteLine("There are currently no scores.");
            }
            else
            {
                for (int i = 0; i < scores.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. Game type: {scores[i].Operation}\n" +
                    $"{scores[i].Number1} {scores[i].Operator} {scores[i].Number2} = {scores[i].CorrectResult}\n" +
                    $"Your answer: {scores[i].UserResult}\n" +
                    $"Result: {scores[i].Win}\n" +
                    $"Time taken: {scores[i].Time} seconds\n");
                }
            }

            Console.WriteLine("Press any button to return to the menu.");
            Console.ReadKey();
            Menu.MenuOptions();
        }

    }
}
