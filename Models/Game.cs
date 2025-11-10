using static MathGame.Enums;

namespace MathGame.Models
{
    internal abstract class Game
    {
        public Difficulty difficulty { get; set; }
        protected DateTime startTime { get; set; }
        protected DateTime endTime { get; set; }
        public TimeSpan durationGame => endTime - startTime;

        public int score { get; set; }

        protected readonly int rounds = 5;

        protected int timeoutSeconds =>
            difficulty switch
            {
                Difficulty.Easy => 30,
                Difficulty.Medium => 25,
                Difficulty.Hard => 20,
                _ => 30,
            };

        public Rating rating => (Rating)score;

        protected IUserInterface _userInterface { get; set; }

        protected Game(Difficulty difficulty, IUserInterface ui)
        {
            this.difficulty = difficulty;
            _userInterface = ui;
        }

        public string DisplayDuration()
        {
            return durationGame.ToString(@"mm\:ss");
        }

        protected void DisplayResult()
        {
            string scoreRatio = score + "/" + rounds;

            string message = $"[bold]{scoreRatio}[/] {rating.ToString()}, ";
            string color = "";
            switch (rating)
            {
                case Rating.Painful:
                case Rating.VeryBad:
                case Rating.Bad:
                    color = "red";
                    message += "you need to practice!";
                    break;
                case Rating.Good:
                    color = "blue";
                    message += "not bad!";
                    break;

                case Rating.Excellent:
                    color = "gold1";
                    message += "Yeah! Almost perfect.";
                    break;
                case Rating.Perfect:
                    color = "green";
                    message += "Wow! You are the best!";
                    break;
            }

            _userInterface.displayGameResult(message, color, DisplayDuration());
        }
    }
}
