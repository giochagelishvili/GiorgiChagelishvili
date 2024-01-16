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

            var customersWithOrders = customers.Select(x => x.CustomerID).Where(orderCount.ContainsKey);

            foreach (int customerId in customersWithOrders)
            {
                string hasMoreThanOneOrder = customerWithMoreThanOneOrder.ContainsKey(customerId) ? "Has more than one order" : "Has one or no order";
                string hasAverageGreaterThanTen = averageGreaterThanTen.ContainsKey(customerId) ? $"Order average: {averageGreaterThanTen[customerId]}" : "Has order average less than 10";

                Console.WriteLine($"Customer ID: {customerId}, Order count: {orderCount[customerId]}, Order sum: {orderSum[customerId]}, Min order: {minOrder[customerId]}, {hasMoreThanOneOrder}, {hasAverageGreaterThanTen}");
            }
        }
    }
}
