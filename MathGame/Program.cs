using MathGame;

OpeningSequence();

static void OpeningSequence()
{
    Console.WriteLine("Welcome to the Math Game!");
    Console.WriteLine("Please select which operation you'd like to practice today.");
    Console.WriteLine(" * a - Addition");
    Console.WriteLine(" * d - Division");
    Console.WriteLine(" * m - Multiplication");
    Console.WriteLine(" * s - Subtraction");

    var operation = Console.ReadLine();

    switch (operation)
    {
        case ("a"):
            break;
    }
}

static void Addition()
{
    Console.Write("You've chosen addition!");
    Console.WriteLine(" Let's begin!");
}

static void SaveGame(string operation, List<int> numbers, bool IsAnswerCorrect)
{

}

static List<SavedGame> RetrieveGame(string username)
{
    return null;
}
