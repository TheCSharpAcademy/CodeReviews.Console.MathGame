using CSharpAcademy_MathsGame;

string? name = GetName();
DateTime date = DateTime.UtcNow;
var menu = new Menu();

menu.ShowMenu(name, date);

string? GetName()
{
    Console.Write("Please enter your name: ");

    name = Console.ReadLine();
    return name;
}

// https://www.youtube.com/watch?v=_T7896oRq3Q&list=PL4G0MUH8YWiD1p5ySamqNWAaWlnwp1Vip&index=21
// TODO: Add in difficulty levels
// TODO: Add in round timers
// TODO: Add timer results to ShowScores
// TODO: Allow a user to select round size
// TODO: Round size to show on score so if roundsize was 10 then score should be x/10
// TODO: Build a random game mode which generates a round using all gametypes
