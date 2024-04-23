using Forum.Application.Topics.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Web.Controllers
{
    public class TopicController : Controller
    {
        private readonly ITopicService _topicService;
        private readonly IConfiguration _config;

        public TopicController(ITopicService topicService, IConfiguration config)
        {
            _topicService = topicService;
            _config = config;
        }

        [HttpGet]
        public async Task<IActionResult> Topics(CancellationToken cancellationToken, int page = 1)
        {
            if (User.IsInRole("Admin"))
                return RedirectToAction("Topics", "Topic", new { area = "Admin" });

            var itemsPerPage = _config.GetValue<int>("Constants:ItemsPerPage");

            var topics = await _topicService.GetAllAsync(page, itemsPerPage, cancellationToken);
            var totalCount = await _topicService.GetTotalCountAsync(cancellationToken);

            ViewBag.CurrentPage = page;
            ViewBag.TotalCount = totalCount;
            ViewBag.ItemsPerPage = itemsPerPage;

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
