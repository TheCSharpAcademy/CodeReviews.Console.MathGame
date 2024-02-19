namespace MathGame
{
    internal class Menu
    {
        string? result;
        internal void ShowMenu()
        {
            bool gameEnd = false;
            while (!gameEnd)
            {
                Console.Clear();
                Console.WriteLine("MATH GAME");
                Console.WriteLine("----------");
                Console.WriteLine("1. Play");
                Console.WriteLine("2. History");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");
                result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                switch (result)
                {
                    case "1":
                        ChooseGame();
                        break;
                    case "2":
                        Helpers.ShowHistory();
                        break;
                    case "3":
                        Console.WriteLine("BYE");
                        gameEnd = true;
                        break;
                    default:
                        ShowMenu();
                        break;

                }
            }
        }
        internal void ChooseGame()

        {
            GameEngine engine = new();
            Console.Clear();
            Console.WriteLine("MATH GAME");
            Console.WriteLine("----------");
            Console.WriteLine("Choose a game: ");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Divison");
            Console.WriteLine("5. Random");
            result = Console.ReadLine();

            result = Helpers.ValidateResult(result);

            switch (result)
            {
                case "1":
                    try
                    {
                        engine.AdditionGame();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        Console.WriteLine("Press enter to go back to main menu");
                        Console.ReadLine();
                    }
                    break;
                case "2":
                    try
                    {
                        engine.SubtractionGame();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        Console.WriteLine("Press enter to go back to main menu");
                        Console.ReadLine();
                    }
                    break;
                case "3":
                    try
                    {
                        engine.MultiplicationGame();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        Console.WriteLine("Press enter to go back to main menu");
                        Console.ReadLine();
                    }
                    break;
                case "4":
                    try
                    {
                        engine.DivisionGame();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        Console.WriteLine("Press enter to go back to main menu");
                        Console.ReadLine();
                    }
                    break;
                case "5":
                    try
                    {
                        engine.RandomGame();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        Console.WriteLine("Press enter to go back to main menu");
                        Console.ReadLine();
                    }
                    break;
                default:
                    Console.WriteLine("Thats not a valid option, please type only the number of the option.");
                    ChooseGame();
                    break;
            }
        }
        internal string ChooseDifficulty()
        {
            Console.Clear();
            Console.WriteLine("MATH GAME");
            Console.WriteLine("----------");
            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Medium");
            Console.WriteLine("3. Hard");
            Console.WriteLine("4. Impossible");
            result = Console.ReadLine();

            result = Helpers.ValidateResult(result);
            return result;
        }
    }
}