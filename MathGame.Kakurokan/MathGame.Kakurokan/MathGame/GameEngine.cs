using Spectre.Console;

namespace MathGame
{
    internal static class GameEngine
    {
        public static void Game(Operations operation, Difficulties difficulty)
        {
            bool win = false;
            char operation_simbol = Check_Operation(operation);
            bool random = false;

            if (operation_simbol == 'r')
            {
                random = true;
            }

            int difficulty_multiplier = difficulty switch
            {
                Difficulties.Easy => 1,
                Difficulties.Medium => 10,
                Difficulties.Hard => 100,
            };

            for (int i = 1; i < 6; i++)
            {
                int n1 = new Random().Next(100 * difficulty_multiplier);
                int n2 = new Random().Next(100 * difficulty_multiplier);

                if (random)
                {
                    operation_simbol = Check_Operation((Operations)new Random().Next(1, 4));
                }
                else if (operation_simbol == '/')
                {
                    while (n1 % n2 != 0)
                    {
                        n1 = new Random().Next(100 * difficulty_multiplier);
                        n2 = new Random().Next(100 * difficulty_multiplier);
                    }
                }

                AnsiConsole.Markup($"Write: [underline]{n1} {operation_simbol} {n2}[/] = ");
                if (Check_result(operation_simbol, int.Parse(Console.ReadLine()), n1, n2))
                {
                    AnsiConsole.Clear();
                    AnsiConsole.MarkupLine($"[lightgreen]Right answer!![/]");
                    AnsiConsole.MarkupLine($"[bold][[{i}/5]][/]");
                    Thread.Sleep(1800);
                    AnsiConsole.Clear();

                }
                else
                {
                    AnsiConsole.Clear();
                    AnsiConsole.MarkupLine($"[red]Sorry, you loose[/]");
                    Thread.Sleep(1500);
                    AnsiConsole.Clear();
                    Program.games.Add(false);
                    break;
                }
                win = true ? i == 5 : false;
            }
            if (win)
            {
                AnsiConsole.Markup("[green]Congratulations!![/] [bold]You won the MathGame!![/]");
                Thread.Sleep(2600);
                Program.games.Add(true);
            }
            Program.Main();
        }

        public static bool Check_result(Char operation_simbol, int user_result, int n1, int n2)
        {
            double true_result = operation_simbol switch
            {
                '+' => n1 + n2,
                '-' => n1 - n2,
                '*' => n1 * n2,
                '/' => n1 / n2
            };
            return true_result == user_result;
        }

        public static char Check_Operation(Operations operation) => operation switch
        {
            Operations.Addition => '+',
            Operations.Subtraction => '-',
            Operations.Multiplication => '*',
            Operations.Division => '/',
            Operations.Random => 'r'
        };

        public enum Operations
        {
            Addition = 1,
            Subtraction = 2,
            Multiplication = 3,
            Division = 4,
            Random = 5
        }
        public enum Difficulties
        {
            Easy,
            Medium,
            Hard
        }

    }
}
