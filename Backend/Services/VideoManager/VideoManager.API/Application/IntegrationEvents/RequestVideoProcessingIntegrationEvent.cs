using EventBuss;

namespace VideoManager.API.Application.IntegrationEvents;

public class RequestVideoProcessingIntegrationEvent : IntegrationEvent<RequestVideoProcessingIntegrationEventTopic>
{
    public Guid VideoId { get; set; }
    public string CreatorId { get; set; } = default!;
    public string OriginalFileName { get; set; } = default!;
    public string VideoFileUrl { get; set; } = default!;

    public RequestVideoProcessingIntegrationEvent() { }

    public RequestVideoProcessingIntegrationEvent(Guid videoId, string creatorId, string originalFileName, string videoFileUrl)
    {
        VideoId = videoId;
        CreatorId = creatorId;
        OriginalFileName = originalFileName;
        VideoFileUrl = videoFileUrl;
    }
}

public class RequestVideoProcessingIntegrationEventTopic : IntegrationEventTopic
{
    public override void OnTopicCreating(IServiceProvider services, IIntegrationEventTopicProperties properties)
    {
        properties.TopicName = "VideoManager." + properties.TopicName;
    }
}