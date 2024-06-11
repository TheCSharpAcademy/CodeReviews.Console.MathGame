// See https://aka.ms/new-console-template for more information
using System.Numerics;
using System.Runtime.InteropServices;


//Math Game completed including difficulty level challenge

string menuSelection = "";
string? inputResult;
int userResponse = 0;
int firstNum = 0;
int seconNum = 0;
int operationResult = 0;
string operationSymbol = string.Empty;
string gameLevelSelected = "";
bool operationCompleted = false;

Random rd = new Random();

var prevGamesList = new List<string>();
do
{
    Console.Clear();
    Console.WriteLine("Welcome to the Math Game!\n");
    Console.WriteLine("Select the game Level:");
    Console.WriteLine("1. Easy");
    Console.WriteLine("2. Medium");
    Console.WriteLine("3. Expert");

    inputResult = Console.ReadLine();
    if (inputResult != null)
    {
        if (inputResult == "1")
        {
            gameLevelSelected = "1";
            break;
        }
        else if (inputResult == "2")
        {
            gameLevelSelected = "2";
            break;
        }
        else if (inputResult == "3")
        {
            gameLevelSelected = "3";
            break;
        }
    }
} while (true);

SetNumbersDifficultyLevel(gameLevelSelected);
do
{
    Console.Clear();
    Console.WriteLine("Please Select an operation:");
    Console.WriteLine("1. Addition");
    Console.WriteLine("2. Substraction");
    Console.WriteLine("3. Multiplication");
    Console.WriteLine("4. Division");
    Console.WriteLine("5. See Previous Games");
    Console.WriteLine("6. To exit program");

    inputResult = Console.ReadLine();
    if (inputResult != null)
    {
        menuSelection = inputResult;
    }
    switch (menuSelection)
    {
        case "1":
            Addition();
            operationCompleted = true;
            break;
        case "2":
            Substraction();
            operationCompleted = true;
            break;
        case "3":
            Multiplication();
            operationCompleted = true;
            break;
        case "4":
            SetDivisionDifficultyLevel(gameLevelSelected);
            Division();
            operationCompleted = true;
            break;
        case "5":
            Console.Clear();
            if (prevGamesList.Count > 0)
            {
                Console.WriteLine("History of Games played");
                foreach (string line in prevGamesList)
                {
                    Console.WriteLine(line);
                }
            }
            else
                Console.WriteLine("No Games have been played!!");

            Console.WriteLine("\nPress Enter Key to continue");
            Console.ReadKey();
            break;
        case "6":
            break;
        default:
            break;
    }
    if (operationCompleted)
    {
        OperationLoop();
        operationCompleted = false;
    }
} while (menuSelection != "6");

void ClearPreviousLine()
{
    Console.SetCursorPosition(0, Console.CursorTop - 1);
    Console.Write(new string(' ', Console.BufferWidth));
    Console.SetCursorPosition(0, Console.CursorTop);
}
void Addition()
{
    Console.WriteLine("Please provide the result of the addition below: ");
    operationResult = firstNum + seconNum;
    operationSymbol = "+";
}
void Substraction()
{
    Console.WriteLine("Please provide the result of the substraction below: ");
    operationResult = firstNum - seconNum;
    operationSymbol = "-";
}
void Multiplication()
{
    Console.WriteLine("Please provide the result of the division below: ");
    operationResult = firstNum * seconNum;
    operationSymbol = "x";
}
void Division()
{
    Console.WriteLine("Please provide the result of the division below: ");
    operationResult = firstNum / seconNum;
    operationSymbol = "/";
}
void OperationLoop()
{
    bool validEntry = false;
    Console.Clear();

    Console.WriteLine($"{firstNum} {operationSymbol} {seconNum}");
    do//loop through the inputs 
    {
        inputResult = Console.ReadLine();
        if (inputResult != null)
        {
            validEntry = int.TryParse(inputResult, out userResponse);
            ClearPreviousLine();//clear last entry
            if (validEntry)
            {
                string result = "";
                if (userResponse == (operationResult))
                {
                    result = $"{firstNum} {operationSymbol} {seconNum} = {operationResult} Great answer !!";
                    Console.WriteLine(result);
                    prevGamesList.Add(result);
                }
                else
                {
                    result = $"{firstNum} {operationSymbol} {seconNum} = {userResponse} Wrong answer !!";
                    Console.WriteLine(result);
                    prevGamesList.Add(result);
                }
                Console.WriteLine("\nPress Enter Key to continue");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Try again with numbers only & press Enter");
            }
        }
    } while (validEntry == false);
}

void SetNumbersDifficultyLevel(string level)
{
    if (level == "1")
    {
        firstNum = rd.Next(101);
        seconNum = rd.Next(101);
    }
    else if (level == "2")
    {
        firstNum = rd.Next(101, 1001);
        seconNum = rd.Next(101, 1001);
    }
    else if (level == "3")
    {
        firstNum = rd.Next(1001, 10001);
        seconNum = rd.Next(1001, 10001);
    }
}
void SetDivisionDifficultyLevel(string level)
{
    if (level == "1")
    {
        firstNum = rd.Next(101);
        while (true)
        {
            seconNum = rd.Next(101);
            if (firstNum % seconNum == 0)
               break;
        }
    }
    else if (level == "2")
    {
        firstNum = rd.Next(101, 1001);
        while (true)
        {
            seconNum = rd.Next(101, 1001);
            if (firstNum % seconNum == 0)
                break;
        }
    }
    else if (level == "3")
    {
        firstNum = rd.Next(1001, 10001);
        while (true)
        {
            seconNum = rd.Next(1001, 10001);
            if (firstNum % seconNum == 0)
                break;
        }
    }
}
