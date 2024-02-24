using MathGame;

string name = UserInputHandler.AskForUserName();

MessageHandler.WelcomeMessage(name);

Menu.ShowMenu();

Console.WriteLine("Press any key to exit ...");
Console.ReadLine();
