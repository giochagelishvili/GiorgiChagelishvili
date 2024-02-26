namespace PizzaProject.Domain.Entity
{
    public class RankHistory
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PizzaId { get; set; }
        public int Rank { get; set; }
    }
}
