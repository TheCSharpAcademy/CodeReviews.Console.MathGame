int option = 0;
		int userInput = 0;
		int num1 = 0;
		int num2 = 0;
		int result = 0;
		int userAnwser = 0;
		int correctAnwserCounter = 0;
		int inconrrectAnswerCounter = 0;
		
		
		Console.WriteLine("Welcome to the math game!!!");
		Console.WriteLine("Please select what kind of operations do you want to play:");
		Console.WriteLine("#1 - SUM ");
		Console.WriteLine("#2 - Subtraction");
		Console.WriteLine("#3 - Multiplication ");
		Console.WriteLine("#4 - Division ");
		Console.WriteLine("#0 - Exit");
		
		//Stop the loop if the user input is a valid number.
		bool isANumber = false;

		//Make sure that the input from the user is a number
		while(isANumber == false)
		{
			 
			if(int.TryParse(Console.ReadLine(), out userInput))
			{
				if (userInput >= 0 && userInput <= 4)
				{
					
				}
			}
			else
			{
			 Console.WriteLine();
			}
			
		}
		
		switch(userInput)
		{
			case 1:
            break;
				
		
		}
