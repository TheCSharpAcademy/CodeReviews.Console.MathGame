// See https://aka.ms/new-console-template for more information

using System.ComponentModel.Design;
using System.Numerics;

Random random = new Random();
int a = random.Next(1, 100); // Generates a random number between 1 and 99
int b = random.Next(1, 100); // Generates a random number between 1 and 99

string? guess = "";
string? calculationSelector = "";

StartGame();

int AdditionGame()
{
    int result =  a + b;
    return result;
}
int SubtractionGame()
{
    int result = a - b;
    return result;
}
int MultiplicationGame()
{
    int result = a * b;
    return result;
}
int DivisionGame()
{
    try
    {
        int result = a / b;
        return result;
    }
    catch (DivideByZeroException e)
    {
        throw new DivideByZeroException("Error: Division by zero is not allowed.");
    }
}

    string HasWon(int guess)
{

}

void StartGame()
{
    Console.WriteLine("Welcome to my Math's Game!");
    Console.WriteLine("Please guess the correct result of two random numbers depending on the operation selected");
    Console.WriteLine("Please now choose from the following operations");
        Console.WriteLine("1. Add");
        Console.WriteLine("2: Substract");
        Console.WriteLine("3: Multiply");
        Console.WriteLine("4: Divide ");

