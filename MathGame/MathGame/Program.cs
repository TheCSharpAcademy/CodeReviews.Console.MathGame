namespace MathGame
{
    class Program
    {
        private static List<string[]> listHistoryMathGame = new List<string[]>();

        static void SaveHistory(string[] history)
        {
            listHistoryMathGame.Add(history);
        }

        static int[] ExampsAndAnswersCreate(string op, out string[] examples)
        {
            Random rnd = new Random();

            examples = new string[5];
            int[] answers = new int[5];

            for(int i= 0; i < examples.Length; i++)
            {
                int firstNum = rnd.Next(0, 100);
                int secondNum = rnd.Next(0, 100);
                string example = $"{firstNum} {op} {secondNum}";
                examples[i] = example;
                int answer;
                switch (op)
                {
                    case "+":
                        answer = firstNum + secondNum;
                        answers[i] = answer;
                        break;
                    case "-":
                        answer = firstNum - secondNum;
                        answers[i] = answer;
                        break;
                    case "*":
                        answer = firstNum * secondNum;
                        answers[i] = answer;
                        break;
                    case "/":
                        answer = firstNum / secondNum;
                        answers[i] = answer;
                        break;
                }
                
            }
            
            return answers;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Math Game!");
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine("\nSelect the mathematical operation you want to work with.\n+\t-\t*\t/ ");
                Console.WriteLine();
                string? op = Console.ReadLine();
                if (op != "+" && op != "-" && op != "*" && op != "/")
                {
                    Console.WriteLine("Pls choose one of this op\n+\t-\t*\t/");
                    continue;
                }

                int[] gameAnswers = ExampsAndAnswersCreate(op, out string[] gameExamples);
                Console.WriteLine();
                Console.WriteLine("You need to solve this examples:\n");

                string[] historyGame = new string[gameAnswers.Length];

                for (int i = 0; i < gameAnswers.Length; i++)
                {
                    string enteredNumFromPlayer;
                    Console.Write($"{gameExamples[i]} = ");
                    enteredNumFromPlayer = Console.ReadLine();
                    historyGame[i] = $"{gameExamples[i]} = {enteredNumFromPlayer}";
                    if (int.TryParse(enteredNumFromPlayer, out int enteredParseIntNum))
                    {
                        if (enteredParseIntNum == gameAnswers[i])
                        {
                            Console.WriteLine("That's a correct answer\n");

                        }
                        else
                        {
                            Console.WriteLine($"You entered wrong number\n");
                        }
                    }
                    else Console.WriteLine("You didn't enter a number. This is incorrect.\n");

                }

                SaveHistory(historyGame);


                while (true)
                {
                    Console.WriteLine("Thank you for playing, would you like to continue?\nY\\N?\nOr wuld you like to see the history of game?");
                    Console.WriteLine("To see the history of game, pls enter \"BURMALDA\"");
                    string finalOrContinue = Console.ReadLine().ToUpper();

                    if (finalOrContinue == "Y") break;
                    else if (finalOrContinue == "N")
                    {
                        Console.WriteLine("Goodbye!");
                        return;
                    }
                    else if (finalOrContinue == "BURMALDA")
                    {
                        if(listHistoryMathGame.Count == 0)
                        {
                            Console.WriteLine("You haven't played any games.");
                            continue;
                        }
                        Console.WriteLine("History: ");
                        int matchNumber = 1;
                        foreach (string[] array in listHistoryMathGame)
                        {
                            Console.WriteLine($"\n------- Game №{matchNumber} -------");
                            foreach (string exmp in array)
                            {
                                Console.WriteLine(exmp);
                            }
                            
                            matchNumber++;
                        }
                        Console.WriteLine("That's your game history! Press any button to continue");
                        Console.ReadLine();
                        continue;
                    }
                    else Console.WriteLine("Invalid input! Pls enter Y or N");
                }

                
                
            }
        }
    }
}
