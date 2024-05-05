namespace MathGame.Kriz_J;

public enum Difficulty
{
    Easy = 'E',
    Medium = 'M',
    Hard = 'H'
}

public enum Mode
{
    Standard = 'S',
    Timed = 'T'
}

public class GameSettings
{
    public Difficulty Difficulty { get; set; } = Difficulty.Easy;

    public Mode Mode { get; set; } = Mode.Standard;

    public (int Lower, int Upper) IntegerBounds => SetIntegerBounds(Difficulty);

    private static (int lower, int upper) SetIntegerBounds(Difficulty difficulty)
    {
        return difficulty switch
        {
            Difficulty.Easy => (lower: 0, upper: 9),
            Difficulty.Medium => (lower: 10, upper: 99),
            Difficulty.Hard => (lower: 100, upper: 999),
            _ => throw new ArgumentOutOfRangeException(nameof(difficulty), difficulty, "Only '[E]asy', '[M]edium', and '[H]ard' are accepted as difficulties.")
        };
    }

    public void ChangeDifficultyOrMode(char input)
    {
        if (Enum.IsDefined(typeof(Difficulty), input))
            Difficulty = (Difficulty)input;

        if (Enum.IsDefined(typeof(Mode), input))
            Mode = (Mode)input;
    }

    public static void PrintGameDifficulties(Difficulty difficulty)
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

    public static void PrintGameModes(Mode mode)
    {
        switch (mode)
        {
            case Mode.Standard:
                ConsoleHelperMethods.FormatWriteLineWithHighlight("", "\t\t[S]tandard", " [T]imed");
                break;
            case Mode.Timed:
                ConsoleHelperMethods.FormatWriteLineWithHighlight("\t\t[S]tandard ", "[T]imed", "");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
        }
    }
}
