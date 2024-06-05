using System;
namespace MathGame.kjanos89
{
    public class Start
    {
        public void StartMenu()
        {
            //Clearing up the console window, listing the options and taking the first character as input.
            Console.Clear();
            Console.WriteLine("__________________________________________________________________");
            Console.WriteLine($"Hello, {GameData.Name}! You currently have {GameData.Points} amount of points. Choose an option from the menu below by pressing the proper key:");
            Console.WriteLine("A - Addition");
            Console.WriteLine("S - Subtraction");
            Console.WriteLine("M - Multiplication");
            Console.WriteLine("D - Division");
            Console.WriteLine("Q - Quit the program");
            Console.WriteLine("V - View game history");
            Console.WriteLine("__________________________________________________________________");
            string selection = Console.ReadLine().ToLower(); //Converting the input to lowercase in case someone presses shift or has caps-lock on
            GameSelected(selection[0]);
        }

        public static void GameSelected(char selected)
        {
            switch (selected)
            {
                case 'a':
                    AdditionGame addition = new AdditionGame(); //The pattern for every option inside the switch is the same. Creating an object and calling the method off of it.
                    addition.Result();
                    break;
                case 's':
                    SubtractionGame subtraction = new SubtractionGame();
                    subtraction.Result();
                    break;
                case 'm':
                    MultiplicationGame multiplication = new MultiplicationGame();
                    multiplication.Result();
                    break;
                case 'd':
                    DivisionGame division = new DivisionGame();
                    division.Result();
                    break;
                case 'v':
                    ViewHistory();
                    break;
                case 'q':
                    Environment.Exit(3);
                    Console.Clear();
                    Console.WriteLine("The program closes in 3 seconds. Hope to see you soon!");
                    break;

                default:
                    Console.WriteLine("Wrong input, please choose from the menu."); //In case someone presses anything but the option letters
                    break;
            }
        }
        public static void ViewHistory()
        {
            Console.Clear();
            Console.WriteLine("Pressing B will return you to the main menu...\n");
            foreach(string s in GameData.Games)
            {
                Console.WriteLine($"{s}");
            }
            string input = Console.ReadLine();
            if (input.ToLower() == "b")
            {
                Start startObject = new Start();
                startObject.StartMenu();
            }
        }
    }
}
