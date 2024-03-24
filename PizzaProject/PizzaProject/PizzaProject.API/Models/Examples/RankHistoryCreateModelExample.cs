using PizzaProject.API.Models.Requests;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaProject.API.Models.Examples
{
    public class RankHistoryCreateModelExample : IExamplesProvider<RankHistoryCreateModel>
    {
        public RankHistoryCreateModel GetExamples()
        {
            return new RankHistoryCreateModel
            {
                UserId = 3,
                PizzaId = 1,
                Rank = 9
            };
        }
    }
}
