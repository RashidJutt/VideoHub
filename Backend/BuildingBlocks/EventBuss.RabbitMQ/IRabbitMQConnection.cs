using RabbitMQ.Client;

namespace EventBuss.RabbitMQ;

public interface IRabbitMQConnection
{
    bool IsConnected { get; }
    bool IsConnecting { get; }

    IConnection GetConnection();
    Task Connect(CancellationToken stoppingToken, out CancellationToken connectionAborted);
    void Stop();
}