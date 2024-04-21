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
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService _topicService;

        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("admin/updatestatus")]
        public async Task UpdateStatus(TopicStatusPutModel status, CancellationToken cancellationToken)
        {
            await _topicService.UpdateStatusAsync(status, cancellationToken);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("admin/updatestate")]
        public async Task UpdateState(TopicStatePutModel state, CancellationToken cancellationToken)
        {
            await _topicService.UpdateStateAsync(state, cancellationToken);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin/topics")]
        public async Task<List<TopicResponseAdminFeedModel>> GetAdminTopics(CancellationToken cancellationToken)
        {
            return await _topicService.GetAdminTopics(cancellationToken);
        }

        [HttpGet("user/{userId}")]
        public async Task<List<TopicResponseNewsFeedModel>> GetUserTopics(int userId, CancellationToken cancellationToken)
        {
            return await _topicService.GetUserTopics(userId, cancellationToken);
        }

        [HttpGet]
        public async Task<List<TopicResponseNewsFeedModel>> GetAll(CancellationToken cancellationToken)
        {
            return await _topicService.GetAllAsync(cancellationToken);
        }

        [HttpGet("{id}")]
        public async Task<TopicResponseModel> Get(int id, CancellationToken cancellationToken)
        {
            return await _topicService.GetAsync(id, cancellationToken);
        }

        [Authorize(Roles = "Member")]
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
