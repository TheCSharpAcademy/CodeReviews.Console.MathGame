using System;
using System.Diagnostics;

string? userInput = "";
int input = 0;

Random random = new Random();

int gameScore = 0;
int a = 0;
int b = 0;

List<string> allScores = new List<string>();

// track each question
Stopwatch stopwatch = new Stopwatch();

// track full game
Stopwatch gameTimer = new Stopwatch();

string elapsedTime = "";
string totalElapsedTime = "";

bool playing = true;


// Shows game menu and starts game with Play()
do {

    bool validOption = false;

    // Intro
    Console.WriteLine("Math! Let's Playing!");
    Console.WriteLine();

    // Menu
    Console.WriteLine("Enter a number to select a game below:");
    Console.WriteLine();
    Console.WriteLine("1. Addition");
    Console.WriteLine("2. Subtraction");
    Console.WriteLine("3. Multiplication");
    Console.WriteLine("4. Division");
    Console.WriteLine("5. Random");
    Console.WriteLine("6. Show scores");
    Console.WriteLine("7. Quit");

    while (!validOption) {
        userInput = Console.ReadLine();
        if ((int.TryParse(userInput, out input)) && input < 8) {
            if (input < 8 && input > 0) {
                validOption = true;
                Console.Clear();
                Play(input);
            }
        } else {
            Console.WriteLine("Invalid input");
            Console.Clear();
            break;
        }
    }

} while (playing);


