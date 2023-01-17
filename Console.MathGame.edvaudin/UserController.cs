namespace MathGame;

internal class UserController
{
    internal static void ProcessInput(string userInput)
    {
        switch (userInput)
        {
            case "a":
                ExerciseManager.StartExerciseRoutine(Operator.Add, 5);
                break;
            case "s":
                ExerciseManager.StartExerciseRoutine(Operator.Subtract, 5);
                break;
            case "m":
                ExerciseManager.StartExerciseRoutine(Operator.Multiply, 5);
                break;
            case "d":
                ExerciseManager.StartExerciseRoutine(Operator.Divide, 5);
                break;
            case "h":
                ExerciseManager.PrintHistory();
                break;
            case "0":
                Program.SetEndAppToTrue();
                break;
            default:
                break;
        }
    }
}