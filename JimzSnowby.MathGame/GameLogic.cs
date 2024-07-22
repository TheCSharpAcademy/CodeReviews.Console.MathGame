namespace MathGame
{
    public class GameLogic
    {
        public List<String> GameHistory {get; set;} = new List<String>();
        
        public int MathOperation(int firstNum, int secondNum, char operation)
        {
            switch (operation)
            {
                case '+':
                    GameHistory.Add($"{firstNum} + {secondNum} = {firstNum + secondNum}");
                    return firstNum + secondNum;
                case '-':
                    GameHistory.Add($"{firstNum} - {secondNum} = {firstNum - secondNum}");
                    return firstNum - secondNum;
                case '*':
                    GameHistory.Add($"{firstNum} * {secondNum} = {firstNum * secondNum}");
                    return firstNum * secondNum;
                case '/':
                    GameHistory.Add($"{firstNum} / {secondNum} = {firstNum / secondNum}");
                    return firstNum / secondNum;
                default:
                    return 0;
            }
        }

    }
}
