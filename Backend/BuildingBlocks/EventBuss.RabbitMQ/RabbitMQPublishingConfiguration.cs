namespace EventBuss.RabbitMQ;

public class RabbitMQPublishingConfiguration
{
    public int MaxRetryCount { get; set; } = 3;
}