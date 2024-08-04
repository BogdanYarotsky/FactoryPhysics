namespace FactoryPhysics.Lib;

public class ProductionLine
{
    public Workstation[] Workstations { get; }
    public WorkInProcess CriticalWorkInProcess => new(RateOfBottleneck.JobsPerHour * RawProcessTime.Hours);
    public RateOfBottleneck RateOfBottleneck => new(1 / Workstations.Max(w => w.AverageProcessTimeHours));
    public RawProcessTime RawProcessTime => new(Workstations.Sum(w => w.AverageProcessTimeHours));
    
    public ProductionLine(params Workstation[] workstations)
    {
        Workstations = workstations ?? throw new ArgumentNullException(nameof(workstations));
        ArgumentOutOfRangeException.ThrowIfZero(workstations.Length);
    }

    public LoadedProductionLine WithWorkInProcess(WorkInProcess w) => new(this, w);
}