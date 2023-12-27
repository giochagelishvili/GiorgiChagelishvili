namespace Practice.Classes
{
    public static class Logger
    {
        public static void Log(Exception ex) 
        {
            string path = @"C:\Users\user\Desktop\Logs.txt";
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine($"Message: {ex.Message}");
                sw.WriteLine($"Stack trace: {ex.StackTrace}");
                sw.WriteLine("-------------------------------------");
            }
        }
    }
}
