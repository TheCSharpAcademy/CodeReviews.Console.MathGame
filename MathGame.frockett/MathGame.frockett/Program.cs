namespace MathGame.frockett;

internal class Program
{
    static void Main(string[] args)
    {
        /* Challenge:
         * 1. Levels of difficulty
         * 2. Add a timer to track how long the user takes to finish the game
         * 3. Let user pick number of questions
         */ 

        Menu menu = new Menu();

        DateTime date = DateTime.UtcNow;

        menu.ShowMenu(date);


    }


}