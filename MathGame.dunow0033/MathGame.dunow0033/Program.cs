namespace MathGame.dunow0033 
{ 
	class Program
	{
		static void Main(string[] args)
		{
			string name = Helpers.GetName();

			Console.Clear();

			Menu menu = new Menu();
			menu.ShowMenu(name);
		}
	}
}
