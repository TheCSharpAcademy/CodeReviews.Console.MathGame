namespace MathGame {
    internal class Program {
        static void Main(string[] args) {

            Console.Write("Please, type in your name. \n" +
                          ">");
            string? name = Console.ReadLine();
            string date = DateTime.Now.ToString();
            Menu(name, date);

        }

        private static void Menu(string? name, string date) {
            Console.WriteLine("<--------------------------------->");
            Console.WriteLine($"Hello, {name}. It's {date}.\n" +
                              $"Welcome to the Math Game!");
            Console.Write("What game would you like to play now? Choose one of the options below:\n" +
                              "A -> Addition\n" +
                              "S -> Subtraction\n" +
                              "M -> Multiplication\n" +
                              "D -> Division\n" +
                              "Q -> Quit\n\n" +

                              ">");
            string selectedGame = Console.ReadLine().ToString().Trim().ToUpper();

            switch (selectedGame) {
                case "A":
                    Addition();
                    break;
                case "S":
                    Subtraction();
                    break;
                case "M":
                    Multiplication();
                    break;
                case "D":
                    Division();
                    break;
                case "Q":
                    Console.WriteLine("Goodbye! ;)");
                    break;
            }
        }

        private static void Division() {
            throw new NotImplementedException();
        }

        private static void Multiplication() {
            throw new NotImplementedException();
        }

        private static void Subtraction() {
            throw new NotImplementedException();
        }

        private static void Addition() {
            throw new NotImplementedException();
        }
    }
}