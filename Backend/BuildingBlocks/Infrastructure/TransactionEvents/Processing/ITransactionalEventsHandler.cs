using Domian.TransactionalEvents;

namespace Infrastructure.TransactionEvents.Processing;

public interface ITransactionalEventsHandler
{
    Task ProcessTransactionalEventsAsync(List<TransactionalEvent> events, CancellationToken cancellationToken);
}

