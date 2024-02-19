using System.ComponentModel.DataAnnotations;
using System.IO.Pipes;
using System.Numerics;
using System.Threading.Channels;
using MathGame;

var username = OpeningSequence();

var isPlaying = true;

while (isPlaying)
{
    PrintMenu(username);
    var selection = Console.ReadLine() ?? "a";
    
    if (selection != "r")
    {
        try
        {
            MathPlay.PlayGame(username, selection);
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    else
    {
        var games = FileIO.RetrieveGames(username);
        FileIO.PrintPastGames(username, games);
    }

    Console.WriteLine("~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~");
    Console.Write("Would you like to play again (y/n)?");
    isPlaying = Console.ReadLine()?.ToLower() == "y";
}
Console.WriteLine("Thanks for playing! :)");

static string OpeningSequence()
{
    Console.WriteLine("Welcome to the Math Game!");
    Console.Write("Please enter your name: ");

    return Console.ReadLine();
}

static void PrintMenu(string username)
{
    Console.WriteLine();
    Console.WriteLine($"Hello, {username}! Please select which operation you'd like to practice today.");
    Console.WriteLine(" * a - Addition");
    Console.WriteLine(" * d - Division");
    Console.WriteLine(" * m - Multiplication");
    Console.WriteLine(" * s - Subtraction");
    Console.WriteLine();
    Console.WriteLine("If you've like to see your past game results, enter \"r\"");
}