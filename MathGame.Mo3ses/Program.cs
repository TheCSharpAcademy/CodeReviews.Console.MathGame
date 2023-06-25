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



    answerMenu = Convert.ToInt32(Console.ReadLine());



    switch (answerMenu)
    {
        case 1:
            PlayMath("Addition", "+");
            break;
        case 2:
            PlayMath("Subtraction", "-");
            break;
        case 3:
            // PlayMath("Multiplication", "*");
            break;
        case 4:
            PlayMath("Division", "/");
            break;
        case 5:
            ShowHistoric();
            break;
        case 6:
            PlayGame = false;
            break;
        default:
            Console.WriteLine("Invalid Option, Try Again.");
            break;
    }
}


void ShowHistoric()
{
    if (gamesHistory.Count == 0)
    {
        Console.WriteLine("No Game History");
    }
    else
    {
        Console.WriteLine("------------------Games History------------------");
        foreach (var game in gamesHistory)
        {
            Console.WriteLine(game);

        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}



bool PlayMath(string operation, string operationSymbol)
{
    Random random = new Random();
    int number1 = random.Next(0, 100);
    int number2 = random.Next(1, 100);
    int result, answer = 0;
    do
    {
        number1 = random.Next(0, 100);
        number2 = random.Next(1, 100);
    }
    while (number1 % number2 != 0);


    string actualOperation = $"{number1} {operationSymbol} {number2}";

    Console.WriteLine(actualOperation);
    answer = Convert.ToInt32(Console.ReadLine());

    switch (operationSymbol)
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
        default:
            result = 0;
            break;
    }
    if (answer == result)
    {

        Console.WriteLine("Correct!");
        gamesHistory.Add($"{actualOperation} |  Correct Answer! ({answer})");
        return true;
    }
    else
    {
        Console.WriteLine("Wrong!");
        Console.WriteLine($"The correct answer is {result}.");
        gamesHistory.Add($"{actualOperation} | Wrong Answer! ({answer})");
        return false;
    }

    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}