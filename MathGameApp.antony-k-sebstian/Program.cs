public class MathGame
{
    public static void Main(String[] args)
    {

        List<String> questions = new List<String>();
        List<int> answers = new List<int>();
        List<int> scoreTracker = new List<int>();
        HashSet<char> operators = new HashSet<char> { '+', '-', '*', '/', '%' };
        Random random = new Random();

        while (true)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Welcome to the Math Game!\n");
            Console.WriteLine("Choose an option to continue\n");
            Console.WriteLine("1. Start Game. 2. View Last Game Results 3. Exit");


            string? input = Console.ReadLine();
            while (input != "1" && input != "2" && input != "3")
            {
                Console.WriteLine("Invalid input. Please enter a valid choice.");
                input = Console.ReadLine();
            }

            int choice = int.Parse(input);

            // game logic
            if (choice == 1)
            {
                Console.WriteLine("\nYou will be asked a series of math questions. Try to answer them correctly!");
                int score = 0;
                int i = 0;
                bool gameStatus = true;
                char op;
                int userAnswer;

                questions.Clear();
                answers.Clear();
                scoreTracker.Clear();

                while (i < 5 || gameStatus)
                {
                    int num1 = random.Next(1, 100);
                    int num2 = random.Next(1, 100);

                    Console.WriteLine("\nChoose an operator from the following: \n");

                    foreach (char c in operators)
                    {
                        Console.Write(c + " ");
                    }

                    Console.WriteLine();

                    while (!char.TryParse(Console.ReadLine(), out op) || !operators.Contains(op))
                    {
                        Console.WriteLine("Enter a valid operator:");
                    }

                    // special case for division and modulus to avoid division by zero and ensure whole number results
                    if (op == '/' || op == '%')
                    {
                        while (num2 == 0 || num1 % num2 != 0)
                        {
                            num1 = random.Next(1, 100);
                            num2 = random.Next(1, 100);
                        }
                    }

                    Console.WriteLine($"Question {i + 1}: What is {num1} {op} {num2}?");

                    while (!int.TryParse(Console.ReadLine(), out userAnswer))
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                    }

                    int correctAnswer = CalculateAnswer(num1, num2, op);

                    if (userAnswer == correctAnswer)
                    {
                        Console.WriteLine("Correct!");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine($"Incorrect! The correct answer is {correctAnswer}.");
                    }
                    questions.Add($"What is {num1} {op} {num2}?");
                    answers.Add(userAnswer);
                    scoreTracker.Add(score);
                    i++;

                    // logic to handle minimum of 5 questions
                    if (i >= 5)
                    {
                        Console.WriteLine("Would you like to continue, Press Y for Yes and N for No");

                        char flag;

                        while (!char.TryParse(Console.ReadLine(), out flag) || (flag != 'Y' && flag != 'N'))
                        {
                            Console.WriteLine("Enter a valid choice");
                        }
                        gameStatus = (flag == 'Y');
                    }
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

    public static int CalculateAnswer(int num1, int num2, char operation)
    {
        switch (operation)
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
