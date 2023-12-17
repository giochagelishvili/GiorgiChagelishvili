namespace Extensions_Practices.Extensions
{
    public static class DateAndTime
    {
        // Turns date into string using (Day/Month/Year Hour:Minute:Seconds:milisecs) format and returns it
        public static string DateToString(this DateTime date)
        {
            int year = date.Year;
            int month = date.Month;
            int day = date.Day;
            int hour = date.Hour;
            int minute = date.Minute;
            int second = date.Second;
            int millisecond = date.Millisecond;

            return $"{day}/{month}/{year} {hour}:{minute}:{second}:{millisecond}";
        }

        // Returns true if given date falls within specific date range else returns false
        public static bool IsBetween(this DateTime dateToCheck, DateTime startDate, DateTime endDate) 
        {
            if (startDate > endDate)
                return false;

            if (startDate < dateToCheck && dateToCheck < endDate)
                return true;

            return false;
        }

        // Calculates and returns the age based on given birth date
        public static int CalculateAge(this DateTime birthDate) 
        {
            DateTime currentTime = DateTime.Now;

            // აქ რეალურად შემეძლო ორივე შემომწება ერთ if-ში მომექცია, მაგრამ კითხვადობისთვის
            // გადავწყვიტე, რომ 2 if გამეკეთებინა. თუ შეგიძლია ქლასრუმის კომენტარში დამიწერე ასე წერა ჯობია თუ ერთი if-ით

            // Check if person had a birthday this year
            if (birthDate.Month < currentTime.Month)
                return currentTime.Year - birthDate.Year;

            if (birthDate.Month == currentTime.Month && birthDate.Day <= currentTime.Day)
                return currentTime.Year - birthDate.Year;

            return currentTime.Year - birthDate.Year - 1;
        }
    }
}
