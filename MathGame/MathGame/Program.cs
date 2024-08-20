using MathGame;

Console.Title = "Math Game";
Console.ForegroundColor = ConsoleColor.White;

UI display = new UI();
List<string> games = new List<string>();

display.Header();
string name = Helpers.GetName();
display.ShowMenu(name);

Console.ReadLine();

