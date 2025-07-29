using MathGame.Models;

namespace MathGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Math Game!");
            string name = Helpers.GetName();

            // Add difficulty level

            Menu menu = new();
            MainGame mainGame = new();

            do
            {
                int selectedOp = menu.ShowMenu(name);

                int rounds = 5;
                int score = 0;
                GameType game = GameType.Default;

                if (selectedOp == 6)
                {
                    Console.WriteLine("Sorry to see you go, goodbye");
                    break;
                }
                else if (selectedOp == 5)
                {
                    Helpers.ShowHistory();
                }
                else
                {
                    for (int i = 0; i < rounds; i++)
                    {
                        (score, game) = mainGame.PlayGame(score, selectedOp);
                    }
                    Helpers.AddToHistory(score, game);
                    Console.WriteLine($"Game Over. Your score is {score}. Press any key to continue...");
                    Console.ReadLine();
                }

            }
            while (true);
        }
    }
}
