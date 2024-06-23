using MathGame.patrickbo89;

var date = DateTime.UtcNow;
var gameEngine = new GameEngine();
var menu = new Menu();

string name = UserInterface.GetName();

menu.DisplayMenu(date, gameEngine, name);