namespace Math_Game.Model.NumericalType
{
    internal class Fraction
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public Fraction(int numerator)
        {
            Numerator = numerator;
            Denominator = 1;
        }

        public Fraction()
        {
            Numerator = 0;
            Denominator = 1;
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator);
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator * b.Denominator - b.Numerator * a.Denominator, a.Denominator * b.Denominator);
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }

        public static Fraction operator /(Fraction a, Fraction b){
            return new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }

        public Fraction Simplify()
        {
            int gcd = GCD(Numerator, Denominator);
            return new Fraction(Numerator / gcd, Denominator / gcd);
        }

        public static int GCD(int a, int b)
        {
            if (a == 0)
                return b;
            return GCD(b % a, a);
        }

        public String DisplayImproper()
        {
            return $"{Numerator}/{Denominator}";
        }

        public String DisplayMixed()
        {
            int whole = Numerator / Denominator;
            int numerator = Numerator % Denominator;
            if(whole == 0)
            {
                return $"{Numerator}/{Denominator}";
            }
            else return $"{whole} {numerator}/{Denominator}";
        }
    }
}
