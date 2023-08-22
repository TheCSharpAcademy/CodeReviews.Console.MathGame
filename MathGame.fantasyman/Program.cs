// Math game program to play math games
List<string> results = new List<string>();


// Function to generate numbers
int[] GenerateNumbers(int level)
{
    Random rnd = new Random();
    int[] numberArray;
    if (level == 1)
    {
        numberArray = new int[2] { rnd.Next(1, 9), rnd.Next(1, 9)};
        return numberArray;
    }
    else if (level == 2)
    {
        numberArray = new int[2] { rnd.Next(10, 99), rnd.Next(10, 99) };
        return numberArray;
    }
    else
    {
        numberArray = new int[2] { rnd.Next(100, 999), rnd.Next(100, 999) };
        return numberArray;
    }
}

// Function to play game
void PlayGame()
{
    Console.Write("What maths operator would you like to use? ");
    string userOperator = Console.ReadLine();
    if (userOperator == "+")
    {
        for (int i = 0; i < 5; i++)
        {
            int[] numbers = GenerateNumbers(1);
            PlayAddition(numbers);
        }
        foreach (string item in results)
        {
            Console.WriteLine(item);
        }
    }
}

// Function to play addition problem
void PlayAddition(int[] numbers)
{
    string outputString = $"{numbers[0]} + {numbers[1]} = ";
    string answer = $"{numbers[0] + numbers[1]}";
    Console.Write(outputString);
    int.TryParse(Console.ReadLine(), out int userAnswer);
    if (userAnswer == (numbers[0] + numbers[1]))
    {
        results.Add($"{outputString}{answer} Result: Passed");
    }
    else
    {
        results.Add($"{outputString} {answer} Result: Failed with {userAnswer}");
    }
}


PlayGame();