﻿using Domian.TransactionalEvents.Contracts;
using EventBuss.Helper.RoutingSlips.Contracts;
using Domian.TransactionalEvents.Outbox;
using EventBuss.RabbitMQ;
namespace EventBuss.Helper.RoutingSlips.Extentions;

public static class TransactionalEventsContextExtensions
{

    public static void AddRoutingSlip(this ITransactionalEventsContext context, Action<IRoutingSlipBuilder> configure, Action<IIntegrationEventProperties>? propertiesConfigurator = null)
    {
        AddRoutingSlip(context, null, configure, propertiesConfigurator);
    }

    public static void AddRoutingSlip(this ITransactionalEventsContext context, string? groupId, Action<IRoutingSlipBuilder> configure, Action<IIntegrationEventProperties>? propertiesConfigurator = null)
    {
        var builder = new RoutingSlipBuilder(Guid.NewGuid());
        configure.Invoke(builder);

        var routingSlip = builder.Build();

        var firstCheckpoint = routingSlip.Checkpoints.FirstOrDefault();
        if (firstCheckpoint == null)
        {
            throw new ArgumentException("No checkpoint is added");
        }

        var routingSlipEvent = new RoutingSlipEvent(RoutingSlipEventType.Proceed, 0, routingSlip);

        context.AddOutboxMessage(groupId, routingSlipEvent, (properties) => {
            if (propertiesConfigurator != null)
            {
                propertiesConfigurator.Invoke(properties);
            }

            if (properties is RabbitMQIntegrationEventProperties rmq)
            {
                rmq.SkipExchange = true;
                rmq.RoutingKey = firstCheckpoint.Destination;
            }
        });
    }

}