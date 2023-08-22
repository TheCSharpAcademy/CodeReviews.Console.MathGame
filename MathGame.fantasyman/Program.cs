// Math game program to play math games

// Function to generate numbers
int[] GenerateNumbers(int low, int high)
{
    Random rnd = new Random();
    int[] numberArray = { rnd.Next(low, high + 1), rnd.Next(low, high + 1) };
    return numberArray;
}

// Function to play addition problem
bool PlayAddition(int level)
{
    if (level == 1)
    {
        int[] numbers = GenerateNumbers(1, 9);
        Console.Write($"{numbers[0]} + {numbers[1]} = ");
        int.TryParse(Console.ReadLine(), out int answer);
        if (answer == (numbers[0] + numbers[1]))
        {
            return true;
        }
        return false;
    }
    return false; // TODO: add more levels
}

if (PlayAddition(1) == true)
{
    Console.WriteLine("Correct");
}
else
{
    Console.WriteLine("Incorrect");
}