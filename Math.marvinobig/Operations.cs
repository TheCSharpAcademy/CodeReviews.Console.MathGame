namespace Math
{
    internal class Operations
    {
        internal static void Addition(string msg, int[] mathNums, List<string[]> history)
        {
            Console.WriteLine(msg);

            Console.Write("How many questions do you want to answer? ");
            bool howManyRounds;
            string? userNumOfRounds;
            int numOfQuestions;

            do
            {
                userNumOfRounds = Console.ReadLine();
                howManyRounds = int.TryParse(userNumOfRounds, out int result);
                numOfQuestions = result;

                if (!howManyRounds)
                {
                    Console.WriteLine("");
                    Console.Write($"{userNumOfRounds} is not a number, please enter one: ");
                }
                else if (numOfQuestions < 1)
                {
                    Console.WriteLine("");
                    Console.Write($"You've chosen to answer {numOfQuestions} questions, please enter a number greater than 0: ");
                }
            }
            while (!howManyRounds || numOfQuestions == 0);

            for (int i = 0; i < numOfQuestions; i++)
            {
                Random random = new();
                int firstNum = mathNums[random.Next(10)];
                int secondNum = mathNums[random.Next(10)];
                int total = firstNum + secondNum;

                Console.WriteLine("");
                Console.Write($"What is {firstNum} + {secondNum} ? ");

                string? userAnswer = Console.ReadLine();
                bool isThisANumber = int.TryParse(userAnswer, out int result);

                if (isThisANumber)
                {
                    if (result == total)
                    {
                        string[] qaHistory = new string[5] { $"Game choice: Addition", $"Q: {firstNum} + {secondNum}", $"A: {total}", $"Your answer: {result}", "Status: Correct" };
                        history.Add(qaHistory);
                        Console.WriteLine($"Your answered: {result}. That is correct");
                    }
                    else
                    {
                        string[] qaHistory = { $"Game choice: Addition", $"Q: {firstNum} + {secondNum}", $"A: {total}", $"Your answer: {result}", "Status: Incorrect" };
                        history.Add(qaHistory);
                        Console.WriteLine($"That is incorrect. The correct answer is {total}");
                    }
                }
                else
                {
                    throw new Exception($"The value '{userAnswer}' is not a number");
                }
            }

            Console.Clear();
            Console.WriteLine("Question & Answer History:");

            foreach (string[] questionAnswer in history)
            {
                App.DisplayHistory(questionAnswer);
            }
        }

        internal static void Subtraction(string msg, int[] mathNums, List<string[]> history)
        {
            Console.WriteLine(msg);

            Console.Write("How many questions do you want to answer? ");
            bool howManyRounds;
            string? userNumOfRounds;
            int numOfQuestions;

            do
            {
                userNumOfRounds = Console.ReadLine();
                howManyRounds = int.TryParse(userNumOfRounds, out int result);
                numOfQuestions = result;

                if (!howManyRounds)
                {
                    Console.WriteLine("");
                    Console.Write($"{userNumOfRounds} is not a number, please enter one: ");
                }
                else if (numOfQuestions < 1)
                {
                    Console.WriteLine("");
                    Console.Write($"You've chosen to answer {numOfQuestions} questions, please enter a number greater than 0: ");
                }
            }
            while (!howManyRounds || numOfQuestions == 0);

            for (int i = 0; i < numOfQuestions; i++)
            {
                Random random = new();
                int firstNum = mathNums[random.Next(10)];
                int secondNum = mathNums[random.Next(10)];
                int total = firstNum - secondNum;

                Console.WriteLine("");
                Console.Write($"What is {firstNum} - {secondNum} ? ");

                string? userAnswer = Console.ReadLine();
                bool isThisANumber = int.TryParse(userAnswer, out int result);

                if (isThisANumber)
                {
                    if (result == total)
                    {
                        string[] qaHistory = new string[5] { $"Game choice: Subtraction", $"Q: {firstNum} - {secondNum}", $"A: {total}", $"Your answer: {result}", "Status: Correct" };
                        history.Add(qaHistory);
                        Console.WriteLine($"Your answered: {result}. That is correct");
                    }
                    else
                    {
                        string[] qaHistory = { $"Game choice: Subtraction", $"Q: {firstNum} - {secondNum}", $"A: {total}", $"Your answer: {result}", "Status: Incorrect" };
                        history.Add(qaHistory);
                        Console.WriteLine($"That is incorrect. The correct answer is {total}");
                    }
                }
                else
                {
                    throw new Exception($"The value '{userAnswer}' is not a number");
                }
            }

            Console.Clear();
            Console.WriteLine("Question & Answer History:");

            foreach (string[] questionAnswer in history)
            {
                App.DisplayHistory(questionAnswer);
            }
        }

        internal static void Multiplication(string msg, int[] mathNums, List<string[]> history)
        {
            Console.WriteLine(msg);

            Console.Write("How many questions do you want to answer? ");
            bool howManyRounds;
            string? userNumOfRounds;
            int numOfQuestions;

            do
            {
                userNumOfRounds = Console.ReadLine();
                howManyRounds = int.TryParse(userNumOfRounds, out int result);
                numOfQuestions = result;

                if (!howManyRounds)
                {
                    Console.WriteLine("");
                    Console.Write($"{userNumOfRounds} is not a number, please enter one: ");
                }
                else if (numOfQuestions < 1)
                {
                    Console.WriteLine("");
                    Console.Write($"You've chosen to answer {numOfQuestions} questions, please enter a number greater than 0: ");
                }
            }
            while (!howManyRounds || numOfQuestions == 0);

            for (int i = 0; i < numOfQuestions; i++)
            {
                Random random = new();
                int firstNum = mathNums[random.Next(10)];
                int secondNum = mathNums[random.Next(10)];
                int total = firstNum * secondNum;

                Console.WriteLine("");
                Console.Write($"What is {firstNum} x {secondNum} ? ");

                string? userAnswer = Console.ReadLine();
                bool isThisANumber = int.TryParse(userAnswer, out int result);

                if (isThisANumber)
                {
                    if (result == total)
                    {
                        string[] qaHistory = new string[5] { $"Game choice: Multiplication", $"Q: {firstNum} x {secondNum}", $"A: {total}", $"Your answer: {result}", "Status: Correct" };
                        history.Add(qaHistory);
                        Console.WriteLine($"Your answered: {result}. That is correct");
                    }
                    else
                    {
                        string[] qaHistory = { $"Game choice: Multiplication", $"Q: {firstNum} x {secondNum}", $"A: {total}", $"Your answer: {result}", "Status: Incorrect" };
                        history.Add(qaHistory);
                        Console.WriteLine($"That is incorrect. The correct answer is {total}");
                    }
                }
                else
                {
                    throw new Exception($"The value '{userAnswer}' is not a number");
                }
            }

            Console.Clear();
            Console.WriteLine("Question & Answer History:");

            foreach (string[] questionAnswer in history)
            {
                App.DisplayHistory(questionAnswer);
            }
        }

        internal static void Division(string msg, int[] mathNums, List<string[]> history)
        {
            Console.WriteLine(msg);

            Console.Write("How many questions do you want to answer? ");
            bool howManyRounds;
            string? userNumOfRounds;
            int numOfQuestions;

            do
            {
                userNumOfRounds = Console.ReadLine();
                howManyRounds = int.TryParse(userNumOfRounds, out int result);
                numOfQuestions = result;

                if (!howManyRounds)
                {
                    Console.WriteLine("");
                    Console.Write($"{userNumOfRounds} is not a number, please enter one: ");
                }
                else if (numOfQuestions < 1)
                {
                    Console.WriteLine("");
                    Console.Write($"You've chosen to answer {numOfQuestions} questions, please enter a number greater than 0: ");
                }
            }
            while (!howManyRounds || numOfQuestions == 0);

            for (int i = 0; i < numOfQuestions; i++)
            {
                Random random = new();
                int firstNum = mathNums[random.Next(10)];
                int secondNum = mathNums[random.Next(10)];
                int total = firstNum / secondNum;

                Console.WriteLine("");
                Console.Write($"What is {firstNum} \u00F7 {secondNum} ? ");

                string? userAnswer = Console.ReadLine();
                bool isThisANumber = int.TryParse(userAnswer, out int result);

                if (isThisANumber)
                {
                    if (result == total)
                    {
                        string[] qaHistory = new string[5] { $"Game choice: Division", $"Q: {firstNum} \u00F7 {secondNum}", $"A: {total}", $"Your answer: {result}", "Status: Correct" };
                        history.Add(qaHistory);
                        Console.WriteLine($"Your answered: {result}. That is correct");
                    }
                    else
                    {
                        string[] qaHistory = { $"Game choice: Division", $"Q: {firstNum} \u00F7 {secondNum}", $"A: {total}", $"Your answer: {result}", "Status: Incorrect" };
                        history.Add(qaHistory);
                        Console.WriteLine($"That is incorrect. The correct answer is {total}");
                    }
                }
                else
                {
                    throw new Exception($"The value '{userAnswer}' is not a number");
                }
            }

            Console.Clear();
            Console.WriteLine("Question & Answer History:");

            foreach (string[] questionAnswer in history)
            {
                App.DisplayHistory(questionAnswer);
            }
        }
    }
}
