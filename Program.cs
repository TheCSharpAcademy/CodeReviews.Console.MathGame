using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;

Maths mathGame = new Maths();
mathGame.playerNameInput();

while (true)
{
    MainMenu();
    Console.WriteLine();
    Console.Write("Your choice: ");

    Console.ForegroundColor = ConsoleColor.Green;
    string? choice = Console.ReadLine();
    Console.ForegroundColor = ConsoleColor.White;

    if (choice == "1")
    {
        mathGame.selectGame();break;
    }
    else if (choice == "2")
    {
        
        mathGame.highScoreList();
        
        Console.WriteLine();
    }
    else if (choice == "3")
    {
        Console.WriteLine("Goodbye!");break;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid choice. Please try again."); Console.ForegroundColor = ConsoleColor.White; 
        Console.WriteLine(); 
        continue;
        
    }
}

mathGame.gameDifficulty();
mathGame.gameStart();
mathGame.highScoreList();
Console.ReadKey();

void MainMenu()
{
    Console.WriteLine("What would you like to do?");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("1. Play a game");
    Console.WriteLine("2. Check High Scores");
    Console.WriteLine("3. Exit");
    Console.ForegroundColor = ConsoleColor.White;
}
public class Maths
{
    GameType gameType;
    Random random = new Random();
    int levelDifficulty = 0;
    int points = 0;
    bool gameOver = false;
    List<string> highScore = new List<string>();
    string playerName { get; set; } = "000";

    public Maths()
    {
        highScore.Add($"{playerName} | High Score: {points}");
    }

    public void gameStart()
    {

        while (gameOver == false)
        {
            int num1 = random.Next(1, levelDifficulty);
            int num2 = random.Next(1, levelDifficulty);

            if (gameType == GameType.Division)
            {
                if (num2 % num1 != 0)
                {
                    continue;
                }
            }

            if (gameType == GameType.Addition)
            {
                AdditionsGame(num1, num2);
            }
            else if (gameType == GameType.Subtraction)
            {
                SubtractionGame(num1, num2);
            }
            else if (gameType == GameType.Multiplication)
            {
                MultiplicationsGame(num1, num2);
            }
            else if (gameType == GameType.Division)
            {
                DivisionsGame(num1, num2);
            }


        }

        highScore.Add($"{playerName} | Highscore: {points}");
        
        gameOver = false;
    }

    public void highScoreList()
    {
        Console.WriteLine();
        Console.WriteLine("High Scores:");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        foreach (string score in highScore)
        {
            Console.WriteLine(score);
        }
        Console.ForegroundColor = ConsoleColor.White;

    }

    public void AdditionsGame(int number1, int number2)
    {
        Console.WriteLine();
        Console.WriteLine($"{number2} + {number1} =");
        int gameAnswer = number1 + number2;
        Console.Write("Your answer: ");
        int userAnswer = Convert.ToInt32(Console.ReadLine());

        if (userAnswer == gameAnswer)
        {
            points++;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Correct!");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Your score is {points}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.WriteLine($"Incorrect! The correct answer is {gameAnswer}");
            gameOver = true;
        }
    }

    public void SubtractionGame(int number1, int number2)
    {
        Console.WriteLine();
        Console.WriteLine($"{number2} - {number1} =");
        int gameAnswer = number2 - number1;
        Console.Write("Your answer: ");
        int userAnswer = Convert.ToInt32(Console.ReadLine());

        if (userAnswer == gameAnswer)
        {
            points++;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Correct!");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Your score is {points}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.WriteLine($"Incorrect! The correct answer is {gameAnswer}");

            gameOver = true;
        }
    }
    public void DivisionsGame(int number1, int number2)
    {
        Console.WriteLine();
        Console.WriteLine($"{number2} / {number1} =");
        int gameAnswer = number2 / number1;
        Console.Write("Your answer: ");
        int userAnswer = Convert.ToInt32(Console.ReadLine());

        if (userAnswer == gameAnswer)
        {
            points++;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Correct!");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Your score is {points}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.WriteLine($"Incorrect! The correct answer is {gameAnswer}");
            gameOver = true;
        }
    }
    public void MultiplicationsGame(int number1, int number2)
    {
        Console.WriteLine();
        Console.WriteLine($"{number2} x {number1} =");
        int gameAnswer = number1 * number2;
        Console.Write("Your answer: ");
        int userAnswer = Convert.ToInt32(Console.ReadLine());

        if (userAnswer == gameAnswer)
        {
            points++;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Correct!");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Your score is {points}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.WriteLine($"Incorrect! The correct answer is {gameAnswer}");
            gameOver = true;
        }
    }
    public void selectGame()
    {
        while (true)
        {

            Console.WriteLine();
            Console.WriteLine("What game would you like to play?");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.Write("Your choice: ");
            Console.ForegroundColor = ConsoleColor.Green;

            string? choice = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            if (choice == "1")
            {
                this.gameType = GameType.Addition; break;
            }
            else if (choice == "2")
            {
                this.gameType = GameType.Subtraction; break;
            }
            else if (choice == "3")
            {
                this.gameType = GameType.Multiplication; break;
            }
            else if (choice == "4")
            {
                this.gameType = GameType.Division; break;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid choice. Please try again.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                continue;

            }

        }
    }

    public void playerNameInput()
    {
        Console.WriteLine();
        Console.Write("Please enter your name: ");
        Console.ForegroundColor = ConsoleColor.Green;
        this.playerName = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.White;

    }
    public void gameDifficulty()
    {
        while (true)
        {

            Console.WriteLine();
            Console.WriteLine("What mode would you like to play:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Medium");
            Console.WriteLine("3. Hard");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Your choice: ");

            Console.ForegroundColor = ConsoleColor.Green;
            string? difficultyChoice = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            if (difficultyChoice == "1")
            {
                this.levelDifficulty = 20; break;
            }
            else if (difficultyChoice == "2")
            {
                this.levelDifficulty = 50; break;
            }
            else if (difficultyChoice == "3")
            {
                this.levelDifficulty = 100; break;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid choice. Please try again.");
                Console.ForegroundColor = ConsoleColor.White;
                continue;
            }





        }

    }
}


enum GameType {
    Addition,
    Subtraction,
    Multiplication,
    Division
}