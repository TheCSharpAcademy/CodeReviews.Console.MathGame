namespace MathGame.Utils
{
    public static class ConsoleUtils
    {
        public static void Error(string message)
        {
            WriteLine(message, ConsoleColor.Red);
        }
        public static void WriteLine(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void DisplayList(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {list[i]}");
            }
        }
        public static bool ReadOption(out int option, Predicate<int> extraValidation)
        {
            if (!int.TryParse(Console.ReadLine(), out option))
            {
                ConsoleUtils.Error($"You have to enter a number");
                return false;
            }

            if (!extraValidation(option))
            {
                ConsoleUtils.Error($"This isn't a valid option");
                return false;
            }

            return true;
        }
}
}
