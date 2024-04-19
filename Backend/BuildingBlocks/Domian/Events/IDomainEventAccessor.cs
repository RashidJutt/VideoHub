namespace Domian.Events;

public interface IDomainEventAccessor
{
    IReadOnlyList<IDomainEvent> GetDomainEvents();
    void ClearDomainEvents();
}
