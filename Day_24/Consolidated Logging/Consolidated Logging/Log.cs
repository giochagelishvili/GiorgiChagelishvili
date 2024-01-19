namespace Consolidated_Logging
{
    public class Log
    {
        public static void LogToConsole(string message) => Console.WriteLine(message);

        public static void LogToFile(string message)
        {
            using(StreamWriter sw = new StreamWriter("./Log.txt", true))
                sw.WriteLine(message);
        }
    }
}
