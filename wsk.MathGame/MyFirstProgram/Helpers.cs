using static MyFirstProgram.GameHistory;
using static System.Formats.Asn1.AsnWriter;

namespace MyFirstProgram
{
    static internal class Helpers
    {
        static internal string GetName()
        {
            Console.WriteLine("Please type your name");
            var name = Console.ReadLine();
            return name;
        }

        static internal DateTime GetDate()
        {
            DateTime utcDate = DateTime.UtcNow;
            return utcDate;
        }

        static internal void WelcomeMessgae(String name, DateTime date)
        {
            Console.WriteLine($"Hello {name}. It's {date.DayOfWeek}. This is your math's game. That's great that you're worling on improving yourself" +
    "\n\nPress any key to show menu");
            Console.ReadKey();
            Console.Clear();
        }

        static internal void ByeMessage()
        {
            Console.WriteLine("Goodbye!");
            Environment.Exit(0);
        }

        static internal void UpdateGameHistory(List<GameHistory> gameHistories, GameType gameType, int score)
        {
            gameHistories.Add(new GameHistory { Date = DateTime.UtcNow, Type = gameType, Score = score });
        }

        static internal void GetGameHistory(List<GameHistory> gameHistories)
        {
            Console.Clear();
            Console.WriteLine("Game History" +
                "\n-------------------------------------------------------");
            foreach (GameHistory i in gameHistories)
            {
                Console.WriteLine($"{i.Date.ToString()} - {i.Type}: {i.Score}pts");
            }
            Console.WriteLine("-------------------------------------------------------" +
                "\n\nPress any key to return to Main Menu");
            Console.ReadKey();
        }

        

    }
}
