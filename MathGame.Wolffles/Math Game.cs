namespace Math_Game;

internal class MathGame

{
    static void Main()
    {

        Menu menu = new Menu();
        menu.InitializeMenuParameters();
        bool runGame = true;


        while (runGame)
        {
            runGame = menu.StartMenu();
        }
   
    }
}