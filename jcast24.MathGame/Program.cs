namespace jcast24.MathGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Math Game!");
            Console.WriteLine("How many games would you like to play?: ");
            int input = Convert.ToInt32(Console.ReadLine());

            var menu = new Menu(); 
            menu.MenuSystem(input);
        }

    }
}