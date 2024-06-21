
using Math;

var date = DateTime.UtcNow;
string? name = GetName();
var querries = questiondToAnswer();


var gameHistory = new List<string>();

var selection = new SelectionMenu();

selection.Selection(name, date, querries);
string? GetName()
{
    Console.WriteLine("Hello! please enter your name to play the game");
    Console.WriteLine("............................................");
    var name = Console.ReadLine();
    while (string.IsNullOrEmpty(name))
    {
        Console.WriteLine("Inalid input, please enter your name");
        name = Console.ReadLine();
    }
    return name;
}

int questiondToAnswer()
{
    Console.Write("How many questions do you want to answer? ");
    string? questions = Console.ReadLine();
    while (string.IsNullOrEmpty(questions) || !int.TryParse(questions, out _))
    {
        Console.WriteLine("Invalid entry, please enter a numerical entry");
        questions = Console.ReadLine();

    }
    return int.Parse(questions);
}


Console.ReadLine();





