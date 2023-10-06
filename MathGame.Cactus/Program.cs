Console.WriteLine("Please type your name");
var username = Console.ReadLine();
var date = DateTime.UtcNow;
var score = 0;
var scoreHistory = new List<string>();

Console.WriteLine($"Hello {username?.ToUpper()}, now time is {date}. Let's start the game.\n");

string menu = @"Please choose the option:
A - Addition
S - Subtraction
M - Multiplication
D - Division
H - ScoreHistory
Q - Quit
";

bool isQuit = false;
do
{
    Console.WriteLine(menu);
    var option = Console.ReadLine();
    switch (option?.Trim().ToUpper())
    {
        case "A":
            Add();
            break;
        case "S":
            Sub();
            break;
        case "M":
            Mul();
            break;
        case "D":
            Div();
            break;
        case "H":
            PrintScoreHistory();
            break;
        case "Q":
            Console.WriteLine("Bye");
            isQuit = true;
            break;
        default:
            Console.WriteLine("Invalid Input");
            break;
    }
} while (!isQuit);

void PrintScoreHistory()
{
    Console.WriteLine("-------------------------------------------------------------");
    scoreHistory.ForEach(s => Console.WriteLine(s));
    Console.WriteLine("-------------------------------------------------------------");
}

void Add()
{
    Console.WriteLine("Addition Game");
    Console.WriteLine("Please input the times you want to play:");
    int times;
    var input = Console.ReadLine();
    if (String.IsNullOrEmpty(input) || !int.TryParse(input, out times))
    {
        Console.WriteLine("Invalid Input.");
        return; // go back to main menu
    }
    var rand = new Random();
    var addScore = 0;
    for (int i = 0; i < times; i++)
    {
        var num1 = rand.Next(0, 99);
        var num2 = rand.Next(0, 99);
        Console.WriteLine($"Please enter the result of {num1} + {num2}:");
        int res;
        input = Console.ReadLine();
        if (String.IsNullOrEmpty(input) || !int.TryParse(input, out res))
        {
            Console.WriteLine("Invalid Input.");
        }
        else if (res == num1 + num2)
        {
            Console.WriteLine("Answer Correct!");
            addScore++;
        }
        else
        {
            Console.WriteLine("Answer Error.");
        };
    }
    score += addScore;
    scoreHistory.Add($"Time: {date}, Type:Addition Game, AddScore: {addScore}, Score: {score}.");
    Console.WriteLine($"Game Finish! Your addition game score is {addScore} and total score is {score}!");
}

void Sub()
{
    Console.WriteLine("Subtraction Game");
    Console.WriteLine("Please input the times you want to play:");
    int times;
    var input = Console.ReadLine();
    if (String.IsNullOrEmpty(input) || !int.TryParse(input, out times))
    {
        Console.WriteLine("Invalid Input.");
        return; // go back to main menu
    }
    var rand = new Random();
    var subScore = 0;
    for (int i = 0; i < times; i++)
    {
        var num1 = rand.Next(0, 99);
        var num2 = rand.Next(0, 99);
        Console.WriteLine($"Please enter the result of {num1} - {num2}:");
        var res = 0;
        input = Console.ReadLine();
        if (String.IsNullOrEmpty(input) || !int.TryParse(input, out res))
        {
            Console.WriteLine("Invalid Input");
        }
        else if (res == num1 - num2)
        {
            Console.WriteLine("Answer Correct!");
            subScore++;
        }
        else
        {
            Console.WriteLine("Answer Error.");
        };
    }
    score += subScore;
    scoreHistory.Add($"Time: {date}, Type:Subtraction Game, SubScore: {subScore}, Score: {score}.");
    Console.WriteLine($"Game Finish! Your subtraction game score is {subScore} and total score is {score}!");
}

void Mul()
{
    Console.WriteLine("Muliplication Game");
    Console.WriteLine("Please input the times you want to play:");
    int times;
    var input = Console.ReadLine();
    if (String.IsNullOrEmpty(input) || !int.TryParse(input, out times))
    {
        Console.WriteLine("Invalid Input.");
        return; // go back to main menu
    }
    var rand = new Random();
    var mulScore = 0;
    for(int i = 0; i < times; i++)
    {
        var num1 = rand.Next(0, 10);
        var num2 = rand.Next(0, 10);
        Console.WriteLine($"Please enter the result of {num1} * {num2}:");
        var res = 0;
        input = Console.ReadLine();
        if (String.IsNullOrEmpty(input) || !int.TryParse(input, out res))
        {
            Console.WriteLine("Invalid Input");
        }
        else if (res == num1 * num2)
        {
            Console.WriteLine("Answer Correct!");
            mulScore++;
        }
        else
        {
            Console.WriteLine("Answer Error.");
        };
    }
    score += mulScore;
    scoreHistory.Add($"Time: {date}, Type:Multiplication Game, MulScore: {mulScore}, Score: {score}.");
    Console.WriteLine($"Game Finish! Your multiplication game score is {mulScore} and total score is {score}!");
}

void Div()
{
    Console.WriteLine("Division Game");
    Console.WriteLine("Please input the times you want to play:");
    int times;
    var input = Console.ReadLine();
    if (String.IsNullOrEmpty(input) || !int.TryParse(input, out times))
    {
        Console.WriteLine("Invalid Input.");
        return; // go back to main menu
    }
    var rand = new Random();
    var divScore = 0;
    var num1 = 0;
    var num2 = 0;
    for (int i = 0; i < times; i++)
    {
        do
        {
            num1 = rand.Next(0, 100);
            num2 = rand.Next(1, 100);
        } while (num1 % num2 != 0);
        Console.WriteLine($"Please enter the result of {num1} / {num2}:");
        var res = 0;
        input = Console.ReadLine();
        if (String.IsNullOrEmpty(input) || !int.TryParse(input, out res))
        {
            Console.WriteLine("Invalid Input");
        }
        else if (res == num1 / num2)
        {
            Console.WriteLine("Answer Correct!");
            divScore++;
        }
        else
        {
            Console.WriteLine("Answer Error.");
        };
    }
    score += divScore;
    scoreHistory.Add($"Time: {date}, Type:Division Game, DivScore: {divScore}, Score: {score}.");
    Console.WriteLine($"Game Finish! Your division game score is {divScore} and total score is {score}!");
}