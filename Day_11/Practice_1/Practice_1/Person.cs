namespace Practice_1
{
    internal class Person
    {
        public Person(string name, int age, string idNumber, Home home)
        {
            Name = name;
            Age = age;
            IdNumber = idNumber;
            Home = home;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string IdNumber { get; set; }
        public Home Home { get; set; }
    }
}