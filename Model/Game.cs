using Math_Game.Helpers;

namespace Math_Game.Model
{
    internal class Game
    {
        internal string Player { get; }
        internal DateTime DateTime { get; }
        internal Types? Type { get; }

        internal int Score { get; }

        internal Game(Types? type, string player, int score)
        {
            Player = player;
            Type = type;
            Score = score;
            DateTime = DateTime.Now;
        }

        public override string ToString()
        {
            return $@"{Player} played {(Type == Types.Addition ? "an" : "a")} {Type} game at {DateTime} and got {Score} {(Score > 1 ? "points" : "point")}";
        }
    }
}

