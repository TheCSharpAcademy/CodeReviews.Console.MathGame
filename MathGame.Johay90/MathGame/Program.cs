UserInteraction userInteraction = new();
App app = new(userInteraction);
app.Run();

public class App
{
    // TODO future refactoring: Inject these via interfaces later (DIP)
    private UserInteraction UserInteraction { get; set; }

    public App(UserInteraction userInteraction)
    {
        UserInteraction = userInteraction;
    }

    public void Run()
    {
        List<Question> questions = new();
        List<Game> games = new();
        Game currentGame;

        while (true)
        {
            Operation operationType = UserInteraction.OperationsMenu();

            // TODO future refactoring: Should get rid of the code reuse. Could do this by using delegates for each type of question and binding the operation to a specific symbol/delegate

            switch (operationType)
            {
                case Operation.Add:
                    currentGame = new Game(Operation.Add);
                    games.Add(currentGame);

                    for (int i = 1; i < 6; i++)
                    {
                        Question question = new(Helpers.RandomNumber(1, 100), Helpers.RandomNumber(1, 100), Operation.Add);

                        question.CorrectAnswer = question.number1 + question.number2;
                        Console.WriteLine($"{i}. {question.number1} + {question.number2}");

                        string? input = Console.ReadLine();
                        question.UserAnswer = int.TryParse(input, out int result) ? result : 0;

                        currentGame.Games.Add(question);
                        if (question.CorrectAnswer == question.UserAnswer) currentGame.Score += 1;
                        
                        Console.WriteLine();
                    }
                    break;
                case Operation.Subtract:
                    currentGame = new Game(Operation.Subtract);
                    games.Add(currentGame);

                    for (int i = 1; i < 6; i++)
                    {
                        Question question = new(Helpers.RandomNumber(1, 100), Helpers.RandomNumber(1, 100), Operation.Subtract);

                        question.CorrectAnswer = question.number1 - question.number2;
                        Console.WriteLine($"{i}. {question.number1} - {question.number2}");

                        string? input = Console.ReadLine();
                        question.UserAnswer = int.TryParse(input, out int result) ? result : 0;

                        currentGame.Games.Add(question);
                        if (question.CorrectAnswer == question.UserAnswer) currentGame.Score += 1;

                        Console.WriteLine();
                    }
                    break;
                case Operation.Multiply:
                    currentGame = new Game(Operation.Multiply);
                    games.Add(currentGame);

                    for (int i = 1; i < 6; i++)
                    {
                        Question question = new(Helpers.RandomNumber(1, 100), Helpers.RandomNumber(1, 100), Operation.Multiply);

                        question.CorrectAnswer = question.number1 * question.number2;
                        Console.WriteLine($"{i}. {question.number1} * {question.number2}");

                        string? input = Console.ReadLine();
                        question.UserAnswer = int.TryParse(input, out int result) ? result : 0;

                        currentGame.Games.Add(question);
                        if (question.CorrectAnswer == question.UserAnswer) currentGame.Score += 1;

                        Console.WriteLine();
                    }
                    break;
                case Operation.Divide:
                    currentGame = new Game(Operation.Divide);
                    games.Add(currentGame);
                    for (int i = 1; i < 6; i++)
                    {

                        double num1;
                        double num2;
                        double a;

                        do
                        {
                            num1 = Helpers.RandomNumber(1, 500);
                            num2 = Helpers.RandomNumber(1, 500);
                            a = num1 / num2;

                        } while (a % 1 != 0);

                        Question question = new((int)num1, (int)num2, Operation.Divide);

                        question.CorrectAnswer = question.number1 / question.number2;
                        Console.WriteLine($"{i}. {question.number1} / {question.number2}");

                        string? input = Console.ReadLine();
                        question.UserAnswer = int.TryParse(input, out int result) ? result : 0;

                        currentGame.Games.Add(question);
                        if (question.CorrectAnswer == question.UserAnswer) currentGame.Score += 1;

                        Console.WriteLine();
                    }
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
}