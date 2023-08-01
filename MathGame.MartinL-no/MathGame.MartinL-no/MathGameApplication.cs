using MathGame.MartinL_no.Models;
using MathGame.MartinL_no.Services;

namespace MathGame.MartinL_no
{
	internal class MathGameApplication
	{
        private readonly MathGameService _service;

        internal MathGameApplication(MathGameService service)
		{
			_service = service;
        }

		internal void Execute()
		{
            ShowMenu();
		}

        internal void ShowMenu()
        {
            var runMenu = true;
            while(runMenu)
            {
                var options = @$"What game would you like to play today? Choose from the options below:
V - View Previous Games
A - Addition
S - Subtraction
M - Multiplication
D - Division
R - Random game
X - Change difficulty level
Y - Change number of questions
Q - Quit the program";

                var option = Ask(options);

                switch (option.ToUpper())
                {
                    case "V":
                        ViewPreviousGames();
                        break;
                    case "A":
                        Addition();
                        break;
                    case "S":
                        Subtraction();
                        break;
                    case "M":
                        Multiplication();
                        break;
                    case "D":
                        Division();
                        break;
                    case "R":
                        RandomGame();
                        break;
                    case "X":
                        ChangeDifficultyLevel();
                        break;
                    case "Y":
                        SelectNumberOfQuestions();
                        break;
                    case "Q":
                        runMenu = false;
                        break;
                    default:
                        ShowError("Invalid option please try again");
                        break;
                }
            }
        }

        private void ViewPreviousGames()
        {
            var games = _service.GetGameResults();
            var divider = "-------------------------------------------------------------------------------------";
            Console.Clear();
            Console.WriteLine(divider);
            Console.WriteLine($"| Date/Time       |  Duration  |  Type           |  Mode    |  Questions  |  Score  |");
            Console.WriteLine(divider);

            foreach (var game in games)
            {
                Console.WriteLine(game);
            }
            Thread.Sleep(4000);
            Console.Clear();
        }

        private void Addition()
        {
            var game = _service.GetAddition();
            Play(game);
        }

        private void Subtraction()
        {
            var game = _service.GetSubtraction();
            Play(game);
        }

        private void Multiplication()
        {
            var game = _service.GetMultiplication();
            Play(game);
        }

        private void Division()
        {
            var exercise = _service.GetDivision();
            PlayDivision(exercise);
        }

        private void RandomGame()
        {
            var game = _service.GetRandomGame();

            if (game.Type == GameType.Division)
            {
                PlayDivision(game);
            }
            else Play(game);
        }

        private void PlayDivision(Game game)
        {
            while (!game.IsGameOver)
            {
                var input = Ask($@"{game.ValueOne} / {game.ValueTwo} = ?
Your choice: ");

                if (!String.IsNullOrWhiteSpace(input) && Int32.TryParse(input, out int answer))
                {
                    _service.AnswerDivisionEquation(game, answer);
                }
            }
        }

        private void Play(Game game)
        {
            string equationSymbol = game.Type == GameType.Addition ? "+"
                : game.Type == GameType.Subtraction ? "-"
                : game.Type == GameType.Multiplication ? "*"
                : throw new NotImplementedException();

            while (!game.IsGameOver)
            {
                var input = Ask($@"{game.ValueOne} {equationSymbol} {game.ValueTwo} = ?
Your choice: ");

                if (!String.IsNullOrWhiteSpace(input) && Int32.TryParse(input, out int answer))
                {
                    _service.AnswerEquation(game, answer);
                }
            }
        }

        private void ChangeDifficultyLevel()
        {
            int level = 0;
            while (level == 0)
            {
                var input = Ask($@"Which difficulty level would you like:
1 - Easy
2 - Medium
3 - Hard");
                if (!String.IsNullOrWhiteSpace(input) && new string[] { "1", "2", "3" }.Contains(input) && Int32.TryParse(input, out int validInput))
                {
                    level = validInput;
                }
                else ShowError("Invalid choice, please try again");

                _service.ChangeDifficulty(level);
            }
        }

        private void SelectNumberOfQuestions()
        {
            var numberOfQuestions = 0;
            while (numberOfQuestions == 0)
            {
                var input = Ask("How many question would you like to answer in each game (1 - 9)?");

                if (!String.IsNullOrWhiteSpace(input) && Int32.TryParse(input, out int validInput) && validInput > 0 && validInput < 10)
                {
                    numberOfQuestions = validInput;
                }
                else ShowError("Invalid choice, please try again");
            }
            _service.ChangeNumberOfQuestions(numberOfQuestions);
        }

        private string? Ask(string question)
        {
            Console.Clear();
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        private void ShowError(string errorMessage)
        {
            Console.Clear();
            Console.WriteLine(errorMessage);
            Thread.Sleep(2000);
        }
    }
}
