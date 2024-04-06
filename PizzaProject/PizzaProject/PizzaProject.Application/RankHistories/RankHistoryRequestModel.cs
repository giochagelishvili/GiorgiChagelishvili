namespace PizzaProject.Application.RankHistories
{
    public class RankHistoryRequestModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PizzaId { get; set; }
        public int Rank { get; set; }
    }
}
