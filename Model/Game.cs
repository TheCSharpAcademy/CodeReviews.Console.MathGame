using Math_Game.Helpers;

namespace Math_Game.Model
{
    internal class Game
    {
        internal string Player { get; }
        internal DateTime DateTime { get; }
        internal Types? Type { get; }

        internal int score { get; }

        internal Game(Types? type, string player, int score)
        {
            Player = player;
            Type = type;
            this.score = score;
            DateTime = DateTime.Now;
        }
    }
}

