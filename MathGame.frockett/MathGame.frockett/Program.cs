using System.ComponentModel.DataAnnotations;

namespace MathGame.frockett
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* 
             * 4. Record previous games (from same session) in a list and have an option in menu to visualize history of previous games
             * 
             * Challenge:
             * 1. Levels of difficulty
             * 2. Add a timer to track how long the user takes to finish the game
             * 3. Let user pick number of questions
             * 4. 'Random game' function where player gets random operations
             */

            /* - variables for input
             * - declare list to store game history
             * 
             * do (menu) while (input is not exit)
             * 
             * switch statement for game logic
             * write each operation as an external method
             * 
             */

            DateTime date = DateTime.UtcNow;
            char[] operations = { '+', '-', '*', '/' };
            string[] gameTitle = { "Addition", "Subtraction", "Multiplication", "Division" };
            bool isGameOn = true;

            Menu(date);

            void Menu(DateTime date)
            {
                string? readResult;
                string menuSelection = "";

                do
                {
                    Console.Clear();
                    Console.WriteLine("Welcome to Frockett's Mathematics Bonanza!");
                    Console.WriteLine($"Today is {date.DayOfWeek}");
                    Console.WriteLine();
                    Console.WriteLine("Please select one of the following options:");
                    Console.WriteLine("1. Addition Challenge");
                    Console.WriteLine("2. Subtraction Challenge");
                    Console.WriteLine("3. Multiplication Challenge");
                    Console.WriteLine("4. Division Challenge");
                    Console.WriteLine("5. View Session History");
                    Console.WriteLine();
                    Console.WriteLine("Or type 'Exit' to close the application");

                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        menuSelection = readResult.ToLower().Trim();
                    }

                    switch (menuSelection)
                    {
                        case "1":
                            MainGameLoop('+');
                            break;
                        case "2":
                            MainGameLoop('-');
                            break;
                        case "3":
                            MainGameLoop('*');
                            break;
                        case "4":
                            MainGameLoop('/');
                            break;
                        case "5":
                            break;
                        case "exit":
                            isGameOn = false;
                            break;
                        default:
                            Console.WriteLine("Please enter a valid menu selection");
                            break;
                    }
                }
                while (isGameOn);
            }

            void MainGameLoop(char operation, int difficulty = 1)
            {
                /*
                Console.WriteLine("Please selected difficulty: ");
                Console.WriteLine("1. Easy");
                Console.WriteLine("2. Medium");
                Console.WriteLine("3. Hard");
                */
                int index;
                string result;
                int score = 0;

                Random random = new Random();
                int firstNum;
                int secondNum;

                Console.Clear();
                if (operations.Contains(operation))
                {
                    index = Array.IndexOf(operations, operation);
                    Console.WriteLine($"{gameTitle[index]} Game");
                }
                else
                {
                    throw new ArgumentException("Unexpected operator char: " + operation);
                }

                for (int i = 0; i < 5; i++)
                {
                    if (operation == '/')
                    {
                        do
                        {
                            firstNum = random.Next(1, 10);
                            secondNum = random.Next(1, 10);
                        } while (firstNum % secondNum != 0);
                    }
                    else
                    {
                        firstNum = random.Next(1, 10);
                        secondNum = random.Next(1, 10);
                    }
                    

                    Console.WriteLine($"\n{firstNum} {operation} {secondNum}");
                    result = Console.ReadLine();

                    if (int.Parse(result) == PerformCalculation(operation, firstNum, secondNum))
                    {
                        Console.WriteLine("Your answer is correct!\n");
                        score++;
                    }
                    else { Console.WriteLine("Your Answer is incorrect!\n"); }
                }
                Console.WriteLine($"Your final score is {score}");
                Console.ReadLine();
            }

            int PerformCalculation(char operation, int firstNum, int secondNum)
            {
                switch (operation)
                {
                    case '+':
                        return firstNum + secondNum;
                    case '-':
                        return firstNum - secondNum;
                    case '*':
                        return firstNum * secondNum;
                    case '/':
                        return firstNum / secondNum;
                    default:
                        throw new ArgumentException("Unexpected operator string: " + operation);
                }
            }

            void PrintHistory()
            {
                return;
            }
        }
    }
}