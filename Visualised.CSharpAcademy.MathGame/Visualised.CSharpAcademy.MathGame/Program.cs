// This program requires https://www.nuget.org/packages/Z.Expressions.Eval/ & https://www.nuget.org/packages/System.Linq.Dynamic.Core

using Visualised.CSharpAcademy.MathGame;

var menu = new Menu();
var date = DateTime.Now;
string userName = Helpers.GetUserName();

menu.PrintMenu(userName, date);

Console.ReadLine();