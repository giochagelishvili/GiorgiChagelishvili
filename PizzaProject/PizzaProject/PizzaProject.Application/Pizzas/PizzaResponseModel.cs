namespace PizzaProject.Application.Pizzas
{
    public class PizzaResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int CaloryCount { get; set; }
    }
}
