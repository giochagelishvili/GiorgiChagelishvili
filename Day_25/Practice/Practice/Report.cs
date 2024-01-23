namespace Practice
{
    public static class Report
    {
        public static Dictionary<int, int> OrderCount(List<Customer> customers, List<Order> orders)
        {
            var groupedByCustomerId = GroupByCustomerId(customers, orders);

            return groupedByCustomerId.ToDictionary(x => x.Key, x => x.Count());
        }

        public static Dictionary<int, decimal> OrderSum(List<Customer> customers, List<Order> orders)
        {
            var groupedByCustomerId = GroupByCustomerId(customers, orders);

            return groupedByCustomerId.ToDictionary(customer => customer.Key, orderList => orderList.Sum(order => order.ProductPrice));
        }

        public static Dictionary<int, decimal> MinOrder(List<Customer> customers, List<Order> orders)
        {
            var groupedByCustomerId = GroupByCustomerId(customers, orders);

            return groupedByCustomerId.ToDictionary(customer => customer.Key, orderList => orderList.Min(order => order.ProductPrice));
        }

        public static Dictionary<int, int> CustomerWithMoreThanOneOrder(List<Customer> customers, List<Order> orders)
        {
            var groupedByCustomerId = GroupByCustomerId(customers, orders).Where(x => x.Count() > 1);

            return groupedByCustomerId.ToDictionary(customer => customer.Key, orderList => orderList.Count());
        }

        public static Dictionary<int, decimal> AverageGreaterThanTen(List<Customer> customers, List<Order> orders)
        {
            var groupedByCustomerId = GroupByCustomerId(customers, orders).Where(orderList => orderList.Average(order => order.ProductPrice) > 10);

            return groupedByCustomerId.ToDictionary(customer => customer.Key, orderList => orderList.Average(order => order.ProductPrice));
        }

        private static IEnumerable<IGrouping<int, ReportedItem>> GroupByCustomerId(List<Customer> customers, List<Order> orders)
        {
            return (from i in customers
                    join g in orders
                    on i.CustomerID equals g.CustomerID
                    select new ReportedItem(i.CustomerID, g.ProductPrice))
                    .GroupBy(i => i.CustomerID);
        }
    }

    public struct ReportedItem
    {
        public int CustomerID { get; set; }
        public decimal ProductPrice { get; set; }

        public ReportedItem(int customerId, decimal productPrice)
        {
            CustomerID = customerId;
            ProductPrice = productPrice;
        }
    }
}
