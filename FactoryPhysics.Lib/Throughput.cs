namespace FactoryPhysics.Lib;

public record Throughput
{
    public double JobsPerHour { get; }
    public Throughput(double jobsPerHour)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(jobsPerHour);
        JobsPerHour = jobsPerHour;
    }

    public static Throughput Calculate(WorkInProcess wip, CycleTime ct)
    {
        ArgumentNullException.ThrowIfNull(wip);
        ArgumentNullException.ThrowIfNull(ct);
        return new(wip.Jobs / ct.Hours);
    }
}