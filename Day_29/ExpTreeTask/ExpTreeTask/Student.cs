namespace ExpTreeTask
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public char Group { get; set; }

        public Student(string firstName, string lastName, int age, char group)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Group = group;
        }
    }
}
