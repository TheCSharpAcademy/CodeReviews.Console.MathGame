namespace MathGame;
internal class Menu
{
    internal int ShowMenu(string name)
    {
        Console.Clear();
        DateTime date = DateTime.Now;
        Console.WriteLine($@"Hi {name}. It's {date}.The following are the possible operations in the game.

Operation      Symbol

1.Addition        +
2.Subtraction     -
3.Multiplication  *
4.Division        / 
5.View game history.
6. Exit the game.");

        Console.WriteLine("---------------------------------------------");

        int op;
        List<int> options = new List<int> { 1, 2, 3, 4, 5, 6 };
        do
        {
            Console.Write("Enter a number between 1 and 6 to select the operation: ");
            string opInput = Console.ReadLine() ?? "";
            op = int.TryParse(opInput, out int res) ? res : 0;
        }
        while (op == 0 || !options.Contains(op));

        return op;
    }
}
