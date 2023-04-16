namespace MathGame.barakisbrown;

internal class Helpers
{
    internal static string ValidateResults(string ?result, string prompt)
    {
        while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
        {
            Console.WriteLine("Your answer needs to be an integer. Try Again.");
            Console.Write(prompt);
            result = Console.ReadLine();
        }
        return result;
    }

    internal static string GetName()
    {
        Console.Write("Enter your name: ");
        string ?name = Console.ReadLine();

        while(string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Name can not be empty. Please try again.");
            name = Console.ReadLine();
        }
        return name;
    }

    internal static MenuOptions ShowMenu(string ?name)
    {
        MenuOptions _options = MenuOptions.Quit;
        string Prompt = $@"
            Welcome {name} to MathGame.  Any numbers used will be integers and the max value of 100. 
            Please Select a menu option:

            A)ddition
            S)ubtraction
            M)ultiplication
            D)ivision

            L)ist games played
            C)hange Difficutly if you dare.
            Q)uit the game

            Select your choice [A/S/M/D/L/C/Q]?
        ";

        Console.WriteLine(Prompt);

        char key = Console.ReadKey(true).KeyChar;

        switch (key)
        {
            case 'A':
            case 'a':
                _options = MenuOptions.Addition;
                break;
            case 'S':
            case 's':
                _options = MenuOptions.Subtraction;
                break;
            case 'M':
            case 'm':
                _options = MenuOptions.Multiplication;
                break;
            case 'D':
            case 'd':
                _options = MenuOptions.Division;
                break;
            case 'L':
            case 'l':
                _options = MenuOptions.ListGamesPlayed;
                break;
            case 'C':
            case 'c':
                _options = MenuOptions.ChangeDifficulty;
                break;
            case 'Q':
            case 'q':
                _options = MenuOptions.Quit;
                break;
        }
        return _options;
    }
}
