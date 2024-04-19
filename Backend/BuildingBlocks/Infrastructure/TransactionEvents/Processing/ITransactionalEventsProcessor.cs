namespace Infrastructure.TransactionEvents.Processing;

public interface ITransactionalEventsProcessor
{
    Task ProcessTransactionalEvents(CancellationToken cancellationToken = default);
}

