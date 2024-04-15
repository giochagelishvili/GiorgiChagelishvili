﻿using Forum.Application.Comments.Interfaces;
using Forum.Application.Comments.Requests;
using Forum.Shared.Localizations;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Forum.Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<IActionResult> Create([FromForm] CommentRequestPostModel comment, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = ErrorMessages.CommentBodyRequired;
                return RedirectToAction("Topic", "Topic", new { id = comment.TopicId });
            }

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            comment.AuthorId = userId;

            await _commentService.CreateAsync(comment, cancellationToken);

            return RedirectToAction("Topic", "Topic", new { id = comment.TopicId });
        }

        public async Task<IActionResult> Delete(int commentId, int topicId, CancellationToken cancellationToken)
        {
            var authorId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            await _commentService.DeleteAsync(commentId, authorId, cancellationToken);

            return RedirectToAction("Topic", "Topic", new { id = topicId });
        }
    }
}
