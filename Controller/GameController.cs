using Math_Game.View;

namespace Math_Game.Controller
{
    internal class GameController
    {
        internal void Run()
        {
            do
            {
                Display.Menu();
                string? option = Console.ReadLine()?.ToUpper();
                Display.Start(option);

            } while (true);
        }
    }
}
