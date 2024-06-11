using MathGame.Kriz_J.Enums;

namespace MathGame.Kriz_J;

public class Settings
{
    public const int MaxNumberOfQuestions = 30;
    
    public const int DefaultNumberOfQuestions = 10;

    public const int MinNumberOfQuestions = 0;

    private int _numberOfQuestions = DefaultNumberOfQuestions;

    public GameType GameType { get; set; }

    public Difficulty Difficulty { get; set; } = Difficulty.Easy;

    public Mode Mode { get; set; } = Mode.Standard;
    
    public int NumberOfQuestions
    {
        get => _numberOfQuestions;
        set => _numberOfQuestions = value switch
        {
            < MinNumberOfQuestions => MinNumberOfQuestions,
            > MaxNumberOfQuestions => MaxNumberOfQuestions,
            _ => value
        };
    }

    public (int Lower, int Upper) NumberLimits => SetNumberLimits(Difficulty);

    //TODO: Customize the difficulty for multiplication and divisions to be fair.
    private static (int lower, int upper) SetNumberLimits(Difficulty difficulty)
    {
        return difficulty switch
        {
            Difficulty.Easy => (lower: 1, upper: 11),
            Difficulty.Medium => (lower: 11, upper: 101),
            Difficulty.Hard => (lower: 101, upper: 1001),
            _ => throw new ArgumentOutOfRangeException(nameof(difficulty), difficulty, "Only '[E]asy', '[M]edium', and '[H]ard' are accepted as difficulties.")
        };
    }

    public void ChangeDifficultyOrMode(char input)
    {
        if (Enum.IsDefined(typeof(Difficulty), (int)input))
        {
            Difficulty = (Difficulty)input;
            UpdateDifficultyPresentation();
        }

        if (Enum.IsDefined(typeof(Mode), (int)input))
        {
            Mode = (Mode)input;
            UpdateModePresentation();
        }
    }

    private void UpdateDifficultyPresentation()
    {
        Console.SetCursorPosition(0, 15); //15 = Difficulty row
        PrintDifficulties(Difficulty);
        Console.SetCursorPosition(10, 22); //(10,22) = Input position
    }

    private void UpdateModePresentation()
    {
        Console.SetCursorPosition(0, 18); //18 = Mode row
        PrintModes(Mode);
        Console.SetCursorPosition(10, 22); //(10,22) = Input position
    }

    public static void PrintDifficulties(Difficulty difficulty)
    {
        switch (difficulty)
        {
            case Difficulty.Easy:
                ConsoleHelperMethods.FormatWriteLineWithHighlight("", "\t\t[E]asy", " [M]edium [H]ard");
                break;
            case Difficulty.Medium:
                ConsoleHelperMethods.FormatWriteLineWithHighlight("\t\t[E]asy ", "[M]edium", " [H]ard");
                break;
            case Difficulty.Hard:
                ConsoleHelperMethods.FormatWriteLineWithHighlight("\t\t[E]asy [M]edium ", "[H]ard", "");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(difficulty), difficulty, null);
        }
    }

    public static void PrintModes(Mode mode)
    {
        switch (mode)
        {
            case Mode.Standard:
                ConsoleHelperMethods.FormatWriteLineWithHighlight("", "\t\t[S]tandard", " [T]imed [C]ustom");
                break;
            case Mode.Timed:
                ConsoleHelperMethods.FormatWriteLineWithHighlight("\t\t[S]tandard ", "[T]imed", " [C]ustom");
                break;
            case Mode.Custom:
                ConsoleHelperMethods.FormatWriteLineWithHighlight("\t\t[S]tandard [T]imed ", "[C]ustom", "");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
        }
    }
}