namespace Practice_1
{
    internal class Cat
    {
        string? _Name;
        string? _Breed;
        string? _Gender;
        int _Age;

        private int _GramsPerBite = 10;

        public string? Name { get; set; }
        public string? Breed { get; set; }
        public string? Gender { get; set; }
        public int Age 
        {
            get { return _Age; }
            set 
            {
                if (value < 0)
                    Console.WriteLine("Age must be a positive integer or 0.");
                else
                    _Age = value;
            }
        }

        public void Meow(int count)
        {
            if (count <= 0)
                return;
            else
                Console.WriteLine("Meowing ...");

            Meow(count - 1);
        }

        public void Eat(int grams)
        {
            if (grams <= 0)
                return;
            else
                Console.WriteLine("Eating ...");

            Eat(grams - _GramsPerBite);
        }
    }
}