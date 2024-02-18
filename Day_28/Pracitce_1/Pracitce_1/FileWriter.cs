namespace Pracitce_1
{
    public static class FileWriter
    {
        private const string Path = "../../../TxtFiles\\";

        public async static Task WriteToFileAsync(int index)
        {
            string filePath = $"{Path}{index}.txt";

            using (var sw = new StreamWriter(filePath, true))
            {
                await Task.Delay(index * 100);
                sw.WriteLine($"Task {index}");
                sw.Flush();
            }   
        }
    }
}
