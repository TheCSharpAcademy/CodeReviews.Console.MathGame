namespace MathGamer;
internal class Menu
{
    GameLogic logic = new GameLogic();
    private int selectedIndex = 0;

    string[] options = new string[6] { "Addition", "Subtraction", "Multiplication", "Division", "View History", "Quit", };
    public void ShowMenu(string name)
    {
        bool playAgain = true;
        while (playAgain)
        {
            selectedIndex = Helpers.MenuRun(name, options, selectedIndex);
            


            Console.Clear();

            

            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine(Figgle.FiggleFonts.Ogre.Render("Addition"));
                    logic.AdditionGame("Addition game selected");
                    break;
                case 1:
                    Console.WriteLine(Figgle.FiggleFonts.Ogre.Render("Subtraction"));
                    logic.SubtractionGame("Subtraction game selected");
                    break;
                case 2:
                    Console.WriteLine(Figgle.FiggleFonts.Ogre.Render("Multiplication"));
                    logic.MultiplicationGame("Multiplication game selected");
                    break;
                case 3:
                    Console.WriteLine(Figgle.FiggleFonts.Ogre.Render("Division"));
                    logic.DivisionGame("Division game selected");
                    break;
                case 4:
                    Helpers.GetGames();
                    break;
                case 5:
                    Console.WriteLine("Bye");
                    Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("Invalid Input...");
                    break;
            }

            if (selectedIndex != 4)
            {
                Console.WriteLine("Press ENTER key to go back");
                ConsoleKeyInfo pAKey = Console.ReadKey(true);
                ConsoleKey kPressed = pAKey.Key;
                
                if (kPressed == ConsoleKey.Enter)
                {
                    playAgain = true;
                    Console.Clear();
                }
                else
                {
                    playAgain = false;
                }
            }

        }
    }
}
