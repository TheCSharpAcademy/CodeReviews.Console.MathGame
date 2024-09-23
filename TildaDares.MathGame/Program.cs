using System.Diagnostics;

var random = new Random();
var history = new List<string>();
var minRange = 1;
var maxRange = 100;
const string WON = "Won";
const string LOST = "Lost";

void Menu()
{
    do
    {
        Console.WriteLine("Welcome to Math Game!");
        Console.WriteLine("Pick an option from the menu below. Select either 1, 2, or 3: ");
        Console.WriteLine("1. Math Game ");
        Console.WriteLine("2. View your game history");
        Console.WriteLine("3. Press any key to exit...");
        
        var option = Console.ReadKey().KeyChar;
        Console.Clear();
        
        switch (option)
        {
            case '1':
                MathOperationMenu();
                break;
            case '2':
                PrintHistory();
                break;
            default:
                return;
        }
    } while (true);
}

void MathOperationMenu()
{
    var signs = "+*-/";
    var sign = "";
    do
    {
        Console.WriteLine("Enter a math operation (+, -, *, or /): ");
        sign = Console.ReadLine().Trim();
    } while (!signs.Contains(sign));
    
    var difficulty = 4;
    var isDifficultyValid = true;
    do
    {
        Console.Clear();
        Console.WriteLine("Pick a difficulty level. Select either 1, 2, 3 or 4: ");
        Console.WriteLine("1. Easy");
        Console.WriteLine("2. Medium");
        Console.WriteLine("3. Hard");
        Console.WriteLine("4. Random\n");
        var input = Console.ReadLine().Trim();
        isDifficultyValid = int.TryParse(input, out difficulty);
    } while (!isDifficultyValid || difficulty < 1 || difficulty > 4);
    
    Console.Clear();
    
    switch (difficulty)
    {
        case 1:
            minRange = 1;
            maxRange = 30;
            break;
        case 2:
            minRange = 30;
            maxRange = 50;
            break; 
        case 3:
            minRange = 50;
            maxRange = 100;
            break;
        case 4:
            minRange = 1;
            maxRange = 100;
            break;
    }
    
    // There's a very small range of numbers for division when using the difficulty levels
    if (sign == "/")
    {
        minRange = 1;
        maxRange = 100;
    }
    
    MathOperation(sign);
}

void MathOperation(string sign)
{
    var firstNumber = 0;
    var secondNumber = 0;
    switch (sign)
    {
        case "+":
            (firstNumber, secondNumber) = GenerateRandomNumbers();
            
            Console.WriteLine($"What is the result of this operation: {firstNumber} + {secondNumber}");
            EvalGameResult(result: firstNumber + secondNumber);
            break; 
        case "-":
            (firstNumber, secondNumber) = GenerateRandomNumbers();
            
            Console.WriteLine($"What is the result of this operation: {firstNumber} - {secondNumber}");
            EvalGameResult(result: firstNumber - secondNumber);
            break;
        case "*":
            (firstNumber, secondNumber) = GenerateRandomNumbers();
            
            Console.WriteLine($"What is the result of this operation: {firstNumber} * {secondNumber}");
            EvalGameResult(result: firstNumber * secondNumber);
            break;
        case "/":
            do
            {
                (firstNumber, secondNumber) = GenerateRandomNumbers();
            } while (firstNumber % secondNumber != 0);
            
            Console.WriteLine($"What is the result of this operation: {firstNumber} / {secondNumber}");
            EvalGameResult(result: firstNumber / secondNumber);
            break;
    }
}
(int, int) GenerateRandomNumbers()
{
    var firstNumber = random.Next(minRange, maxRange);
    var secondNumber = random.Next(minRange, maxRange);
    
    return (firstNumber, secondNumber);
}

void PrintHistory()
{
    Console.WriteLine("\nGame History:");
    if (!history.Any())
    {
        Console.WriteLine("No history available.\n");
        return;
    }

    var wins = 0;
    for (var i = 0; i < history.Count; i++)
    {
        Console.WriteLine($"Round {i + 1}: {history[i]}\n");
        if (history[i] == WON) wins++;
    }
    Console.WriteLine($"Total Score: {wins}/{history.Count}\n");
}

void EvalGameResult(int result)
{
    var userAns = "";
    var timer = new Stopwatch();
    timer.Start();
    
    do
    {
        Console.WriteLine("Answer must be an integer: ");
        userAns = Console.ReadLine().Trim();
    } while (!int.TryParse(userAns, out _));
    timer.Stop();
   
    
    var userResult = int.Parse(userAns);
    Console.Clear();
    if (userResult != result)
    {
        Console.WriteLine($"Incorrect! The correct answer is {result}");
        history.Add(LOST);
    }
    else
    {
        Console.WriteLine($"CORRECT! You won this round!");
        history.Add(WON);
    }
    Console.WriteLine($"Time Elapsed: {timer.Elapsed}\n");
}

Menu();