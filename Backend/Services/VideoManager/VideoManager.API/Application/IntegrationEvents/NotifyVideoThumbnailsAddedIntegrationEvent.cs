using EventBuss;
using VideoManager.API.Application.DtoModels;

namespace VideoManager.API.Application.IntegrationEvents;

public class NotifyVideoThumbnailsAddedIntegrationEvent : IntegrationEvent<NotifyVideoThumbnailsAddedIntegrationEventTopic>
{
    public Guid VideoId { get; set; }
    public string CreatorId { get; set; } = default!;
    public List<VideoThumbnailDto> Thumbnails { get; set; } = default!;

    public NotifyVideoThumbnailsAddedIntegrationEvent() { }

    public NotifyVideoThumbnailsAddedIntegrationEvent(Guid videoId, string creatorId, List<VideoThumbnailDto> thumbnails)
    {
        VideoId = videoId;
        CreatorId = creatorId;
        Thumbnails = thumbnails;
    }
}

public class NotifyVideoThumbnailsAddedIntegrationEventTopic : IntegrationEventTopic
{
    public override void OnTopicCreating(IServiceProvider services, IIntegrationEventTopicProperties properties)
    {
        properties.TopicName = "VideoManager." + properties.TopicName;
    }
}
