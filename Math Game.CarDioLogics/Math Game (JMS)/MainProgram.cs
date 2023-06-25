using Math_Game__JMS_;

var date = DateTime.UtcNow;

var games = new List<string>();

string name = GameLogic.GetName();

GameLogic.WelcomeMessage(date, name);

GameLogic.ShowMenu(games);