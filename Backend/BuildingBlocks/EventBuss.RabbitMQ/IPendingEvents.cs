namespace EventBuss.RabbitMQ;

public interface IPendingEvents
{
    ValueTask<IPendingEvent> PollPendingEvent(CancellationToken cancellationToken);
}