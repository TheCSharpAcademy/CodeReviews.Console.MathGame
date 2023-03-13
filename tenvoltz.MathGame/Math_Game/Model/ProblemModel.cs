using Math_Game.Model.Problems;

namespace Math_Game.Model;

internal class ProblemModel
{
    public IProblem Problem { get; set; }
    public int Score { get; set; }

    public void IncrementScore() { Score++; }
    public void GenerateProblem() { 
        Problem.Generate(); 
    }
    public Result ValidateAnswer(String result) { 
        return Problem.Validate(result); 
    }
    public String DisplayProblem()
    {
        return Problem.Display(); 
    }
}