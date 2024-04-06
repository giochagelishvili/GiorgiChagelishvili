using Mapster;
using Microsoft.AspNetCore.Mvc;
using PizzaProject.API.Models.Requests;
using PizzaProject.Application.RankHistories;

namespace PizzaProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankHistoryController : ControllerBase
    {
        private readonly IRankHistoryService _rankHistoryService;

        public RankHistoryController(IRankHistoryService rankHistoryService)
        {
            _rankHistoryService = rankHistoryService;
        }

        /// <summary>
        /// Get all rank history
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<RankHistoryResponseModel>> Get(CancellationToken cancellationToken)
        {
            return await _rankHistoryService.GetAll(cancellationToken);
        }

        /// <summary>
        /// Get rank using ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<RankHistoryResponseModel> Get(int id, CancellationToken cancellationToken)
        {
            return await _rankHistoryService.Get(id, cancellationToken);
        }

        /// <summary>
        /// Create rank history
        /// </summary>
        /// <param name="rankHistory"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Post(RankHistoryCreateModel rankHistory, CancellationToken cancellationToken)
        {
            var requestModel = rankHistory.Adapt<RankHistoryRequestModel>();

            await _rankHistoryService.Create(requestModel, cancellationToken);
        }
    }
}
