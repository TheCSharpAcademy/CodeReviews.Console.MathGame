using System.Diagnostics;

Console.WriteLine("Welcome to Math-Game");

bool PlayGame = true;
List<string> gamesHistory = new List<string>();
Stopwatch stopwatch = new Stopwatch();

while (PlayGame)
{
    int answer = 0;

    Console.WriteLine("------------------ Choose an option ------------------");
    Console.WriteLine("1 - Normal Game (Choose the Operation and play with time free)");
    Console.WriteLine("2 - Hard Game (10 Random Operation with time limit)");
    Console.WriteLine("3 - Random Game(Random Operation)");
    Console.WriteLine("4 - Result History");
    Console.WriteLine("5 - Exit");
    Console.WriteLine("------------------------------------------------------");
    answer = Convert.ToInt32(Console.ReadLine());

    switch (answer)
    {
        case 1:
            NormalPlay();
            break;
        case 2:
            HardPlay();
            break;
        case 3:
            RandomPlay();
            break;
        case 4:
            ShowHistoric();
            break;
        case 5:
            PlayGame = false;
            break;
        default:
            Console.WriteLine("Invalid Option, Try Again.");
            break;

    }
}


void NormalPlay()
{
    int answerMenu = 0;


    Console.WriteLine("------------------ Menu ------------------");
    Console.WriteLine("1 - Addition");
    Console.WriteLine("2 - Subtraction");
    Console.WriteLine("3 - Multiplication");
    Console.WriteLine("4 - Division");
    Console.WriteLine("5 - Exit");
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
            PlayMath("Multiplication", "*");
            break;
        case 4:
            PlayMath("Division", "/");
            break;
        case 5:
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


void HardPlay()
{

    Console.WriteLine("---------------------- RULES ----------------------");
    Console.WriteLine("YOU CANNOT CHOOSE THE OPERATIONS");
    Console.WriteLine("YOU HAVE ONLY 5 SECONDS TO ANSWER EACH QUESTION");
    Console.WriteLine("IF YOU RESPOND AFTER THE GAME'S TIME LIMIT, THE GAME WILL END");
    Console.WriteLine("IF YOU ANSWER INCORRECTLY, THE GAME WILL END");
    Console.WriteLine("GOOD LUCK C:");
    Console.WriteLine("---------------------------------------------------");
    Console.WriteLine("Press any key to start...");
    Console.ReadKey();

    for (int i = 0; i < 10; i++)
    {
        stopwatch.Restart();
        bool answer = RandomPlay();
        stopwatch.Stop();

        if (stopwatch.Elapsed.Seconds > 5)
        {
            Console.WriteLine("TIME LIMIT EXCEEDED!");
            Console.WriteLine($"STREAK: {i}");
            break;
        }
        else if (answer == false)
        {
            Console.WriteLine($"INCORRECT GAME ENDED WITH STREAK: {i}");
            break;
        }
    }

}

bool RandomPlay()
{
    Random random = new Random();
    string[] operations = new string[] { "+", "-", "*", "/" };
    string[] operationsName = new string[] { "Addition", "Subtraction", "Multiplication", "Division" };

    int indexOperation = random.Next(0, operations.Length);
    return PlayMath(operationsName[indexOperation], operations[indexOperation]);


}

bool PlayMath(string operation, string operationSymbol)
{
    stopwatch.Start();

    Random random = new Random();
    int number1 = random.Next(0, 100);
    int number2 = random.Next(1, 100);
    int result, answer = 0;

    if (operation == "Division")
    {
        do
        {
            number1 = random.Next(0, 100);
            number2 = random.Next(1, 100);
        }
        while (number1 % number2 != 0);
    }


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
        gamesHistory.Add($"{actualOperation} |  Correct Answer! ({answer}) in {stopwatch.Elapsed.Seconds} seconds");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        return true;
    }
    else
    {
        Console.WriteLine("Wrong!");
        Console.WriteLine($"The correct answer is {result}.");
        gamesHistory.Add($"{actualOperation} | Wrong Answer! ({answer}) in {stopwatch.Elapsed.Seconds} seconds");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        return false;
    }
}