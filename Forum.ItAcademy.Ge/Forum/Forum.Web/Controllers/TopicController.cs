using Forum.Application.Topics.Interfaces;
using Forum.Application.Topics.Requests;
using Forum.Shared.Models.Topics;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Forum.Web.Controllers
{
    public class TopicController : Controller
    {
        private readonly ITopicService _topicService;

        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] TopicRequestPresentationModel topic, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return View();

            var postModel = topic.Adapt<TopicRequestPostModel>();

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            postModel.AuthorId = userId;

            await _topicService.CreateAsync(postModel, cancellationToken);

            return View();
        }
    }
}
