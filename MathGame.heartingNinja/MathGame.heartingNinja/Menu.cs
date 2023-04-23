namespace MathProject
{
    internal class Menu
    {

        GameEngine gameEngine = new();


        internal void ShowMenu(string name, string date)
        {
            Console.Clear();
            Console.WriteLine($"Hello {name.ToUpper()}. It's {date}");
            Console.WriteLine("Press Enter to show menu");
            Console.ReadLine();
            Console.WriteLine("\n");

            bool isGammeOn = true;
            do
            {
                Console.Clear();
                Console.WriteLine($@"What game would you like to play? Choose from options:
V - View Previous Games
A - Addition
S - Subtraction
M - Muliplacation
D - Division
Q - Quit program");
                Console.WriteLine("---------------------------");

                string gameSelected = Console.ReadLine();

                // start menu for difficulty level
                Console.Clear();
                switch (gameSelected.Trim().ToLower())
                {
                    case "v":
                        Helpers.PrintGames();
                        break;
                    case "a":
                        Console.WriteLine("Select difficulty level: ");
                        Console.WriteLine("E - Easy");
                        Console.WriteLine("M - Medium");
                        Console.WriteLine("H - Hard");
                        string diffSelectedA = Console.ReadLine();

                        switch (diffSelectedA.Trim().ToLower())
                        {
                            case "e":
                                gameEngine.low = 1;
                                gameEngine.high = 9;
                                gameEngine.AdditionGame("Addition game - Easy");
                                
                                break;
                            case "m":
                                gameEngine.low = 1;
                                gameEngine.high = 99;
                                gameEngine.AdditionGame("Addition game - Medium");                              
                                break;
                            case "h":
                                gameEngine.low = 1;
                                gameEngine.high = 999;
                                gameEngine.AdditionGame("Addition game - Hard");                        
                                break;
                            default:
                                Console.WriteLine("Invald Input");
                                break;
                        }
                        break;

                    case "s":
                        Console.WriteLine("Select difficulty level: ");
                        Console.WriteLine("E - Easy");
                        Console.WriteLine("M - Medium");
                        Console.WriteLine("H - Hard");
                        string diffSelected = Console.ReadLine();

                        switch (diffSelected.Trim().ToLower())
                        {
                            case "e":
                                gameEngine.low = 1;
                                gameEngine.high = 9;
                                gameEngine.SubtractionGame("Subtractrion game - Easy");
                                break;
                            case "m":
                                gameEngine.low = 1;
                                gameEngine.high = 99;
                                gameEngine.SubtractionGame("Subtractrion game - Medium");
                                break;
                            case "h":
                                gameEngine.low = 1;
                                gameEngine.high = 999;
                                gameEngine.SubtractionGame("Subtractrion game - Hard");
                                break;
                            default:
                                Console.WriteLine("Invald Input");
                                break;
                        }
                        break;

                    case "m":
                        Console.WriteLine("Select difficulty level: ");
                        Console.WriteLine("E - Easy");
                        Console.WriteLine("M - Medium");
                        Console.WriteLine("H - Hard");
                        string diffSelectedM = Console.ReadLine();

                        switch (diffSelectedM.Trim().ToLower())
                        {
                            case "e":
                                gameEngine.low = 1;
                                gameEngine.high = 9;
                                gameEngine.MultiplicationGame("Multiplication game - Easy");
                                break;
                            case "m":
                                gameEngine.low = 1;
                                gameEngine.high = 99;
                                gameEngine.MultiplicationGame("Multiplication game - Medium");
                                break;
                            case "h":
                                gameEngine.low = 1;
                                gameEngine.high = 999;
                                gameEngine.MultiplicationGame("Multiplication game - Hard");
                                break;
                            default:
                                Console.WriteLine("Invald Input");
                                break;
                        }
                        break;

                    case "d":
                        Console.WriteLine("Select difficulty level: ");
                        Console.WriteLine("E - Easy");
                        Console.WriteLine("M - Medium");
                        Console.WriteLine("H - Hard");
                        string diffSelectedD = Console.ReadLine();

                        switch (diffSelectedD.Trim().ToLower())
                        {
                            case "e":
                                gameEngine.low = 1;
                                gameEngine.high = 99;
                                gameEngine.DivisionGame("Division game - Easy");
                                break;
                            case "m":
                                gameEngine.low = 1;
                                gameEngine.high = 999;
                                gameEngine.DivisionGame("Division game - Medium");
                                break;
                            case "h":
                                gameEngine.low = 1;
                                gameEngine.high = 9999;
                                gameEngine.DivisionGame("Division game game - Hard");
                                break;
                            default:
                                Console.WriteLine("Invald Input");
                                break;
                        }
                        break;

                    case "q":
                        Console.WriteLine("GoodBye");
                        isGammeOn = false;
                        break;
                    default:
                        Console.WriteLine("Invald Input");
                        break;
                }
            } while (isGammeOn);
        }
    }
}

        




