using PRagudo.MathGame;

QuestionGenerator questionGenerator = new();
List<GameRecord> history = [];

int menuChoice;
int gameCounter = 0;
string answer;

while (true)
{
    Console.Clear();
    Console.WriteLine();

    Game.ShowMenu();
    menuChoice = Game.GetChoice("\nEnter choice: ", 1, 2);

    if (menuChoice == 1)
    {
        await Game.Execute(++gameCounter, history, questionGenerator);
    }
    else
    {
        Console.WriteLine("\nGames: ");

        if (history.Count == 0)
        {
            Console.WriteLine("\tNo games yet!");
        }
        else
        {
            Console.WriteLine("\n\tEnter 0 to display all games");
            int counter = 0;
            foreach (var name in history)
            {
                Console.WriteLine($"\tGame {++counter}");
            }

            int gameIdChoice = Game.GetChoice("\nEnter game id: ", -1, history.Count);
            Game.ShowGameHistory(gameIdChoice, history);
        }
    }

    while (true)
    {
        answer = Game.GetStringInput("\nPlay again? (y/n): ").ToLower().Trim();

        if (answer == "y" || answer == "n")
            break;

        Console.WriteLine("\nInvalid answer! Try again.");
    }

    if (answer == "n")
        break;
}