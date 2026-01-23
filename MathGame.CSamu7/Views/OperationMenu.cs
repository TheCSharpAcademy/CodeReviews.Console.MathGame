using MathGame.Utils;

namespace MathGame.Views
{
    public class OperationMenu
    {
        private readonly List<string> _operations = ["Sum", "Rest", "Multiplication", "Division"];
        private readonly string _title = "Choose the operation you prefer";
        private readonly string _instruction = "Enter an operation: ";
        public string GetOperation()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(_title);
                ConsoleUtils.DisplayList(_operations);
                Console.Write(_instruction);

                if (!ConsoleUtils.ReadOption(out int option, x => x > 0 && x <= _operations.Count))
                {
                    Thread.Sleep(2000);
                    continue;
                }

                return option switch
                {
                    1 => "+",
                    2 => "-",
                    3 => "*",
                    _ => "/"
                };
            }
        }
    }
}
