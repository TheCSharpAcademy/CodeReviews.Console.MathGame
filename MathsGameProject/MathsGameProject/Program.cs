using MathsGameProject;



Helpers.GetName();

do
{
    Menu.MainMenu();
    Action method = ConfigurationSettings.GameType switch
    {
        Enums.GameTypes.addition => () => GameEngine.PlayGame(),
        Enums.GameTypes.subtraction => () => GameEngine.PlayGame(),
        Enums.GameTypes.multiplication => () => GameEngine.PlayGame(),
        Enums.GameTypes.division => () => GameEngine.PlayGame(),
        Enums.GameTypes.Random => () => GameEngine.PlayGame(),
        Enums.GameTypes.ViewHistory => () =>Helpers.ViewGameHistory(),
        Enums.GameTypes.Configuration => () => Helpers.Configuration(),
        Enums.GameTypes.QuitGame => () => { },
        _ => () => { }
    };
    method();

} while (ConfigurationSettings.GameType != Enums.GameTypes.QuitGame) ;

Console.WriteLine("Thank you for playing. Press any key to exit");
Console.ReadKey();










