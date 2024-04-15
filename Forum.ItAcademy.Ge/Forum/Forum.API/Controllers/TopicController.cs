using Forum.API.Infrastructure.Models.Topics;
using Forum.Application.Topics.Interfaces;
using Forum.Application.Topics.Requests;
using Forum.Application.Topics.Responses;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Forum.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService _topicService;

        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<List<TopicResponseNewsFeedModel>> GetAll(CancellationToken cancellationToken)
        {
            return await _topicService.GetAllAsync(cancellationToken);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<TopicResponseModel> Get(int id, CancellationToken cancellationToken)
        {
            return await _topicService.GetAsync(id, cancellationToken);
        }

        [HttpPost]
        public async Task Create(TopicRequestPostApiModel apiModel, CancellationToken cancellationToken)
        {
            var topic = apiModel.Adapt<TopicRequestPostModel>();

            var id = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            topic.AuthorId = id;

            await _topicService.CreateAsync(topic, cancellationToken);
        }
    }
}
