namespace Math_Game.Model.Problems;

internal interface IProblem
{
    string Name { get; }
    string Format { get; }
    string Description { get; }
    ProblemType ProblemType { get; }
    void Generate();
    String Display();
    Result Validate(string result);
    String DisplayAnswer();
}
internal enum Result
{
    Correct,
    Incorrect,
    Invalid,
}
internal enum ProblemType
{
    Addition,
    Addition_Reciprical,
    Subtraction,
    Substraction_Reverse,
    Multiplication,
    Division
}