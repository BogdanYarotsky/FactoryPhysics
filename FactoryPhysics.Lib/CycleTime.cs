namespace FactoryPhysics.Lib;

public record CycleTime
{
    public double Hours { get; }
    public CycleTime(double hours)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(hours);
        Hours = hours;
    }
    
    public static CycleTime From(WorkInProcess wip, Throughput th) 
        => new(wip.Jobs / th.JobsPerHour);
}