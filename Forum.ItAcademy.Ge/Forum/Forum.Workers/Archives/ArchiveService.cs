using Forum.Application.Topics.Interfaces;
using Forum.Application.Topics.Requests;
using Forum.Application.Topics.Responses;
using Forum.Domain;

namespace Forum.Workers.Archives
{
    public class ArchiveService
    {
        private readonly ITopicServiceOld _topicService;

        public ArchiveService(ITopicServiceOld topicService)
        {
            _topicService = topicService;
        }

        public async Task<List<TopicResponseWorkerModel>> GetTopicWorkerAsync(CancellationToken cancellationToken)
        {
            return await _topicService.GetTopicWorkerAsync(cancellationToken);
        }

        public async Task UpdateStatusAsync(int topicId, CancellationToken cancellationToken)
        {
            var updateModel = new TopicStatusPutModel
            {
                Id = topicId,
                Status = Status.Inactive
            };

            await _topicService.UpdateStatusAsync(updateModel, cancellationToken);
        }
    }
}
