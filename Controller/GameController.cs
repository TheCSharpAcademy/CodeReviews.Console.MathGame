using Math_Game.View;

namespace Math_Game.Controller
{
    internal class GameController
    {
        internal void Run()
        {
            string? option;
            do
            {
                Display.Menu();
                option = Console.ReadLine()?.ToUpper();
                Display.Start(option);

            } while (option != "Q");
        }
    }
}
