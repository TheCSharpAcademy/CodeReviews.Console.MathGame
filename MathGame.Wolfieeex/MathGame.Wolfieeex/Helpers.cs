namespace MathGame.Wolfieeex
{
    internal class Helpers
    {
        public static void ReinsertLine(string message)
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write($"\r{new string(' ', Console.BufferWidth)}");
            Console.Write("\r" + message);
        }

        public static void ReadInput(ref string? input, string failMessage)
        {
            bool isValidLoop = true;
            while (isValidLoop)
            {
                try
                {
                    // Check for valid input:
                    input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input))
                    {
                        throw new NullReferenceException(failMessage);
                    }
                    isValidLoop = false;
                }
                catch (NullReferenceException ex)
                {
                    Helpers.ReinsertLine(ex.Message);
                }
            }
        }
    }
}
