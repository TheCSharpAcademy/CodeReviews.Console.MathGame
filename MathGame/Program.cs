using System.IO.Pipes;
using MathGame;

OpeningSequence();

static void OpeningSequence()
{
    var sg = new SavedGame();

    Console.WriteLine("Welcome to the Math Game!");

    Console.Write("Please enter your name: ");
    sg.Username = Console.ReadLine();

    PrintMenu(sg);

    var playing = true;

    while (playing)
    {
        var operation = Console.ReadLine();

        switch (operation)
        {
            case "a":
                Addition(sg);
                break;
            case "d":
                break;
            case "m":
                break;
            case "s":
                break;
            default:
                Console.WriteLine("Looks ");
                break;
        }
    }
}

static void Addition(SavedGame sg)
{
    Console.Write("You've chosen addition!");
    sg.Operation = MathOperation.Addition;

    var firstNum = new Random().Next(1, 101);
    var secondNum = new Random().Next(1, 101);

    sg.Operands = new List<int>() { firstNum, secondNum };

    Console.WriteLine($"What is {firstNum} + {secondNum}?");
    Console.Write("Your answer: ");

    var answer = Console.ReadLine();

    try
    {
        if (int.Parse(answer) == firstNum + secondNum)
        {
            sg.IsAnswerCorrect = true;
            Console.WriteLine("Congratulations, that's correct! You win!");
        }
        else
        {
            Console.WriteLine($"Sorry, that's not correct. The correct answer is {firstNum + secondNum}");
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("Something went wrong! Make sure your answer uses numerical characters only.");
    }
    finally
    {
        Save(sg);
    }
}

static void Save(SavedGame sg)
{

}

static void PrintMenu(SavedGame sg)
{
    Console.WriteLine();
    Console.WriteLine($"Hello, {sg.Username}! Please select which operation you'd like to practice today.");
    Console.WriteLine(" * a - Addition");
    Console.WriteLine(" * d - Division");
    Console.WriteLine(" * m - Multiplication");
    Console.WriteLine(" * s - Subtraction");
}

static List<SavedGame> RetrieveGames(string username)
{
    return null;
}
