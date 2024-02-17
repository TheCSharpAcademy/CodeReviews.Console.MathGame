using MathGameUI;

string name = UserInputHandler.AskForUserName();

MessageHandler.WelcomeMessage(name);

Menu.ShowMenu();

Console.ReadLine();
