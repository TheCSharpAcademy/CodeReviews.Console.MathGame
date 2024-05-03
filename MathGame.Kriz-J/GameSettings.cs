namespace MathGame.Kriz_J
{
    public class GameSettings
    {
        public char Difficulty { get; set; } = 'M';
        
        public char Mode { get; set; } = 'S';

        public (int Lower, int Upper) IntegerBounds => SetIntegerBounds(Difficulty);

        private static (int lower, int upper) SetIntegerBounds(char difficulty)
        {
            return difficulty switch
            {
                'E' => (lower: 0, upper: 9),
                'M' => (lower: 10, upper: 99),
                'H' => (lower: 100, upper: 999),
                _ => throw new ArgumentException()
            };
        }
    }
}
