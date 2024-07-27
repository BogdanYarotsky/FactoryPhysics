﻿namespace FactoryPhysics.Lib;

public record Throughput
{
    public double JobsPerHour { get; }
    public Throughput(double jobsPerHour)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(jobsPerHour);
        JobsPerHour = jobsPerHour;
    }
}