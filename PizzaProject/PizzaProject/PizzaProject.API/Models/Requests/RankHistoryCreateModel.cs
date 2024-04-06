namespace PizzaProject.API.Models.Requests
{
    public class RankHistoryCreateModel
    {
        public int UserId { get; set; }
        public int PizzaId { get; set; }
        public int Rank { get; set; }
    }
}
