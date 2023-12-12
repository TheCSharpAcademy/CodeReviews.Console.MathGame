namespace MathGameLibrary
{
    public class Helper
    {
        public static int GetInt(string message)
        {
            Console.WriteLine(message);
            string? input;
            do 
            { 
                input = Console.ReadLine(); 
            } while (string.IsNullOrEmpty(input) || !int.TryParse(input, out _));
            return int.Parse(input);
        }

        public static int GetRandomInt(int a, int b) 
        {
            var random = new Random();
            return random.Next(a, b);
        }

        public static string GetString(string message)
        {
            Console.WriteLine(message);
            string? input;
            do
            {
                input = Console.ReadLine();
            } while (string.IsNullOrEmpty(input));
            return input;
        }
    }
}
