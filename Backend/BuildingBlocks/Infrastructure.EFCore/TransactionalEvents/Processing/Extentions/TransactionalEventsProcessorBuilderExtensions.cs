using Infrastructure.TransactionEvents.Processing;
using Infrastructure.TransactionEvents.Processing.Extentions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Infrastructure.EFCore.TransactionalEvents.Processing.Extentions;

public static class TransactionalEventsProcessorBuilderExtensions
{
    public static ITransactionalEventsProcessorBuilder UseEntityFrameworkCore<TDbContext>(this ITransactionalEventsProcessorBuilder builder)
        where TDbContext : DbContext
    {
        builder.Services.TryAddTransient<ITransactionalEventsProcessor, TransactionalEventsProcessor<TDbContext>>();
        return builder;
    }
}
