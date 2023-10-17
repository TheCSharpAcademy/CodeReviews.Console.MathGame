using System.Collections.Generic;

namespace MathGame
{
    public static class History
    {
        private static List<string> _history = new List<string>();
        public static List<string> GetHistory()
        {
            return _history;
        }
        public static void SetHistory(string content)
        {
            _history.Add(content);
        }
    }
}