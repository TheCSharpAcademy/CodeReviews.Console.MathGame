public static class Text
{
    // Main Game Menu
        public static string MainMenu = "";
        public static string EasyDifficulty = "";
        public static string HardDifficulty = "";
        public static string ChooseOperation = "";
        public static string OperationExplanation = "";
        public static string PastResults = "";
        public static string MainExit = "";
        public static string OutMessage = "";
    // 'Play by operation' submenu
        public static string AdditionMode = "";
        public static string SubtractionMode = "";
        public static string MultiplicationMode = "";
        public static string DivisionMode = "";
    // Mode Labels
        public static string EasyModeLabel = "";
        public static string HardModeLabel = "";
        public static string AdditionModeLabel = "";
        public static string SubtractionModeLabel = "";
        public static string MultiplicationModeLabel = "";
        public static string DivisionModeLabel = "";
    // 'Game finished'
        public static string Replay = "";
        public static string SwitchItUp = "";
        public static string BackToMenu = "";
    // 'Run info'
        public static string CorrectAnswers = "";
        public static string Streak = "";
        public static string Time = "";
    // Gameplay
        public static string SolveThis = "";
        public static string Question = "";
        public static string Correct = "";
        public static string Wrong = "";
        public static string StopThat = "";
    // PastResults Labels
        public static string FinalRunTime = "";
        public static string FinalCorrectAnswers = "";
        public static string FinalBestStreak = "";
        public static string FinalScore = "";
        public static string NoResultsYet = "";
        public static string PressAnyKey = "";
        
    public static void LoadEnglish()
    {
        // Main Game Menu
            MainMenu = "\nChoose an option:";
            EasyDifficulty = "EASY mode";
            HardDifficulty = "HARD mode";
            ChooseOperation = "OPERATION mode";
            OperationExplanation = "Choose to play a single kind of operation: addition, subtraction, multiplication or division";
            PastResults = "See past scores";
            MainExit = "Exit the game";
            OutMessage = "Too bad! See you!";
        // 'Play by operation' submenu
            AdditionMode = "Play ONLY ADDITIONS mode";
            SubtractionMode = "Play ONLY SUBTRACTIONS mode";
            MultiplicationMode = "Play ONLY MULTIPLICATIONS mode";
            DivisionMode = "Play ONLY DIVISIONS mode";
        // Mode Labels
            EasyModeLabel = "Easy";
            HardModeLabel = "Hard";
            AdditionModeLabel = "Addition";
            SubtractionModeLabel = "Subtraction";
            MultiplicationModeLabel = "Multiplication";
            DivisionModeLabel = "Division";
        // 'Game finished'
            Replay = "Replay this game mode";
            SwitchItUp = "Try the other mode";
            BackToMenu = "Go back to the main menu";
        // 'Run info'
            CorrectAnswers = "You had {0} correct answers!";
            Streak = "You had a streak of {0} correct answers in a row!";
            Time = "You finished in {0} seconds!";
        // Gameplay
            SolveThis = "Introduce the correct answer for this equation (in numbers):";
            Question = "Question";
            Correct = "That's right!";
            Wrong = "That's wrong!";
            StopThat = "Please only enter numerical characters";
        // PastResults Labels
            FinalRunTime = "Time taken:";
            FinalCorrectAnswers = "Correct answers:";
            FinalBestStreak = "Best streak:";
            FinalScore = "Final socre:";
            NoResultsYet = "You haven't played any of the modes yet!\nCome back when you have to check your score!";
            PressAnyKey = "Press any key to exit";
    }
    public static void LoadSpanish()
    {
        // Main Game Menu
            MainMenu = "\nElegí una opción:";
            EasyDifficulty = "Modo FÁCIL";
            HardDifficulty = "Modo DIFÍCIL";
            ChooseOperation = "Modo OPERACIÓN";
            OperationExplanation = "Jugá con un sólo tipo de operación: suma, resta, multiplicación o división";
            PastResults = "Ver resultados anteriores";
            MainExit = "Salir del juego";
            OutMessage = "¡Qué mal! ¡Nos vemos!";
        // 'Play by operation' submenu
            AdditionMode = "Jugar sólo con SUMAS";
            SubtractionMode = "Jugar sólo con RESTAS";
            MultiplicationMode = "Jugar sólo con MULTIPLICACIONES";
            DivisionMode = "Jugar sólo con DIVISIONES";
        // Mode Labels
            EasyModeLabel = "Fácil";
            HardModeLabel = "Difícil";
            AdditionModeLabel = "Suma";
            SubtractionModeLabel = "Resta";
            MultiplicationModeLabel = "Multiplicación";
            DivisionModeLabel = "División";
        // 'Game finished'
            Replay = "Jugá de nuevo en este modo";
            SwitchItUp = "Probá el otro modo de juego";
            BackToMenu = "Volver al menú principal";
        // 'Run info'
            CorrectAnswers = "¡Respondiste bien {0} preguntas!";
            Streak = "¡Tuviste una racha de {0} respuestas correctas seguidas!";
            Time = "Completaste la partida en {0} segundos.";
        // Gameplay
            SolveThis = "Resolvé correctamente esta cuenta (en números):";
            Question = "Pregunta";
            Correct = "¡Correcto!";
            Wrong = "¡Incorrecto!";
            StopThat = "Por favor, sólo números";
        // PastResults
            FinalRunTime = "Tiempo total:";
            FinalCorrectAnswers = "Respuestas correctas:";
            FinalBestStreak = "Mejor racha:";
            FinalScore = "Puntaje final:";
            NoResultsYet = "Todavía no jugaste ninguna partida.\nVolvé cuando hayas jugado para ver tu puntaje";
            PressAnyKey = "Presioná cualquier tecla para salir";
    }
}