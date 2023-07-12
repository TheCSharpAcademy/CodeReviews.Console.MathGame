using static Math_Game_lib.Helpers;

namespace Math_Game_lib
{
    public static class Menu
    {
        public static void MainMenu()
        {
            bool anotherGame = true;

            do
            {
                ShowMenu();

                string choice = UserValidations.GetChoice(Console.ReadLine());

                anotherGame = ChooseTypeOfGame(anotherGame, choice);
            }
            while (anotherGame);

            Console.Clear();
            Console.WriteLine("Thank you for playing Math game!");
        }

    }
}
