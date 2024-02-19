using System.ComponentModel.DataAnnotations;
using System.IO.Pipes;
using System.Numerics;
using MathGame;

var sg = new SavedGame();

OpeningSequence(sg);
PrintMenu(sg);

var isPlaying = true;

while (isPlaying)
{
    var selection = Console.ReadLine();
    sg.Operation = ToMathOpEnum(selection);
    Func<int, int, int> operation = GetMathOp(selection);

    var n1 = new Random().Next(1, 101);
    var n2 = new Random().Next(1, 101);

    if (sg.Operation is MathOperation.Division)
    {
        var possibleDivisors = Enumerable.Range(1, n1)
            .Where(n => n1 % n == 0)
            .ToList()
            ;
        n2 = possibleDivisors[new Random().Next(possibleDivisors.Count())];
    }

    sg.Operands = Tuple.Create(n1, n2);

    Console.WriteLine();
    Console.WriteLine($"What is {n1} {GetMathOpPhrase(selection)} {n2}?");

    var answer = String.Empty;

    do
    {
        Console.Write("Your answer: ");
        answer = Console.ReadLine();
        Console.WriteLine();
    } while (!int.TryParse(answer, out _));

    if (int.Parse(answer) == operation(n1, n2))
    {
        Console.WriteLine("Congratulations! That's correct.");
        sg.IsAnswerCorrect = true;
    }
    else
    {
        Console.WriteLine($"Sorry, that's wrong. The correct answer is {operation(n1, n2)}");
    }

    Save(sg);

    Console.WriteLine("Would you like to play again (y/n)?");
    isPlaying = Console.ReadLine()?.ToLower() == "y";
}
Console.WriteLine("Thanks for playing! :)");

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
}

static void PrintMenu(SavedGame sg)
{
    Console.WriteLine();
    Console.WriteLine($"Hello, {sg.Username}! Please select which operation you'd like to practice today.");
    Console.WriteLine(" * a - Addition");
    Console.WriteLine(" * d - Division");
    Console.WriteLine(" * m - Multiplication");
    Console.WriteLine(" * s - Subtraction");
    Console.WriteLine();
    Console.WriteLine("If you've like to see your past game results, enter \"r\"");
}

static void Save(SavedGame sg)
{
    var path = AppDomain.CurrentDomain.BaseDirectory + "games.txt";
    File.AppendAllText(path, sg.ToFileString());
}

static List<SavedGame> RetrieveGames(string username)
{
    var path = AppDomain.CurrentDomain.BaseDirectory + "games.txt";
    return File.ReadAllLines(path)
        .Select(SavedGame.ParseFromFile)
        .Where(s => s.Username == username)
        .ToList()
        ;
}

static void PrintPastGames(List<SavedGame> games)
{
    foreach(var g in games)
    {
        Console.WriteLine(g.ToGameString());
    }
}
