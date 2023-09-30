using MathGame;
void HandleChoices(List<string> results)
{
    bool onGoingGame;
    do
    {
        var choice = Console.ReadLine();
        Display.DisplayDivider();
        onGoingGame = false;
        try
        {
            switch (Int32.Parse(choice))
            {
                case 1:
                    results.Add(ActionHandler.HandleAddition()); break;
                case 2:
                    results.Add(ActionHandler.HandleSubtraction()); break;
                case 3:
                    results.Add(ActionHandler.HandleMultiplication()); break;
                case 4:
                    results.Add(ActionHandler.HandleDivision()); break;
                case 5:
                    Display.DisplayResults(results); break;
                default:
                    Display.DisplayWrongOption();
                    onGoingGame = true;
                    break;
            }
        }
        catch (FormatException)
        {
            Display.DisplayWrongOption();
            onGoingGame = true;
        }
        catch (ArgumentNullException)
        {
            Display.DisplayWrongOption();
            onGoingGame = true;
        }
    } while (onGoingGame) ;
}
bool PlayAgain()
{
    Display.DisplayPlayAgainQuestion();
    var choice = Console.ReadLine();
    choice ??= "";
    bool incorrectChoice;
    do
    {
        incorrectChoice = false;
        switch (choice.ToLower())
        {
            case "yes":
                return true;
            case "no":
                return false;
            default:
                Display.DisplayWrongOption();
                incorrectChoice = true;
                break;
        }
    } while (incorrectChoice);

    return true;
}

void Game()
{
    List<string> results = new();
    Display display = new();
    bool onGoing;
    do
    {
        display.DisplayMenu();
        HandleChoices(results);
        onGoing = PlayAgain();
        if (!onGoing)
        {
            Display.DisplayResults(results);
        }
    }while(onGoing);
}

Game();