namespace MathGame
{
    public class Operations
    {
        public static string MathOperation { get; set; }
        public static void Operation(string mathOperation)
        {
            Console.Clear();
            MathOperation = mathOperation;

            do
            {
                TextOutput.StartGame(MathOperation);

                Difficulty.PickDifficulty(MathOperation, TextOutput.Rounds);

                for (int i = 0; i < TextOutput.Rounds; i++)
                {
                    TextOutput.TimedCalculation(MathOperation);
                    
                    TextOutput.Result();
                }
            } while (TextOutput.PlayAgain() == true);

            Menu.MenuOptions();
        }
        
    }
}
