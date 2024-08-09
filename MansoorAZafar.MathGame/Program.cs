namespace MansoorAZafar.MathGame
{
    internal class Program
    {
        private enum Difficulty
        {
            Unset = 0,
            Easy = 1,
            Normal,
            Hard
        }

        private enum GameChoices
        {
            Addition = 1,
            Subtraction,
            Multiplication,
            Division,
            Random,
            ViewGameHistory,
            ChangeDifficulty,
            ChangeNumberOfRounds,
            Quit
        }

        private Difficulty difficulty = Difficulty.Unset;
        private DateTime timeStart;
        private DateTime timeEnd;

        private GameChoices gameSelection;
        private int numberOfRounds = 5;

        private List<string> history = new List<string>();

        private readonly Random rand = new();


        public static void Main(string[] args)
        {
            Program game = new Program();
            game.StartGame();
        }


        public void StartGame()
        {
            bool playAgain = true;
            while (playAgain)
            {
                Menu();
                switch (this.gameSelection)
                {
                    case GameChoices.ViewGameHistory:
                        ShowGameHistory(); break;
                    case GameChoices.ChangeDifficulty:
                        this.difficulty = Difficulty.Unset; // reset the difficulty each time before its called
                        SelectDifficulty(); break;
                    case GameChoices.ChangeNumberOfRounds:
                        SelectNumberOfRounds(); break;
                    case GameChoices.Quit:
                        playAgain = false;
                        break;
                    default:
                        PlayGame(); break;
                }
                System.Console.Write("\nEnter any key to continue...\n> ");
                System.Console.ReadLine();
            }
            System.Console.WriteLine("\nThanks for playing! Goodbye!");
        }


        private void Menu()
        {
            System.Console.Clear();
            System.Console.WriteLine("*".PadLeft(30, '*'));
            System.Console.WriteLine($"Welcome to Math Game!\n"
            + "Please Select which one you want to play!\n"
            + "1. Adding \n"
            + "2. Subtracting \n"
            + "3. Multiplying \n"
            + "4. Dividing \n"
            + "5. Random Game \n"
            + "6. View Game History \n"
            + "7. Change Difficulty (Default is easy)\n"
            + "8. Select Number of Rounds (5 is default)\n"
            + "9. Quit");

            System.Console.WriteLine("*".PadLeft(30, '*'));
            System.Console.Write("> ");

            string? readInput = System.Console.ReadLine();
            while (!(Enum.TryParse(readInput, out this.gameSelection)) || ((int)this.gameSelection > 9 || (int)this.gameSelection < 1))
            {
                System.Console.Write("\nPlease choose a value between 1-9\n> ");
                readInput = System.Console.ReadLine();
            }
        }


        public void SelectDifficulty()
        {
            System.Console.Clear();
            /*
             * Accepts User Input of either the words ["easy", "normal", "hard"] or the
             * numbers [1, 2, 3] and assign it to the difficuty enumeration instance (this.difficulty)
             */

            while (this.difficulty == Difficulty.Unset)
            {
                System.Console.Write
                (
                    "*".PadLeft(100, '*')
                    + "\nPlease choose a difficulty"
                    + "\nThe higher the difficulty -> the greater the Divisor and vice versa\n"
                    + "\n1. Easy\n2. Normal\n3. Hard\n"
                    + new string('*', 100)
                    + "\n> "
                );

                string? readInput = System.Console.ReadLine()?.Trim().ToLower();
                if (readInput == null)
                {
                    this.DisplayInvalidDifficultySelection();
                    continue;
                }

                if (Enum.TryParse(typeof(Difficulty), readInput, true, out var difficultyEnum) && (Difficulty?)difficultyEnum != Difficulty.Unset)
                    this.difficulty = (Difficulty)difficultyEnum;
                else if (int.TryParse(readInput, out var difficultyInt) && difficultyInt >= 1 && difficultyInt <= 3)
                    this.difficulty = (Difficulty)difficultyInt;
                else DisplayInvalidDifficultySelection();
            }
            System.Console.WriteLine("\nDifficulty Updated.\n");
        }


        private void DisplayInvalidDifficultySelection()
        {
            System.Console.Write("\nPlease choose a difficulty or the numbers 1, 2 or 3!\n\n"
                        + "Enter any key to continue...\n> ");
            System.Console.ReadLine();
            System.Console.Clear();
        }


        private void StartTimer() { this.timeStart = DateTime.Now; }


        private decimal GetElapsedTimeInSeconds()
        {
            this.timeEnd = DateTime.Now;
            TimeSpan elapsedTime = this.timeEnd - this.timeStart;
            return (decimal)elapsedTime.TotalSeconds;
        }


        private void ShowGameHistory()
        {
            System.Console.Clear();
            System.Console.WriteLine("Displaying History:\n");
            for (int i = 0; i < this.history.Count; ++i)
            {
                System.Console.WriteLine($"Game #{i + 1}: {this.history[i]}");
            }
        }


        private void SelectNumberOfRounds()
        {
            System.Console.Clear();
            System.Console.Write("Select the number of rounds\n> ");
            while (!(int.TryParse(System.Console.ReadLine(), out this.numberOfRounds)) || (this.numberOfRounds < 0))
                System.Console.Write("\nPlease Select a positive whole number (x > 0)\n> ");
        }


        private void PlayGame()
        {
            #region Set-up
            //Setup of the range of the numbers (based off difficulty selected)
            int randomLowerRange, randomUpperRange;
            //Default is Easy & Unset
            switch (this.difficulty)
            {
                case Difficulty.Normal:
                    randomLowerRange = 30;
                    randomUpperRange = 60;
                    break;
                case Difficulty.Hard:
                    randomLowerRange = 60;
                    randomUpperRange = 100;
                    break;
                default:
                    randomLowerRange = 1;
                    randomUpperRange = 30;
                    break;
            }

            //Setup of the string and character word & symbol (used for storing in the history array at the end)
            char? selectonSymbol;
            string? selectionAlphaWord;

            switch (this.gameSelection)
            {
                case GameChoices.Addition:
                    selectonSymbol = '+';
                    selectionAlphaWord = "Addition";
                    break;
                case GameChoices.Subtraction:
                    selectonSymbol = '-';
                    selectionAlphaWord = "Subtraction";
                    break;
                case GameChoices.Multiplication:
                    selectonSymbol = '*';
                    selectionAlphaWord = "Multiplication";
                    break;
                case GameChoices.Division:
                    selectonSymbol = '/';
                    selectionAlphaWord = "Division";
                    break;
                default:
                    selectonSymbol = '?';
                    selectionAlphaWord = "Random";
                    break;
            }

            //Setup for the actual gameplay 
            const int lowerRangeDivisor = 1;

            int score = 0;
            int? expectedAnswer;

            int userInput;
            string? readInput;

            //We make a local variable to store it because 
            // 1. it's faster to access
            // 2. We will check inside the for loop if they selected the 'random' version
            //    - where we will set it to a random operation
            GameChoices gameSelectionLocal = this.gameSelection;
            #endregion Done Set-up

            this.StartTimer();
            for (int currentRound = 0; currentRound < this.numberOfRounds; ++currentRound)
            {
                //We create a local because the one done in 'setup' has an impossible symbol for random
                // if you use the outer one -> the expression will look like 
                // x ? y
                // but it should be 
                // x [+ - * /] y
                char gameSymbol;
                if (this.gameSelection == GameChoices.Random) gameSelectionLocal = (GameChoices)this.rand.Next((int)GameChoices.Addition, (int)GameChoices.Random);

                System.Console.Clear();
                System.Console.WriteLine("*".PadLeft(30, '*'));

                //Getting & Setting the Expected Answer
                int firstValue = this.rand.Next(minValue: randomLowerRange, maxValue: randomUpperRange);
                int secondValue = this.rand.Next(minValue: lowerRangeDivisor, maxValue: firstValue);
                
                //Need to add special rules for division so
                // 1. only integer division
                // 2. 0 cannot be in the divisior 
                if(gameSelectionLocal == GameChoices.Division)
                {
                    while((firstValue % secondValue) != 0)
                        secondValue = this.rand.Next(minValue: lowerRangeDivisor, maxValue: firstValue);
                }

                switch (gameSelectionLocal)
                {
                    case GameChoices.Addition:
                        expectedAnswer = firstValue + secondValue;
                        gameSymbol = '+';
                        break;
                    case GameChoices.Subtraction:
                        expectedAnswer = firstValue - secondValue;
                        gameSymbol = '-';
                        break;
                    case GameChoices.Multiplication:
                        expectedAnswer = firstValue * secondValue;
                        gameSymbol = '*';
                        break;
                    default:
                        expectedAnswer = firstValue / secondValue;
                        gameSymbol = '/';
                        break;
                }

                //Getting User's Answer
                System.Console.Write($"{firstValue} {gameSymbol} {secondValue}\n> ");
                readInput = System.Console.ReadLine();
                if (!(int.TryParse(readInput, out userInput)))
                {
                    Console.Beep();
                    Console.WriteLine("\nHey! The answer has to be a whole number!\nMaybe next round you'll get it!\n\nEnter any key to Continue");
                    Console.ReadLine();
                    continue;
                }

                //Validating User Answer
                if (userInput != expectedAnswer) System.Console.WriteLine($"\nSorry! thats not correct\nThe actual answer was {expectedAnswer}");
                else
                {
                    System.Console.WriteLine("Congrats! You got it right!");
                    ++score;
                }
                if (currentRound != this.numberOfRounds - 1)
                {
                    System.Console.Write("\nEnter any key to continue\n> ");
                    System.Console.ReadLine();
                }
                else
                {
                    System.Console.WriteLine("\nCongrats! You finished!");
                }
            }
            decimal seconds = this.GetElapsedTimeInSeconds();
            //Increse the size of the array by 2 (as to not need to dynamically increase it so often)
            // (the same way a dynamic array is done)

            this.history.Add($"\nGame Selection\t\t:\t{selectionAlphaWord} ({selectonSymbol})\n"
                + $"Difficulty\t\t:\t{(this.difficulty == Difficulty.Unset ? Difficulty.Easy : this.difficulty)}\n"
                + $"Score\t\t\t:\t{score}\n"
                + $"Rounds\t\t\t:\t{this.numberOfRounds}\n"
                + $"Time Taken (in seconds)\t:\t{seconds}s\n");
        }
    }
}