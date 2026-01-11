namespace MathGame
{
    public class Player
    {
        public string Name;
        public Player(string name) 
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}