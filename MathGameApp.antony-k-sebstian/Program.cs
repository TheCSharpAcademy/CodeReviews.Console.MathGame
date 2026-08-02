public class MathGame
{
    public static void Main(String[] args)
    {

        List<String> questions = new List<String>();
        List<int> answers = new List<int>();
        List<int> scoreTracker = new List<int>();
        char[] operators = { '+', '-', '*', '/', '%' };
        Random random = new Random();

        while (true)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Welcome to the Math Game!");
            Console.WriteLine("Choose an option to continue");
            Console.WriteLine("1. Start Game. 2. View Last Game Results 3. Exit");

            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return;
            }

            // game logic
            if (choice == 1)
            {
                Console.WriteLine("You will be asked a series of math questions. Try to answer them correctly!");
                int score = 0;
                int i = 0;

                foreach (char c in operators)
                {
                    int num1 = random.Next(1, 100);
                    int num2 = random.Next(1, 100);

                    // special case for division and modulus to avoid division by zero and ensure whole number results
                    if (c == '/' || c == '%')
                    {
                        while (num2 == 0 || num1 % num2 != 0)
                        {
                            num1 = random.Next(1, 100);
                            num2 = random.Next(1, 100);
                        }
                    }

                    Console.WriteLine($"Question {i + 1}: What is {num1} {c} {num2}?");

                    string? userAnswerInput = Console.ReadLine();

                    if (!int.TryParse(userAnswerInput, out int userAnswer))
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                        return;
                    }

                    int correctAnswer = CalculateAnswer(num1, num2, c);

                    if (userAnswer == correctAnswer)
                    {
                        Console.WriteLine("Correct!");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine($"Incorrect! The correct answer is {correctAnswer}.");
                    }
                    questions.Add($"What is {num1} {c} {num2}?");
                    answers.Add(userAnswer);
                    scoreTracker.Add(score);
                    i++;
                }
            }
            // view last game results logic
            else if (choice == 2)
            {
                Console.WriteLine("Last Game Results:");
                for (int i = 0; i < scoreTracker.Count; i++)
                {
                    Console.WriteLine($"Question {i + 1}: {questions[i]} - Your Answer: {answers[i]} - Score: {scoreTracker[i]}");
                }
            }
            else if (choice == 3)
            {
                Console.WriteLine("Thank you for playing! Goodbye!");
                return;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
                return;
            }
        }
    }

    public static int CalculateAnswer(int num1, int num2, char op)
    {
        switch (op)
        {
            case '+':
                return num1 + num2;
            case '-':
                return num1 - num2;
            case '*':
                return num1 * num2;
            case '/':
                return num1 / num2;
            case '%':
                return num1 % num2;
            default:
                throw new ArgumentException("Invalid operator");
        }
    }
}
