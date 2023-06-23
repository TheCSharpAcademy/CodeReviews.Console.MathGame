Console.WriteLine("Welcome to Math-Game");

bool PlayGame = true;

List<string> gamesHistory = new List<string>();

while (PlayGame)
{

    Random random = new Random();

    int number1 = random.Next(0, 100);
    int number2 = random.Next(1, 100);
    int result = 0;
    int answerMenu = 0;
    int answer = 0;

    string actualOperation = "";

    Console.WriteLine("------------------ Menu ------------------");
    Console.WriteLine("1 - Addition");
    Console.WriteLine("2 - Subtraction");
    Console.WriteLine("3 - Multiplication");
    Console.WriteLine("4 - Division");
    Console.WriteLine("5 - Previous games history");
    Console.WriteLine("6 - Exit");
    Console.WriteLine("------------------------------------------");



    answerMenu = Convert.ToInt32(System.Console.ReadLine());



    switch (answerMenu)
    {
        case 1:
            actualOperation = $"{number1} + {number2}";
            System.Console.WriteLine(actualOperation);
            answer = Convert.ToInt32(System.Console.ReadLine());
            result = number1 + number2;
            break;
        case 2:
            actualOperation = $"{number1} - {number2}";
            System.Console.WriteLine(actualOperation);
            answer = Convert.ToInt32(System.Console.ReadLine());
            result = number1 - number2;
            break;
        case 3:
            actualOperation = $"{number1} * {number2}";
            System.Console.WriteLine(actualOperation);
            answer = Convert.ToInt32(System.Console.ReadLine());
            result = number1 * number2;
            break;
        case 4:
            actualOperation = $"{number1} / {number2}";
            System.Console.WriteLine(actualOperation);
            answer = Convert.ToInt32(System.Console.ReadLine());
            result = number1 / number2;
            break;
        case 5:
            ShowHistoric();
            break;
        case 6:
            PlayGame = false;
            break;
        default:
            System.Console.WriteLine("Invalid Option, Try Again.");
            break;
    }

    if (result == answer)
    {
        System.Console.WriteLine("Correct Answer");
        gamesHistory.Add($"{actualOperation} = {result} (CORRECT)");
    }
    else
    {
        System.Console.WriteLine($"Incorrect Answer Correct Value = {result}");
        gamesHistory.Add($"{actualOperation} = {answer} WRONG (CORRECT IS {result})");
    }
}


void ShowHistoric()
{
    if (gamesHistory.Count == 0)
    {
        System.Console.WriteLine("No Game History");
    }
    else
    {
        System.Console.WriteLine("------------------Games History------------------");
        foreach (var game in gamesHistory)
        {
            System.Console.WriteLine(game);

        }
        System.Console.WriteLine("Press any key to continue...");
        System.Console.ReadKey();
    }
}

