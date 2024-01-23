namespace Practice
{
    public static class FileReader
    {
        public static List<Customer> ReadCustomers(string path)
        {
            return File.ReadLines(path).Select(line => new Customer
            (
                int.Parse(line.Split('|')[0]),
                line.Split('|')[1]
            )).ToList();
        }

        public static List<Order> ReadOrders(string path)
        {
            return File.ReadLines(path).Select(line => new Order
            (
                int.Parse(line.Split('|')[0]), 
                line.Split('|')[1], line.Split('|')[2], 
                decimal.Parse(line.Split('|')[3]), 
                int.Parse(line.Split('|')[4])
            )).ToList();
        }
    }
}
