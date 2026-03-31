using MathGame;

List<string> pastGames = new List<string>();

string name = Helpers.GetName();
DateTime date = DateTime.Now;

Menu menu = new();

menu.ShowMenu(name, date);

// while (true)
// {
//     
//
//     string menuSelection = Console.ReadLine();
//     
//     if (menuSelection == "1")
//     {
//         int result = PlayGame(questions, answers);
//         Console.WriteLine($"You got {result} / {questions.Length} correct!");
//         
//         pastGames.Add($"{result} / {questions.Length} - {((decimal)result / questions.Length):P0}");
//     }
//     else if (menuSelection == "2")
//     {
//         PrintPastGames(pastGames);
//     }
//     else if (menuSelection == "x")
//     {
//         break;
//     }
//     else
//     {
//         Console.WriteLine("Incorrect menu selection. Please try again.");
//     }
// }
//
//
// // Gets input from user and increments correct if it matches the answer
// int PlayGame(string[] questions, int[] answers)
// {
//     int correct = 0;
//     
//     for (int i = 0; i < questions.Length; i++)
//     {
//         Console.Write($"What does {questions[i]} = ");
//         int userInput = int.Parse(Console.ReadLine());
//
//         if (userInput == answers[i])
//         {
//             Console.WriteLine("Correct!");
//             correct++;
//         }
//         else
//         {
//             Console.WriteLine("Incorrect :(");
//         }
//     }
//     
//     return correct;
// }
//
// void PrintPastGames(List<string> games)
// {
//     Console.WriteLine("Past Games:");
//     foreach (string game in games)
//     {
//         Console.WriteLine(game);
//     }
// }