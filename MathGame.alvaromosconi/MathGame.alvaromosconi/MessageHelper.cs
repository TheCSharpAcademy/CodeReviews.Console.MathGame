namespace MathGame.alvaromosconi
{
    internal static class MessageHelper
    {
        internal static void ShowErrorMessage(string message)
        {
            Console.Clear();
            Console.WriteLine("ERROR: " + message);
            Console.WriteLine();
        }
        
        internal static void ShowCorrectAnswerMessage()
        {
            Console.WriteLine("Correct! Type any key for the next question.");
            Console.ReadKey();
        }

        internal static void ShowIncorrectAnswerMessage() 
        {
            Console.WriteLine("Wrong answer! Type any key for the next question.");
            Console.ReadKey();
        }
        internal static void NewGameMessage(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
        }

        internal static string GetQuestion(int firstOperator, int secondOperator, string operand)
        {
            return $"{firstOperator} {operand} {secondOperator}?";
        }

        internal static void PrintFinalScore(int score)
        {
            Console.WriteLine($"Your final score is: {score}");
        }
    }
}
