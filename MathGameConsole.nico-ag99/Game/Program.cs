using Game.Controller;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameLogic game = new GameLogic();
            game.GameRun();
        }
    }
}
