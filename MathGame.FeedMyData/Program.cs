// Instructions
// A game that consists of asking the player what's the result of a math question (i.e. 9 x 9 = ?), collecting the input and adding a point in case of a correct answer.
// A game needs to have at least 5 questions.
// The divisions should result on INTEGERS ONLY and dividends should go from 0 to 100. Example: Your app shouldn't present the division 7/2 to the user, since it doesn't result in an integer.
// Users should be presented with a menu to choose an operation
// You should record previous games in a List and there should be an option in the menu for the user to visualize a history of previous games.
// You don't need to record results on a database. Once the program is closed the results will be deleted.
// --- Challenges ----
// Implement levels of difficulty.
// Add a timer to track how long the user takes to finish the game.
// Create a 'Random Game' option where the players will be presented with questions from random operations
// -------------------------------------------------

using System.Collections.Generic;
using System.Diagnostics;

class Program
{
  static List<string> gamesPlayed = new();
  static Random rand = new();
  static int maxQuestions = 5;
  static int gamesCount = 0;
  static int totalScore = 0;
  static int difficulty = 1;
  static int maxDifficulty = 5;
  static TimeSpan totalTime = TimeSpan.Zero;
  static string userInput = "";
  static string menu = "To start a game, choose a math operation by typing the number associated:\n"
                    + "\t1. For addition\n"
                    + "\t2. For substraction\n"
                    + "\t3. For multiplication\n"
                    + "\t4. For Division\n"
                    + "\t5. For a random pick\n"
                    + "\t6. Change overall difficulty\n"
                    + "\t7. View Score and game History\n"
                    + "\tType 'Exit' to quit\n";


  static void Main(string[] args)
  {
    //Starting flow presenting the menu
    Console.Clear();
    Console.WriteLine("--- Math Game ---\n");
    Console.WriteLine($"Rules: Give the answer of {maxQuestions} Maths operation of your choice. Good luck.");
    Console.Write(menu);

    // Selecting a menu Item
    while (userInput != "exit")
    {
      Console.WriteLine("");
      Console.Write("Enter a menu choice : ");

      userInput = Console.ReadLine();
      if (userInput != null)
        userInput = userInput.ToLower().Trim();

      if (int.TryParse(userInput, out int menuSelection))
      {
        if (menuSelection >= 1 && menuSelection <= 5)
          MathQuestions(menuSelection, difficulty);

        else if (menuSelection == 6)
          difficulty = SetDifficulty();

        else if (menuSelection == 7)
          GamesSummary();
      }
    }
  }

  static void MathQuestions(int operationType, int difficulty)
  {
    gamesCount++;
    Stopwatch timer = new();
    timer.Restart();

    string header = $"Game number {gamesCount} | Difficulty {difficulty}\n";
    string gameReview = header;
    Console.Write(header);

    string userInput = "";
    int answer = 0;
    int result = 0;
    int score = 0;

    // generating the questions and reading user response here
    for (int i = maxQuestions; i > 0; i--)
    {
      string question = "";
      bool answerReadable = false;

      // Picking a random question if the user selected a random game
      int currentOperator = operationType;
      int rollOperator = rand.Next(1, 4);
      char[] operators = ['+', '-', 'x', '/'];

      if (operationType == 5)
        currentOperator = rollOperator;

      //numbers scale according to the difficulty
      int[] numbers = GenerateNumbers(difficulty, currentOperator);
      int a = numbers[0];
      int b = numbers[1];

      switch (currentOperator)
      {
        case 1:
          result = a + b;
          break;
        case 2:
          result = a - b;
          break;
        case 3:
          result = a * b;
          break;
        case 4:
          result = a / b;
          break;
      }

      question = $"{a} {operators[currentOperator - 1]} {b}\t= ";
      Console.Write(question);

      // Reading user answer
      while (!answerReadable)
      {
        userInput = Console.ReadLine().Trim();
        answerReadable = int.TryParse(userInput, out answer);
      }

      if (answer == result)
      {
        gameReview += $"{question}{answer}\t\tcorrect\n";
        score++;
      }

      else
        gameReview += $"{question}{answer}\t\tfalse -> {result}\n";
    }

    // wraping up all the game info and updating the game summary
    timer.Stop();

    string scoreMessage = $"You answered {score}/{maxQuestions} questions correctly in {FormatSeconds(timer.Elapsed)}.";
    Console.WriteLine(scoreMessage);

    gameReview += scoreMessage;
    gameReview += "\n";
    gamesPlayed.Add(gameReview);
    totalTime += timer.Elapsed;
    totalScore += score;
  }

