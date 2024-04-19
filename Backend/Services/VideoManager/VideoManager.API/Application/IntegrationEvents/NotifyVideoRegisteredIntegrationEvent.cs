using Domian.Events;
using EventBuss;
using VideoManager.Domain.Models;

namespace VideoManager.API.Application.IntegrationEvents;

public class NotifyVideoRegisteredIntegrationEvent : IntegrationEvent<NotifyVideoRegisteredIntegrationEventTopic>
{
    public Guid VideoId { get; set; }
    public string CreatorId { get; set; } = default!;

    public NotifyVideoRegisteredIntegrationEvent() { }

    public NotifyVideoRegisteredIntegrationEvent(Guid videoId, string creatorId)
    {
        VideoId = videoId;
        CreatorId = creatorId;
    }
}

public class NotifyVideoRegisteredIntegrationEventTopic : IntegrationEventTopic
{
    public override void OnTopicCreating(IServiceProvider services, IIntegrationEventTopicProperties properties)
    {
        properties.TopicName = "VideoManager." + properties.TopicName;
    }
}
