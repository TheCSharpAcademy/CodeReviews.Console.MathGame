using System.Collections;

var userInteraction = new UserInteraction();
var game = new Game(userInteraction);
game.Run();

public class Game
{
    // TODO future refactoring: Inject these via interfaces later (DIP)
    private UserInteraction UserInteraction { get; set; }

    public Game(UserInteraction userInteraction)
    {
        UserInteraction = userInteraction;
    }

    public void Run()
    {
        var list = new List<Question>();

        while (true)
        {
            var operationType = UserInteraction.OperationsMenu();

            // TODO future refactoring: Should get rid of the code reuse. Could do this by using delegates for each type of question and binding the operation to a specific symbol/delegate

            switch (operationType)
            {
                case Operation.Add:

                    for (int i = 1; i < 6; i++)
                    {
                        var question = new Question(Helpers.RandomNumber(1, 100), Helpers.RandomNumber(1, 100), Operation.Add);

                        question.CorrectAnswer = question.number1 + question.number2;
                        Console.WriteLine($"{i}. {question.number1} + {question.number2}");

                        var input = Console.ReadLine();
                        question.UserAnswer = int.TryParse(input, out int result) ? result : 0;

                        list.Add(question);

                        Console.WriteLine();
                    }
                    break;
                case Operation.Subtract:

                    for (int i = 1; i < 6; i++)
                    {
                        var question = new Question(Helpers.RandomNumber(1, 100), Helpers.RandomNumber(1, 100), Operation.Subtract);

                        question.CorrectAnswer = question.number1 - question.number2;
                        Console.WriteLine($"{i}. {question.number1} - {question.number2}");

                        var input = Console.ReadLine();
                        question.UserAnswer = int.TryParse(input, out int result) ? result : 0;

                        list.Add(question);

                        Console.WriteLine();
                    }
                    break;
                case Operation.Multiply:

                    for (int i = 1; i < 6; i++)
                    {
                        var question = new Question(Helpers.RandomNumber(1, 100), Helpers.RandomNumber(1, 100), Operation.Multiply);

                        question.CorrectAnswer = question.number1 * question.number2;
                        Console.WriteLine($"{i}. {question.number1} * {question.number2}");

                        var input = Console.ReadLine();
                        question.UserAnswer = int.TryParse(input, out int result) ? result : 0;

                        list.Add(question);

                        Console.WriteLine();
                    }
                    break;
                case Operation.Divide:
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

                        var question = new Question((int)num1, (int)num2, Operation.Divide);

                        question.CorrectAnswer = question.number1 / question.number2;
                        Console.WriteLine($"{i}. {question.number1} / {question.number2}");

                        var input = Console.ReadLine();
                        question.UserAnswer = int.TryParse(input, out int result) ? result : 0;

                        list.Add(question);

                        Console.WriteLine();
                    }
                    break;
            }


            Console.WriteLine("Would you like to view previous games (v) and start a new game, or exit (e)");
            var endInput = Console.ReadLine();
            switch (endInput)
            {
                case "v":
                    for (int index = 0; index < list.Count; index++)
                    {
                        Question? item = list[index];
                        Console.WriteLine($"{index + 1}. {item}");
                    }
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