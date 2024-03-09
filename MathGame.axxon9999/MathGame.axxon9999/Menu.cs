namespace MathGame.axxon9999
{
    internal class Menu
    {
        GameEngine engine = new();

        internal void ShowMenu(string name, DateTime date)
        {

            Helpers.DisplayIntroduction(name, date);

            do
            {
                string mainMenuInput;

                do
                {
                    mainMenuInput = Helpers.DisplayMainMenu(name).ToUpper();

                } while (mainMenuInput != "V" && mainMenuInput != "A" && mainMenuInput != "S" && mainMenuInput != "M" && mainMenuInput != "D" && mainMenuInput != "R" && mainMenuInput != "Q");

                if (mainMenuInput == "Q")
                {
                    Console.Clear();
                    Console.WriteLine("\n\n");
                    Console.WriteLine("Goodbye");
                    Console.WriteLine("\n\n");
                    break;
                }

                if (mainMenuInput == "V")
                {
                    Console.Clear();
                    Helpers.PrintGames();
                    continue;
                }

                Helpers.PrintSelection(mainMenuInput);

                int[] levelInput;
                do
                {
                    Console.WriteLine();
                    levelInput = Helpers.DisplayLevelMenu();

                } while (levelInput[0] < 1 || levelInput[0] > 3);

                int questionsInput;
                do
                {
                    Console.WriteLine();
                    questionsInput = Helpers.DisplayAmountQuestions();

                } while (questionsInput < 5 || questionsInput > 20);

                engine.PlayTheGame(mainMenuInput, questionsInput, levelInput);

            } while (true);
        }
    }
}
