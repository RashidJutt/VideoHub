using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.TransactionEvents.Extentions;

public class TransactionalEventsContextConfigurator
{

    public IServiceCollection Services { get; private set; }

    public TransactionalEventsContextConfigurator(IServiceCollection services)
    {
        Services = services;
    }
}