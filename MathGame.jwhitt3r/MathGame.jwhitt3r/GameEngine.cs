using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.jwhitt3r
{
    public sealed class GameEngine
    {
        private Score gameScores = new Score();
        private static readonly Lazy<GameEngine> lazy = new Lazy<GameEngine>(() => new GameEngine());

        public static GameEngine Instance { get { return lazy.Value; } }

        private GameEngine() {}
        
        public void NewGame()
        {
            
            char val = Menu.GenerateMenu();
            while (true)
            {
                if (val == '+' || val == '-' || val == '/' || val == '*')
                {
                    _ = new Game(val, gameScores, Menu.GenerateDifficultyMenu());
                    val = Menu.GenerateMenu();

                }
                
                if (val == 'e')
                {
                    gameScores.PrintScores();
                    val = Menu.GenerateMenu();
                }
            }
        }
    }
}
