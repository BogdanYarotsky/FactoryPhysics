namespace FactoryPhysics.Lib;

public class LoadedProductionLine
{
    public ProductionLine ProductionLine { get; }
    public WorkInProcess WorkInProcess { get; }

    public CycleTime BestCaseCycleTime =>
        WorkInProcess.Jobs <= ProductionLine.CriticalWorkInProcess.Jobs
            ? new(ProductionLine.RawProcessTime.Hours)
            : new(WorkInProcess.Jobs / ProductionLine.RateOfBottleneck.JobsPerHour);

    public Throughput BestCaseThroughput => 
        WorkInProcess.Jobs <= ProductionLine.CriticalWorkInProcess.Jobs
            ? new(WorkInProcess.Jobs / ProductionLine.RawProcessTime.Hours)
            : new(ProductionLine.RateOfBottleneck.JobsPerHour);

    public CycleTime WorstCaseCycleTime => 
        new(WorkInProcess.Jobs * ProductionLine.RawProcessTime.Hours);
    
    public CycleTime PracticalWorstCaseCycleTime => 
        new(ProductionLine.RawProcessTime.Hours + (WorkInProcess.Jobs - 1) 
            / ProductionLine.RateOfBottleneck.JobsPerHour);

    public Throughput PracticalWorstCaseThroughput => 
        new(WorkInProcess.Jobs / (ProductionLine.CriticalWorkInProcess.Jobs + WorkInProcess.Jobs - 1) 
            * ProductionLine.RateOfBottleneck.JobsPerHour);
    
    public LoadedProductionLine(ProductionLine productionLine, WorkInProcess workInProcess)
    {
        ProductionLine = productionLine ?? throw new ArgumentNullException(nameof(productionLine));
        WorkInProcess = workInProcess ?? throw new ArgumentNullException(nameof(workInProcess));
    }

    public TimeMeasuredProductionLine WithCycleTime(CycleTime ct) => new(this, ct);
}