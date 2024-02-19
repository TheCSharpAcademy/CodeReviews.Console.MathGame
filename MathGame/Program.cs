using System.IO.Pipes;
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

    var sg = new SavedGame();

    switch (operation)
    {
        case ("a"):
            Addition(sg);
            break;
    }
}

static void Addition(SavedGame sg)
{
    Console.Write("You've chosen addition!");
    sg.Operation = MathOperation.Addition;

    var firstNum = new Random().Next(1, 101);
    var secondNum = new Random().Next(1, 101);

    Console.WriteLine($"What is {firstNum} + {secondNum}?");
    Console.Write("Your answer: ");

    var answer = Console.ReadLine();

    try
    {
        if (int.Parse(answer) == firstNum + secondNum)
        {

        }
    }
    catch(Exception e)
    {
        Console.WriteLine("Something went wrong! Make sure your answer uses numerical characters only.");
    }

}

static void SaveGame(string operation, List<int> numbers, bool IsAnswerCorrect)
{

}

static List<SavedGame> RetrieveGame(string username)
{
    return null;
}
