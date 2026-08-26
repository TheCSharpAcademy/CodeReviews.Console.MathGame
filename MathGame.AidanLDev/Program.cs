using Spectre.Console;

Random rng = new();

bool stillPlaying = true;
int curGame = 1;
int curScore = 0;
int totalScore = 0;
List<string> gameHistory = [];


Dictionary<int, char> operators = new()
{
  { 1, '+' },
  { 2, '-' },
  { 3, '*' },
  { 4, '/' }
};

void addToGameHistory(int num1, int num2, int res, int usersRes, int curScore, char mathSymbol)
{
  gameHistory.Add($"{num1} {mathSymbol} {num2} = {res} - your answer {usersRes}. Current score {curScore}");
}

void displayWrongAnswer(int res)
{
  AnsiConsole.MarkupLine($"[red]Unlucky... the result was {res}[/]");
}

void displayCorrectAnswer(int res)
{
  AnsiConsole.MarkupLine($"[green]Right you are! The answer was {res}[/]");
  curScore++;
}


void additionQuestion()
{
  int num1 = rng.Next(1, 100);
  int num2 = rng.Next(1, 100);
  Console.WriteLine($"What is {num1:N0} + {num2:N0}");
  int res = num1 + num2;
  string? usersResStr = Console.ReadLine();
  if (usersResStr != null)
  {
    int.TryParse(usersResStr, out int usersRes);
    if (usersRes != res)
    {
      displayWrongAnswer(res);
    }
    else
    {
      displayCorrectAnswer(res);
    }
    addToGameHistory(num1, num2, res, usersRes, curScore, '+');
  }
}

void subtractionQuestion()
{
  int num1 = rng.Next(1, 100);
  int num2 = rng.Next(1, 100);
  Console.WriteLine($"What is {num1:N0} - {num2:N0}");
  int res = num1 - num2;
  string? usersResStr = Console.ReadLine();
  if (usersResStr != null)
  {
    int.TryParse(usersResStr, out int usersRes);
    if (usersRes != res)
    {
      displayWrongAnswer(res);
    }
    else
    {
      displayCorrectAnswer(res);
    }
    addToGameHistory(num1, num2, res, usersRes, curScore, '-');
  }
}

void multiplicationQuestion()
{
  int num1 = rng.Next(1, 10);
  int num2 = rng.Next(1, 10);
  Console.WriteLine($"What is {num1:N0} * {num2:N0}");
  int res = num1 * num2;
  string? usersResStr = Console.ReadLine();
  if (usersResStr != null)
  {
    int.TryParse(usersResStr, out int usersRes);
    if (usersRes != res)
    {
      displayWrongAnswer(res);
    }
    else
    {
      displayCorrectAnswer(res);
    }
    addToGameHistory(num1, num2, res, usersRes, curScore, '*');
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
      displayWrongAnswer(res);
    }
    else
    {
      displayCorrectAnswer(res);
    }
    addToGameHistory(divided, quotient, res, usersRes, curScore, '/');
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
  totalScore += curScore;
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
  AnsiConsole.MarkupLine($"Total score [green]{totalScore}[/]");
  Console.WriteLine("\n");
}

List<string> BuildMenuChoices()
{
  List<string> menuChoices = ["Start a new game"];

  if (curGame > 1)
  {
    menuChoices.Add("View previous game history");
  }
  menuChoices.Add("Exit game");
  return menuChoices;
}

while (stillPlaying)
{
  string userChoice = AnsiConsole.Prompt(
    new SelectionPrompt<string>().
    Title("Please select from the following...")
    .AddChoices(BuildMenuChoices())
  ).ToLower().Trim();

  switch (userChoice)
  {
    case "exit game":
      Console.WriteLine("Thank you for playing :)");
      stillPlaying = false;
      break;
    case "start a new game":
      playGame();
      break;
    case "view previous game history":
      displayHistory();
      break;
    default:
      playGame();
      break;
  }
}