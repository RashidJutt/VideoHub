﻿using EventBuss.Helper.RoutingSlips.Contracts;

namespace EventBuss.Helper.RoutingSlips;

public class RoutingSlipCheckpoint : IRoutingSlipCheckpoint
{
    public string Name { get; set; }
    public string Destination { get; set; }
    public string? PropertiesData { get; set; }

    public RoutingSlipCheckpoint(string name, string destination, string? propertiesData)
    {
        Name = name;
        Destination = destination;
        PropertiesData = propertiesData;
    }
}
