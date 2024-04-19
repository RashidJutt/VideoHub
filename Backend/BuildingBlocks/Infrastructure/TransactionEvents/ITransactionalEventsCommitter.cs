using Domian.TransactionalEvents;

namespace Infrastructure.TransactionEvents;

public interface ITransactionalEventsCommitter
{
    Dictionary<string, List<TransactionalEvent>> ObtainEventGroups();
    void RemoveFromContext(Dictionary<string, List<TransactionalEvent>> eventGroups);
    Task AddToContextAsync(Dictionary<string, List<TransactionalEvent>> eventGroups, TimeSpan? availableDelay = null, CancellationToken cancellationToken = default);
}
