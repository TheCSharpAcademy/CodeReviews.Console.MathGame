using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace HelloWorld;

class Program
{
  static void Main(string[] args)
  {
    int points = 0;
    bool playAgain = true;
    Random random = new Random();

    List<Questions> questions = new List<Questions>();
    // Addition questions
    questions.Add(new Questions("9 + 10 = ?", '+', 19));
    questions.Add(new Questions("7 + 13 = ?", '+', 20));
    questions.Add(new Questions("25 + 35 = ?", '+', 60));
    questions.Add(new Questions("18 + 22 = ?", '+', 40));

    // Subtraction questions
    questions.Add(new Questions("15 - 4 = ?", '-', 11));
    questions.Add(new Questions("50 - 23 = ?", '-', 27));
    questions.Add(new Questions("100 - 45 = ?", '-', 55));
    questions.Add(new Questions("73 - 28 = ?", '-', 45));

    // Multiplication questions
    questions.Add(new Questions("12 * 12 = ?", '*', 144));
    questions.Add(new Questions("6 * 9 = ?", '*', 54));
    questions.Add(new Questions("7 * 8 = ?", '*', 56));
    questions.Add(new Questions("11 * 5 = ?", '*', 55));
    questions.Add(new Questions("8 * 8 = ?", '*', 64));

    // Division questions (integers only, dividends 0-100)
    questions.Add(new Questions("56 / 7 = ?", '/', 8));
    questions.Add(new Questions("81 / 9 = ?", '/', 9));
    questions.Add(new Questions("100 / 10 = ?", '/', 10));
    questions.Add(new Questions("48 / 6 = ?", '/', 8));
    questions.Add(new Questions("72 / 8 = ?", '/', 9));
    questions.Add(new Questions("63 / 7 = ?", '/', 9));

    List<AnsweredQuestion> PreviousGames = new List<AnsweredQuestion>();

    while (playAgain)
    {
      System.Console.WriteLine("Welcome to the Math Game!");
      while (playAgain)
      {
        Console.WriteLine("=== Math Game Menu ===");
        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Subtraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");
        Console.WriteLine("5. View Previous Games");
        Console.WriteLine("6. Exit");
        Console.Write("Enter your choice (1-6): ");
        string choiceInput = Console.ReadLine();
        int choice;

        // Try parsing safely
        if (!int.TryParse(choiceInput, out choice) || choice < 1 || choice > 5)
        {
          Console.WriteLine("\nExiting the game. Thanks for playing!");
          playAgain = false;
          break;
        }
        else if (choice == 5)
        {
          Console.WriteLine("\nHere are your previous games:");
          foreach (var answered in PreviousGames)
          {
            string correctness = answered.IsCorrect ? "Correct" : "Wrong";
            Console.WriteLine($"{answered.QuestionText} Your answer: {answered.UserAnswer}. Correct answer: {answered.Answer}. Result: {correctness}");
          }
          continue;
        }

        char operationChar = ' ';
        switch (choice)
        {
          case 1: operationChar = '+'; break;
          case 2: operationChar = '-'; break;
          case 3: operationChar = '*'; break;
          case 4: operationChar = '/'; break;
        }

        List<Questions> filteredQuestions = questions.Where(q => q.Operation == operationChar).ToList();
        Questions question = filteredQuestions[random.Next(filteredQuestions.Count)];

        Console.WriteLine(question.QuestionText);
        if (!int.TryParse(Console.ReadLine(), out int userAnswer))
        {
          Console.WriteLine("Invalid input! Please enter a number.\n");
          continue;
        }

        PreviousGames.Add(new AnsweredQuestion(question.QuestionText, question.Operation, question.Answer, userAnswer));

        if (userAnswer == question.Answer)
        {
          points++;
          Console.WriteLine("Correct!\n");
        }
        else
        {
          Console.WriteLine($"Wrong! The correct answer is {question.Answer}\n");
        }
      }
      Console.WriteLine($"Your total points is: {points}!");
      Console.WriteLine("Do you want to play again? (y/n)");
      string response = Console.ReadLine();
      if (response.ToLower() != "y")
      {
        playAgain = false;
      }
      else
      {
        playAgain = true;
        points = 0;
      }
    }

  }
}

class Questions
{
  public string QuestionText { get; }
  public char Operation { get; }
  public int Answer { get; }

  public Questions(string questionText, char operation, int answer)
  {
    QuestionText = questionText;
    Operation = operation;
    Answer = answer;
  }
}
class AnsweredQuestion : Questions
{
  public int UserAnswer { get; set; }
  public bool IsCorrect { get; set; }

  // Call base constructor for QuestionText, Operation, Answer
  public AnsweredQuestion(string questionText, char operation, int answer, int userAnswer)
      : base(questionText, operation, answer)
  {
    UserAnswer = userAnswer;
    IsCorrect = userAnswer == answer;
  }
}


/*
You need to create a game that consists of asking the player what's the result of a math question (i.e. 9 x 9 = ?), collecting the input and adding a point in case of a correct answer.


A game needs to have at least 5 questions.


The divisions should result on INTEGERS ONLY and dividends should go from 0 to 100. Example: Your app shouldn't present the division 7/2 to the user, since it doesn't result in an integer.


Users should be presented with a menu to choose an operation


You should record previous games in a List and there should be an option in the menu for the user to visualize a history of previous games.


You don't need to record results on a database. Once the program is closed the results will be deleted.
*/