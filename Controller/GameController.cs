using Math_Game.Helpers;
using Math_Game.Model;
using Math_Game.View;

namespace Math_Game.Controller
{
    internal class GameController
    {
        internal static readonly string[] operation = new[] {"A", "S", "M", "D" };
        internal List<Game> Games = new(); 

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
                    Types type = TypesMethod.GetType(option);
                    int score = 0;
                    
                    int[] problems = Problem.Generate(type);
                    int i = 0;
                    do
                    {
                        int x = problems[i], y = problems[i + 1];
                        Display.Start(type, x, y);
                        bool result = Int32.TryParse(Console.ReadLine(), out int answer);
                        if (result)
                        {
                            if (Problem.CheckAnswer(type, x, y, answer))
                                score++;
                            i += 2;
                        }
                        else
                        {
                            Display.Answer();
                            Console.ReadLine();
                        }
                    } while (i < problems.Length);

                    Games.Add(new Game(type, name, score));
                }
                else
                    Display.Start(option);

                if (option == "C")
                    name = Console.ReadLine();
                else if (option == "V")
                    Display.ViewHistory(Games);



            } while (option != "Q");
        }
    }
}
