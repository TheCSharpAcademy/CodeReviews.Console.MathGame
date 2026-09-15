using Math_Game.Enums;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("MathGameTests")]

namespace Math_Game.Tools;

internal class Validator
{
    public bool ValidateMenuOption(string input) => Enum.GetNames<MenuOptions>().Contains(input);
    public bool ValidateDifficulty(string input) => Enum.GetNames<Difficulty>().Contains(input);
}