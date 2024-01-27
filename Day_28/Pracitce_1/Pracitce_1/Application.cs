namespace Pracitce_1
{
    public static class Application
    {
        private static CancellationTokenSource cts = new();

        public static void Start()
        {
            RunTasks();
            WaitForCancelation();
        }

        private static void WaitForCancelation()
        {
            Task.Run(() =>
            {
                Console.WriteLine("Press enter to stop the program.");
                Console.ReadLine();
                cts.Cancel();
            }).Wait();
        }

        private static void RunTasks()
        {
            for (int i = 1; i <= 10; i++)
            {
                int indexer = i;

                Task.Run(() =>
                {
                    while (!cts.Token.IsCancellationRequested)
                        _ = FileWriter.WriteToFileAsync(indexer);
                });
            }
        }
    }
}
