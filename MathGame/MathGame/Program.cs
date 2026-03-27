using System.Collections.Generic;

string[] questions = ["9 x 9", "5 + 3", "6 - 2", "8 / 4", "7 * 5"];
int[] answers = [81, 8, 4, 2, 35];
List<string> pastGames = new List<string>();

while (true)
{
    showMainMenu();

    string menuSelection = Console.ReadLine();
    
    if (menuSelection == "1")
    {
        int result = playGame(questions, answers);
        Console.WriteLine($"You got {result} / {questions.Length} correct!");
        
        pastGames.Add($"{result} / {questions.Length} - {((decimal)result / questions.Length):P0}");
    }
    else if (menuSelection == "2")
    {
        printPastGames(pastGames);
    }
    else if (menuSelection == "x")
    {
        break;
    }
    else
    {
        Console.WriteLine("Incorrect menu selection. Please try again.");
    }
}



void showMainMenu()
{
    Console.WriteLine("Main Menu");
    Console.WriteLine("1. Play Math Game!");
    Console.WriteLine("2. Show Scores");
    Console.WriteLine("Enter x to exit");
}

// Gets input from user and increments correct if it matches the answer
int playGame(string[] questions, int[] answers)
{
    int correct = 0;
    
    for (int i = 0; i < questions.Length; i++)
    {
        Console.Write($"What does {questions[i]} = ");
        int userInput = int.Parse(Console.ReadLine());

        if (userInput == answers[i])
        {
            Console.WriteLine("Correct!");
            correct++;
        }
        else
        {
            Console.WriteLine("Incorrect :(");
        }
    }
    
    return correct;
}

void printPastGames(List<string> games)
{
    Console.WriteLine("Past Games:");
    foreach (string game in games)
    {
        Console.WriteLine(game);
    }
}