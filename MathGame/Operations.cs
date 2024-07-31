namespace MathGame
{
    public class Operations
    {
        public static string Operation { get; set; }
        public static void Addition()
        {
            Console.Clear();
            Operation = "Addition";

            do
            {
                TextOutput.StartGame(Operation);

                Difficulty.PickDifficulty(Operation, TextOutput.Rounds);

                for (int i = 0; i < TextOutput.Rounds; i++)
                {
                    TextOutput.TimedCalculation(Operation);
                    
                    TextOutput.Result();
                }
            } while (TextOutput.PlayAgain() == true);

            Menu.MenuOptions();
        }

        public static void Substraction()
        {
            Console.Clear();
            Operation = "Substraction";

            do
            {
                TextOutput.StartGame(Operation);

                Difficulty.PickDifficulty(Operation, TextOutput.Rounds);

                for (int i = 0; i < TextOutput.Rounds; i++)
                {
                    TextOutput.TimedCalculation(Operation);

                    TextOutput.Result();
                }
            } while (TextOutput.PlayAgain() == true);

            Menu.MenuOptions();
        }

        public static void Multiplication()
        {
            Console.Clear();
            Operation = "Multiplication";

            do
            {
                TextOutput.StartGame(Operation);

                Difficulty.PickDifficulty(Operation, TextOutput.Rounds);

                for (int i = 0; i < TextOutput.Rounds; i++)
                {
                    TextOutput.TimedCalculation(Operation);

                    TextOutput.Result();
                }
            } while (TextOutput.PlayAgain() == true);

            Menu.MenuOptions();
        }

        public static void Division()
        {
            Console.Clear();
            Operation = "Division";

            do
            {
                TextOutput.StartGame(Operation);

                Difficulty.PickDifficulty(Operation, TextOutput.Rounds);

                for (int i = 0; i < TextOutput.Rounds; i++)
                {
                    TextOutput.TimedCalculation(Operation);

                    TextOutput.Result();
                }
            } while (TextOutput.PlayAgain() == true);

            Menu.MenuOptions();
        }
    }
}
