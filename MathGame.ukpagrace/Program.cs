// See https://aka.ms/new-console-template for more information




class MathGame{

  int rangeOne = 1;
  int rangeTwo = 10;


  public string Option{get; set;} = "";
  Random random= new Random();

  public List<string> PreviousGame{get; set;} = new List<string>();

  public bool ContinueGame{get; set;} = true;



  public void DisplayOption(){
    Console.WriteLine(Option);
  }



  void RandomGame(){
    int randomNumber = random.Next(1, 5);

    switch(randomNumber){
      case 1:
       AdditionGame(); 
      break;
      case 2: 
        SubstractionGame(); 
      break;
      case 3:
       MultiplicationGame();
      break;
      case 4:
       DivisionGame(); 
      break;
      default:
       AdditionGame();
      break;
    }
  }
  void ShowLevelMenu(){
    Console.WriteLine("choose a level of difficulty\n");
    Console.WriteLine("E - Easy");
    Console.WriteLine("M - Meduim");
    Console.WriteLine("H - Hard");

    Option = Console.ReadLine().Trim().ToLower();

    switch(Option){
      case "e":
        rangeOne = 1;
        rangeTwo = Option == "d" ?   10 : 99;
  
        break;

      case "m":
        rangeOne = 100;
        rangeTwo = 999;
      break;

      case "h":
        rangeOne = 1000;
        rangeTwo = 9999;
      break; 

      default:
        Console.WriteLine("Please select an option in the menu");
      break;
    }
  }


  void ShowMenu(){
      Console.WriteLine("What game would you like to play today\n");
      Console.WriteLine("R - Random");
      Console.WriteLine("A - Addition");
      Console.WriteLine("S - Subtraction");
      Console.WriteLine("M - Multiplication");
      Console.WriteLine("D - Division");


      Option = Console.ReadLine().Trim().ToLower();
     switch(Option){
        case "a":
          AdditionGame();
        break;

        case "s":
          SubstractionGame();
        break;

        case "m":
          MultiplicationGame();
        break;

        case "d":
          DivisionGame();
        break;

        case "r":
          RandomGame();
        break;

        default:
        Console.WriteLine("Invalid menu option");
        break;
        

    }

}

void AdditionGame(){
  int score = 0;

      for(int i=4; i > 0; i--){

        
        int firstNumber = random.Next(rangeOne, rangeTwo);
        int secondNumber = random.Next(rangeOne, rangeTwo);

        Console.WriteLine($"{firstNumber} +  {secondNumber}");
        int result;
        bool success = int.TryParse(Console.ReadLine(), out result);
        if(!success) Console.WriteLine("Enter a number");
        if(success && result == firstNumber / secondNumber){
          Console.WriteLine("Correct");
          score++;
        }

        if(i == 1){
          Console.WriteLine($"Your score is {score}");
        }
      }

       PreviousGame.Add($"Addition   {score}");
}

void SubstractionGame(){
  int score = 0;

      for(int i=4; i > 0; i--){
        int firstNumber = random.Next(rangeOne, rangeTwo);
        int secondNumber = random.Next(rangeOne, rangeTwo);

        while(firstNumber < secondNumber){
          firstNumber = random.Next(rangeOne, rangeTwo);
          secondNumber = random.Next(rangeOne, rangeTwo);
        }

        Console.WriteLine($"{firstNumber} -  {secondNumber}");
        int result;
        bool success = int.TryParse(Console.ReadLine(), out result);
        if(!success) Console.WriteLine("Enter a number");
        if(success && result == firstNumber / secondNumber){
          Console.WriteLine("Correct");
          score++;
        }

        if(i == 1){
          Console.WriteLine($"Your score is {score}");
        }
      }

      PreviousGame.Add($"Substraction   {score}");
}


void MultiplicationGame(){
  int score = 0;

    for(int i=4; i > 0; i--){
      int firstNumber = random.Next(rangeOne, rangeTwo) ;
      int secondNumber = random.Next(rangeOne, rangeTwo);

      Console.WriteLine($"{firstNumber} *  {secondNumber}");
      int result;
      bool success = int.TryParse(Console.ReadLine(), out result);
      if(!success) Console.WriteLine("Enter a number");
      if(success && result == firstNumber / secondNumber){
        Console.WriteLine("Correct");
        score++;
      }

      if(i == 1){
        Console.WriteLine($"Your score is {score}");
      } 
    }
    PreviousGame.Add($"Multiplication {score}");
}


void DivisionGame(){
  int score = 0;

    for(int i=4; i > 0; i--){
      int firstNumber = random.Next(rangeOne, rangeTwo);
      int secondNumber = random.Next(rangeOne, rangeTwo);

      while(firstNumber % secondNumber != 0){
        firstNumber = random.Next(rangeOne, rangeTwo);
        secondNumber = random.Next(rangeOne, rangeTwo);
      }

      Console.WriteLine($"{firstNumber} / {secondNumber}");
      int result;
      bool success = int.TryParse(Console.ReadLine(), out result);
      if(!success) Console.WriteLine("Enter a number");
      if(success && result == firstNumber / secondNumber){
        Console.WriteLine("Correct");
        score++;
      }

      if(i == 1){
        Console.WriteLine($"Your score is {score}");
      } 
    }
    PreviousGame.Add($"Division {score}");
}

   public void RunGame(){

    do{
      Console.WriteLine("V - View Previous Games");
      Console.WriteLine("Q - Quit the program");
      Console.WriteLine("Y - See menu");

      Option = Console.ReadLine().Trim().ToLower();


      switch (Option){
        case "q":
          ContinueGame = false;
          break;

        case "v":
            foreach(string item in PreviousGame){
              Console.WriteLine(item);
            }
          break;

          case "y":
            ShowLevelMenu();
            ShowMenu();
            break;




        default:
            Console.WriteLine("Game Type, Score\n");
            Console.WriteLine("Select an option");
            break;
        }
      } while (ContinueGame);
   }

   


  public static void Main(string[] args){
    Console.WriteLine("Please select a option");




   MathGame mathGame= new MathGame();

    mathGame.RunGame();
  }
}

