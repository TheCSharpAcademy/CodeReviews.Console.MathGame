List<string> HistoryList = [];

PrintWelcome();

while (true)
{
    string input = Console.ReadLine() ?? "";

    switch (input)
    {
        case "1":
        case "2":
        case "3":
        case "4":
            break;
        case "5":
            PrintHistory();
            continue;
        case "6":
            Environment.Exit(0);
            break;
        default:
            PrintWelcome();
            Console.WriteLine(input);
            Console.WriteLine("Invalid selection, please try again");
            continue;
    }
    
    string op = GetOperator(input);
    PlayGame(op);
}

void PlayGame(string operation)
{
    int score = 0;
    PrintGameReady();
    float totalTime = 0f;
    for (var i = 1; i <= 3; i++)
    {
        var (a,b) = GetOperands(operation);
        Console.WriteLine($"{i}. {a} {operation} {b}");
        long start = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        string answer = Console.ReadLine() ?? "";

        while (!answer.All(char.IsNumber) || string.IsNullOrEmpty(answer))
        {
            Console.WriteLine("Invalid selection.");
            answer = Console.ReadLine() ?? "";
        }
        
        long end = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        totalTime += (end - start) / 1000.0f;

        if (CheckAnswer(a, b, operation, answer)) score++;
    }

    string time = totalTime.ToString("F2");
    HistoryList.Add($"Score: {score}/3 Time: {time}s");

    Console.Clear();
    Console.WriteLine($"You scored: {score}/3 in {time} seconds!");
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
    PrintWelcome();
}

static string GetOperator(string selection)
{
    if (selection == "1") return "+";
    else if (selection == "2") return "-";
    else if (selection == "3") return "/";
    else return "*";
}

static (int, int) GetOperands(string operation)
{
    Random dice = new();
    if (operation == "+") return (dice.Next(1, 101), dice.Next(1, 101));
    else if (operation == "-")
    {
        int a = dice.Next(1, 101);
        int b = dice.Next(1, 101);
        return a > b ? (a, b) : (b, a);
    } else if (operation == "/") {
        int a = dice.Next(2, 13);
        int b = dice.Next(2, 13);
        return (a * b, b);
    } else {
        int a = dice.Next(2, 13);
        int b = dice.Next(2, 13);
        return (a, b);
    }
}

static bool CheckAnswer(int a, int b, string operation, string answer)
{
    if (operation == "+") return a + b == int.Parse(answer);
    else if (operation == "-") return a - b == int.Parse(answer); 
    else if (operation == "/") return a / b == int.Parse(answer); 
    else return a * b == int.Parse(answer); 
}

static void PrintWelcome()
{
    Console.Clear();
    Console.WriteLine("Welcome to my math game!");
    Console.WriteLine("This is a timed game where you have to complete three operations as quick as possible to test your math skills.");
    Console.WriteLine("Enter a number to chose a gamemode or quit.");
    Console.WriteLine("1. + Addition");
    Console.WriteLine("2. - Subtraction");
    Console.WriteLine("3. / Division");
    Console.WriteLine("4. * Multiplication");
    Console.WriteLine("5. Game History");
    Console.WriteLine("6. Quit");
}

void PrintHistory()
{
    for (var i = 0; i < HistoryList.Count; i++)
    {
        Console.WriteLine($"Game {i+1}: {HistoryList[i]}");
    }
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
    PrintWelcome();
}

static void PrintGameReady()
{
    Console.Clear();
    Console.WriteLine("Okay, get ready.");
    Thread.Sleep(500);
    Console.Clear();
    Console.WriteLine("3...");
    Thread.Sleep(1000);
    Console.Clear();
    Console.WriteLine("2...");
    Thread.Sleep(1000);
    Console.Clear();
    Console.WriteLine("1...");
    Thread.Sleep(1000);
    Console.Clear();
}