namespace MathGame
{
    internal class Menu
    {
        internal static void GetMenu()
        {
            DateTime start = DateTime.UtcNow;
            List<string> list = new List<string>();
            Console.WriteLine("Welcome to the math game, let's play");
            Console.WriteLine();
            bool exit = false;

            Console.WriteLine("Choose difficulty: 0 - easy, 1 - hard");

            int difficulty = int.Parse(Console.ReadLine());

            Console.WriteLine();

            while (!exit)
            {
                Console.WriteLine("Choose a game: ");
                Console.WriteLine(new string('-', 100));
                Console.WriteLine("A - ADDITION");
                Console.WriteLine("S - SUBTRACTION");
                Console.WriteLine("M - MULTIPLICATION");
                Console.WriteLine("D - DIVISION");
                Console.WriteLine("R - RANDOM GAME");
                Console.WriteLine("H - HISTORY");
                Console.WriteLine("E - EXIT");
                Console.WriteLine(new string('-', 100));
                string option = Console.ReadLine();

                switch (option.ToUpper())
                {
                    case "A":
                        Console.WriteLine("How many round do you want to play? ");
                        var roundsA = Console.ReadLine();
                        Helpers.Validation2(roundsA);
                        TaskUtils.AdditionGame(difficulty, ref list, int.Parse(roundsA));
                        break;
                    case "S":
                        Console.WriteLine("How many round do you want to play? ");
                        var roundsS = Console.ReadLine();
                        Helpers.Validation2(roundsS);
                        TaskUtils.SubGame(difficulty, ref list, int.Parse(roundsS));
                        break;
                    case "M":
                        Console.WriteLine("How many round do you want to play? ");
                        var roundsM = Console.ReadLine();
                        Helpers.Validation2(roundsM);
                        TaskUtils.MultiplitionGame(difficulty, ref list, int.Parse(roundsM));
                        break;
                    case "D":
                        Console.WriteLine("How many round do you want to play? ");
                        var roundsD = Console.ReadLine();
                        Helpers.Validation2(roundsD);
                        TaskUtils.DivisionGame(difficulty, ref list, int.Parse(roundsD));
                        break;
                    case "R":
                        Console.WriteLine("How many round do you want to play? ");
                        var roundsR = Console.ReadLine();
                        Helpers.Validation2(roundsR);
                        TaskUtils.RandomGame(difficulty, ref list, int.Parse(roundsR));
                        break;
                    case "H":
                        foreach (var game in list)
                        {
                            Console.WriteLine($"{game}");
                        }
                        break;
                    case "E":
                        exit = true;
                        break;
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
