namespace MathGame
{
    internal static class Helpers
    {
        private static readonly List<char> PossibleInputs = new List<char> { 'a', 's', 'm', 'd', 'h', 'q'};
        public static string GetName()
        {
            string? name;
            do
            {
                Console.WriteLine("What is your name?");
                name = Console.ReadLine();
            } while (ValidateName(name!));
            return name!;
        }

        private static bool ValidateName(string nameToValidate)
        {
            return string.IsNullOrEmpty(nameToValidate) || string.IsNullOrWhiteSpace(nameToValidate) || nameToValidate.Any(char.IsNumber);
        }

        public static char GetActionInput()
        {
            char action = ' ';
            do
            {
                try
                {
                    action = Convert.ToChar(Console.ReadLine()!.ToLower());
                }
                catch
                {
                    Console.WriteLine("Action must be a single character valid input from list above");
                    continue;
                }
            } while(!ValidateActionInput(action));

            return action;
        }

        private static bool ValidateActionInput(char input)
        {
            if (PossibleInputs.Contains(input))
                return true;
            else
                return false;
        }

        public static int GetAnswer()
        {
            string input;
            int answer;
            do
            {
                input = Console.ReadLine();
            } while (!Int32.TryParse(input, out answer));
            return answer;
        }
    }
}
