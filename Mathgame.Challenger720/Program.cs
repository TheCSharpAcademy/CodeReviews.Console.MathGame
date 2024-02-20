using System.Reflection.Metadata.Ecma335;

string? menuSelection;
string? answer;
Random random = new Random();
int number;
int point;
bool verify;
bool showMenu = true;
var history = new List<string>();

while (showMenu)
{
    Console.Clear();
    MainMenu();
    showMenu = MainMenu();
}

bool MainMenu()
{
    Console.WriteLine("What game would you like to play today? Choose from the options below:");
    Console.WriteLine("V - View Previous Games");
    Console.WriteLine("A - Addition");
    Console.WriteLine("S - Subtraction");
    Console.WriteLine("M - Multiplication");
    Console.WriteLine("D - Division");
    Console.WriteLine("Q - Quit the program");
    Console.WriteLine("----------------------------------------------------------------------");

    do
    {
        menuSelection = Console.ReadLine();
    } while ((menuSelection == null) || (menuSelection != "V" && menuSelection != "A" && menuSelection != "S" && menuSelection != "M" && menuSelection != "D" && menuSelection != "Q"));

    switch (menuSelection)
    {
        case "V":
            foreach (var log in history)
            {
                Console.WriteLine(log);
            }
            Console.WriteLine("Press any key to return to Main Menu.");
            Console.ReadLine();
            return true;
        case "A":
            point = 0;
            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Addition();
            }
            Score();
            history.Add($"Addition: {point}");
            return true;
        case "S":
            point = 0;
            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Subtraction();
            }
            Score();
            history.Add($"Subtraction: {point}");
            return true;
        case "M":
            point = 0;
            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Multiply();
            }
            Score();
            history.Add($"Multiplication: {point}");
            return true;
        case "D":
            point = 0;
            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Division();
            }
            Score();
            history.Add($"Division: {point}");
            return true;
        case "Q":
            return false;
        default:
            return false;
    }
}

void Addition()
{
    int A = random.Next(1, 101);
    int B = random.Next(1, 101);
    int sum = A + B;
    Console.WriteLine("Addition game");
    Console.WriteLine($"{A} + {B}");
    do
    {
        answer = Console.ReadLine();
        verify = int.TryParse(answer, out number);
    } while ((answer == null) || (!verify));
    Check(number, sum);
}

void Subtraction()
{
    int A;
    int B;
    do
    {
        A = random.Next(1, 101);
        B = random.Next(1, 101);
    } while (A < B);
    int sub = A - B;
    Console.WriteLine("Subtraction game");
    Console.WriteLine($"{A} - {B}");
    do
    {
        answer = Console.ReadLine();
        verify = int.TryParse(answer, out number);
    } while ((answer == null) || (!verify));
    Check(number, sub);
}

void Multiply()
{
    int A = random.Next(1, 11);
    int B = random.Next(1, 11);
    int product = A * B;
    Console.WriteLine("Multiplication game");
    Console.WriteLine($"{A} * {B}");
    do
    {
        answer = Console.ReadLine();
        verify = int.TryParse(answer, out number);
    } while ((answer == null) || (!verify));
    Check(number, product);
}

void Division()
{
    int A = 1;
    int B = 1;
    int remainder = 1;
    while (remainder != 0)
    {
        A = random.Next(1, 101);
        B = random.Next(1, 101);
        remainder = A % B;
    }
    int divide = A / B;
    Console.WriteLine("Division game");
    Console.WriteLine($"{A} / {B}");
    do
    {
        answer = Console.ReadLine();
        verify = int.TryParse(answer, out number);
    } while ((answer == null) || (!verify));
    Check(number, divide);
}

void Check(int input, int ans)
{
    if (input == ans)
    {
        Console.WriteLine("Your answer was correct! Type any key for the next question");
        point += 1;
    }
    else
        Console.WriteLine("Incorrect. Type any key for next question");
    Console.ReadLine();
}

void Score()
{
    Console.WriteLine($"Game over. Your final score is {point}. Press any key to go back to main menu.");
    Console.ReadLine();
}