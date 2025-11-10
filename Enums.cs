using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    internal class Enums
    {
        internal enum MenuAction
        {
            PlayGame,
            About,
            ShowHistory,
            ExitGame,
        }

        internal enum Operator
        {
            Add,
            Subtract,
            Multiply,
            Division,
        }

        internal enum Difficulty
        {
            Easy,
            Medium,
            Hard,
        }

        internal enum GameType
        {
            Training,
            Random,
        }

        internal enum Rating
        {
            Painful = 0,
            VeryBad= 1,
            Bad=2,
            Good=3,
            Excellent = 4,
            Perfect = 5

        }
    }
}
