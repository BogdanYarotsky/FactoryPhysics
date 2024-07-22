namespace FactoryPhysics.Lib;

public record Throughput
{
    public double JobsPerHour { get; }
    public Throughput(double jobsPerHour)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(jobsPerHour);
        JobsPerHour = jobsPerHour;
    }

    public static Throughput From(WorkInProcess wip, CycleTime ct) 
        => new(wip.Jobs / ct.Hours);
}