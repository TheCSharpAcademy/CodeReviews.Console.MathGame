using OhshieMathGame.InfiniteGameModeSettings;

static class OperatorsConfiguration
{
    private static List<string> _tempAllowedOperators = new List<string>();
    
    public static void SaveOperatorConfiguration()
    {
        GameController.OperatorsInPlay = _tempAllowedOperators;
    }
    // main Operator settings menu.
    public static void OperatorsSettings()
    {
        _tempAllowedOperators = GameController.AllPossibleOperators;
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
        if (_tempAllowedOperators.Count < 1)
        {
            Console.WriteLine("What you want to toggle?");
            Console.WriteLine("You much choose at least 1 operator".ToUpper());
        }
        else
            Console.WriteLine("What you want to toggle?\n"+
                              "Press enter to confirm your choice.");
        Program.MenuOperator = Console.ReadKey().Key;
        Console.Clear();
            switch (Program.MenuOperator)
            {
                case ConsoleKey.D1:
                {
                    if (_tempAllowedOperators.Contains("+"))
                    {
                        _tempAllowedOperators.Remove("+");
                    }
                    else
                    {
                        _tempAllowedOperators.Add("+");
                    }

                    break;
                }
                case ConsoleKey.D2:
                {
                    if (_tempAllowedOperators.Contains("-"))
                    {
                        _tempAllowedOperators.Remove("-");
                    }
                    else
                    {
                        _tempAllowedOperators.Add("-");
                    }

                    break;
                }
                case ConsoleKey.D3:
                {
                    if (_tempAllowedOperators.Contains("*"))
                    {
                        _tempAllowedOperators.Remove("*");
                    }
                    else
                    {
                        _tempAllowedOperators.Add("*");
                    }

                    break;
                }
                case ConsoleKey.D4:
                {
                    if (_tempAllowedOperators.Contains("/"))
                    {
                        _tempAllowedOperators.Remove("/");
                    }
                    else
                    {
                        _tempAllowedOperators.Add("/");
                    }

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
}