namespace PizzaProject.API.Models.Requests
{
    public class PizzaCreateModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int CaloryCount { get; set; }
    }
}
