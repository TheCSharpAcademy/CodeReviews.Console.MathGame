namespace MathGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Qestion[] qestions =
            [
                new Qestion("2 + 2", 4),
                new Qestion("3 * 3", 9),
                new Qestion("10 / 2", 5),
                new Qestion("5 - 3", 2),
            ];

            List<string> history = [];

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1 - Play");
                Console.WriteLine("2 - View History");
                Console.WriteLine("3 - Exit");
                Console.Write("Choose an option: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        PlayGame(qestions, history);
                        break;

                    case "2":
                        ShowHistory(history);
                        break;

                    case "3":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

                Console.WriteLine();
            }

            Console.WriteLine("Thanks for playing!");
        }

        static void PlayGame(Qestion[] qestions, List<string> history)
        {
            DisplayQestions(qestions);
            var inputIndex = ChooseQestion(qestions);

            Console.WriteLine($"Answer this question {qestions[inputIndex].Text}: ");
            string? answerInput = Console.ReadLine();

            if (int.TryParse(answerInput, out int answer))
            {
                bool correct = qestions[inputIndex].IsCorrect(answer);
                Console.WriteLine(correct ? "Correct" : "Incorrect");

                history.Add($"{DateTime.Now:G} | {qestions[inputIndex].Text} | Your answer: {answer} | {(correct ? "Correct" : "Incorrect")}");
            }
            else
            {
                Console.WriteLine("Invalid integer.");
                history.Add($"{DateTime.Now:G} | {qestions[inputIndex].Text} | Invalid answer");
            }
        }

        static void ShowHistory(List<string> history)
        {
            Console.WriteLine("History");
            Console.WriteLine("=======");

            if (history.Count == 0)
            {
                Console.WriteLine("No history yet.");
                return;
            }

            foreach (var item in history)
            {
                Console.WriteLine(item);
            }
        }

        static void DisplayQestions(Qestion[] qestions)
        {
            Console.WriteLine("Choose Question To Answer");
            Console.WriteLine("========================");
            for (int i = 0; i < qestions.Length; i++)
            {
                Console.WriteLine($"{i + 1}- What is {qestions[i].Text} ?");
            }
        }

        static int ChooseQestion(Qestion[] qestions)
        {
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int result))
            {
                if (result <= 0 || result > qestions.Length)
                {
                    Console.WriteLine("Error: choose from range.");
                    return ChooseQestion(qestions);
                }

                return result - 1;
            }

            Console.WriteLine("Error: That is not a valid integer.");
            return ChooseQestion(qestions);
        }
    }

    internal record Qestion(string Text, int Answer)
    {
        public bool IsCorrect(int answer) => Answer == answer;
    }
}