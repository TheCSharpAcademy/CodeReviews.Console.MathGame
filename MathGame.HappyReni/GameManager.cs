namespace MathGame
{

    internal class GameManager
    {
        private int _round_count = 5;
        private int _point { get; set; }
        private bool _isDifficult { get; set; }
        private SELECTOR _selector { get; set; }
        private List<History> _history;

        public GameManager()
        {
            _selector = SELECTOR.INVALID_SELECT;
            _point = 0;
            _isDifficult = false;
            _history = new();
            MainMenu();
        }

        private void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("".PadRight(24, '='));
            Console.WriteLine("Choose your game.");
            Console.WriteLine("0. View Previous Games");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Substraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Random Game");
            Console.WriteLine("6. Levels of Difficulty");
            Console.WriteLine("9. Exit The Program");
            Console.WriteLine("".PadRight(24, '='));
            _selector = (SELECTOR)GetInput("").val;
            Begin(_selector);
        }

        private void Begin(SELECTOR s)
        {
            Console.Clear();
            if (s == SELECTOR.ViewPreviousGames)
            {
                ShowHistory();
                WaitForInput($"Press any button to go back to the main menu.");
            }
            else if (s == SELECTOR.EXIT)
            {
                WaitForInput($"Bye Bye");
                Environment.Exit(0);
            }
            else if (s == SELECTOR.Difficulty)
            {
                string level = _isDifficult ? "DIFFICULT" : "EASY";
                var diff = GetInput($"Current Difficulty : {level}\nWould you want to change it ? (Y)").str;
                _isDifficult = diff == "Y"? !_isDifficult : _isDifficult;
                WaitForInput($"Difficulty has changed");
            }
            else
            {
                _round_count = GetInput("Enter the number of questions.").val;
                Console.Clear();

                Random rand = new();
                var isRandom = s == SELECTOR.RandomGame;
                var startTime = DateTime.Now;
                for (int i = 0; i < _round_count; i++)
                {
                    s = isRandom ? (SELECTOR)rand.Next(1, 5) : s;
                    Operation(s);
                }
                var playTime = DateTime.Now - startTime;
                Console.WriteLine($"Your final score is {_point}.");
                Console.WriteLine($"Your play time is {playTime.ToString("ss")} seconds.");
                WaitForInput($"Press any button to go back to the main menu.");
            }
            MainMenu();
        }

        private void WaitForInput(string s) 
        {
            Console.WriteLine(s);
            Console.ReadLine();
        }

        private void Operation(SELECTOR s)
        {
            Game game = new(s,_isDifficult);
            Console.WriteLine(game.Question);
            game.Input = GetInput("").val;
            var result = game.GetResult();
            _point += (result.resultType == "CORRECT") ? 1 : 0;
            WaitForInput(result.resultMessage);
            AddHistory(result);

            Console.Clear();
        }

        private void AddHistory((string question, int answer, int input, string resultMessage, string resultType) r)
        {
            DateTime dateTime = DateTime.Now;
            _history.Add(new History(dateTime, r.question, r.answer, r.input, r.resultType));
        }

        private void ShowHistory()
        {
            if (_history.Count == 0) Console.WriteLine("There is no previous history !");
            else
            {
                Console.WriteLine($"{"Time",-25}{"Question",-20}{"CorrectAnswer",-20}{"Answer",-20}{"Result",-5}");
                Console.WriteLine("".PadRight(100, '='));

                foreach (var h in _history)
                {
                    Console.WriteLine($"{h.Time,-25}{h.Question,-20}{h.CorrectAnswer,-20}{h.Answer,-20}{h.Result,-5}");
                }
            }
            Console.WriteLine("".PadRight(100, '='));
        }

        private (bool res, string str, int val) GetInput(string s)
        {
            // This function returns string input too in case you need it
            int number;
            Console.WriteLine(s);
            Console.Write(">> ");
            string str = Console.ReadLine();
            var res = int.TryParse(str, out number);

            number = res ? number : (int)SELECTOR.INVALID_SELECT;
            str = str == null ? "" : str;

            return (res, str, number);
        }
    }
}
