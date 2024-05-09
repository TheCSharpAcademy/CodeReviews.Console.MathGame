using MyFirstProgram;
using static MyFirstProgram.Helpers;


var name = GetName();
Console.Clear();
var utcDate = GetDate();
WelcomeMessgae(name, utcDate);


List<GameHistory> gameHistories = new List<GameHistory>();
Menu menu = new Menu();
menu.ShowMenu(gameHistories);



