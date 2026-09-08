using System;
using System.Collections.Generic;
using System.Text;

namespace MathGame;

public class UI
{
    List<string> hist = new();
    public bool contPlaying = true;
    public int addWinCount = 0;
    public int subWinCount = 0;
    public int mulWinCount = 0;
    public int divWinConut = 0;

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
                    for (int i = 0; i < 6; i++)
                    {
                        bool resultAdd = Engine.Addition();
                        if (resultAdd)
                            addWinCount++;
                    }
                    hist.Add($"{DateTime.Now} - Addition - {addWinCount}");
                    Console.WriteLine($"\nScore: {addWinCount}");
                    break;
                case 2:
                    for (int i = 0; i < 6; i++)
                    {
                        bool resultSub = Engine.Subtraction();
                        if (resultSub)
                            subWinCount++;
                    }
                    hist.Add($"{DateTime.Now} - Subtraction - {subWinCount}");
                    Console.WriteLine($"\nScore: {subWinCount}");
                    break;
                case 3:
                    for (int i = 0; i < 6; i++) 
                    {
                        bool resultMul = Engine.Multiplication();
                    if (resultMul)
                        mulWinCount++;
                    }
                    hist.Add($"{DateTime.Now} - Multiplication - {mulWinCount}");
                    Console.WriteLine($"\nScore: {mulWinCount}");
                    break;
                case 4:
                    for (int i = 0; i < 6; i++)
                    {
                        bool resultDiv = Engine.Division();
                        if (resultDiv)
                            divWinConut++;
                    }
                    hist.Add($"{DateTime.Now} - Division - {divWinConut}");
                    Console.WriteLine($"\nScore: {divWinConut}");
                    break;
                case 5:
                    Console.WriteLine();
                    foreach (string history in hist)
                    {
                        Console.WriteLine(history);
                        Console.WriteLine("--------------------------------------------------");
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