using Math_Game.Enums;
using Tools;

namespace Math_Game.Tools;

internal class MathQuizUserInteractor : IMathQuizUserInteractor
{
    readonly IUserInteractor _console;
    readonly Validator _validator;

    public MathQuizUserInteractor(Validator validator, IUserInteractor console)
    {
        _validator = validator;
        _console = console;
    }

    public void DisplayMenu()
    {
        _console.DisplayMessage("");
        foreach(var option in Enum.GetNames<MenuOptions>())
        {
            ColorChanger.WriteColored(ConsoleColor.Magenta, option);
        }
        _console.DisplayMessage("");
        ColorChanger.Reset();
    }
    public void DisplayDifficulties()
    {
        _console.DisplayMessage("");
        foreach (var option in Enum.GetNames<Difficulty>())
        {
            ColorChanger.WriteColored(ConsoleColor.Magenta, option);
        }
        _console.DisplayMessage("");
        ColorChanger.Reset();
    }
    public string PromptForOption()
    {
        string? userInput;
        bool isInputValid;
        do
        {
            _console.DisplayMessage("Choose from the list what type of game you want to play by selecting the option name.");
            _console.DisplayMessage("");
            userInput = _console.GetUserInput();
            isInputValid = _validator.ValidateMenuOption(userInput);
        } while (!isInputValid);
        return userInput;
    }

    public string PromptForDifficulty()
    {
        string? userInput;
        bool isInputValid;
        do
        {
            _console.DisplayMessage("Choose the difficulty you prefer by selecting the option name.");
            _console.DisplayMessage("");
            userInput = _console.GetUserInput();
            isInputValid = _validator.ValidateDifficulty(userInput);
        } while (!isInputValid);
        return userInput;
    }

    public void DisplayMessage(string message)
    {
        _console.DisplayMessage(message);
    }
    
    public string PromptForAnswer()
    {
        string userInput;
        _console.WriteOnSameLine($"|        Your answer: {userInput = _console.GetUserInput()}       |");
        return userInput;
    }

    public void DisplayCorrect()
    {
        ColorChanger.ChangeText(ConsoleColor.Green);
        _console.DisplayMessage("");
        _console.DisplayMessage("------------");
        _console.DisplayMessage("| Correct! |");
        _console.DisplayMessage("------------");
        _console.DisplayMessage(@"
             .-""""""""""""-.
          .-'                '-.
        .'                      '.
       /                          \
      /                            \
     :       ██          ██        :
     |      ████        ████       |
     |      ████        ████       |
     :                              :
     |                              |
     |     (                  )     |
     |      \                /      |
     |       \              /       |
     |        '------------'        |
     :                              :
      \                            /
       '.                        .'
         '-.                  .-'
            '-.____________.-'
");
        ColorChanger.Reset();
        ReadKey();
        Clear();
    }

    public void DisplayIncorrect(string result)
    {
        ColorChanger.ChangeText(ConsoleColor.Red);
        _console.DisplayMessage("");
        _console.DisplayMessage("-------------------------------");
        _console.DisplayMessage($"| Incorrect! The result was {result} |");
        _console.DisplayMessage("-------------------------------");
        _console.DisplayMessage(@"
             .-""""""""""""-.
          .-'                '-.
        .'                      '.
       /                          \
      /                            \
     :       ██          ██        :
     |      ████        ████       |
     |      ████        ████       |
     :                              :
     |                              |
     |        .------------.        |
     |       /   v     v    \       |
     |      /                \      |
     |     (                  )     |
     :                              :
      \                            /
       '.                        .'
         '-.                  .-'
            '-.____________.-'
");
        ColorChanger.Reset();
        ReadKey();
        Clear();
    }
    public bool PromptForGameEnd()
    {
        _console.DisplayMessage("----------------------------------");
        _console.DisplayMessage("| Do you want to play again? Y/N |");
        _console.DisplayMessage("----------------------------------");
        return string.Equals(_console.GetUserInput().ToUpper(), "Y"); 
    }

    public void DisplayResults(List<(int Points, double Time)> results)
    {
        _console.Clear();
        ColorChanger.WriteColored(ConsoleColor.Yellow, "Today's Results:");
        results
        .Select((result, i) => (result, i))
        .ToList()
        .ForEach(result => ColorChanger.WriteColored
        (ConsoleColor.DarkYellow, $"| - Game n°{result.i + 1}: {result.result.Points} points. {result.result.Time} seconds. - |"));
        ReadKey();
        _console.Clear();
    }

    public void Clear()
    {
        _console.Clear();
    }

    public void ReadKey()
    {
        _console.DisplayMessage("Press any key to continue.");
        _console.ReadKey();
    }
    public void Quit()
    {
        _console.DisplayMessage("---------------------------------------------");
        _console.DisplayMessage("| Thanks for playing! Press any key to exit. |");
        _console.DisplayMessage("---------------------------------------------");
        ReadKey();
    }
}