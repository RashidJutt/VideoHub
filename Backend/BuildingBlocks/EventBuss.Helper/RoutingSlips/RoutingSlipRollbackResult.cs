using Domian.Contracts;
using Domian.TransactionalEvents.Contracts;
using EventBuss.Helper.RoutingSlips.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Domian.TransactionalEvents.Outbox;
using EventBuss.RabbitMQ;
namespace EventBuss.Helper.RoutingSlips;

public class RoutingSlipRollbackResult : IRoutingSlipRollbackResult
{

    private readonly RoutingSlip _routingSlip;
    private readonly int _nextCheckpointIndex;
    private readonly Action<IIntegrationEventProperties>? _configureEvent;

    public RoutingSlipRollbackResult(RoutingSlip routingSlip, int nextCheckpointIndex, Action<IIntegrationEventProperties>? configureEvent)
    {
        _routingSlip = routingSlip;
        _nextCheckpointIndex = nextCheckpointIndex;
        _configureEvent = configureEvent;
    }

    public async Task ExecuteAsync(IServiceProvider serviceProvider, IIncomingIntegrationEventProperties eventProperties, IIncomingIntegrationEventContext eventContext, CancellationToken cancellationToken = default)
    {
        var nextCheckpoint =
            _nextCheckpointIndex >= 0 ?
                _routingSlip.Checkpoints[_nextCheckpointIndex] :
                _routingSlip.RollbackDestination!;

        var transactionalEventContext = serviceProvider.GetRequiredService<ITransactionalEventsContext>();
        var unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();

        var @event = new RoutingSlipEvent(RoutingSlipEventType.Rollback, _nextCheckpointIndex, _routingSlip);

        transactionalEventContext.AddOutboxMessage(@event, (properties) =>
        {
            _configureEvent?.Invoke(properties);

            if (properties is RabbitMQIntegrationEventProperties rmq)
            {
                rmq.SkipExchange = true;
                rmq.RoutingKey = nextCheckpoint.Destination;
            }
        });

        await unitOfWork.CommitAsync(cancellationToken);
    }

}
