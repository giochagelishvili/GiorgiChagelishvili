namespace ExpTreeTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new()
            {
                new Student("Dodo", "Gugeshashvili", 21, 'M'),
                new Student("Jaba", "Ioseliani", 23, 'M'),
                new Student("Eduard", "Shevardnadze", 23, 'M'),
                new Student("Giorgi", "Brwyinvale", 21, 'C'),
                new Student("Nikusha", "Nozadze", 20, 'C'),
                new Student("Vakhtang", "Basilauri", 20, 'C'),
            };

            List<object> filterParameters = new() { 'M' };
            var filteredStudents = Filter.FilterStudents(students, filterParameters);
        }
    }
}
