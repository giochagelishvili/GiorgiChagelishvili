using Forum.Application.Topics.Interfaces;
using Forum.Shared.Localizations;
using Forum.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace DemoProject.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITopicService _topicService;

        public HomeController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            if (User.IsInRole("Admin"))
                return RedirectToAction("Topics", "Topic", new { area = "Admin" });

            var topics = await _topicService.GetAllAsync(cancellationToken);

            return View(topics);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var model = new ErrorViewModel();
            var errorMessage = Encoding.UTF8.GetString(HttpContext.Session.Get("ErrorMessage"));

            if (errorMessage != null)
                model.ErrorMessage = errorMessage;
            else
                model.ErrorMessage = ErrorMessages.UnhandledErrorOccurred;

            return View(model);
        }
    }
}