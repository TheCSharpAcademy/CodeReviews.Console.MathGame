using MathGame.gsharshavardhan;

var menu = new Menu();
string userName = GetName();
menu.ShowMenu(userName);
string GetName()
{
    Console.WriteLine("Please type your name:");
    var userName = Console.ReadLine();
    return userName;
}
