namespace MathGame
{
    public static class Randomizer
    {
        public static Level RandomLevel()
        {
            var randomizer = new Random();
            var levels = Enum.GetValues(typeof(Level));
            var indexRandomLevel = randomizer.Next(levels.Length);
            return (Level)indexRandomLevel;
        }
        public static Operation RandomOperation()
        {
            var randomizer = new Random();
            var operations = Enum.GetValues(typeof(Operation));
            var indexRandomOperation = randomizer.Next(operations.Length);
            return (Operation)indexRandomOperation;
        }
    }
}