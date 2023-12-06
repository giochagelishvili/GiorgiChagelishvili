namespace Practice_1
{
    internal class Home
    {
        public Home(string address, string city)
        {
            Address = address;
            City = city;
        }

        public string Address {  get; set; }
        public string City { get; set; }
    }
}
