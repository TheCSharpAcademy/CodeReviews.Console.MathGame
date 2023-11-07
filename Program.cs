namespace MathGame {

    internal class Program {

        public List<string> games = new();

        public static void Main(string[] args) {
            Menu menu = new Menu();
            Console.Write("Please, type in your name. \n" +
                          ">");


            Data.name = Console.ReadLine();
            
            menu.ShowMenu(Data.name, Data.date);
        }
    }
}