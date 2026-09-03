using System;
using System.Collections.Generic;
using System.Text;

namespace MathGame;

public class UI
{
    List<string> hist = new();
    public int totalCount = 0;
    public int winCount = 0;
    public bool contPlaying = true;
    private void DisplayMenu()
    {
        Console.WriteLine("-----------\tWelcome to the math game!\t-----------");
    }
    private int DisplayOptions()
    {
        Console.WriteLine("Please select from the options below for your challenge.");
        Console.WriteLine("\n1. Addition");
        Console.WriteLine("2. Subtraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");
        Console.WriteLine("5. History");
        Console.WriteLine("6. Quit");

        Console.Write("\nSelection: ");
        string input = Console.ReadLine();

        while (!int.TryParse(input, out int result) || result < 1 || result > 6)
        {
            Console.WriteLine("\nPlease select from the options below for your challenge.");
            Console.WriteLine("\n1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. History");
            Console.WriteLine("6. Quit");

            Console.WriteLine("\nInvalid input. Please try again:");
            Console.Write("\nSelection: ");
            input = Console.ReadLine();
        }
        return int.Parse(input);
    }

    public void StartGame()
    {
        DisplayMenu();
        do
        {

            int input = DisplayOptions();
            switch (input)
            {
                case 1:
                    bool resultAdd = Engine.Addition();
                    if (resultAdd)
                        winCount++;
                    totalCount++;
                    if (resultAdd)
                        hist.Add("Addition - WIN");
                    else hist.Add("Addition - LOSS");
                    Console.WriteLine($"Score: {winCount}");
                    break;
                case 2:
                    bool resultSub = Engine.Subtraction();
                    if (resultSub)
                        winCount++;
                    totalCount++;
                    if (resultSub)
                        hist.Add("Subtraction - WIN");
                    else hist.Add("Subtraction - LOSS");
                    Console.WriteLine($"Score: {winCount}");
                    break;
                case 3:
                    bool resultMul = Engine.Multiplication();
                    if (resultMul)
                        winCount++;
                    totalCount++;
                    if (resultMul)
                        hist.Add("Multiplication - WIN");
                    else hist.Add("Multiplication - LOSS");
                    Console.WriteLine($"Score: {winCount}");
                    break;
                case 4:
                    bool resultDiv = Engine.Division();
                    if (resultDiv)
                        winCount++;
                    totalCount++;
                    if (resultDiv)
                        hist.Add("Division - WIN");
                    else hist.Add("Division - LOSS");
                    Console.WriteLine($"Score: {winCount}");
                    break;
                case 5:
                    Console.WriteLine();
                    foreach (string history in hist)
                    {
                        Console.WriteLine(history);
                        Console.WriteLine("-----------\t ------- \t-----------");
                    }
                    break;
                case 6:
                    contPlaying = false;
                    break;
            }
            Console.WriteLine();
        } while (contPlaying);
    }
}