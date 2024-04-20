using Forum.Application.Topics.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Web.Controllers
{
    public class TopicController : Controller
    {
        private readonly ITopicService _topicService;

        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        [HttpGet]
        public async Task<IActionResult> Topics(CancellationToken cancellationToken)
        {
            if (User.IsInRole("Admin"))
                return RedirectToAction("Topics", "Topic", new { area = "Admin" });

            var topics = await _topicService.GetAllAsync(cancellationToken);

            return View(topics);
        }

        [HttpGet]
        public async Task<IActionResult> UserTopics(int id, CancellationToken cancellationToken)
        {
            var result = await _topicService.GetUserTopics(id, cancellationToken);

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
    }
}
