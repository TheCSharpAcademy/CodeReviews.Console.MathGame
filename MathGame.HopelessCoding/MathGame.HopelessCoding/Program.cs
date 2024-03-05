// My Math Game.
//
// First user selects math operand (, -, *,/) or list or exit in the menu by writing it.
// If input is operand, user is asked to choose difficulty level (easy, medium, hard) and two numbers are generated based on difficulty level.
// Then calculation task is shown for the user. User must give correct answer to continue forward.
//
// Input "list" will list all the previous tasks and correct answers
// "Exit" will shutdown the program.
//
// Alternative version which could be done: (Add n times rounds for each task (each games runs n times). Collect each game score to history list.)
//

using MathGame.HopelessCoding;

var menu = new Menu();

var rnd = new Random();
var taskHistory = new List<string>();

menu.ShowMenu();