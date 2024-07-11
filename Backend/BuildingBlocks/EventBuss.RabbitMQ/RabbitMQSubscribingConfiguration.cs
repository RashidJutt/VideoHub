namespace EventBuss.RabbitMQ;

public class RabbitMQSubscribingConfiguration
{
    public int MaxLocalRetryCount { get; set; } = 3;
}