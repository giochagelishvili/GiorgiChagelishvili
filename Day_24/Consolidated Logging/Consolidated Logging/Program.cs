namespace Consolidated_Logging
{
    internal class Program
    {
        public delegate void LogMessage(string message);

        static void Main(string[] args)
        {
            LogMessage logToConsole = Log.LogToConsole;
            LogMessage logToFile = Log.LogToFile;

            LogMessage logger = logToConsole + logToFile;

            logger.Invoke("Dea xarisxiani AI a");
        }
    }
}
