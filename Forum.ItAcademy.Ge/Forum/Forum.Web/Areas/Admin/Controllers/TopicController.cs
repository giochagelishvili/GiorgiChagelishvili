using Forum.Application.Topics;
using Forum.Application.Topics.Interfaces;
using Forum.Application.Topics.Interfaces.Services;
using Forum.Application.Topics.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TopicController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IAdminTopicService _adminTopicService;

        public TopicController(IConfiguration config, IAdminTopicService adminTopicService)
        {
            _config = config;
            _adminTopicService = adminTopicService;
        }

        [HttpGet]
        public async Task<IActionResult> Topics(CancellationToken cancellationToken, int page = 1)
        {
            var itemsPerPage = _config.GetValue<int>("Constants:ItemsPerPage");

            var topics = await _adminTopicService.GetAllTopicsAsync(page, itemsPerPage, cancellationToken);
            var totalCount = await _adminTopicService.GetTopicsCountAsync(cancellationToken);

            ViewBag.CurrentPage = page;
            ViewBag.TotalCount = totalCount;
            ViewBag.ItemsPerPage = itemsPerPage;

            return View(topics);
        }

        [HttpGet]
        public async Task<IActionResult> Archive(CancellationToken cancellationToken, int page = 1)
        {
            var itemsPerPage = _config.GetValue<int>("Constants:ItemsPerPage");

            var topics = await _adminTopicService.GetAllArchivedTopicsAsync(page, itemsPerPage, cancellationToken);
            var totalCount = await _adminTopicService.GetArchivedTopicsCountAsync(cancellationToken: cancellationToken);

            ViewBag.CurrentPage = page;
            ViewBag.TotalCount = totalCount;
            ViewBag.ItemsPerPage = itemsPerPage;

            return View(topics);
        }

        [HttpGet]
        public async Task<IActionResult> UserTopics(int userId, CancellationToken cancellationToken, int page = 1)
        {
            var itemsPerPage = _config.GetValue<int>("Constants:ItemsPerPage");

            var topics = await _adminTopicService.GetAllUserTopicsAsync(userId, page, itemsPerPage, cancellationToken);
            var totalCount = await _adminTopicService.GetUserTopicsCountAsync(userId, cancellationToken);

            ViewBag.CurrentPage = page;
            ViewBag.TotalCount = totalCount;
            ViewBag.ItemsPerPage = itemsPerPage;
            ViewBag.UserId = userId;

            return View(topics);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var topic = await _adminTopicService.GetTopicAsync(id, cancellationToken);

            return View(topic);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateState([FromForm] TopicStatePutModel model, CancellationToken cancellationToken)
        {
            await _adminTopicService.UpdateStateAsync(model, cancellationToken);

            return RedirectToAction(nameof(Edit), new { id = model.Id });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus([FromForm] TopicStatusPutModel model, CancellationToken cancellationToken)
        {
            await _adminTopicService.UpdateStatusAsync(model, cancellationToken);

            return RedirectToAction(nameof(Edit), new { id = model.Id });
        }
    }
}
