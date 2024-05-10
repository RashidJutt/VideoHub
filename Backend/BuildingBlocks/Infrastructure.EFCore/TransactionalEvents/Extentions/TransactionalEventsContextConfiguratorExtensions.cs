using Infrastructure.TransactionEvents.Extentions;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.EFCore.TransactionalEvents.Extentions;

public static class TransactionalEventsContextConfiguratorExtensions
{

    public static void UseNpgsql(this TransactionalEventsContextConfigurator configurator)
    {
        configurator.Services.Configure<TransactionalEventsContextConfig>(x => {
            x.CommandResolver = new NpgsqlTransactionalEventsCommandResolver();
        });
    }
}