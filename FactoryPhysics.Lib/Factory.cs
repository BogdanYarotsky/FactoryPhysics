namespace FactoryPhysics.Lib;

public static class Factory
{
    public static WorkInProcess GetWorkInProcess(CycleTime ct, Throughput th) 
        => new(ct.Hours * th.JobsPerHour);

    public static BottleneckRate GetBottleneckRate(Workstations workstations)
        => new(1 / workstations.Max(w => w.CycleTime.Hours));
}