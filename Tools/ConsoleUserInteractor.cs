
namespace Tools
{
    public class ConsoleUserInteractor : IUserInteractor
    {
        public string GetUserInput() => Console.ReadLine();
        public void ReadKey() => Console.ReadKey();

        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void WriteOnSameLine(string message)
        {
            Console.Write(message);
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void Quit()
        {
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
