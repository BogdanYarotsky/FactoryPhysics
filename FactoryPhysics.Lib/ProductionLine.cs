using System.Collections.ObjectModel;

namespace FactoryPhysics.Lib;

public class ActiveProductionLine(WorkInProcess workInProcess, params Workstation[] workstations)
    : ProductionLine(workstations)
{
    public WorkInProcess WorkInProcess { get; } = workInProcess;

    public CycleTime BestCaseCycleTime =>
        WorkInProcess.Jobs <= CriticalWorkInProcess.Jobs
            ? new(RawProcessTime.Hours)
            : new(WorkInProcess.Jobs / RateOfBottleneck.JobsPerHour);

    public Throughput BestCaseThroughput => 
        WorkInProcess.Jobs <= CriticalWorkInProcess.Jobs
            ? new(WorkInProcess.Jobs / RawProcessTime.Hours)
            : new(RateOfBottleneck.JobsPerHour);

    public CycleTime WorstCaseCycleTime => new(WorkInProcess.Jobs * RawProcessTime.Hours);
    
    public CycleTime PracticalWorstCaseCycleTime => 
        new(RawProcessTime.Hours + (WorkInProcess.Jobs - 1) / RateOfBottleneck.JobsPerHour);

    public Throughput PracticalWorstCaseThroughput => 
        new(WorkInProcess.Jobs / (CriticalWorkInProcess.Jobs + WorkInProcess.Jobs - 1) 
            * RateOfBottleneck.JobsPerHour);
    
    public Utilization GetUtilization(CycleTime ct) 
        => new(Throughput.Calculate(WorkInProcess, ct).JobsPerHour / RateOfBottleneck.JobsPerHour);
    
    public bool IsGoodLine(CycleTime ct)
    {
        var pwc = GetPracticalWorstCaseCycleTime(wip);
        return pwc.Hours <= ct.Hours;
    }
}

public class ProductionLine : ReadOnlyCollection<Workstation>
{
    public WorkInProcess CriticalWorkInProcess => new(RateOfBottleneck.JobsPerHour * RawProcessTime.Hours);
    public RateOfBottleneck RateOfBottleneck => new(1 / this.Max(w => w.AverageProcessTimeHours));
    public RawProcessTime RawProcessTime => new(this.Sum(w => w.AverageProcessTimeHours));
    public ProductionLine(params Workstation[] workstations) : base(workstations)
    {
        ArgumentOutOfRangeException.ThrowIfZero(workstations.Length);
    }
}