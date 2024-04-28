namespace MathGame.N_Endy.GameUserInteraction
{
    public class UserInteraction : IUserInteraction
    {
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void Exit()
        {
            Environment.Exit(0);
        }

        public string GetPlayerName()
        {
            Console.Write("Enter your name: ");
            return Console.ReadLine();
        }

        public void DisplayGamePrompt(string name)
        {
            Console.WriteLine($"Welcome to the Math Game {name}");
            Console.WriteLine("Please choose a game from the following options:");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Quit");
            Console.WriteLine("Display previous games.");
            Console.WriteLine("Please enter your choice:");
        }
    }
}