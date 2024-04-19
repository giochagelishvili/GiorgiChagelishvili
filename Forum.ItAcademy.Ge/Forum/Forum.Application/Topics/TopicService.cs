using Forum.Application.Exceptions;
using Forum.Application.Topics.Interfaces;
using Forum.Application.Topics.Requests;
using Forum.Application.Topics.Responses;
using Forum.Domain;
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

        public async Task UpdateStatusAsync(TopicStatusPutModel model, CancellationToken cancellationToken)
        {
            if (!await _topicRepository.Exists(model.Id, cancellationToken))
                throw new TopicNotFoundException();

            if (!Enum.IsDefined(typeof(Status), model.Status))
                throw new InvalidStatusException();

            await _topicRepository.UpdateStatusAsync(model, cancellationToken);
        }

        public async Task UpdateStateAsync(TopicStatePutModel model, CancellationToken cancellationToken)
        {
            if (!await _topicRepository.Exists(model.Id, cancellationToken))
                throw new TopicNotFoundException();

            if (model.State != State.Show && model.State != State.Hide)
                throw new InvalidStateException();

            await _topicRepository.UpdateStateAsync(model, cancellationToken);
        }

        public async Task<TopicResponseAdminModel> GetAdminTopic(int id, CancellationToken cancellationToken)
        {
            var result = await _topicRepository.GetAsync(id, cancellationToken);

            if (result == null)
                throw new TopicNotFoundException();

            return result.Adapt<TopicResponseAdminModel>();
        }

        public async Task<List<TopicResponseAdminFeedModel>> GetAdminTopics(CancellationToken cancellationToken)
        {
            var result = await _topicRepository.GetAllAsync(cancellationToken);

            return result.Adapt<List<TopicResponseAdminFeedModel>>();
        }

        public async Task<List<TopicResponseNewsFeedModel>> GetUserTopics(int userId, CancellationToken cancellationToken)
        {
            var result = await _topicRepository.GetUserTopics(userId, cancellationToken);

            return result.Adapt<List<TopicResponseNewsFeedModel>>();
        }

        public async Task<List<TopicResponseNewsFeedModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _topicRepository.GetAllAsync(cancellationToken);

            return result.Adapt<List<TopicResponseNewsFeedModel>>();
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
