/* 
REQUIREMENTS:
1) You need to create a Math game containing the 4 basic operations
2) The divisions should result on INTEGERS ONLY and divisors should go from 0
    to 100. Example: Your app shouldn't present the division 7/2 to the user, 
    since it doesn't result in an integer.
3) Users should be presented with a menu to choose an operation.
4) You should record previous games in a List and there should be an option in
    the menu for the user to visualize a history of previous games.
5) You don't need to record results on a database. Once the program is closed 
    the results will be deleted.

CHALLENGES:
1) Try to implement levels of difficulty.
2) Add a timer to track how long the user takes to finish the game.
3) Add a function that let's the user pick the number of questions.
4) Create a 'Random Game' option where the players will be presented with 
    questions from random operations
*/

using MathGame;

Game game = new Game();

while (game.Menu()){
    continue;
}

Environment.Exit(0);