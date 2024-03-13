using MathGame.Antonderegt;

List<Result> results = [];

void ShowMenu()
{
    Console.Clear();
    Console.WriteLine("1. Add");
    Console.WriteLine("2. Substract");
    Console.WriteLine("3. Multiply");
    Console.WriteLine("4. Divide");
    Console.WriteLine("5. Scores");
    Console.WriteLine("6. Exit");

    Console.Write("\nSelect option: ");
}

void ShowScores()
{
    Console.Clear();
    Console.WriteLine("Your results");
    foreach (Result r in results)
    {
        Console.WriteLine($"Question: {r.Question}, Asnwer: {r.Correct}");
    }
}

while (true)
{
    IQuestion? question;
    ShowMenu();
    string? input = Console.ReadLine();
    Console.Clear();

    if (int.TryParse(input, out int number))
    {
        switch (number)
        {
            case 1:
                question = new AdditionQuestion();
                break;
            case 2:
                question = new SubstractionQuestion();
                break;
            case 3:
                question = new MultiplicationQuestion();
                break;
            case 4:
                question = new DivisionQuestion();
                break;
            case 5:
                ShowScores();
                Console.WriteLine("\nPress enter to continue...");
                Console.ReadLine();
                continue;
            case 6:
                return;
            default:
                Console.WriteLine("Unknown action, press enter to try again...");
                Console.ReadLine();
                continue;
        }
    }
    else
    {
        Console.WriteLine("Please enter a number, press enter to try again...");
        Console.ReadLine();
        continue;
    }

    Console.Write($"{question?.Question} = ");

    string? answerString = Console.ReadLine();

    if (int.TryParse(answerString, out int answer))
    {
        if (answer == question?.Answer)
        {
            Console.WriteLine("Correct!");
            results.Add(new Result(question.Question, true));
        }
        else
        {
            Console.WriteLine("Wrong answer..");
            results.Add(new Result(question?.Question ?? "", false));
        }
    }
    else
    {
        Console.WriteLine("Please enter a number, press enter to try again...");
        Console.ReadLine();
        continue;
    }

    Console.WriteLine("\nPress enter to continue...");
    Console.ReadLine();
}