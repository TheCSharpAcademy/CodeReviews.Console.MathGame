using System;

Console.WriteLine("Welcome to Math game");
string userName = GetUserName();

StartMenu(userName);
string getUserName()
{
    Console.WriteLine("Please enter your name:");
    string name = Console.ReadLine();
    return name;
}