// See https://aka.ms/new-console-template for more information

int a = 0;
int b = 0;

string? userInput = "";

Console.WriteLine("Welcome to my Math's Game!");
Console.WriteLine("Please choose values for two numbers");
Console.WriteLine("Enter value for first number: ");
if (userInput != null)
{
    userInput = Console.ReadLine();
    int.TryParse(userInput, out a);
}
Console.WriteLine("Enter value for second number: ");
if (userInput)
Console.WriteLine("Please choose from the following operations");
Console.WriteLine("1. Add");
Console.WriteLine("2: Substract");
Console.WriteLine("3. Multiply");
Console.WriteLine("4: Divide ");



