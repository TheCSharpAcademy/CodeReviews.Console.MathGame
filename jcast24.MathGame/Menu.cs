namespace jcast24.MathGame;
internal class Menu
{
    internal int AskUser()
    {
        // Console.WriteLine("Please enter the amount of questions you would like to ask: ");
        // int input = int.Parse(Console.ReadLine());
        // return input;
        int number;
        bool isValid = false;

        do
        {
            Console.WriteLine("Please enter the amount of questions you would like to be asked: ");
            var input = Console.ReadLine();

            isValid = int.TryParse(input, out number);

            if (!isValid)
            {
                Console.WriteLine("Invalid input please try again: ");
            }
        } while (!isValid);

        return number;
    }
    
    internal void MenuSystem()
    {
        Engine engine = new Engine();
        bool isGameOn = true;

        int numOfGames = AskUser();

        do
        {
            Console.Clear();
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("(a) Addition");
            Console.WriteLine("(s) Subtraction");
            Console.WriteLine("(m) Multiplication");
            Console.WriteLine("(d) Division");
            Console.WriteLine("(v) View games!");
            Console.WriteLine("(r) Random Game!");
            Console.WriteLine("(q) Quit!");

            string? input = Console.ReadLine();

            switch (input.Trim().ToLower())
            {

                case "a":
                    engine.Addition(numOfGames);
                    break;
                case "s":
                    engine.Subtraction(numOfGames);
                    break;
                case "m":
                    engine.Multiplication(numOfGames);
                    break;
                case "d":
                    engine.Division(numOfGames);
                    break;
                case "v":
                    engine.GetGames();
                    break;
                case "r":
                    engine.RandomGame(numOfGames);
                    break;
                case "q":
                    Console.WriteLine("Goodbye! Thank you for playing!");
                    isGameOn = false;
                    break;
                default:
                    Console.WriteLine("Please type a correct value");
                    break;
            }
        } while (isGameOn);
    }
}