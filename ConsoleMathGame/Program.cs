/*
You need to create a game that consists of asking the player what's the result of a math question (i.e. 9 x 9 = ?), collecting the input and adding a point in case of a correct answer.

A game needs to have at least 5 questions.

The divisions should result in INTEGERS ONLY and dividends should go from 0 to 100. Example: Your app shouldn't present the division 7/2 to the user, since it doesn't result in an integer.

Users should be presented with a menu to choose an operation

You should record previous games in a List and there should be an option in the menu for the user to visualize a history of previous games.

You don't need to record results on a database. Once the program is closed the results will be deleted.
*/

using MathGame;
var game = new GameLogic();

bool playing = true;

while(playing){
  Console.Clear();
  Console.WriteLine("Start a new game? y/n");
  var input = Console.ReadKey();

  if(input.KeyChar != 'y')
  {
    playing = false;
  } 
  else 
  {
    game.NewGame();
  }

  if(playing)
  {
    Console.WriteLine("View Game History? y/n");
    input = Console.ReadKey();
    if(input.KeyChar != 'y')
    {
      continue;
    } 
    else
    {
      Console.Clear();
      foreach (string question in game.GameHistory)
      {
        Console.WriteLine(question);
      }

      Console.WriteLine("Questions answered: " + game.GameHistory.Count);
      Console.WriteLine("Press any key to continue...");
      Console.ReadKey();
    }
  }
}
