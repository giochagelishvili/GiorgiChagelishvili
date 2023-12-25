namespace Exception_Practice.Exceptions
{
    public static class Output
    {
        public static string GetLastInnerExMessage(Exception ex)
        {
            if (ex.InnerException != null) 
                return ex.InnerException.Message;

            return "";
        }

        public static string GetAllInnerExMessageTogether(Exception ex)
        {
            string result = "";

            while (ex != null)
            {
                result += $"{ex.Message} ";
                ex = ex.InnerException;
            }

            return result;
        }
    }
}
