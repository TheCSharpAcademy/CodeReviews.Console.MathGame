using Math_Game.Model;
using Math_Game.Model.Problems;
using Math_Game.View;
using System.Diagnostics;

namespace Math_Game.Controller;

internal class GameController
{
    private ProblemModel model;
    private ProblemView view;

    public GameController(ProblemModel model, ProblemView view)
    {
        this.model = model;
        this.view = view;
    }

    public void RunProblem(int amount)
    {
        TimeSpan totalDuration = TimeSpan.Zero;
        for(int i = 0; i < amount; i++)
        {
            model.GenerateProblem();
            view.ShowProblem();
            Result result;
            DateTime startTime = DateTime.Now;
            do
            {
                string answer = view.PromptAnswer();
                result = model.ValidateAnswer(answer);
                view.ShowResult(result);
            } while (result == Result.Invalid);

            if (result == Result.Correct)
            {
                model.IncrementScore();
            }
            view.ShowProgress(amount - i - 1);

            DateTime endTime = DateTime.Now;
            TimeSpan duration = endTime - startTime;
            view.ShowDuration(duration);
            totalDuration += duration;

            view.PromptContinue();
        }
        Helpers.AddToHistory(model.Problem.ProblemType, model.Score, totalDuration.Divide(amount));
    }

    public void SetProblem(ProblemType problemType)
    {
        switch (problemType)
        {
            case ProblemType.Addition:
                model.Problem = new Addition();
                break;
            case ProblemType.Subtraction:
                model.Problem = new Subtraction();
                break;
            case ProblemType.Multiplication:
                model.Problem = new Multiplication();
                break;
            case ProblemType.Division:
                model.Problem = new Division();
                break;
            case ProblemType.Substraction_Reverse:
                model.Problem = new SubtractionReverse();
                break;
            case ProblemType.Addition_Reciprical:
                model.Problem = new AdditionReciprical();
                break;
            default:
                Debug.WriteLine("Uh Oh! Missing case");
                break;
        }
    }

}