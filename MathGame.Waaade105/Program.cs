Console.WriteLine(
    "Welcome to the Math Game! Choose a math operation and answer 5 questions. " +
    "You will receive 1 point for each correct answer.");

List<string> gamesHistory = [];
bool stillWantToPlay = true;

while (stillWantToPlay)
{
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("1.Addition\n2.Subtraction\n3.Multiplication\n4.Division\n5.Game history\n6.Exit");
    Console.WriteLine("Choice:");

    int choice;
    while (!int.TryParse(Console.ReadLine(), out choice))
    {
        Console.WriteLine("Invalid choice.");
    }

    switch (choice)
    {
        case 1:
            PlayGame("+", gamesHistory);
            break;
        case 2:
            PlayGame("-", gamesHistory);
            break;
        case 3:
            PlayGame("*", gamesHistory);
            break;
        case 4:
            PlayGame("/", gamesHistory);
            break;
        case 5:
            ShowGameHistory(gamesHistory);
            break;
        case 6:
            stillWantToPlay = false;
            break;

        default:
            Console.WriteLine("Invalid choice. Please select a number from 1 to 6.");
            break;
    }
}

void ShowGameHistory(List<string> gamesHistory)
{
    if(gamesHistory.Count == 0)
    {
        Console.WriteLine("No games have been played yet.");
        return;
    }

    foreach (string game in gamesHistory)
    {
        Console.WriteLine(game);
    }
}

void PlayGame(string operationSign, List<string> gamesHistory)
{
    var random = new Random();
    int points = 0;
    int askedQuestions = 5;

    for (int i = 1; i <= askedQuestions; i++)
    {
        int number1;
        int number2;

        if (operationSign == "/")
        {
            do
            {
                number1 = random.Next(0, 101);
                number2 = random.Next(1, 101);
            } while (number1 % number2 != 0);
        }
        else
        {
            number1 = random.Next(0, 101);
            number2 = random.Next(1, 101);
        }


        int result = 0;
        switch (operationSign)
        {
            case "+":
                result = number1 + number2;
                break;
            case "-":
                result = number1 - number2;
                break;
            case "*":
                result = number1 * number2;
                break;
            case "/":
                result = number1 / number2;
                break;
        }

        Console.WriteLine($"question {i}:");
        Console.WriteLine($"{number1} {operationSign} {number2} = ?");

        int answer;
        while (!int.TryParse(Console.ReadLine(), out answer))
        {
            Console.WriteLine("Please enter a valid number:");
        }

        if (result == answer)
        {
            Console.WriteLine("Correct! 1 point was added");
            points++;
        }
        else
        {
            Console.WriteLine("Not this time. The correct answer is " + result);
        }
    }

    string gameType = operationSign switch
    {
        "+" => "Addition",
        "-" => "Subtraction",
        "*" => "Multiplication",
        "/" => "Division",
        _ => "Unknown"
    };

    gamesHistory.Add($"{gameType} - Result: {points}/{askedQuestions}");

    Console.WriteLine("You answered all questions.");
    Console.WriteLine($"Result: {points}/{askedQuestions}");
}



   


