using Spectre.Console;

namespace MathsGameProject
{
    internal static class Helpers
    {
        internal static List<string[]> GameHistory = new List<string[]>();
        internal static void ViewGameHistory()
        {
            var table = new Table();
            table.Border(TableBorder.Rounded);

            table.AddColumn("[yellow]Date[/]");
            table.AddColumn("[yellow]Game Type[/]");
            table.AddColumn("[yellow]Score[/]");
            table.AddColumn("[yellow]Dificulty Level[/]");
            table.AddColumn("[yellow]Time Used[/]");


            foreach (var game in GameHistory)
            {
                table.AddRow(
                    $"[cyan]{game[0]} [/]",
                    $"[cyan]{game[1]} [/]",
                    $"[cyan]{game[2]} [/]",
                    $"[cyan]{game[3]} [/]",
                    $"[cyan]{game[4]} [/]"
                    );
            }

            AnsiConsole.Write(table);
            AnsiConsole.MarkupLine("Press Any Key to Continue.");
            Console.ReadKey();
        }

        internal static void AddToHistroy(int score, string timeUsed)
        {
            string level = ConfigurationSettings.DificultyLevel.ToString();
            string gameType = ConfigurationSettings.GameType.ToString();
            string[] game = new string[] { DateTime.Now.ToString("g"), gameType, score.ToString(), level, timeUsed };
            GameHistory.Add(game);

        }

        internal static void Configuration()
        {
            bool validRound = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Maths Game Configuration\n");
                Console.WriteLine($"Rounds is set to < {ConfigurationSettings.Rounds} >\n");
                Console.WriteLine("Enter new value from 1 to 10");

                var NewRounds = Console.ReadLine();
                if (int.TryParse(NewRounds, out int parseRounds))
                {

                    if (parseRounds > 0 && parseRounds < 11)
                    {
                        ConfigurationSettings.Rounds = parseRounds;
                        validRound = true;
                    }
                }
                if (!validRound)
                {
                    Console.WriteLine("You must enter an interger between 1 and 10. Press any key to continue");
                    Console.ReadKey();
                }
            } while (!validRound);

            Console.WriteLine("\n");

            ConfigurationSettings.DificultyLevel = AnsiConsole.Prompt(
            new SelectionPrompt<Enums.Dificulty>()
                .Title("Choose a Dificulty Level")
                .AddChoices(Enum.GetValues<Enums.Dificulty>()));

            Console.Clear();
            Console.WriteLine($"You have chosen:\n");
            Console.WriteLine($"A {ConfigurationSettings.Rounds} round Game");
            Console.WriteLine($"A dificulty level of: {ConfigurationSettings.DificultyLevel}");
            Console.WriteLine("\nPress any key to return to the Main Menu");
            Console.ReadKey();




        }

        internal static int[] GetNumbers(Enums.GameTypes gameType)
        {
            var getInt = new Random();
            var result = new int[2];
            int firstNumber = getInt.Next(1, (int)ConfigurationSettings.DificultyLevel);
            int secondNumber = getInt.Next(1, (int)ConfigurationSettings.DificultyLevel);
            if (gameType == Enums.GameTypes.division)
            {
                while (firstNumber % secondNumber != 0)
                {
                    firstNumber = getInt.Next(1, (int)ConfigurationSettings.DificultyLevel);
                    secondNumber = getInt.Next(1, firstNumber);
                }
            }
            result[0] = firstNumber;
            result[1] = secondNumber;
            return result;



        }
        internal static (bool, int) GetGoodAnswer()
        {
            (bool, int) tupleGoodAnswer;
            int intAnswer = 0;

            var answer = Console.ReadLine();

            bool boolAnswer = (int.TryParse(answer, out intAnswer));
            if (!boolAnswer || string.IsNullOrEmpty(answer))
            {
                Console.WriteLine("you must enter an Integer for your answer. Press a key to continue");
                Console.ReadKey();
            }
            tupleGoodAnswer = (boolAnswer, intAnswer);
            return tupleGoodAnswer;
        }

        internal static void GetName()
        {
            string? name = "";

            while (string.IsNullOrEmpty(name))
            {
                Console.Clear();
                Console.WriteLine("What is your name?");
                name = Console.ReadLine();
                Console.WriteLine($"\nHi {name}, press any key to play the Maths Game");
                Console.ReadKey();
            }
        }

    }
}
