using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.alvaromosconi
{
    internal class GameEngine
    {
        internal void RunGame(string gameChoice)
        {
            switch (gameChoice)
            {
                case "1":
                    RunAdditionGame();
                    break;
                case "2":
                    RunSubstractionGame();
                    break;
                case "3":
                    RunMultiplicationGame();
                    break;
                case "4":
                    RunDivisionGame();
                    break;
            }
        }

        private void RunDivisionGame()
        {
            throw new NotImplementedException();
        }

        private void RunMultiplicationGame()
        {
            throw new NotImplementedException();
        }

        private void RunSubstractionGame()
        {
            throw new NotImplementedException();
        }

        private void RunAdditionGame()
        {
            throw new NotImplementedException();
        }
    }
}
