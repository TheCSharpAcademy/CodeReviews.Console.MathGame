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
                string type = Type[game - 1];

                switch (game)
                {
                    case 1:
                        Difficulty.Easy(type, 1);
                        TextOutput.TimedCalculation(type);
                        TextOutput.Result();

                        break;
                    case 2:
                        Difficulty.Medium(type, 1);
                        TextOutput.TimedCalculation(type);
                        TextOutput.Result();
                        break;
                    case 3:
                        Difficulty.Hard(type, 1);
                        TextOutput.TimedCalculation(type);
                        TextOutput.Result();
                        break;
                }

            } while (TextOutput.PlayAgain() == true);

            Menu.MenuOptions();
        }
    }
}
