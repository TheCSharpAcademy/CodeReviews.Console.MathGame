using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("MathGameTests")]

namespace Math_Game.Tools;

internal interface IMathQuizUserInteractor
{
    public void DisplayMenu();
    public string PromptForOption();
    public void DisplayMessage(string message);
    public string PromptForAnswer();
    public void DisplayCorrect();
    public void DisplayIncorrect(string result);
    public bool PromptForGameEnd();
    public void DisplayResults(List<(int Points, double Time)> results);
    public void DisplayDifficulties();
    public string PromptForDifficulty();
    public void Clear();
    public void ReadKey();
    public void Quit();
}