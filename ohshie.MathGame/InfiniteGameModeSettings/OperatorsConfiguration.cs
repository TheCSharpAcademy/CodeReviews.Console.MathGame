using OhshieMathGame.InfiniteGameModeSettings;

static class OperatorsConfiguration
{
    public static List<string> _tempAllowedOperators = new List<string>()
    {
        "+",
        "-",
        "*",
        "/"
    };
    
    // main Operator settings menu.
    public static void OperatorsSettings()
    {
        while (true)
        {
            string plus = "";
            string minus = "";
            string multiply = "";
            string divide = "";

            CurrentOperatorState(ref plus, ref minus, ref multiply, ref divide);
            Console.WriteLine("Current activated operators:\n" +
                              $"+ [{plus}]\t Press 1 to toggle\n" +
                              $"- [{minus}]\t Press 2 to toggle\n" +
                              $"* [{multiply}]\t Press 3 to toggle\n" +
                              $"/ [{divide}]\t Press 4 to toggle");
            OperatorToggler();
            if (_tempAllowedOperators.Count >= 1 && Program.MenuOperator == ConsoleKey.Enter)
            {
                break;
            }
        }
    }
    
    // currently displays a list of activated operators
    private static void CurrentOperatorState(ref string plus, ref string minus, ref string multiply, ref string divide)
    {
        for (int i = 0; i < _tempAllowedOperators.Count; i++)
        {
            if (_tempAllowedOperators[i] == "+")
            {
                plus = "x";
            }
            else if (_tempAllowedOperators[i] == "-")
            {
                minus = "x";
            }
            else if (_tempAllowedOperators[i] == "*")
            {
                multiply = "x";
            }
            else if (_tempAllowedOperators[i] == "/")
            {
                divide = "x";
            }
        }
    }
    
    // method allows turning Operators on and off
    private static void OperatorToggler()
    {
        Console.WriteLine("What you want to toggle?");
        if (_tempAllowedOperators.Count < 1)
        {
            Console.WriteLine("You much choose at least 1 operator".ToUpper());
        }
        else
            Console.WriteLine("Press enter to confirm your choice.");
        Program.MenuOperator = Console.ReadKey().Key;
        Console.Clear();
            switch (Program.MenuOperator)
            {
                case ConsoleKey.D1:
                {
                    OperatorTogglerAddRemove("+");
                    break;
                }
                case ConsoleKey.D2:
                {
                    OperatorTogglerAddRemove("-");
                    break;
                }
                case ConsoleKey.D3:
                {
                    OperatorTogglerAddRemove("*");
                    break;
                }
                case ConsoleKey.D4:
                {
                    OperatorTogglerAddRemove("/");
                    break;
                }
                case ConsoleKey.Enter:
                {
                    break;
                }
                default:
                {
                    Console.WriteLine("Looks like you selected something that you shouldn't, try again.");
                    break;
                }
            }
    }
    
    // Helper method for OperatorToggler
    private static void OperatorTogglerAddRemove(string operation)
    {
        if (_tempAllowedOperators.Contains(operation))
        {
            _tempAllowedOperators.Remove(operation);
        }
        else
        {
            _tempAllowedOperators.Add(operation);
        } 
    }
}