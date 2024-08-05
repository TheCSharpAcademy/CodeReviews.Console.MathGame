namespace MathGame
{
    public class Randomizer
    {
        public static List<string> Type = new List<string> { "Addition", "Substraction", "Multiplication", "Division" };
        public static void RandomGame()
        {
            Console.Clear();
            Random random = new Random();           

            do
            {
                int game = random.Next(1, 4);
                string type = Type[random.Next(0, 4)];

                switch (game)
                {
                    case 1:
                        Difficulty.DifficultyGenerator(type, 1, "Easy");
                        TextOutput.TimedCalculation(type);
                        TextOutput.Result();

                        break;
                    case 2:
                        Difficulty.DifficultyGenerator(type, 1, "Medium");
                        TextOutput.TimedCalculation(type);
                        TextOutput.Result();
                        break;
                    case 3:
                        Difficulty.DifficultyGenerator(type, 1, "Hard");
                        TextOutput.TimedCalculation(type);
                        TextOutput.Result();
                        break;
                }

            } while (TextOutput.PlayAgain() == true);

            Menu.MenuOptions();
        }
    }
}