  static int[] GenerateNumbers(int difficulty, int operatorType)
  {
    // increasing possible number range depending on the maximum difficulty
    // skiping 0 with the difficulty starting at 1
    int minRandom = (int)Math.Pow(10, maxDifficulty);
    int maxRandom = (int)Math.Pow(10, maxDifficulty + 1);

    // using this to scale the random numbers down
    // if diffulty is level 2/6 then I should reduce the number range from 10^(4+1)
    int difficultyPower = maxDifficulty + 1 - difficulty;
    int numberDivider = (int)Math.Pow(10, difficultyPower);

    int a = rand.Next(minRandom, maxRandom);
    int b = rand.Next(minRandom, maxRandom);
    int tempNumber = 1;

    // making the level 1 the easiest possible with number ranging from 1 to 9
    if (difficulty == 1)
    {
      a = a / minRandom;
      b = b / minRandom;
    }

    else if (difficulty == 2)
    {
      a /= numberDivider;

      if (operatorType == 1 || operatorType == 2)
        b /= numberDivider;

      // Multiply by 10 to have smaller operation 
      else
        b /= (numberDivider * 10);
    }

    // from difficulty 3 scaling up by x10 each number
    else
    {
      if (operatorType == 1 || operatorType == 2)
      {
        a /= numberDivider;
        b /= numberDivider;
      }
      // Multiply by 10 to have smaller operation 
      else
      {
        a /= (numberDivider * 10);
        b /= (numberDivider * 10);
      }
    }

    // generating division from multiplication to avoid decimals
    if (operatorType == 4)
    {
      tempNumber = a * b;
      a = tempNumber;
    }

    int[] numbers = [a, b];
    return numbers;
  }

  static void GamesSummary()
  {
    Console.WriteLine($"---------------------");
    Console.WriteLine($"--- GAMES SUMMARY ---");
    Console.WriteLine($"---------------------");
    Console.WriteLine($"You played {gamesCount} game(s).");
    Console.WriteLine($"You answered {totalScore}/{maxQuestions * gamesCount} questions correctly in {FormatSeconds(totalTime)}.");
    Console.WriteLine("---------------------");

    foreach (string game in gamesPlayed)
      Console.WriteLine(game);
  }

  static int SetDifficulty()
  {
    Console.WriteLine($"---------------------------");
    Console.WriteLine("--- CHANGING DIFFICULTY ---");
    Console.WriteLine($"---------------------------");
    Console.WriteLine($"Modifying the difficulty change the range of the numbers used for the calculation.");
    Console.WriteLine($"The current difficulty is at level {difficulty} / {maxDifficulty}.");

    // Ensuring that the user enter the correct difficulty range
    string userDifficulty = "na";
    int newDifficulty = -1;

    while (newDifficulty < 1 || newDifficulty > maxDifficulty)
    {
      Console.Write("Enter a difficulty level: ");
      userDifficulty = Console.ReadLine();

      if (userDifficulty != null)
        userDifficulty = userDifficulty.ToLower().Trim();

      int.TryParse(userDifficulty, out newDifficulty);
    }

    Console.WriteLine("The difficulty has been updated.");
    return newDifficulty;
  }

  static string FormatSeconds(TimeSpan elapsed)
  {
    return $"{elapsed.TotalSeconds:F1} seconds";
  }
}