namespace MathGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GameEngine engine = new GameEngine();
            Menu menu = new Menu();

            var date = DateTime.UtcNow;

            var games = new List<string>();

            string name = Helpers.GetName();

            menu.ShowMenu(name);
            
            
            
        }
    }
}
