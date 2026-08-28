namespace MathGame.DzemalKurtic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var menu = new Menu();

            string? name = Helpers.GetName();

            var date = DateTime.UtcNow;

            menu.ShowMenu(name, date);
        }
    }
}