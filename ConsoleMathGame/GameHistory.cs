namespace MathGame 
{ 
    public class GameHistory 
    { 
        //Property to store game details
        public required string Operation { get; set; } 
        public required int Operand1 { get; set; } 
        public required int Operand2 { get; set; } 
        public required int UserAnswer { get; set; } 
        public required int CorrectAnswer { get; set; } 
        public required bool IsCorrect { get; set; } 
        public TimeSpan TimeTaken { get; set; } // Property to store time taken
    } 
} 
