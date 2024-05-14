namespace Patryk_MM.MathGame.Helpers {
    public static class NumberGenerator {
        public static (int, int) GenerateNumbers(char gameMode) {
            int a, b;
            Random random = new Random();
            if (gameMode == '*') {
                a = random.Next(2, 16);
                b = random.Next(2, 16);
                return (a, b);  
            }
            a = random.Next(1, 101);
            b = random.Next(1, 101);
            if (gameMode == '/') {
                while (a % b != 0 || b == 1 || a == b) {
                    a = random.Next(1, 101);
                    b = random.Next(1, 101);
                }
            };
            return (a, b);
        }
    }
}
