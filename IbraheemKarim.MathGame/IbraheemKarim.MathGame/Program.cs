using IbraheemKarim.MathGame;

var dateAndTime = DateTime.UtcNow;

string username = GetUserName();

var menu = new Menu();

menu.ShowGreetings(username, dateAndTime);

ActionType action = menu.GetDesiredAction();

menu.ProcessActionType(action);






    string GetUserName()
{
    string name ="";
    do
    {
        Console.Clear();
        Console.Write("Hello, please enter your name: ");
        name = Console.ReadLine();
    }while(string.IsNullOrWhiteSpace(name));

    return name;
}









