using Forum.Application.Topics.Interfaces;
using Forum.Application.Topics.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Forum.Web.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "Member")]
    public class TopicController : Controller
    {
        private readonly ITopicService _topicService;

        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        [HttpGet("topics/user/{userId}")]
        public async Task<IActionResult> UserTopics(int userId, CancellationToken cancellationToken)
        {
            var result = await _topicService.GetUserTopics(userId, cancellationToken);

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Topic(int id, CancellationToken cancellationToken)
        {
            if (TempData.ContainsKey("Error"))
                ViewBag.Error = TempData["Error"];

            var topic = await _topicService.GetAsync(id, cancellationToken);

            return View(topic);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] TopicRequestPostModel topic, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return View();

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            topic.AuthorId = userId;

            await _topicService.CreateAsync(topic, cancellationToken);

            return RedirectToAction("Topics", "Topic", new { area = "" });
        }
    }
}
