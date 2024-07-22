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