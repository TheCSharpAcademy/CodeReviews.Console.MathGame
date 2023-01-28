using anajmowicz.MathGame.Models;

namespace anajmowicz.MathGame
{
    internal class Helpers
    {
        static List<Game> games = new();

        internal static void AddToHistory(GameType type, int gameScore)
        {
            games.Add(new Game
            {
                Date = DateTime.Now,
                Score = gameScore,
                Type = type,
            });
        }

        internal static void PrintGames()
        {
            Console.Clear();
            Console.WriteLine("Games history:");
            Console.WriteLine("-----------------------");

            foreach (Game game in games)
            {
                Console.WriteLine($"{game.Date} - {game.Type}: {game.Score} pts");
            }

            Console.WriteLine("-----------------------\n");
            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadLine();
        }

        internal static string ValidateResult(string result)
        {
            while(string.IsNullOrEmpty(result) || !Int32.TryParse(result,out _))
            {
                Console.WriteLine("Your answers has to be an integer. Please enter a valid number.");
                Console.Write("> ");
                result = Console.ReadLine();
            }
            return result;
        }

        internal static string ValidateSelection(string selection)
        {
            string[] possibleAnswers = {"a", "s", "m", "d", "v", "q"};
            while(!possibleAnswers.Contains(selection.Trim().ToLower())){
                Console.WriteLine("Incorrect choice. Try again");
                Console.Write("> ");
                selection = Console.ReadLine().Trim().ToLower();
            }
            return selection;
        }

        internal static string GetName()
        {
            Console.WriteLine("Welcome to Math Game. What's your name?");
            Console.Write("> ");
            string name = Console.ReadLine();

            while(string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name can't be empty.");
                Console.Write("> ");
                name = Console.ReadLine();
            }
            return name;
        }

        internal static void ShowIntro()
        {
            Console.WriteLine(@"
                 __  __       _   _        ____                      
                |  \/  | __ _| |_| |__    / ___| __ _ _ __ ___   ___ 
                | |\/| |/ _` | __| '_ \  | |  _ / _` | '_ ` _ \ / _ \
                | |  | | (_| | |_| | | | | |_| | (_| | | | | | |  __/
                |_|  |_|\__,_|\__|_| |_|  \____|\__,_|_| |_| |_|\___|
                                                     
                            Press any key to continue");
            Console.ReadLine();
        }
    }
}
