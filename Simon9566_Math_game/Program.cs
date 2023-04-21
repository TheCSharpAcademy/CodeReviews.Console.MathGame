// Start of the program, get the player name, current date and clear the console to allow for the main loop

Console.WriteLine("Please enter your name");
string player_name = Console.ReadLine();
var date = DateTime.Now;
Console.Clear();

Console.WriteLine($"Hello {player_name}, {date} is a good time to practice your mathematical skills. Are you ready?");
// Main menu
void Print_menu()
{
    Console.WriteLine();
    Console.WriteLine("Select your desired difficulty level");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("E - Easy, addition only");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("M - Medium, addition and subtraction");
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("D - Difficult, addition subtraction and multiplication");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("S- Superb,  addition has been replaced with division, all results are to be given with 2 decimal spaces, even if those are zeroes :)");
    Console.ResetColor();
}

// Getting the difficulty and constructing main play loops based on them

string difficulty = "tmp";
var difficulties = new Dictionary<string, string>();
difficulties.Add("E", "easy");
difficulties.Add("M", "medium");
difficulties.Add("D", "difficult");
difficulties.Add("S", "special");


int a = 0;
int b = 0;
bool playing = true;
int guess = 0;
int points = 0;
string result = "";
int history_key = 1;

Dictionary< int, string> history = new Dictionary<int, string>();

Random random = new Random();

void Display_history()
{
    foreach(int key in history.Keys)
    {
        Console.WriteLine($"{key} : {history[key]}");
    }
}

void Increment_history(string operation)
{
    history.Add(history_key, operation);
    history_key++;
}

void Ask_continue()
{
    Console.WriteLine("If you want to stop enter \"N\"");
    string choice = Console.ReadLine().ToUpper();
    if (choice == "N")
    {
        playing = false;
    }
}

int Get_large()
{
    int tmp = random.Next(100, 999);
    return tmp;
}

int Get_small()
{
        int tmp = random.Next(3, 100);
    return tmp;
}

void Validate_guess()
{
     var tmp = Console.ReadLine();
     bool  parse_result = int.TryParse(tmp, out guess);
}

void Ask_addition()
{
    a = Get_large();
    b = Get_large();
    result = $"{a + b}";
    Console.WriteLine($"What is {a} + {b}?");
    Validate_guess(); 
    if (guess == a + b)
    {
        Console.WriteLine("You are correct");
        points++;
        result = $"{a} + {b} = {a + b}";
        Increment_history(result);
    }
    else
    {
        Console.WriteLine($"Unfortunately the correct answer was {result}");
    }
}

void Ask_subtraction()
{
    a = 0;
    b = 0;
    while (a <= b)
    { 
        a = Get_large();
        b = Get_large();
    }
    result = $"{a - b}";
    Console.WriteLine($"What is {a} - {b}?");
    Validate_guess();  
    if (guess == a - b)
    {
        Console.WriteLine("You are correct");
        points++;
        result = $"{a} - {b} = {a - b}";
        Increment_history(result);
    }
    else
    {
        Console.WriteLine($"Unfortunately the correct answer was {result}");
    }
}


void Ask_multiplication()
{
    a = Get_small();
    b = Get_small();
    result = $"{a * b}";
    Console.WriteLine($"What is {a} * {b}?");
    Validate_guess(); 
    if (guess == a * b)
    {
        Console.WriteLine("You are correct");
        points++;
        result = $"{a} * {b} = {a * b}";
        Increment_history(result);
    }
    else
    {
        Console.WriteLine($"Unfortunately the correct answer was {a * b}");
    }
}

void Ask_division()
{
    a = Get_large();
    b = Get_small();
    result = $"{a / b}";
    Console.WriteLine($"What is {a} / {b}?");
    Validate_guess();
    if (guess == a/b)
    {
        Console.WriteLine("You are correct");
        points++;
        result = $"{a} / {b} = {a / b}";
        Increment_history(result);
    }
    else
    {
        Console.WriteLine($"Unfortunately the correct answer was {a/b}");
    }
}


while (playing)
{
    Print_menu();
    while (difficulties.ContainsKey(difficulty) == false)
    {
        difficulty = Console.ReadLine().ToUpper();
    }

    if (difficulties[difficulty] == "history")
    {
        Display_history();
    }

    if (difficulties[difficulty] == "easy")
    {
        for (int i = 0; i < 10; i++)
        {
            Ask_addition();
        }
    }
    else if (difficulties[difficulty] == "medium")
    {
        int operation = random.Next(1, 3);
        if (operation == 1)
        {
            for (int i = 0; i < 10; i++)
            {
                Ask_addition();
            }
        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                Ask_subtraction();
            }
        }
    }
    else if (difficulties[difficulty] == "difficult")
    {
        int operation = random.Next(1, 4);
        if (operation == 1)
        {
            for (int i = 0; i < 10; i++)
            {
                Ask_addition();
            }
        }
        else if (operation == 2)
        {
            for (int i = 0; i < 10; i++)
            {
                Ask_subtraction();
            }
        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                Ask_multiplication();
            }
        }
    }
    else
    {
        int operation = random.Next(1, 4);
        if (operation == 1)
        {
            for (int i = 0; i < 10; i++)
            {
                Ask_division();
            }
        }
        else if (operation == 2)
        {
            for (int i = 0; i < 10; i++)
            {
                Ask_subtraction();
            }
        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                Ask_multiplication();
            }
        }
    }
    Console.WriteLine("What do you want to do now,\n H -  acces history");
    Print_menu();
    Ask_continue();
    difficulties.Add("H", "history");
}
