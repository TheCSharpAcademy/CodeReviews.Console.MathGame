namespace Math
{
    internal class App
    {
        private readonly string[] availableChoices = new string[5] { "a", "s", "m", "d", "q" };
        private readonly int[] mathNumsList = { 23, 45, 56, 78, 23, 78, 46, 98, 2, 10 };
        private List<string[]> history = new();
        protected string? username;
        protected int seperatorLineLength;

        public App(int lineLength) {
            Console.WriteLine("Maths - console app for learning maths!");
            Console.Write("What is your name? ");

            username = Console.ReadLine();
            seperatorLineLength = lineLength;
        }

        internal void Menu()
        {
            Console.WriteLine($"What would you like to study {username}? ");

            for (int i = 0; i < seperatorLineLength; i++)
            {
                Console.Write('-');
            }

            Console.WriteLine("");

            Console.WriteLine(@"
                Addition: press the 'a' key
                Substraction: press the 's' key
                Multiplication: press the 'm' key
                Division: press the 'd' key
                Quit: press the 'q' key
            ");

            for (int i = 0; i < seperatorLineLength; i++)
            {
                Console.Write('-');
            }

            Console.WriteLine("");
            Console.Write("Game Choice: ");
        }

        internal void GameSelect()
        {
            try
            {
                string? userChoice;

                do
                {
                    userChoice = Console.ReadKey().KeyChar.ToString().ToLower();

                    if (!availableChoices.Contains(userChoice))
                    {
                        Console.WriteLine("");
                        Console.Write($"{userChoice} is not available, please choose another: ");
                    }
                }
                while (!availableChoices.Contains(userChoice));

                if (availableChoices.Contains(userChoice))
                {
                    Console.WriteLine("");

                    if (userChoice == "a") Operations.Addition("Addition game selected", mathNumsList, history);
                    if (userChoice == "s") Operations.Subtraction("Subtraction game selected", mathNumsList, history);
                    if (userChoice == "m") Operations.Multiplication("Multiplication game selected", mathNumsList, history);
                    if (userChoice == "d") Operations.Division("Division game selected", mathNumsList, history);
                    if (userChoice == "q") Quit("Goodbye");
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("");
                Console.WriteLine(err.Message);
                Environment.Exit(1);
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        internal static void DisplayHistory(string[] history)
        {
            Console.WriteLine("");

            for (int i = 0; i < history.Length; i++)
            {
                Console.WriteLine(history[i]);
            }

            Console.WriteLine("");
        }

        internal static void Quit(string msg)
        {
            Console.WriteLine(msg);
            Environment.Exit(1);
        }
    }
}
