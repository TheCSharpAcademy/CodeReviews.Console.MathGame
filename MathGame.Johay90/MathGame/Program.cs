UserInteraction userInteraction = new();
App app = new(userInteraction);
app.Run();

public class App
{
    private UserInteraction UserInteraction { get; set; }

    public delegate int OperationDelegate(int a, int b);
    private List<Game> games = new();

    public App(UserInteraction userInteraction)
    {
        UserInteraction = userInteraction;
    }

    public void Run()
    {
        while (true)
        {
            Operation operationType = UserInteraction.OperationsMenu();

            switch (operationType)
            {
                case Operation.Add:
                    PerformGameOperation(Operation.Add, (a, b) => a + b);
                    break;
                case Operation.Subtract:
                    PerformGameOperation(Operation.Subtract, (a, b) => a - b);
                    break;
                case Operation.Multiply:
                    PerformGameOperation(Operation.Multiply, (a, b) => a * b);
                    break;
                case Operation.Divide:
                    PerformGameOperation(Operation.Divide, (a, b) => a / b);
                    break;
            }


            Console.WriteLine("Would you like to view previous games (v) and start a new game, or exit (e)");
            string? endInput = Console.ReadLine();
            switch (endInput)
            {
                case "v":
                    Console.Clear();
                    UserInteraction.GameHistory(games);
                    Console.WriteLine();
                    break;
                case "e": 
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option, application will exit after button press.");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
            }

        }
    }

    private void PerformGameOperation(Operation operationType, OperationDelegate operation)
    {
        Game currentGame = new(operationType);
        games.Add(currentGame);

        for (int i = 1; i <= 5; i++)
        {
            int num1 = Helpers.RandomNumber(1, 100);
            int num2 = Helpers.RandomNumber(1, 100);
            if (operationType == Operation.Divide)
            {
                // Ensure the division results in an integer
                while (num1 % num2 != 0)
                {
                    num1 = Helpers.RandomNumber(1, 500);
                    num2 = Helpers.RandomNumber(1, 500);
                }
            }

            Question question = new(num1, num2, operationType)
            {
                CorrectAnswer = operation(num1, num2)
            };

            Console.WriteLine($"{i}. {num1} {GetOperationSymbol(operationType)} {num2}");

            string? input = Console.ReadLine();
            question.UserAnswer = int.TryParse(input, out int result) ? result : 0;

            currentGame.Games.Add(question);
            if (question.CorrectAnswer == question.UserAnswer) currentGame.Score += 1;

            Console.WriteLine();
        }
    }

    private string GetOperationSymbol(Operation operationType)
    {
        return operationType switch
        {
            Operation.Add => "+",
            Operation.Subtract => "-",
            Operation.Multiply => "*",
            Operation.Divide => "/",
            _ => ""
        };
    }

}