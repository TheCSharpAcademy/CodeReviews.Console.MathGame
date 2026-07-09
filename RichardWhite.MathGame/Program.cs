using System;
using System.Collections.Generic;

// List to store the history of previous games
List<string> gameHistory = [];

bool keepPlaying = true;

while (keepPlaying)
{
    Console.WriteLine ("--------------------------------------------------------");
    Console.WriteLine ("What math game would you like to play? \nType the corresponding number and press 'Enter'" +
        "\n'1' for Addition" +
        "\n'2' for Subtraction" +
        "\n'3' for Multiplication" +
        "\n'4' for Division" +
        "\n'5' for Game History" +
        "\n'6' to Exit");
    Console.WriteLine ("--------------------------------------------------------");

    string? input = Console.ReadLine ();
    int? choice = int.TryParse (input, out int result) ? result : null;

    if (choice != null && choice >= 1 && choice <= 6)
    {
        switch (choice)
        {
            case 1: PlayGame ("Addition", "+", (a, b) => a + b); break;
            case 2: PlayGame ("Subtraction", "-", (a, b) => a - b); break;
            case 3: PlayGame ("Multiplication", "x", (a, b) => a * b); break;
            case 4: PlayGame ("Division", "/", (a, b) => a / b, isDivision: true); break;
            case 5: ShowHistory (); break;
            case 6: keepPlaying = false; Console.WriteLine ("Thanks for playing!"); break;
        }
    }
    else
    {
        Console.WriteLine ("Invalid input. Please enter a number between 1 and 6.\n");
    }
}

void PlayGame (string gameName, string symbol, Func<int, int, int> operation, bool isDivision = false)
{
    Console.WriteLine ($"\n--- Starting {gameName} Game ---");
    Random random = new ();
    int score = 0;

    for (int i = 0; i < 5; i++)
    {
        int num1, num2;

        if (isDivision)
        {
            // Unique generation logic for perfect integer division
            while (true)
            {
                num1 = random.Next (0, 101);
                num2 = random.Next (1, 11);
                if (num1 % num2 == 0) break;
            }
        }
        else if (gameName == "Subtraction")
        {
            // Unique generation logic to prevent negative answers
            num1 = random.Next (0, 101);
            num2 = random.Next (0, num1 + 1);
        }
        else // Addition and Multiplication
        {
            num1 = gameName == "Multiplication" ? random.Next (0, 13) : random.Next (0, 51);
            num2 = gameName == "Multiplication" ? random.Next (0, 13) : random.Next (0, 51);
        }

        // Execute the dynamic operation math rule passed through the parameter
        int correctAnswer = operation (num1, num2);

        Console.Write ($"Question {i + 1}: {num1} {symbol} {num2} = ? ");
        _ = int.TryParse (Console.ReadLine (), out int userAnswer);

        if (userAnswer == correctAnswer)
        {
            Console.WriteLine ("Correct!");
            score++;
        }
        else
        {
            Console.WriteLine ($"Incorrect. The correct answer was {correctAnswer}.");
        }
    }

    Console.WriteLine ($"Game Over! You scored {score}/5.");
    gameHistory.Add ($"{gameName} Game: {score}/5 points");
}

void ShowHistory ( )
{
    Console.WriteLine ("\n--- Game History ---");
    if (gameHistory.Count == 0)
    {
        Console.WriteLine ("No games played yet!");
    }
    else
    {
        foreach (string entry in gameHistory)
        {
            Console.WriteLine ($"- {entry}");
        }
    }
    Console.WriteLine ("--------------------\n");
}
