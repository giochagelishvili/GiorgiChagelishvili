namespace Practice
{
    public class Order
    {
        public int OrderID { get; set; }
        public string Date { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int CustomerID { get; set; }

        public Order(int orderID, string date, string productName, decimal productPrice, int customerID)
        {
            OrderID = orderID;
            Date = date;
            ProductName = productName;
            ProductPrice = productPrice;
            CustomerID = customerID;
        }
    }
}
