using EventBuss.Helper.RoutingSlips.Contracts;

namespace EventBuss.Helper.RoutingSlips;

public class RoutingSlipRollbackCompleteResult : IRoutingSlipRollbackResult
{
    public Task ExecuteAsync(IServiceProvider serviceProvider, IIncomingIntegrationEventProperties eventProperties, IIncomingIntegrationEventContext eventContext, CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }
}