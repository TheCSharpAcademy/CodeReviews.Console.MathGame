namespace MathGame;

class Program
{
    static void Main()
    {
        //add a list to store all results
        List<string> previousGames = new();

        //the do while loop returns to the main menu until the user exits
        string response;
        do
        {
            response = Menu.HomeMenu();

            switch (response)
            {
                //new game
                case "1":
                    //get gamemode and validate input
                    string gameMode = Menu.GetGameMode();
                    string difficulty = Menu.GetDifficulty();
                    int numberOfQuestions = Menu.GetNumberOfQuestions();

                    //create a new game
                    GameEngine game = new(gameMode, difficulty, numberOfQuestions);
                    previousGames.Add(game.StartGame());
                    break;

                //view results
                case "2":
                    foreach (string previousGame in previousGames)
                    {
                        Console.WriteLine("--------------------\n"
                            + $"Game: {previousGames.IndexOf(previousGame) + 1}\n"
                            + $"{previousGame}\n"
                            + "--------------------\n");
                    }
                    //allow the user to decide when to return to the main menu:
                    Console.WriteLine("Press enter to return to the main menu");
                    Console.ReadLine();
                    Console.Clear();
                    break;

                default: Console.Clear(); break;
            }
        }
        while (response.Equals("1") || (response.Equals("2")));
    }
}