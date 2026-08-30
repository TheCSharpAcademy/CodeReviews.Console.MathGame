using System.Diagnostics.Metrics;

namespace MathGameAcademy
{
    class Program
    {
        private static List<int[]> gameList = new List<int[]>();
        private static List<char> operatorList = new List<char>();

        private static List<int[]> gameHistory = new List<int[]>();

        private static int GameRound = 0;
        static void Main(string[] args) 
        {
            bool playAgain = false;
            do
            {
                GameRound++;
                Console.WriteLine("Welcome to the Math Game!");
                Console.WriteLine("How many rounds do you want to play? (Enter a number between 5 and 10):");
                int roundsInt = GetInteger(5, 10);
                int pointsInt = 0;
                Random random = new Random();
                char _operator = GetOperator();
                if (_operator == 'r')
                {
                    int opInt = random.Next(1, 5);
                    switch (opInt)
                    {
                        case 1:
                            _operator = '+';
                            break;
                        case 2:
                            _operator = '-';
                            break;
                        case 3:
                            _operator = '*';
                            break;
                        case 4:
                            _operator = '/';
                            break;
                    }
                }
                for (int i = 0; i < roundsInt; i++)
                {
                    int[] randomNumbers = new int[2];
                    
                    randomNumbers[0] = random.Next(1, 101);
                    randomNumbers[1] = random.Next(1, 101);

                    if (_operator == '/')
                    {
                        do
                        {
                            randomNumbers[1] = random.Next(1, 51);
                            if (randomNumbers[1] == 1 || randomNumbers[1] == 2)
                            {
                                randomNumbers[1] = random.Next(1, 51); // to make probability of 1 and 2 lower, since they are more likely to be factors of other numbers
                            }
                            do
                            {
                                randomNumbers[0] = random.Next(1, 101);
                            } while (randomNumbers[0] < randomNumbers[1]);

                        } while (randomNumbers[0] % randomNumbers[1] != 0);
                    }


                    int resultGuess = GetNumber(randomNumbers, _operator);
                    int correctResult = Calculator.MathCalculation(randomNumbers, _operator);
                    if (resultGuess == correctResult)
                    {
                        Console.WriteLine("Correct!");
                        pointsInt++;
                        Console.WriteLine($"You have {pointsInt} points of {roundsInt} possible points.");
                    }
                    else
                    {
                        Console.WriteLine($"Incorrect! The correct answer is {correctResult}");
                        Console.WriteLine($"You have {pointsInt} points of {roundsInt} possible points.");
                    }
                    gameList.Add(new int[] { randomNumbers[0], randomNumbers[1], resultGuess, correctResult });
                    operatorList.Add(_operator);
                }

                Console.WriteLine("Game Finished!");
                Console.WriteLine("You got {0} points out of {1} possible points.", pointsInt, roundsInt);
                gameHistory.Add(new int[] {GameRound, pointsInt, roundsInt });

                bool runMenu = true;
                while (runMenu)
                {
                    PrintSeparator();
                    Console.WriteLine("Do you want to see the game history? Type 'h': ");
                    Console.WriteLine("Do you want to delete the game history? Type 'd': ");
                    Console.WriteLine("Do you want to play again? Type 'p': ");
                    Console.WriteLine("Do you want to stop the game? Type 's': ");
                    string userInputMenu;
                    do
                    {
                        Console.Write("Enter a valid choice: ");
                        userInputMenu = Console.ReadLine().Trim().ToLower();
                        PrintSeparator();
                    } while (userInputMenu != "h" && userInputMenu != "d" && userInputMenu != "p" && userInputMenu != "s");

                    switch (userInputMenu)
                    {
                        case "h":
                            int roundCounter = 0;
                            if (gameList.Count == 0)
                            {
                                Console.WriteLine("No game history available.");
                                break;
                            }
                            else if (gameList.Count != operatorList.Count)
                            {
                                Console.WriteLine("Game history is corrupted. Please delete the game history.");
                                break;
                            }
                            else
                            {
                                foreach(int[] game in gameHistory)
                                {
                                    Console.WriteLine($"Game {game[0]}: {game[1]} points out of {game[2]} possible points.");
                                }
                                foreach (int[] game in gameList)
                                {
                                    var op = operatorList[roundCounter];
                                    Console.WriteLine($"Round {roundCounter+1}: {game[0]} {op} {game[1]} = {game[2]} (Correct answer: {game[3]})");
                                    roundCounter++;
                                }
                            }

                            break;

                        case "d":
                            gameList.Clear();
                            operatorList.Clear();
                            Console.WriteLine("Game history deleted.");
                            break;

                        case "p":
                            playAgain = true;
                            runMenu = false;
                            PrintSeparator();
                            PrintSeparator();
                            break;

                        case "s":
                            playAgain = false;
                            runMenu = false;
                            break;

                        default:
                            Console.WriteLine("Invalid input. Please enter exactly 'h', 'd', 'p' or 's':");
                            break;
                    }
                }

            }while (playAgain);

        }
        private static void PrintSeparator()
        {
            Console.WriteLine(new string('-', 30));
        }
        private static int GetInteger(int min, int max)
        {
            int rounds;
            bool check;
            do
            {
                check = int.TryParse(Console.ReadLine(), out rounds);
                if (!check || rounds < min || rounds > max)
                {
                    check = false;
                    Console.WriteLine($"Invalid input. Please enter a number between {min} and {max}.");
                }
            } while (check == false);
            return rounds;
        }
        //private static bool YesOrNo(string message)
        //{
        //    Console.WriteLine(message);
        //    char choice;
        //    bool check;
        //    do
        //    {
        //        check = char.TryParse(Console.ReadLine(), out choice);

        //        if (!check || (choice != 'y' && choice != 'Y' && choice != 'n' && choice != 'N'))
        //        {
        //            check = false; 
        //            Console.WriteLine("Invalid input. Please enter exactly 'y' or 'n':");
        //        }
        //    } while (check == false);

        //    if (choice == 'y' || choice == 'Y')
        //    {
        //        return true;
        //    }
        //    return false;
        //}
        
        private static int GetNumber(int[] random, char _operator)
        {
            Console.WriteLine($"What is {random[0]}{_operator}{random[1]}?");
            bool check;
            int result;
            do
            {
                check = int.TryParse(Console.ReadLine(), out result);
                if(!check)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            } while (check == false);
            return result;
        }
        private static char GetOperator()
        {
            Console.WriteLine("Type an operator or random r (+, -, *, /, r):");
            char _operator;
            bool check;
            do
            {
                check = char.TryParse(Console.ReadLine(), out _operator);
                if (!check || (_operator != '+' && _operator != '-' && _operator != '*' && _operator != '/' && _operator != 'r'))
                {
                    check = false;
                    Console.WriteLine("Invalid operator. Please choose one of the following: +, -, *, /, r");
                }
            } while (check == false);
            return _operator;       
        }

    }
    
}
