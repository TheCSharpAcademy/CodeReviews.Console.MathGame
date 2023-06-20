class MathGame {
     static void Main() {
          MathGame Game = new MathGame();
          
          Game.MainMenu();
     }

     //global List to keep record of the games
     List<String> GameRecord = new List<String>();

     void MainMenu() {

          String[] Menu = { "1 - Addition", "2 - Subraction", "3 - Multiplication", "4 - Division", "5 - Show Previous Games" };
          bool MenuCheck = false;
          int GameSelection = 0;
          int Input;
          bool isInputValid = false;

          Console.WriteLine("Welcome!");
          Console.WriteLine("Select a Math Game\n");

          for (int i = 0; i < Menu.Length; i++) {
               Console.WriteLine(Menu[i]);
          }
          
          while (MenuCheck == false) {

               do {
                    string UserInput = Console.ReadLine();
                    isInputValid = int.TryParse(UserInput, out Input);

                    if (!isInputValid) {
                         Console.WriteLine("Invalid input. Please enter an integer:");
                    }

               } while (!isInputValid);

                                                    // -1 to use as index of array
               GameSelection = Convert.ToInt32(Input) - 1;

               if (GameSelection < 0 || GameSelection > 4) {
                    Console.WriteLine("Incorrect option.\n");
                    Console.WriteLine("Please select an appropriate option.\n");
               }
               else if (GameSelection == 4) {

                    if (GameRecord.Count < 1) {
                         Console.WriteLine("You much play a game first!");
                         Console.WriteLine("Try again after playing a game.");
                    }
                    else {
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

     void GameLoop(int GameSelection) {
          
          int UserAnswer;
          char[] GameModes = { '+', '-', '*', '/' };
          int NumOne;
          int NumTwo;
          bool Loop = true;
          string StoredQuestion;
          string StoredAnswer;
          
          Random rnd = new Random();
          
          while (Loop == true) {               
               Console.WriteLine("Use -1 to exit");
               
               NumOne = rnd.Next(0, 11);
               NumTwo = rnd.Next(0, 11);

               if (GameSelection == 3) {
                    DivisionOperation(rnd, out NumOne, out NumTwo);

                    Console.WriteLine("What is " + NumOne + " " + GameModes[GameSelection] + " " + NumTwo);

                    StoredQuestion = "What is " + NumOne + " " + GameModes[GameSelection] + " " + NumTwo;
               }
               else {                    
                    Console.WriteLine("What is " + NumOne + " " + GameModes[GameSelection] + " " + NumTwo);
                    StoredQuestion = "What is " + NumOne + " " + GameModes[GameSelection] + " " + NumTwo;
               }               
               UserAnswer = Convert.ToInt32(Console.ReadLine());
               
               StoredAnswer = Convert.ToString(UserAnswer);
               
               Record(StoredQuestion, StoredAnswer);
               
               if (UserAnswer == -1)
                    MainMenu();
               else
                    AnswerCheck(NumOne, NumTwo, UserAnswer, GameSelection);
          }
     }
     
     static void DivisionOperation(Random rnd, out int NumOne, out int NumTwo) {

          do {
               NumOne = rnd.Next(0, 101);
               NumTwo = rnd.Next(1, 101); //not allowing to divide by 0

          } while (NumOne % NumTwo != 0);
     }
     
     void AnswerCheck(int NumOne, int NumTwo, int UserAnswer, int GameSelection) {          
          int CorrectAnswer = 0;

          switch (GameSelection) {
               case 0:
                    CorrectAnswer = NumOne + NumTwo;
                    break;
               case 1:
                    CorrectAnswer = NumOne - NumTwo;
                    break;
               case 2:
                    CorrectAnswer = NumOne * NumTwo;
                    break;
               case 3:
                    CorrectAnswer = NumOne / NumTwo;
                    break;
          }
          
          if (CorrectAnswer == UserAnswer) {
               Console.WriteLine("Correct!");
          }
          else {
               Console.WriteLine("Wrong!\n" + "Correct Answer was " + CorrectAnswer);
          }
     }

     void Record(String StoredQuestion, String StoredAnswer) {
          if (Convert.ToInt32(StoredAnswer) == -1) {
               GameRecord.Add("End of Match");
          }
          else {
               GameRecord.Add(StoredQuestion + "\n" + StoredAnswer);
          }
     }
}