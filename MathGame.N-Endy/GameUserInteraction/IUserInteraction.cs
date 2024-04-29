using MathGame.N_Endy.GameEntities;

namespace MathGame.N_Endy.GameUserInteraction
{
    public interface IUserInteraction
    {
        void ShowMessage(string message);
        void Exit();
        void DisplayGamePrompt(string name);
        void DisplayQuestion(Question question);
        string GetPlayerName();
        string GetUserChoice();
    }
}