using Infrastructure.TransactionEvents.Processing;
using Microsoft.EntityFrameworkCore;

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
