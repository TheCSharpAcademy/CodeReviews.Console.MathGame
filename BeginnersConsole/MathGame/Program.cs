using MathGame;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

Menu menu = new(configuration);
DateTime date = DateTime.UtcNow;

List<string> games = new();

string name = Helpers.GetName();

menu.ShowMenu(name, date);