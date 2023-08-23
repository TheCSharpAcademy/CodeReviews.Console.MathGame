namespace MathGame
{
    internal class GameManager
    {
        private int _round_count = 5;
        private int Point { get; set; }
        private bool IsDifficult { get; set; }
        private SELECTOR Selector { get; set; }
        private List<History> _history;

        public GameManager()
        {
            Selector = SELECTOR.INVALID_SELECT;
            Point = 0;
            IsDifficult = false;
            _history = new();
            MainMenu();
        }

        private void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("".PadRight(24, '='));
            Console.WriteLine($"Choose your game. Your current score is {Point}");
            Console.WriteLine("0. View Previous Games");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Substraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Random Game");
            Console.WriteLine("6. Levels of Difficulty");
            Console.WriteLine("9. Exit The Program");
            Console.WriteLine("".PadRight(24, '='));
            Selector = (SELECTOR)GetInput("").val;
            Begin(Selector);
        }

        private void Begin(SELECTOR selector)
        {
            Console.Clear();
            if (selector == SELECTOR.ViewPreviousGames)
            {
                ShowHistory();
                WaitForInput($"Press any button to go back to the main menu.");
            }
            else if (selector == SELECTOR.EXIT)
            {
                WaitForInput($"Bye Bye");
                Environment.Exit(0);
            }
            else if (selector == SELECTOR.Difficulty)
            {
                string level = IsDifficult ? "DIFFICULT" : "EASY";
                var diff = GetInput($"Current Difficulty : {level}\nWould you want to change it ? (Y)").str;
                IsDifficult = diff == "Y"? !IsDifficult : IsDifficult;
                WaitForInput($"Difficulty has changed");
            }
            else
            {
                var input_number = GetInput("Enter the number of questions.");
                if (input_number.res)
                {
                    _round_count = input_number.val;
                    Console.Clear();

                    Random rand = new();
                    int _point = 0;
                    var isRandom = selector == SELECTOR.RandomGame;
                    var startTime = DateTime.Now;
                    for (int i = 0; i < _round_count; i++)
                    {
                        selector = isRandom ? (SELECTOR)rand.Next(1, 5) : selector ;
                        _point += Operation(selector) ;
                    }
                    var playTime = DateTime.Now - startTime;
                    Console.WriteLine($"Your score is {_point}.");
                    Console.WriteLine($"Your play time is {playTime.ToString("ss")} seconds.");
                    WaitForInput($"Press any button to go back to the main menu.");
                }
                else WaitForInput("Invalid Input. Try again.");
            }

            MainMenu();
        }

        private void WaitForInput(string message) 
        {
            Console.WriteLine(message);
            Console.ReadLine();
        }

        private int Operation(SELECTOR selector)
        {
            Game game = new(selector,IsDifficult);
            Console.WriteLine(game.Question);
            game.Input = GetInput("").val;
            var result = game.GetResult();
            Point += (result.resultType == "CORRECT") ? 1 : 0;
            WaitForInput(result.resultMessage);
            AddHistory(result);

            Console.Clear();
            return (result.resultType == "CORRECT") ? 1 : 0;
        }

        private void AddHistory((string question, int answer, int input, string resultMessage, string resultType) result)
        {
            DateTime dateTime = DateTime.Now;
            _history.Add(new History(dateTime, result.question, result.answer, result.input, result.resultType));
        }

        private void ShowHistory()
        {
            if (_history.Count == 0) Console.WriteLine("There is no previous history !");
            else
            {
                Console.WriteLine($"{"Time",-25}{"Question",-20}{"CorrectAnswer",-20}{"Answer",-20}{"Result",-5}");
                Console.WriteLine("".PadRight(100, '='));

                foreach (var history in _history)
                {
                    Console.WriteLine($"{history.Time,-25}{history.Question,-20}{history.CorrectAnswer,-20}{history.Answer,-20}{history.Result,-5}");
                }
            }
            Console.WriteLine("".PadRight(100, '='));
        }

        private (bool res, string str, int val) GetInput(string message)
        {
            // This function returns string input too in case you need it
            int number;
            Console.WriteLine(message);
            Console.Write(">> ");
            string str = Console.ReadLine();
            var res = int.TryParse(str, out number);

            number = res ? number : (int)SELECTOR.INVALID_SELECT;
            str = str == null ? "" : str;

            return (res, str, number);
        }
    }
}
