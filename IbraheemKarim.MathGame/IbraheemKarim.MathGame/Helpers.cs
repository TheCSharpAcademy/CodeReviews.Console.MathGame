
namespace IbraheemKarim.MathGame
{
    internal static class Helpers
    {
        public static string GetUserName()
        {
            string name = "";
            do
            {
                Console.Clear();
                Console.Write("Hello, please enter your name: ");
                name = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(name));

            return name;
        }
        internal static string ValidateResult(string? result)
        {
            while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
            {
                Console.WriteLine("Invalid input. Try again.");
                result = Console.ReadLine();
            }

            return result;
        }
    }
}
