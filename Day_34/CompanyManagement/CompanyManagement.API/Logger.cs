using CompanyManagement.API.Infrastructure;

namespace CompanyManagement.API
{
    public static class Logger
    {
        public static void Log(ApiError apiError) => File.AppendAllText("Logs.txt", apiError.ToString());
    }
}
