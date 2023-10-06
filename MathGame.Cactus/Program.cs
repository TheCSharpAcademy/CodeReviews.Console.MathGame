using MathGame.Cactus;

// user information
Console.WriteLine("Please type your name");
var username = Console.ReadLine();
var date = DateTime.UtcNow;
var score = 0;
var scoreHistory = new List<string>();

Console.WriteLine($"Hello {username?.ToUpper()}, now time is {date}. Let's start the game.\n");
Console.WriteLine("Please enter any key to start the game.");
var key = Console.ReadLine();

// game menu
bool isQuit = false;
do
{
    Console.Clear();
    Console.WriteLine(Constants.MENU);
    var input = Console.ReadLine();
    var option = input?.Trim().ToUpper();
    switch (option)
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
    if (option == "A" || option == "S" || option == "M" || option == "D" || option == "H")
    {
        Console.WriteLine("Please enter any key to go to the menu.");
        key = Console.ReadLine();
    }
} while (!isQuit);

void PrintScoreHistory()
{
    Console.Clear();
    Console.WriteLine(Constants.SCORE_HISTORY);
    Console.WriteLine("----------------------------------------------------------------------");
    scoreHistory.ForEach(s => Console.WriteLine(s + "\t"));
    Console.WriteLine("----------------------------------------------------------------------");
}

void Add()
{
    Console.Clear();
    Console.WriteLine(Constants.ADD_GAME);
    Console.WriteLine("Please input the times you want to play:");
    int times;
    var input = Console.ReadLine();
    if (string.IsNullOrEmpty(input) || !int.TryParse(input, out times))
    {
        Console.WriteLine(Constants.INVALID_INPUT);
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
        if (string.IsNullOrEmpty(input) || !int.TryParse(input, out res))
        {
            Console.WriteLine(Constants.INVALID_INPUT);
        }
        else if (res == num1 + num2)
        {
            Console.WriteLine(Constants.CORRECT);
            addScore++;
        }
        else
        {
            Console.WriteLine(Constants.ERROR);
        };
    }
    score += addScore;
    scoreHistory.Add($"Time: {date}, Type:{Constants.ADD_GAME}, AddScore: {addScore}, Score: {score}.");
    Console.WriteLine($"Game Finish! Your addition game score is {addScore} and total score is {score}!");
}

void Sub()
{
    Console.Clear();
    Console.WriteLine(Constants.SUB_GAME);
    Console.WriteLine("Please input the times you want to play:");
    int times;
    var input = Console.ReadLine();
    if (string.IsNullOrEmpty(input) || !int.TryParse(input, out times))
    {
        Console.WriteLine(Constants.INVALID_INPUT);
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
        if (string.IsNullOrEmpty(input) || !int.TryParse(input, out res))
        {
            Console.WriteLine(Constants.INVALID_INPUT);
        }
        else if (res == num1 - num2)
        {
            Console.WriteLine(Constants.CORRECT);
            subScore++;
        }
        else
        {
            Console.WriteLine(Constants.ERROR);
        };
    }
    score += subScore;
    scoreHistory.Add($"Time: {date}, Type:{Constants.SUB_GAME}, SubScore: {subScore}, Score: {score}.");
    Console.WriteLine($"Game Finish! Your subtraction game score is {subScore} and total score is {score}!");
}

void Mul()
{
    Console.Clear();
    Console.WriteLine(Constants.MUL_GAME);
    Console.WriteLine("Please input the times you want to play:");
    int times;
    var input = Console.ReadLine();
    if (string.IsNullOrEmpty(input) || !int.TryParse(input, out times))
    {
        Console.WriteLine(Constants.INVALID_INPUT);
        return; // go back to main menu
    }
    var rand = new Random();
    var mulScore = 0;
    for (int i = 0; i < times; i++)
    {
        var num1 = rand.Next(0, 10);
        var num2 = rand.Next(0, 10);
        Console.WriteLine($"Please enter the result of {num1} * {num2}:");
        var res = 0;
        input = Console.ReadLine();
        if (string.IsNullOrEmpty(input) || !int.TryParse(input, out res))
        {
            Console.WriteLine(Constants.INVALID_INPUT);
        }
        else if (res == num1 * num2)
        {
            Console.WriteLine(Constants.CORRECT);
            mulScore++;
        }
        else
        {
            Console.WriteLine(Constants.ERROR);
        };
    }
    score += mulScore;
    scoreHistory.Add($"Time: {date}, Type:{Constants.MUL_GAME}, MulScore: {mulScore}, Score: {score}.");
    Console.WriteLine($"Game Finish! Your multiplication game score is {mulScore} and total score is {score}!");
}

void Div()
{
    Console.Clear();
    Console.WriteLine(Constants.DIV_GAME);
    Console.WriteLine("Please input the times you want to play:");
    int times;
    var input = Console.ReadLine();
    if (string.IsNullOrEmpty(input) || !int.TryParse(input, out times))
    {
        Console.WriteLine(Constants.INVALID_INPUT);
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
        if (string.IsNullOrEmpty(input) || !int.TryParse(input, out res))
        {
            Console.WriteLine(Constants.INVALID_INPUT);
        }
        else if (res == num1 / num2)
        {
            Console.WriteLine(Constants.CORRECT);
            divScore++;
        }
        else
        {
            Console.WriteLine(Constants.ERROR);
        };
    }
    score += divScore;
    scoreHistory.Add($"Time: {date}, Type:{Constants.DIV_GAME}, DivScore: {divScore}, Score: {score}.");
    Console.WriteLine($"Game Finish! Your division game score is {divScore} and total score is {score}!");
}