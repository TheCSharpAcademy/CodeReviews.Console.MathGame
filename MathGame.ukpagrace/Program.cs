class MathGame{
    int rangeOne = 1;
    int rangeTwo = 10;
    public string option = "";
    readonly Random random= new();
    public List<string> previousGame = [];
    public bool endGame;

    public void RandomGame(){
        int randomNumber = random.Next(1, 5);
        string operation;

        switch(randomNumber){
        case 1:
            operation = "+"; 
        break;
        case 2: 
            operation = "-";
        break;
        case 3:
            operation = "*";
        break;
        case 4:
            operation = "/";
        break;
        default:
            operation = "+";
        break;
        }
        PerformMath(operation);
    }

    void ShowLevelMenu(){
        Console.WriteLine("choose a level of difficulty\n");
        Console.WriteLine("E - Easy");
        Console.WriteLine("M - Meduim");
        Console.WriteLine("H - Hard");

        option = Console.ReadLine().Trim().ToLower();
        Console.Clear();
        switch(option){
            case "e":
                rangeOne = 1;
                rangeTwo = option == "d" ?   99 : 10;
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

    public void ShowMenu(){
        Console.WriteLine("What game would you like to play today\n");
        Console.WriteLine("R - Random");
        Console.WriteLine("A - Addition");
        Console.WriteLine("S - Subtraction");
        Console.WriteLine("M - Multiplication");
        Console.WriteLine("D - Division");

        option = Console.ReadLine().Trim().ToLower();
        Console.Clear();
        switch(option){
            case "a":
                PerformMath("+");
            break;
            case "s":
                PerformMath("-");
            break;
            case "m":
                PerformMath("*");
            break;
            case "d":
                PerformMath("/");
            break;
            case "r":
                RandomGame();
            break;
            default:
                Console.WriteLine("Invalid menu option");
            break;
        }
    }

    public void PerformMath(string operation){
        int score = 0;
        string operationPerformed = "No operation performed";
        for(int i=2; i > 0; i--){
            int firstNumber = random.Next(rangeOne, rangeTwo) ;
            int secondNumber = random.Next(rangeOne, rangeTwo);
            int mathResult = 0;
            int usersAnswer;
            while(operation == "-" && firstNumber < secondNumber){
                firstNumber = random.Next(rangeOne, rangeTwo);
                secondNumber = random.Next(rangeOne, rangeTwo);
            }

            while(operation == "/" && firstNumber % secondNumber != 0){
                firstNumber = random.Next(rangeOne, rangeTwo);
                secondNumber = random.Next(rangeOne, rangeTwo);
            }
            Console.WriteLine($"{firstNumber} {operation}  {secondNumber}");

            while(!int.TryParse(Console.ReadLine() , out usersAnswer)){
                Console.WriteLine("Enter a number");
            }
            Console.Clear();

            switch(operation){
                case "+":
                    mathResult = firstNumber + secondNumber;
                    operationPerformed = "Addition";
                break;
                case "-":
                    mathResult = firstNumber - secondNumber;
                    operationPerformed = "Subtraction";
                break;
                case "*":
                    mathResult = firstNumber * secondNumber;
                    operationPerformed = "Multiplication";
                break;
                case "/":
                    mathResult = firstNumber / secondNumber;
                    operationPerformed = "Division";
                break;
                default:
                break;
            }

            if(usersAnswer == mathResult){
                score++;
            }

            if(i == 1){
                Console.WriteLine($"Your score is {score}");
            }
        }
        previousGame.Add($"{operationPerformed} {score}");
    }

    public void RunGame(){
        do{
            Console.WriteLine("V - View Previous Games");
            Console.WriteLine("Q - Quit the program");
            Console.WriteLine("Y - See menu");
            option = Console.ReadLine().Trim().ToLower();
            Console.Clear();

            switch (option){
            case "q":
                endGame = true;
                break;
            case "v":
                if(previousGame.Count == 0){
                    Console.WriteLine("No operation has been peformed, perform an operation");
                }else{
                    foreach(string item in previousGame){
                        Console.WriteLine(item);
                    }
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
        } while (!endGame);
    }

    public static void Main(string[] args){
        Console.WriteLine("Please select a option");
        MathGame mathGame= new();
        mathGame.RunGame();
    }
}