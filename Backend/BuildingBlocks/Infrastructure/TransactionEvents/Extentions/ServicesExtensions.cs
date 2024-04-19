using Infrastructure.TransactionEvents.Processing;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.TransactionEvents.Extentions;

public static class ServicesExtensions
{
    public static ITransactionalEventsProcessorBuilder AddTransactionalEventsProcessingService(this IServiceCollection services, Action<TransactionalEventsProcessorConfiguration>? options = null)
    {
        services.AddHostedService<TransactionalEventsProcessingService>();

        if (options != null)
        {
            services.Configure(options);
        }

        var builder = new TransactionalEventsProcessorBuilder(services);
        return builder;
    }
}

