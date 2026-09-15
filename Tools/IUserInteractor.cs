
namespace Tools
{
    public interface IUserInteractor
    {
        public void DisplayMessage(string message);
        public void WriteOnSameLine(string message);
        public void ReadKey();
        public string GetUserInput();
        public void Clear();
        public void Quit();
    }
}
