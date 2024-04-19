namespace Domian.Events;

public interface IDomainEventsDispatcher
{
    Task DispatchDomainEventsAsync();
}