void Play(int x) {




    switch (x) {


        case 1:
            TimeSpan ts;
            TimeSpan gameTimeSpan;

            for (int i = 0; i < 5; i++) {

                a = random.Next(1, 40);
                b = random.Next(1, 90);

                Console.WriteLine($"{a} + {b} = ?");
                if (i == 0) {
                    stopwatch.Start();
                    gameTimer.Start();
                }
                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out input)) {
                    if (input == a + b) {
                        ts = stopwatch.Elapsed;

                        if (ts.Seconds <= 3) {
                            gameScore += 3;
                        } else if (ts.Seconds <= 6) {
                            gameScore += 2;
                        } else {
                            gameScore++;
                        }
                    }
                    stopwatch.Reset();
                }

                if (i == 4) {
                    stopwatch.Stop();
                    gameTimer.Stop();

                    ts = stopwatch.Elapsed;
                    gameTimeSpan = gameTimer.Elapsed;


                    elapsedTime = String.Format("{0:000}", ts.Seconds);
                    totalElapsedTime = String.Format("{0:000}", gameTimeSpan.Seconds);

                    allScores.Add($"{DateTime.Now.ToString("MM/dd/yyyy")} - Addition: {gameScore} points in {totalElapsedTime} seconds");
                    Console.WriteLine($"You scored {gameScore} points in {totalElapsedTime} seconds. Press Enter to continue to the main menu.");
                    Console.ReadLine();

                    gameScore = 0;
                    stopwatch.Reset();
                    gameTimer.Reset();
                }
                Console.Clear();

            }

            break;

        case 2:
            for (int i = 0; i < 5; i++) {

                a = random.Next(30, 99);
                b = random.Next(1, 31);

                Console.WriteLine($"{a} - {b} = ?");
                if (i == 0) {
                    stopwatch.Start();
                    gameTimer.Start();
                }
                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out input)) {
                    if (input == a - b) {
                        ts = stopwatch.Elapsed;

                        if (ts.Seconds <= 3) {
                            gameScore += 3;
                        } else if (ts.Seconds <= 6) {
                            gameScore += 2;
                        } else {
                            gameScore++;
                        }
                    }
                    stopwatch.Reset();
                }

                if (i == 4) {
                    stopwatch.Stop();
                    gameTimer.Stop();

                    ts = stopwatch.Elapsed;
                    gameTimeSpan = gameTimer.Elapsed;


                    elapsedTime = String.Format("{0:000}", ts.Seconds);
                    totalElapsedTime = String.Format("{0:000}", gameTimeSpan.Seconds);

                    allScores.Add($"{DateTime.Now.ToString("MM/dd/yyyy")} - Subtraction: {gameScore} points in {totalElapsedTime} seconds");
                    Console.WriteLine($"You scored {gameScore} points in {totalElapsedTime} seconds. Press Enter to continue to the main menu.");
                    Console.ReadLine();

                    gameScore = 0;
                    stopwatch.Reset();
                    gameTimer.Reset();
                }
                Console.Clear();

            }
            break;

        case 3:

            for (int i = 0; i < 5; i++) {

                a = random.Next(1, 13);
                b = random.Next(1, 13);

                Console.WriteLine($"{a} * {b} = ?");
                if (i == 0) {
                    stopwatch.Start();
                    gameTimer.Start();
                }
                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out input)) {
                    if (input == a * b) {
                        ts = stopwatch.Elapsed;

                        if (ts.Seconds <= 3) {
                            gameScore += 3;
                        } else if (ts.Seconds <= 6) {
                            gameScore += 2;
                        } else {
                            gameScore++;
                        }
                    }
                    stopwatch.Reset();
                }

                if (i == 4) {
                    stopwatch.Stop();
                    gameTimer.Stop();

                    ts = stopwatch.Elapsed;
                    gameTimeSpan = gameTimer.Elapsed;


                    elapsedTime = String.Format("{0:000}", ts.Seconds);
                    totalElapsedTime = String.Format("{0:000}", gameTimeSpan.Seconds);

                    allScores.Add($"{DateTime.Now.ToString("MM/dd/yyyy")} - Multiplication: {gameScore} points in {totalElapsedTime} seconds");
                    Console.WriteLine($"You scored {gameScore} points in {totalElapsedTime} seconds. Press Enter to continue to the main menu.");
                    Console.ReadLine();

                    gameScore = 0;
                    stopwatch.Reset();
                    gameTimer.Reset();
                }
                Console.Clear();

            }
            break;

        case 4:

            for (int i = 0; i < 5; i++) {

                do {
                    a = random.Next(0, 101);
                    b = random.Next(1, 40);
                } while (a % b != 0);

                Console.WriteLine($"{a} ÷ {b} = ?");
                if (i == 0) {
                    stopwatch.Start();
                    gameTimer.Start();
                }
                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out input)) {
                    if (input == a / b) {
                        ts = stopwatch.Elapsed;

                        if (ts.Seconds <= 3) {
                            gameScore += 3;
                            stopwatch.Reset();
                        } else if (ts.Seconds <= 6) {
                            gameScore += 2;
                            stopwatch.Reset();
                        } else {
                            gameScore++;
                            stopwatch.Reset();
                        }
                    }

                    stopwatch.Reset();
                }

                if (i == 4) {
                    stopwatch.Stop();
                    gameTimer.Stop();

                    ts = stopwatch.Elapsed;
                    gameTimeSpan = gameTimer.Elapsed;


                    elapsedTime = String.Format("{0:000}", ts.Seconds);
                    totalElapsedTime = String.Format("{0:000}", gameTimeSpan.Seconds);

                    allScores.Add($"{DateTime.Now.ToString("MM/dd/yyyy")} - Division: {gameScore} points in {totalElapsedTime} seconds");
                    Console.WriteLine($"You scored {gameScore} points in {totalElapsedTime} seconds. Press Enter to continue to the main menu.");
                    Console.ReadLine();

                    gameScore = 0;
                    stopwatch.Reset();
                    gameTimer.Reset();
                }
                Console.Clear();

            }
            break;

        case 5:

            Play(random.Next(1, 5));

            break;

        case 6:

            Console.WriteLine("Game History");
            Console.WriteLine("-------------------------------");
            Console.WriteLine();
            foreach (string score in allScores) {
                Console.WriteLine(score);
            }
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Press \"Enter\" to continue to the main menu");
            Console.ReadLine();
            Console.Clear();
            break;

        default:
            Console.WriteLine("Exiting game");
            playing = false;
            break;

    }
}