namespace MathGame
{
    public static class Menu
    {
        static List<Game> games = new();

        public static void Show()
        {
            while (true)
            {
                Console.WriteLine("Menu: F1 - Новая игра; F2 - Случайная игра; F3 - История; Esc - Выход");

                while (true)
                {
                    var selected = false;
                    var theEnd = false;

                    ConsoleKey key = Console.ReadKey().Key;
                    switch (key)
                    {
                        case ConsoleKey.F1:
                            selected = true;
                            StartNewGame();
                            break;
                        case ConsoleKey.F2:
                            selected = true;
                            StartRandomGame();
                            break;
                        case ConsoleKey.F3:
                            selected = true;
                            ViewHistory();
                            break;
                        case ConsoleKey.Escape:
                            theEnd = true;
                            break;
                        default:
                            continue;
                    }
                    if (theEnd)
                    {
                        Environment.Exit(0);
                    }
                    if (selected)
                    {
                        break;
                    }
                }
                Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в меню.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        
        private static void StartNewGame()
        {
            var player = PlayerInput();
            var level = LevelInput();
            var operation = OperationInput();

            var game = new Game(NewNumberGame(), player, level, operation);
            game.Play();
            games.Add(game);
        }
        private static void StartRandomGame()
        {
            var game = new Game(NewNumberGame(), PlayerInput());
            game.Play();
            games.Add(game);
        }
        private static void ViewHistory()
        {
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Id}. Игрок {game.Player} Правильно {game.Score} Всего {game.Examples.Count()} Время {game.Time}");
            }
        }
        private static Player PlayerInput()
        {
            string name = "";
            while (name == "")
            {
                Console.Write("Введи свое имя: ");
                name = Console.ReadLine();
            }
            return new Player(name);
        }
        private static Level LevelInput()
        {
            var levels = Enum.GetValues(typeof(Level));
            var indexLevels = (int[])levels;
            int minLevel = indexLevels.Min();
            int maxLevel = indexLevels.Max();

            int levelNumber = 0;
            while (levelNumber < minLevel || levelNumber > maxLevel)
            {
                Console.Write($"Выбери уровень сложности от {minLevel} до {maxLevel}: ");
                int.TryParse(Console.ReadLine(), out levelNumber);
            }
            return (Level)Enum.GetValues(typeof(Level)).GetValue(levelNumber);
        }
        private static List<Operation> OperationInput()
        {
            var operations = new List<Operation>();
            while (operations.Count < 5)
            {
                operations.Clear();

                Console.Write($"Введи через пробел операторы +, -, *, / (не менее 5 шт) ");
                var stringOperations = Console.ReadLine();
                var arrayOperations = stringOperations.Split();
                foreach (var oper in arrayOperations)
                {
                    var selectOper = SelectedOperation(oper);
                    if (selectOper != null)
                    {
                        operations.Add(selectOper ?? Operation.Subtraction); // todo Nullable Reference Types
                    }
                }
            }
            return operations;
        }
        private static Operation? SelectedOperation(string inputVal)
        {
            if (inputVal == "+")
                return Operation.Addition;
            if (inputVal == "-")
                return Operation.Subtraction;
            if (inputVal == "*")
                return Operation.Multiplication;
            if (inputVal == "/")
                return Operation.Division;
            return null;
        }
        private static int NewNumberGame()
        {
            return games.Count() + 1;
        }
    }
}