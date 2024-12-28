namespace math_game
{
	internal class Program
	{
		enum GameMode
		{
			Division = 1,
			Multiplication = 2,
			Addition = 3,
			Subtraction = 4
		}

		enum Difficulty
		{
			Easy = 1,
			Normal = 2,
			Hard = 3
		}

		class Game
		{
			private static Random random = new();
			private GameMode selectedMode;
			private int difficulty;
			private int[] operators;
			private string operation = string.Empty;
			private int answer;
			public bool correct;

			public Game(GameMode selectedMode, int difficulty)
			{
				this.selectedMode = selectedMode;
				this.difficulty = difficulty;
				this.operators = GetOps(selectedMode, difficulty);
				this.answer = GenerateAnswer(selectedMode, operators);
			}

			private static int[] GetOps(GameMode selectedMode, int difficulty)
			{
				int opOne = random.Next(1, 10 * difficulty);
				int opTwo = random.Next(1, 10 * difficulty);
				switch (selectedMode)
				{
					case GameMode.Division:
						while (opOne % opTwo != 0)
						{
							opOne = random.Next(1, 15 * difficulty);
							opTwo = random.Next(1, 15 * difficulty);
						}

						return [opOne, opTwo];
					default:
						return [opOne, opTwo];
				}
			}


			private static int GenerateAnswer(GameMode selectedMode, int[] operators)
			{
				return selectedMode switch
				{
					GameMode.Division => operators[0] / operators[1],
					GameMode.Multiplication => operators[0] * operators[1],
					GameMode.Addition => operators[0] + operators[1],
					GameMode.Subtraction => operators[0] - operators[1],
					_ => 0,
				};
			}

			public void Play()
			{
				switch (this.selectedMode)
				{
					case GameMode.Division:
						this.operation = "/";
						break;
					case GameMode.Multiplication:
						this.operation = "*";
						break;
					case GameMode.Addition:
						this.operation = "+";
						break;
					case GameMode.Subtraction:
						this.operation = "-";
						break;

				}
				Console.Write($"{this.operators[0]} {operation} {this.operators[1]} = ");
				string? input;
				int answer;
				do
				{
					input = Console.ReadLine();
					if (!int.TryParse(input, out _))
					{
						Console.WriteLine("Not a valid answer. ");
						Console.WriteLine("Try again.");
					}
				}
				while (!int.TryParse(input, out answer));

				if (answer == this.answer)
				{
					Console.WriteLine("Correct!");
					this.correct = true;
				}
				else
				{
					Console.WriteLine($"Incorrect! The answer is {this.answer}");
					this.correct = false;
				}
			}
		}


		static void Main()
		{
			(GameMode, Difficulty) init = Startup();
			List<Game> gamesList = GameGenerator(init.Item1, init.Item2);
			foreach (Game game in gamesList)
			{
				game.Play();
			}
			Console.WriteLine(QuizGrade(gamesList));
		}

		static string QuizGrade(List<Game> gamesList)
		{
			int correct = 0;
			foreach (Game game in gamesList)
			{
				if (game.correct)
				{
					correct++;
				}
			}
			return $"You got {correct} out of {gamesList.Count} correct!";
		}


		static (GameMode, Difficulty) Startup()
		{
			GameMode selectedMode = GetGameMode();
			Difficulty difficulty = GetDifficulty();
			Console.WriteLine($"\n{selectedMode} selected");

			return (selectedMode, difficulty);
		}


		private static GameMode GetGameMode()
		{
			string? input;
			Console.WriteLine("\n-------------------------------");
			Console.WriteLine("Welcome to bry-val's Math Game!");
			Console.WriteLine("Choose an operation to test!\n1: Division\n2: Multiplication\n3: Addition\n4: Subtraction\n");
			Console.WriteLine("Enter the number:");
			Console.WriteLine("-------------------------------");

			do
			{
				input = Console.ReadLine();
				if (!IsGameMode(input))
				{
					Console.WriteLine("Not a valid game mode. ");
					Console.WriteLine("Choose an operation to test!\n1: Division\n2: Multiplication\n3: Addition\n4: Subtraction");

				}
			} while (!IsGameMode(input));

			return (GameMode)int.Parse(input!);
		}

		private static Difficulty GetDifficulty()
		{
			string? input;
			Console.WriteLine("\n-------------------------------");
			Console.WriteLine("Enter your difficulty!\n1: Easy\n2: Normal\n3: Hard");
			Console.WriteLine("-------------------------------");
			do
			{
				input = Console.ReadLine();
				if (!IsDifficulty(input))
				{
					Console.WriteLine("Not a valid difficulty. ");
					Console.WriteLine("Enter your difficulty!\n1: Easy\n2: Normal\n3: Hard");
				}
			} while (!IsDifficulty(input));
			return (Difficulty)int.Parse(input!);
		}
		private static bool IsDifficulty(string? input)
		{
			bool isNum = int.TryParse(input, out int result);
			if (input == null || !isNum)
			{
				return false;
			}
			return Enum.IsDefined(typeof(Difficulty), result);

		}
		private static bool IsGameMode(string? input)
		{
			bool isNum = int.TryParse(input, out int result);
			if (input == null || !isNum)
			{
				return false;
			}
			return Enum.IsDefined(typeof(GameMode), result);

		}

		static List<Game> GameGenerator(GameMode selectedMode, Difficulty difficulty)
		{
			List<Game> gameList = [];
			for (int i = 0; i <= 5; i++)
			{

				gameList.Add(EquationGenerator(selectedMode, difficulty));
			}
			return gameList;

		}

		private static Game EquationGenerator(GameMode selectedMode, Difficulty difficulty)
		{

			return new Game(selectedMode, (int)difficulty);
		}
	}
}
