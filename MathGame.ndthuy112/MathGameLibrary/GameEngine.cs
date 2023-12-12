namespace MathGameLibrary
{
    public class GameEngine
    {
        public static GameModel GameSession(char gameTypeChar)
        {
            int score = 0;
            string gameType;
            switch (gameTypeChar)
            {
                case '+':
                    gameType = "Addition";
                    break;
                case '-':
                    gameType = "Subtraction";
                    break;
                case '*':
                    gameType = "Multiplication";
                    break;
                case '/':
                    gameType = "Division";
                    break;
                default:
                    throw new ArgumentException("Invalid");
            }
            int numberOfQuestions = Helper.GetInt("Number of questions: ");
            for (int i = 0; i < numberOfQuestions; i++)
            {
                bool Question;
                switch (gameTypeChar)
                {
                    case '+':
                        Question = GenerateAddition();                        
                        break;
                    case '-':
                        Question = GenerateSubtraction();                    
                        break;
                    case '*':
                        Question = GenerateMultiplication();
                        break;
                    case '/':
                        Question = GenerateDivision();
                        break;
                    default:
                        throw new ArgumentException("Invalid");
                }
                if (Question)
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine("Incorrect!");
                }
            }
            Console.WriteLine($"Game session finished! Your score is {score} out of {numberOfQuestions}.");
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            GameModel gameHistory = new GameModel(score, numberOfQuestions, gameType, DateTime.Now);
            return gameHistory;
        }
        private static bool GenerateAddition()
        {
            int firstOperand = Helper.GetRandomInt(1, 100);
            int secondOperand = Helper.GetRandomInt(1, 100);
            
            int correctAnswer = firstOperand + secondOperand;

            Console.WriteLine($"{firstOperand} + {secondOperand} = ?");
            int playerAnswer = Helper.GetInt("Your answer:");

            return (correctAnswer == playerAnswer);
        }

        private static bool GenerateSubtraction()
        {
            int firstOperand = Helper.GetRandomInt(1, 100);
            int secondOperand = Helper.GetRandomInt(1, firstOperand);
            
            int correctAnswer = firstOperand - secondOperand;

            Console.WriteLine($"{firstOperand} - {secondOperand} = ?");
            int playerAnswer = Helper.GetInt("Your answer:");

            return (correctAnswer == playerAnswer);
        }
        private static bool GenerateMultiplication()
        {
            int firstOperand = Helper.GetRandomInt(1, 10);
            int secondOperand = Helper.GetRandomInt(1, 10);
            
            int correctAnswer = firstOperand * secondOperand;

            Console.WriteLine($"{firstOperand} * {secondOperand} = ?");
            int playerAnswer = Helper.GetInt("Your answer:");

            return (correctAnswer == playerAnswer);
        }
        private static bool GenerateDivision()
        {
            int firstOperand = Helper.GetRandomInt(1, 100);
            int secondOperand;
            do
            {
                secondOperand = Helper.GetRandomInt(1, firstOperand);
            }
            while (firstOperand % secondOperand != 0);
            
            int correctAnswer = firstOperand / secondOperand;

            Console.WriteLine($"{firstOperand} / {secondOperand} = ?");
            int playerAnswer = Helper.GetInt("Your answer:");

            return (correctAnswer == playerAnswer);
        }

        public static void ShowHistory(List<GameModel> gameHistoryList)
        {
            foreach (GameModel gameModel in gameHistoryList)
            {
                Console.WriteLine($"{gameModel.TimePlayed}\t{gameModel.GameType}\t{gameModel.Score}/{gameModel.TotalQuestions}");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }  
    }
}