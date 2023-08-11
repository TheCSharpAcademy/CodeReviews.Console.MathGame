using MathGame.CharlieDW;

var menu = new UserMenu();
DateTime date = DateTime.UtcNow;
string? userName = Helpers.GetName();

menu.ShowMenu(userName, date);


