

using System.Security.AccessControl;

namespace MyFirstProgram
{
    internal class GameHistory
    {
        private DateTime _date;
        private int _score;

        internal DateTime Date { get { return _date; } set {  _date = value; } }
        internal GameType Type { get; set; }
        internal int Score { get { return _score; } set { _score = value; } }

        internal enum GameType
        {
            Addition,
            Subtraction,
            Multiplication,
            Division
        }





    }
}
