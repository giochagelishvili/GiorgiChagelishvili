using Forum.Application.Topics.Interfaces;
using Forum.Application.Topics.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
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
            var topics = await _topicService.GetAdminTopics(cancellationToken);

            return View(topics);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var topic = await _topicService.GetAdminTopic(id, cancellationToken);

            return View(topic);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateState([FromForm] TopicStatePutModel model, CancellationToken cancellationToken)
        {
            await _topicService.UpdateStateAsync(model, cancellationToken);

            return RedirectToAction(nameof(Edit), new { id = model.Id });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus([FromForm] TopicStatusPutModel model, CancellationToken cancellationToken)
        {
            await _topicService.UpdateStatusAsync(model, cancellationToken);

            return RedirectToAction(nameof(Edit), new { id = model.Id });
        }
    }
}
