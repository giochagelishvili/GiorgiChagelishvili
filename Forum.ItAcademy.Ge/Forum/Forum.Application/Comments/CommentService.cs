using Forum.Application.Comments.Interfaces;
using Forum.Application.Comments.Requests;
using Forum.Application.Exceptions;
using Forum.Application.Topics.Interfaces;
using Forum.Domain.Comments;
using Mapster;

namespace Forum.Application.Comments
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly ITopicRepository _topicRepository;

        public CommentService(ICommentRepository commentRepository, ITopicRepository topicRepository)
        {
            _commentRepository = commentRepository;
            _topicRepository = topicRepository;
        }

        public async Task CreateAsync(CommentRequestPostModel comment, CancellationToken cancellationToken)
        {
            if (!await _topicRepository.Exists(comment.TopicId, cancellationToken))
                throw new TopicNotFoundException();

            var entity = comment.Adapt<Comment>();

            await _commentRepository.CreateAsync(entity, cancellationToken);
        }

        public async Task DeleteAsync(int commentId, int authorId, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetAsync(commentId, cancellationToken);

            if (comment == null || comment.AuthorId != authorId)
                throw new CommentNotFoundException();

            await _commentRepository.DeleteAsync(commentId, cancellationToken);
        }
    }
}
