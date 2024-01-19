namespace Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customers = FileReader.ReadCustomers("../../../../Customers.txt");
            List<Order> orders = FileReader.ReadOrders("../../../../Orders.txt");

            Dictionary<int, int> orderCount = Report.OrderCount(customers, orders);
            Dictionary<int, decimal> orderSum = Report.OrderSum(customers, orders);
            Dictionary<int, decimal> minOrder = Report.MinOrder(customers, orders);
            Dictionary<int, int> customerWithMoreThanOneOrder = Report.CustomerWithMoreThanOneOrder(customers, orders);
            Dictionary<int, decimal> averageGreaterThanTen = Report.AverageGreaterThanTen(customers, orders);

            foreach (var customer in customers)
            {
                string hasMoreThanOneOrder = customerWithMoreThanOneOrder.ContainsKey(customer.CustomerID) ? "Has more than one order" : "Has one or no order";
                string hasAverageGreaterThanTen = averageGreaterThanTen.ContainsKey(customer.CustomerID) ? $"Order average: {averageGreaterThanTen[customer.CustomerID]}" : "Has order average less than 10";

                Console.WriteLine($"{customer.CustomerName} - Order count: {orderCount[customer.CustomerID]}, Order sum: {orderSum[customer.CustomerID]}, Min order: {minOrder[customer.CustomerID]}, {hasMoreThanOneOrder}, {hasAverageGreaterThanTen}");
            }
        }
    }
}
