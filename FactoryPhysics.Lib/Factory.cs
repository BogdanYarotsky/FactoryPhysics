namespace FactoryPhysics.Lib;

public static class Factory
{
    public static WorkInProcess GetWorkInProcess(CycleTime ct, Throughput th) 
        => new(ct.Hours * th.JobsPerHour);

    public static RateOfBottleneck GetBottleneckRate(Workstations workstations)
        => new(1 / workstations.Max(w => w.AverageProcessTimeHours));

    public static RawProcessTime GetRawProcessTime(Workstations workstations)
        => new(workstations.Sum(w => w.AverageProcessTimeHours));
    
    public static WorkInProcess GetCriticalWorkInProcess(Workstations workstations) 
        => new(GetBottleneckRate(workstations).JobsPerHour * GetRawProcessTime(workstations).Hours);

    public static Utilization GetUtilization(Throughput th, RateOfBottleneck rb)
        => new(th.JobsPerHour / rb.JobsPerHour);
}