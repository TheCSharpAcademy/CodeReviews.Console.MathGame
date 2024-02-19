using System.IO.Pipes;
using System.Numerics;
using MathGame;

var sg = new SavedGame();

OpeningSequence(sg);

var playing = true;

while (playing)
{
    var selection = Console.ReadLine();
    sg.Operation = ToMathOpEnum(selection);
    Func<int, int, int> operation = GetMathOp(selection);
}

static Func<int, int, int> GetMathOp(string operation) => operation switch
{
    "a" => (n1, n2) => n1 + n2,
    "d" => (n1, n2) => n1 / n2,
    "m" => (n1, n2) => n1 * n2,
    "s" => (n1, n2) => n1 - n2,
    _ => throw new ArgumentException("Mathematical operation not recognized."),
};

static MathOperation ToMathOpEnum(string operation) => operation switch
{
    "a" => MathOperation.Addition,
    "d" => MathOperation.Division,
    "m" => MathOperation.Multiplication,
    "s" => MathOperation.Subtraction,
    _ => throw new ArgumentException("Mathematical operation not recognized."),
};

static string GetMathOpPhrase(string operation) => operation switch
{
    "a" => "plus",
    "d" => "divided by",
    "m" => "times",
    "s" => "minus",
    _ => throw new ArgumentException("Mathematical operation not recognized."),
};

static void OpeningSequence(SavedGame sg)
{
    Console.WriteLine("Welcome to the Math Game!");
    Console.Write("Please enter your name: ");

    sg.Username = Console.ReadLine();

    PrintMenu(sg);
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

static void Save(SavedGame sg)
{

}

static List<SavedGame> RetrieveGames(string username)
{
    return null;
}
