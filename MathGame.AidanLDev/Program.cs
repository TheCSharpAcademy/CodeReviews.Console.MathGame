Random rng = new();

bool stillPlaying = true;
int curGame = 1;
int curScore = 0;
List<string> gameHistory = [];

void menuOptions()
{
  Console.WriteLine("1: Play new game");
  if (curGame > 1)
  {
    Console.WriteLine("2: View game history");
  }

  Console.WriteLine("(e) to exit...");
}

void printMainMenu()
{
  Console.WriteLine("Welcome to the Maths Game! Please select from one of the options:\n");
  menuOptions();
}

Dictionary<int, char> operators = new()
{
  { 1, '+' },
  { 2, '-' },
  { 3, '*' },
  { 4, '/' }
};


void additionQuestion()
{
  int num1 = rng.Next(1, 100000);
  int num2 = rng.Next(1, 100000);
  Console.WriteLine($"What is {num1:N0} + {num2:N0}");
  int res = num1 + num2;
  string? usersResStr = Console.ReadLine();
  if (usersResStr != null)
  {
    int.TryParse(usersResStr, out int usersRes);
    if (usersRes != res)
    {
      Console.WriteLine($"Unlucky... the result was {res}");
    }
    else
    {
      Console.WriteLine($"Right you are! The answer was {res}");
      curScore++;
    }
    gameHistory.Add($"{num1} + {num2} = {res} - your answer {usersRes}. Current score {curScore}");
  }
}

void subtractionQuestion()
{
  int num1 = rng.Next(1, 100000);
  int num2 = rng.Next(1, 100000);
  Console.WriteLine($"What is {num1:N0} - {num2:N0}");
  int res = num1 - num2;
  string? usersResStr = Console.ReadLine();
  if (usersResStr != null)
  {
    int.TryParse(usersResStr, out int usersRes);
    if (usersRes != res)
    {
      Console.WriteLine($"Unlucky... the result was {res}");
    }
    else
    {
      Console.WriteLine($"Right you are! The answer was {res}");
      curScore++;
    }
    gameHistory.Add($"{num1} - {num2} = {res} - your answer {usersRes}. Current score {curScore}");
  }
}

void multiplicationQuestion()
{
  int num1 = rng.Next(1, 100);
  int num2 = rng.Next(1, 100);
  Console.WriteLine($"What is {num1:N0} * {num2:N0}");
  int res = num1 * num2;
  string? usersResStr = Console.ReadLine();
  if (usersResStr != null)
  {
    int.TryParse(usersResStr, out int usersRes);
    if (usersRes != res)
    {
      Console.WriteLine($"Unlucky... the result was {res}");
    }
    else
    {
      Console.WriteLine($"Right you are! The answer was {res}");
      curScore++;
    }
    gameHistory.Add($"{num1} * {num2} = {res} - your answer {usersRes}. Current score {curScore}");
  }
}

void divisionQuestion()
{
  int divisor = rng.Next(1, 11);
  int quotient = rng.Next(1, 11);
  int divided = divisor * quotient;
  Console.WriteLine($"What is {divided:N0}/{quotient:N0}");
  int res = divided / quotient;
  string? usersResStr = Console.ReadLine();
  if (usersResStr != null)
  {
    int.TryParse(usersResStr, out int usersRes);
    if (usersRes != res)
    {
      Console.WriteLine($"Unlucky... the result was {res}");
    }
    else
    {
      Console.WriteLine($"Right you are! The answer was {res}");
      curScore++;
    }
    gameHistory.Add($"{divided}/{quotient} = {res} - your answer {usersRes}. Current score {curScore}");
  }
}

void playGame()
{
  for (int i = 1; i < 6; i++)
  {
    int operatorRng = rng.Next(1, 5);
    char mathOperator = operators[operatorRng];
    switch (mathOperator)
    {
      case '+':
        additionQuestion();
        break;
      case '-':
        subtractionQuestion();
        break;
      case '*':
        multiplicationQuestion();
        break;
      case '/':
        divisionQuestion();
        break;
      default:
        additionQuestion();
        break;
    }
  }
  Console.WriteLine($"You got {curScore}/5");
  curGame++;
  curScore = 0;
}

void displayHistory()
{
  for (int i = 0; i < gameHistory.Count; i++)
  {
    if (i % 5 == 0)
    {
      int gameNumber = (i / 5) + 1;
      Console.WriteLine($"== Game {gameNumber} ==");
    }

    Console.WriteLine(gameHistory[i]);

  }
}

while (stillPlaying)
{

  printMainMenu();
  string? userInput = Console.ReadLine();
  if (userInput != null)
  {
    userInput = userInput.Trim().ToLower();
    if (userInput != "e" || userInput != "1" || userInput != "2" || (userInput == "2" && curGame == 1))
    {
      Console.WriteLine($"You inputted... {userInput}, please choose one of the options provided");
      menuOptions();
    }

    if (userInput == "e")
    {
      Console.WriteLine("Thank you for playing :)");
      stillPlaying = false;
      break;
    }

    if (userInput == "1")
    {
      playGame();
    }

    Console.WriteLine($"User inputted {userInput}");
    if (userInput == "2")
    {
      Console.WriteLine("Display history");
      displayHistory();
    }

  }

}