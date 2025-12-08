using System;

namespace MathGame.Models
{
    internal enum GameMode
    {
        ADDITION = 1,
        SUBTRACTION,
        MULTIPLICATION,
        DIVISION,
    }

    internal class GameModeExtensions
    {
        public static string ToSymbol(GameMode mode)
        {
            switch(mode)
            {
                case GameMode.ADDITION:
                    return "+";
                case GameMode.SUBTRACTION:
                    return "-";
                   case GameMode.MULTIPLICATION:    
                    return "*";
                    case GameMode.DIVISION:
                    return "/";
                default:
                    throw new System.NotImplementedException("Impossible Game Mode given");
            }
        }
    }
}
