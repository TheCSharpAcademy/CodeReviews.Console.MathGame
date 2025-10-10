namespace MathsGameProject
{
    internal static class ConfigurationSettings
    {
        internal static int Rounds { get; set; } = 4;
        internal static Enums.Dificulty DificultyLevel { get; set; } = Enums.Dificulty.easy;
        internal static Enums.GameTypes GameType { get; set; } = Enums.GameTypes.addition;

    }
}
