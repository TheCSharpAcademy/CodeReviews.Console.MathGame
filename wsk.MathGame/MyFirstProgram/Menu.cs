

namespace MyFirstProgram
{
    internal class Menu
    {
        internal Menu() { }

        internal void ShowMenu(List<GameHistory> gameHistories)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("What game would you like to play today? Choose from the options below" +
                    "\nV - View Previous Game History" +
                    "\nA - Addition" +
                    "\nS - Subtraction" +
                    "\nM - Multiplication" +
                    "\nD - Division" +
                    "\nQ - Quit The Game" +
                    "\n-------------------------------------------------------");


                string gameChoice = Console.ReadLine().Trim().ToLower();
                Console.Clear();
                GameEngine gameEngine = new GameEngine();
                int score = 0;
                switch (gameChoice)
                {
                    case "v":
                        Helpers.GetGameHistory(gameHistories);
                        break;
                    case "a":
                        gameEngine.AdditionGame(score, gameHistories);
                        break;
                    case "s":
                        gameEngine.SubtractionGame(score, gameHistories);
                        break;
                    case "m":
                        gameEngine.MultiplicationGame(score, gameHistories);
                        break;
                    case "d":
                        gameEngine.DivisionGame(score, gameHistories);
                        break;
                    case "q":
                        Helpers.ByeMessage();
                        break;
                }
            } while (true);
        }

        

        


    }
}
