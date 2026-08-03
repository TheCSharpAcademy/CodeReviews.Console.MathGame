namespace PRagudo.MathGame;

public static class Game
{
    public static async Task Execute(int gameCount, List<GameRecord> history, QuestionGenerator questionGenerator)
    {
        GameRecord gameRecord = new()
        {
            Id = gameCount
        };

        int points = 0;

        for (int i = 0; i < 5; i++)
        {
            Console.Clear();

            Console.WriteLine($"\nProgress: {i + 1}/5");
            Console.WriteLine($"Points: {points}\n");

            ShowOperations();
            int choice = GetChoice("\nEnter choice: ", 1, 5);

            Question question = new();

            if (choice == 5)
            {
                question = questionGenerator.GetQuestion();
            }
            else
            {
                question = questionGenerator.GetQuestion(choice - 1);
            }

            Console.WriteLine($"\nQuestion: {question.Content}");

            int answer;
            while (true)
            {
                Console.Write("Answer: ");

                if (int.TryParse(Console.ReadLine()?.Trim() ?? "", out answer))
                    break;

                Console.WriteLine("Invalid answer! Try again!");
            }

            QuestionRecord questionRecord = new()
            {
                Content = question,
                PlayerAnswer = answer
            };

            Console.WriteLine();
            if (answer == question.Answer)
            {
                points++;
                Console.WriteLine("Correct!");
                questionRecord.Correct = true;
            }
            else
            {
                Console.WriteLine("Wrong!");
                Console.WriteLine($"Answer is {question.Answer:N0}");
                questionRecord.Correct = false;
            }

            gameRecord.QuestionRecords.Add(questionRecord);
            await Task.Delay(1000);
        }

        gameRecord.TotalPoints = points;
        Console.WriteLine($"\nTotal points: {points} / 5");
        history.Add(gameRecord);
    }


    public static string GetStringInput(string message)
    {
        while (true)
        {
            Console.Write(message);
            string? input = Console.ReadLine();

            if (input == null || input.IsWhiteSpace())
            {
                Console.WriteLine("Invalid input! Try again.");
                continue;
            }

            return input.Trim();
        }
    }

    public static void ShowMenu()
    {
        Console.WriteLine("1. Play");
        Console.WriteLine("2. Show history");
    }

    public static int GetChoice(string message, int lowerBoundary, int higherBoundary)
    {
        while (true)
        {
            Console.Write(message);
            if (!int.TryParse(Console.ReadLine(), out int option))
            {
                Console.WriteLine("Invalid input! Try again.");
                continue;
            }

            if (option < lowerBoundary || option > higherBoundary)
            {
                Console.WriteLine($"Must be between {lowerBoundary} and {higherBoundary}! Try again.");
                continue;
            }

            return option;
        }
    }

    private static void ShowOperations()
    {
        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Subtraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");
        Console.WriteLine("5. Random");
    }

    public static void ShowGameHistory(int gameId, List<GameRecord> history)
    {
        if (gameId == 0) {
            for (int i = 0; i < history.Count; i++)
            {
                PrintGameRecord(history[i]);
            }
        }
        else
        {
            var gameRecord = history
                .FirstOrDefault(h => h.Id == gameId);

            if (gameRecord == null)
            {
                Console.WriteLine($"Game {gameId} is not on the list!");
                return;
            }

            PrintGameRecord(gameRecord);
        }
    }

    private static void PrintGameRecord(GameRecord gameRecord)
    {
        Console.WriteLine($"\nGame {gameRecord.Id}");
        Console.WriteLine($"Total: {gameRecord.TotalPoints} / 5\n");

        int counter = 0;
        foreach (var questionRecord in gameRecord.QuestionRecords)
        {
            Console.WriteLine($"\t{++counter}. ");
            Console.WriteLine($"\tQuestion: {questionRecord.Content.Content}");
            Console.WriteLine($"\tAnswer: {questionRecord.Content.Answer}");
            Console.WriteLine($"\tPlayer Answer: {questionRecord.PlayerAnswer}");
            Console.WriteLine($"\t{(questionRecord.Correct ? "Correct" : "Incorrect")}");

            Console.WriteLine("\n");
        }
    }
}