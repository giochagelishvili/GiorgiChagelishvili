using Forum.Application.Exceptions;
using Forum.Application.Topics.Interfaces;
using Forum.Application.Topics.Requests;
using Forum.Application.Topics.Responses;
using Forum.Domain.Topics;
using Mapster;

namespace Forum.Application.Topics
{
    public class TopicService : ITopicService
    {
        private readonly ITopicRepository _topicRepository;

        public TopicService(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public async Task<List<TopicResponseModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _topicRepository.GetAllAsync(cancellationToken);

            if (result == null)
                throw new TopicNotFoundException();

            return result.Adapt<List<TopicResponseModel>>();
        }

        public async Task<TopicResponseModel> GetAsync(int id, CancellationToken cancellationToken)
        {
            var result = await _topicRepository.GetAsync(id, cancellationToken);

            if (result == null)
                throw new TopicNotFoundException();

            return result.Adapt<TopicResponseModel>();
        }

        public async Task CreateAsync(TopicRequestPostModel topic, CancellationToken cancellationToken)
        {
            var entity = topic.Adapt<Topic>();

            await _topicRepository.CreateAsync(entity, cancellationToken);
        }
    }
}
