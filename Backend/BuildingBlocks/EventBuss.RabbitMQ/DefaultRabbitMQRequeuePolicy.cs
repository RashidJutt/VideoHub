﻿using SharedKernel.Exceptions;

namespace EventBuss.RabbitMQ;

/// <summary>
/// This policy handles transient errors.
/// </summary>
public class DefaultRabbitMQRequeuePolicy : IRabbitMQRequeuePolicy
{
    public bool ShouldRequeue(Exception exception)
    {
        return exception.Identify(ExceptionCategories.Transient);
    }
}