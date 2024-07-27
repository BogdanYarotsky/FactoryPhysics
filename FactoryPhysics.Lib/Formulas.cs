namespace FactoryPhysics.Lib;

public static class Formulas
{
    public static WorkInProcess GetWorkInProcess(CycleTime ct, Throughput th) 
        => new(ct.Hours * th.JobsPerHour);
    
    public static Throughput GetThroughput(WorkInProcess wip, CycleTime ct) 
        => new(wip.Jobs / ct.Hours);

    public static RateOfBottleneck GetBottleneckRate(Workstations workstations)
        => new(1 / workstations.Max(w => w.ProcessTimeHours));

    public static RawProcessTime GetRawProcessTime(Workstations workstations)
        => new(workstations.Sum(w => w.ProcessTimeHours));
    
    public static WorkInProcess GetCriticalWorkInProcess(Workstations workstations) 
        => new(GetBottleneckRate(workstations).JobsPerHour * GetRawProcessTime(workstations).Hours);

    public static Utilization GetUtilization(Throughput th, RateOfBottleneck rb)
    {
        if (th.JobsPerHour > rb.JobsPerHour)
            throw new ArgumentException("throughput can't be better than rate of bottleneck");
        
        return new(th.JobsPerHour / rb.JobsPerHour);
    }
}