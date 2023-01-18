namespace MathGame;

internal class UserController
{
    internal static void ProcessInput(string userInput)
    {
        switch (userInput)
        {
            case "a":
                SetExerciseDifficulty(Operator.Add);
                break;
            case "s":
                SetExerciseDifficulty(Operator.Subtract);
                break;
            case "m":
                SetExerciseDifficulty(Operator.Multiply);
                break;
            case "d":
                SetExerciseDifficulty(Operator.Divide);
                break;
            case "r":
                SetExerciseDifficulty(Operator.Random);
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

    private static void SetExerciseDifficulty(Operator op)
    {
        Console.Write("Please select a difficulty: easy (e) medium (m) or hard (m): ");
        Difficulty difficulty = UserInput.GetExerciseDifficulty();
        SetExerciseLength(op, difficulty);
    }

    private static void SetExerciseLength(Operator op, Difficulty difficulty) 
    {
        Console.Write("Please type how many questions you want in your exercise: ");
        int length = UserInput.GetExerciseLength();
        ExerciseManager.StartExerciseRoutine(op, difficulty, length);
    }
}