namespace MathGame
{
    public class Menu
    {
        public static void MenuOptions()
        {
            Console.Clear();
            Console.Write("Welcome to the Math Game. Please pick an option between 1 and 4 to start a game:\n");
            Console.WriteLine("\n" +
                "1. Addition\n" +
                "2. Substraction\n" +
                "3. Multiplication\n" +
                "4. Division\n" +
                "5. Random game\n" +
                "6. Show all scores\n" +
                "7. Exit");

            bool again = true;

            do
            {
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Operations.Operation("Addition");
                        break;
                    case "2":
                        Operations.Operation("Substraction");
                        break;
                    case "3":
                        Operations.Operation("Multiplication");
                        break;
                    case "4":
                        Operations.Operation("Division");
                        break;
                    case "5":
                        Randomizer.RandomGame();
                        break;
                    case "6":
                        Score.ShowScores();
                        break;
                    case "7":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please pick an option between 1 and 7.");
                        again = false;
                        break;
                }
            } while (again == false);
        }
    }
}
