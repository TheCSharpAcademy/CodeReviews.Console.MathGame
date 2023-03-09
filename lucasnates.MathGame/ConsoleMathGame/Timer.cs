namespace ConsoleMathGame
{
    internal class Timer
    {
        private DateTime startTime; 

        public void Start() 
        {
            startTime = DateTime.Now; 
        }

        public TimeSpan Stop() 
        {
            TimeSpan elapsedTime = DateTime.Now - startTime; 
            return elapsedTime; 
        }
    }
}
