public class Helpers
{
    public List<Question> list { get; set; }

    public static int RandomNumber(int min, int max) => Random.Shared.Next(min, max);
}