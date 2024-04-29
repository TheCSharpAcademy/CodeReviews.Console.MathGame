using MathGame.N_Endy.GameEntities;

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
            Thread.Sleep(1000);
            Console.WriteLine("\nPlease choose a game from the following options:");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Quit");
            Console.WriteLine("6. Display previous games.");
            Thread.Sleep(1000);
            Console.WriteLine("\nPlease enter your choice:");
        }

        public void DisplayQuestion(Question question)
        {
            Console.WriteLine($"\nQuestion: {question.Operand1} {question.Operation} {question.Operand2}");
            Console.Write("Answer: ");
        }

        public string GetUserChoice()
        {
            return Console.ReadLine();
        }
    }
}