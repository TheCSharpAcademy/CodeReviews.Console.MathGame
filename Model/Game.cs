namespace Math_Game.Model
{
    internal class Game
    {
        internal string Player { get; set; }
        internal int[] Numbers { get; }
        internal DateTime DateTime { get; }
        internal Type GameType { get; private set; }

        private Random _random = new();

        internal Game(string type, string player)
        {
            Player = player;
            UpdateGameType(type);
            DateTime = DateTime.Now;
            Numbers = new int[_random.Next(10)];
            UpdateNumbers();
        }

        private void UpdateGameType(string type)
        {
            switch (type)
            {
                case "A":
                    GameType = Type.Addition;
                    break;
                case "S":
                    GameType = Type.Subtraction;
                    break;
                case "M":
                    GameType = Type.Multiplication;
                    break;
                case "D":
                    GameType = Type.Division;
                    break;
            }
        }

        private void AdditionMultiplication()
        {
            for (int i = 0; i < Numbers.Length; i++)
            {
                Numbers[i] = _random.Next(100);
            }
        }

        private void Subtraction()
        {
            for (int i = 0; i < Numbers.Length; i = +2)
            {
                Numbers[i] = _random.Next(100);
                Numbers[i + 1] = _random.Next(Numbers[i]);
            }
        }

        private void Division()
        {
            for (int i = 0; i < Numbers.Length; i=+2)
            {
                Numbers[i + 1] = _random.Next(100);
                Numbers[i] = _random.Next(100) * Numbers[i + 1];
            }
        }

        private void UpdateNumbers()
        {
            switch (GameType)
            {
                case Type.Addition:
                case Type.Multiplication:
                    AdditionMultiplication();
                    break;
                case Type.Subtraction:
                    Subtraction();
                    break;
                case Type.Division:
                    Division();
                    break;
            }
        }
    }

    internal enum Type
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }
}

