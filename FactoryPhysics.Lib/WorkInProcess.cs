namespace FactoryPhysics.Lib;

public record WorkInProcess
{
    public double Jobs { get; }
    public WorkInProcess(double jobs)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(jobs);
        Jobs = jobs;
    }
    
    public static WorkInProcess From(CycleTime ct, Throughput th) 
        => new(ct.Hours * th.JobsPerHour);
}