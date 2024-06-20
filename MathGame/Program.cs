// Top Level Set-Up

Console.Write("Please enter your name: ");
string? name = Console.ReadLine();
var date = DateTime.Now;

// Menu
Console.WriteLine("------------------------------------------------------");
Console.WriteLine($"Welcome to The Math Game, {name}.\nThe time is {date.Hour}:{date.Minute} on {date.Month}/{date.Day}/{date.Year}.\n");
Console.WriteLine($@"Please select a game to play from the list below:
A - Addition
S - Subtraction
M - Multiplication
D - Division
R - Random
Q - Quit");
Console.WriteLine("------------------------------------------------------");

// Addition Game

// Subtraction Game

// Multiplication Game

// Divsion Game