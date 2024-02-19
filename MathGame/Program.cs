using System.ComponentModel.DataAnnotations;
using System.IO.Pipes;
using System.Numerics;
using System.Threading.Channels;
using MathGame;

var current = new SavedGame();

OpeningSequence(current);

var isPlaying = true;

while (isPlaying)
{
    PrintMenu(current);
    var selection = Console.ReadLine() ?? "a";
    
    if (selection != "r")
    {
        MathPlay.PlayGame(current, selection);
    }
    else
    {
        var games = FileIO.RetrieveGames(current.Username);
        FileIO.PrintPastGames(current.Username, games);
    }

    Console.WriteLine("~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~");
    Console.Write("Would you like to play again (y/n)?");
    isPlaying = Console.ReadLine()?.ToLower() == "y";
}
Console.WriteLine("Thanks for playing! :)");

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