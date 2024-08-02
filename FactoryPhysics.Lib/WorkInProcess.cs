namespace FactoryPhysics.Lib;

public record WorkInProcess
{
    public double Jobs { get; }
    public WorkInProcess(double jobs)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(jobs);
        Jobs = jobs;
    }
    
    public static WorkInProcess Calculate(CycleTime ct, Throughput th)
    {
        ArgumentNullException.ThrowIfNull(ct);
        ArgumentNullException.ThrowIfNull(th);
        return new(ct.Hours * th.JobsPerHour);
    }
}