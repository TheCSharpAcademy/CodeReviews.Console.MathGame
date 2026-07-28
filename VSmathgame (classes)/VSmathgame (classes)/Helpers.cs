
using VSmathgame__classes_.Models;

namespace VSmathgame__classes_
{
    internal class Helpers
    {
        public static List<Game> games = new List<Game>()
       
        // field created to access list outside of the top level document

       {

        new Game { Date = DateTime.Now.AddDays(1), Type = GameType.Addition, Score = 5 },
        new Game { Date = DateTime.Now.AddDays(2), Type = GameType.Multiplication, Score = 4 },
        new Game { Date = DateTime.Now.AddDays(3), Type = GameType.Division, Score = 4 },
        new Game { Date = DateTime.Now.AddDays(4), Type = GameType.Subtraction, Score = 3 },
        new Game { Date = DateTime.Now.AddDays(5), Type = GameType.Addition, Score = 1 },
        new Game { Date = DateTime.Now.AddDays(6), Type = GameType.Multiplication, Score = 2 },
        new Game { Date = DateTime.Now.AddDays(7), Type = GameType.Division, Score = 3 },
        new Game { Date = DateTime.Now.AddDays(8), Type = GameType.Subtraction, Score = 4 },
        new Game { Date = DateTime.Now.AddDays(9), Type = GameType.Addition, Score = 4 },
        new Game { Date = DateTime.Now.AddDays(10), Type = GameType.Multiplication, Score = 1 },
        new Game { Date = DateTime.Now.AddDays(11), Type = GameType.Subtraction, Score = 0 },
        new Game { Date = DateTime.Now.AddDays(12), Type = GameType.Division, Score = 2 },
        new Game { Date = DateTime.Now.AddDays(13), Type = GameType.Subtraction, Score = 5 },

       };
        
        internal static void PreviousGames()
        {

            var gamesToPrint = games.Where(prevgame => prevgame.Date > new DateTime(2026, 01, 01)).OrderByDescending(prevgame => prevgame.Score);
            Console.Clear();
            Console.WriteLine("Game History:");

            foreach (var game in gamesToPrint)
            {
                Console.WriteLine($"{game.Date} {game.Type} {game.Score} pts ");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadLine();


        }
internal static void AddToHistory(int gamescore, GameType gameType)
{
            games.Add(new Game
            {      
                Date = DateTime.Now,
                Score = gamescore,
                Type = gameType
            });

}
        internal static int[] getDivisionNumbers()
        {
            var random = new Random();

            var first = random.Next(1, 99);
            var second = random.Next(1, 99);

            var result = new int[2];
            // create int array named result

            while (first % second != 0)
            {
                // keep regenerating both numbers until first divides evenly by second

                first = random.Next(1, 99);
                second = random.Next(1, 99);
                //reference the array with the created random 
            }

            result[0] = first;
            result[1] = second;
            // store the valid pair in the array

            return result;
            // return this array

        }
        // static keyword used to access each method solutionwide
         

    }
}
