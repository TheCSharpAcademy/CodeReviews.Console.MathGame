class MathGame {
     static void Main() {
          //math game instance
          MathGame Game = new MathGame();
          //calling the main menu method
          Game.MainMenu();
     }

     //global List to keep record of the games
     List<String> GameRecord = new List<String>();

     //Main Menu Method
     void MainMenu() {
          //variables
          String[] Menu = { "1 - Addition", "2 - Subraction", "3 - Multiplication", "4 - Division", "5 - Show Previous Games" };
          int GameSelection = 0;
          bool MenuCheck = false;

          //asking user to select a game mode
          Console.WriteLine("Welcome!");
          Console.WriteLine("Select a Math Game\n");

          //present the user with options
          for (int i = 0; i < Menu.Length; i++) {
               Console.WriteLine(Menu[i]);
          }

          //Menu selecion check
          while (MenuCheck == false) {
               //take in user input          // -1 because im using an array for game selection
               GameSelection = Convert.ToInt32(Console.ReadLine()) - 1;
               //if the option was not correct, user can try again
               if (GameSelection < 0 || GameSelection > 4) {
                    Console.WriteLine("Incorrect option.\n");
                    Console.WriteLine("Please select an appropriate option.\n");
               }
               else if (GameSelection == 4) {

                    if (GameRecord.Count < 1) {
                         Console.WriteLine("You much play a game first!");
                         Console.WriteLine("Try again after playing a game.");
                    }
                    else {//will print out the list if its not empty
                         for (int i = 0; i < GameRecord.Count; i++) {
                              Console.WriteLine(GameRecord[i]);
                         }
                    }
               }
               else {
                    GameLoop(GameSelection);
               }
          }
     }

     //Game Look Method
     void GameLoop(int GameSelection) {
          //variables
          int UserAnswer;
          char[] GameModes = { '+', '-', '*', '/' };
          int NumOne;
          int NumTwo;
          bool Loop = true;
          string StoredQuestion;
          string StoredAnswer;

          //random number generator
          Random rnd = new Random();

          //game loop
          while (Loop == true) {
               //giving use the option to quit the game
               Console.WriteLine("Use -1 to exit");

               //Generate two random numbers ranging from 0 to 10
               NumOne = rnd.Next(0, 11);
               NumTwo = rnd.Next(0, 11);

               if (GameSelection == 3) {
                    DivisionOperation(rnd, out NumOne, out NumTwo);

                    Console.WriteLine("What is " + NumOne + " " + GameModes[GameSelection] + " " + NumTwo);

                    StoredQuestion = "What is " + NumOne + " " + GameModes[GameSelection] + " " + NumTwo;
               }
               else {
                    //asking the user math questions
                    Console.WriteLine("What is " + NumOne + " " + GameModes[GameSelection] + " " + NumTwo);
                    StoredQuestion = "What is " + NumOne + " " + GameModes[GameSelection] + " " + NumTwo;
               }
               //stores the user answer
               UserAnswer = Convert.ToInt32(Console.ReadLine());

               //keeps the record of the user answer
               StoredAnswer = Convert.ToString(UserAnswer);

               //calling the record method to store the answers
               Record(StoredQuestion, StoredAnswer);

               //checking if user wants to quit the loop allowing them to return to the main menu
               if (UserAnswer == -1)
                    MainMenu();
               else
                    AnswerCheck(NumOne, NumTwo, UserAnswer, GameSelection);
          }
     }

     //division resulting in an int only; ranging from 0 to 100
     static void DivisionOperation(Random rnd, out int NumOne, out int NumTwo) {

          do {
               NumOne = rnd.Next(0, 101);
               NumTwo = rnd.Next(1, 101); //not allowing to divide by 0

          } while (NumOne % NumTwo != 0);
     }

     //Answer Check Method
     void AnswerCheck(int NumOne, int NumTwo, int UserAnswer, int GameSelection) {
          //Variables
          int CorrectAnswer = 0;

          //checking if the user answer is correct
          switch (GameSelection) {
               case 0://add
                    CorrectAnswer = NumOne + NumTwo;
                    break;
               case 1://subtract
                    CorrectAnswer = NumOne - NumTwo;
                    break;
               case 2://multiply
                    CorrectAnswer = NumOne * NumTwo;
                    break;
               case 3://divide
                    CorrectAnswer = NumOne / NumTwo;
                    break;
          }
          //Gives the User feedback
          if (CorrectAnswer == UserAnswer) {
               Console.WriteLine("Correct!");
          }
          else {
               Console.WriteLine("Wrong!\n" + "Correct Answer was " + CorrectAnswer);
          }
     }

     //store a record of previous games in a list
     void Record(String StoredQuestion, String StoredAnswer) {
          if (Convert.ToInt32(StoredAnswer) == -1) {
               GameRecord.Add("End of Match");
          }
          else {
               GameRecord.Add(StoredQuestion + "\n" + StoredAnswer);
          }
     }
}