using Forum.Application.Topics.Interfaces;
using Forum.Application.Topics.Requests;
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

        [HttpGet("topic/{id}")]
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

            return RedirectToAction("Index", "Home");
        }
    }
}
