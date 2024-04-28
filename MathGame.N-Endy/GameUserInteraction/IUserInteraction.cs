namespace MathGame.N_Endy.GameUserInteraction
{
    public interface IUserInteraction
    {
        void ShowMessage(string message);
        void Exit();
        void DisplayGamePrompt();
        //void DisplayQuestion(Question question);
        string GetPlayerName();
    }
}