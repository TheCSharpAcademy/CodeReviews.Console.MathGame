// Math game program to play math games

// Initialising a list to store results
List<string> results = new List<string>();


// Function to generate numbers
int[] GenerateNumbers(int flag)
{
    Random rnd = new Random();
    int[] numberArray;
    if (flag == 1)
    {
        numberArray = new int[2] { rnd.Next(1, 99), rnd.Next(1, 99)};
        return numberArray;
    }
    else
    {
        while (true)
        {
            numberArray = new int[2] { rnd.Next(1, 99), rnd.Next(1, 99) };
            if ((numberArray[0] % numberArray[1] == 0) && (numberArray[0] != numberArray[1]))
            {
                return numberArray;
            }
        }
    }
}

// Function to play game
void PlayGame()
{
    Console.Clear();
    Console.WriteLine(@$"What game would you like to play today?:
    A - Addition
    S - Subtraction
    M - Multiplication
    D - Division
    P - Display Results
    Q - Quit the program");
    Console.WriteLine("---------------------------------");

    char userOperator = Console.ReadKey(true).KeyChar;
    int[] numbers = GenerateNumbers(1);
    if (userOperator == 'a')
    {
        Console.Clear();
        Console.WriteLine("Addition game selected");
        PlayAddition(numbers);
    }
    else if (userOperator == 's')
    {
        Console.Clear();
        Console.WriteLine("Subtraction game selected");
        PlaySubtraction(numbers);
    }
    else if (userOperator == 'm')
    {
        Console.Clear();
        Console.WriteLine("Multiplication game selected");
        PlayMultiplacation(numbers);
    }
    else if (userOperator == 'd')
    {
        Console.WriteLine("Division game selected");
        numbers = GenerateNumbers(2);
        PlayDivision(numbers);
    }
    else if (userOperator == 'p')
    {
        Console.Clear();
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Results: ");
        foreach (string item in results)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("--------------------------------");
        Console.ReadKey();
    }
    else if (userOperator == 'q')
    {
        Console.Clear();
        Console.WriteLine("Goodbye");
        Environment.Exit(1);
    }
    else
    {
        Console.WriteLine("Invalid input");
    }
}

void PlayAddition(int[] numbers)
{
    string outputString = $"{numbers[0]} + {numbers[1]} = ";
    int answer = numbers[0] + numbers[1];
    Console.Write(outputString);
    int.TryParse(Console.ReadLine(), out int userAnswer);
    if (userAnswer == answer)
    {
        results.Add($"{outputString}{answer} Passed");
    }
    else
    {
        results.Add($"{outputString}{answer} Failed ({userAnswer})");
    }
}

void PlaySubtraction(int[] numbers)
{
    string outputString = $"{numbers[0]} - {numbers[1]} = ";
    int answer = numbers[0] - numbers[1];
    Console.Write(outputString);
    int.TryParse(Console.ReadLine(), out int userAnswer);
    if (userAnswer == answer)
    {
        results.Add($"{outputString}{answer} Passed");
    }
    else
    {
        results.Add($"{outputString}{answer} Failed ({userAnswer})");
    }
}

void PlayMultiplacation(int[] numbers)
{
    string outputString = $"{numbers[0]} x {numbers[1]} = ";
    int answer = numbers[0] * numbers[1];
    Console.Write(outputString);
    int.TryParse(Console.ReadLine(), out int userAnswer);
    if (userAnswer == answer)
    {
        results.Add($"{outputString}{answer} Passed");
    }
    else
    {
        results.Add($"{outputString}{answer} Failed ({userAnswer})");
    }
}

void PlayDivision(int[] numbers)
{
    string outputString = $"{numbers[0]} / {numbers[1]} = ";
    int answer = numbers[0] / numbers[1];
    Console.Write(outputString);
    int.TryParse(Console.ReadLine(), out int userAnswer);
    if (userAnswer == answer)
    {
        results.Add($"{outputString}{answer} Passed");
    }
    else
    {
        results.Add($"{outputString}{answer} Failed ({userAnswer})");
    }
}


while (true)
{
    PlayGame();
}
