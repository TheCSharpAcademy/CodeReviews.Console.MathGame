namespace MathGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Menu menu = new Menu();

            var date = DateTime.UtcNow;

            string name = Helpers.GetName();

            menu.ShowMenu(name, date);
            
            
            
        }
    }
}
