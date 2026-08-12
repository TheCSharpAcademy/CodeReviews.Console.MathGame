namespace MathGameRecap.Common
{
    public class Enums
    {
        public enum GameType
        {
            Add,
            Subtract,
            Multiply,
            Divide,
            Random,
            MainMenu
        }

        public enum MenuChoice
        {
            Play,
            History,
            Exit
        }

        public enum Difficulty
        {
            Easy,
            Medium,
            Hard
        }

        public static char GameTypeToSymbol(GameType type) => type switch 
        {
            GameType.Add => '+',
            GameType.Subtract => '-',
            GameType.Multiply => '*',
            GameType.Divide => '/',
            _ => throw new NotImplementedException()

        };
    }
}
