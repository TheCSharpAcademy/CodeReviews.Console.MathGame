using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.jwhitt3r
{
    public sealed class GameEngine
    {
        private Game? _gameInstance;
        private Score gameScores = new Score();
        private static readonly Lazy<GameEngine> lazy = new Lazy<GameEngine>(() => new GameEngine());

        public static GameEngine Instance { get { return lazy.Value; } }

        private GameEngine() {}
        
        public void NewGame()
        {
            
            char val = Menu.GenerateMenu();
            while (val != 'q')
            {
                if (val == '+' || val == '-' || val == '/' || val == '*')
                {
                    _gameInstance = new Game(val, gameScores);
                    val = Menu.GenerateMenu();

                }
                if (val == 'e')
                {
                    gameScores.PrintScores();
                    val = Menu.GenerateMenu();
                }

                if (val == 'q')
                {
                    Console.WriteLine("Thank you for playing");
                    Environment.Exit(0);
                }
            }
        }
    }
}
