using Math_Game.Helpers;
using Math_Game.Model;
using Math_Game.View;

namespace Math_Game.Controller
{
    internal class GameController
    {
        internal static readonly string[] operation = new[] {"A", "S", "M", "D" };

        internal void Run()
        {
            Display.Welcome();
            string? name = Console.ReadLine();
            if (String.IsNullOrEmpty(name))
                Environment.Exit(0);

            string? option;
            do
            {
                Display.Menu();
                option = Console.ReadLine()?.ToUpper();

                if (operation.Contains(option))
                {
                    Types? type = TypesMethod.GetType(option);
                    int score = 0;
                    
                    int[]? problems = Problem.Generate(type);
                    int i = 0;
                    do
                    {
                        Display.Start(type, problems[i], problems[i + 1]);
                        bool result = Int32.TryParse(Console.ReadLine(), out int answer);
                        if (result)
                        {
                            i += 2;
                            score++;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a number, press enter to continue...");
                            Console.ReadLine();
                        }
                    } while (i < problems.Length);

                    Game game = new Game(type, name, score);
                }
                else
                    Display.Start(option);
                if (option == "C")
                    name = Console.ReadLine();

            } while (option != "Q");
        }
    }
}
