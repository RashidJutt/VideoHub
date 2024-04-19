﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Processors;
public class RateLimitedRequestProcessorOptions
{
    public int MaxConcurrentProcessingLimit { get; set; } = 4;
    public float MaxProcessingRateLimit { get; set; } = 50;
}

