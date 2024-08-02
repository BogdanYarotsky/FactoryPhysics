using System.Collections.ObjectModel;

namespace FactoryPhysics.Lib;

public class ProductionLine : ReadOnlyCollection<Workstation>
{
    public WorkInProcess CriticalWorkInProcess => new(RateOfBottleneck.JobsPerHour * RawProcessTime.Hours);
    public RateOfBottleneck RateOfBottleneck => new(1 / this.Max(w => w.ProcessTimeHours));
    public RawProcessTime RawProcessTime => new(this.Sum(w => w.ProcessTimeHours));
    
    public ProductionLine(params Workstation[] workstations) : base(workstations)
    {
        ArgumentOutOfRangeException.ThrowIfZero(Count);
    }
    
    public Utilization GetUtilization(Throughput throughput) 
        => new(throughput.JobsPerHour / RateOfBottleneck.JobsPerHour);

    public CycleTime GetBestCycleTime(WorkInProcess wip) 
        => wip.Jobs <= CriticalWorkInProcess.Jobs 
            ? new(RawProcessTime.Hours) 
            : new(wip.Jobs / RateOfBottleneck.JobsPerHour);
}