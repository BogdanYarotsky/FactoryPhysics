namespace FactoryPhysics.Lib;

public class TimeMeasuredProductionLine
{
    public LoadedProductionLine FinishedWorkCycle { get; }
    public CycleTime ActualCycleTime { get; }
    public Throughput Throughput 
        => Throughput.Calculate(FinishedWorkCycle.WorkInProcess, ActualCycleTime);
    public Utilization Utilization 
        => new(Throughput.JobsPerHour / FinishedWorkCycle.ProductionLine.RateOfBottleneck.JobsPerHour);

    public bool RequiresImprovement 
        => FinishedWorkCycle.PracticalWorstCaseCycleTime.Hours <= ActualCycleTime.Hours;

    public TimeMeasuredProductionLine(LoadedProductionLine finishedWorkCycle, CycleTime cycleTime)
    {
        FinishedWorkCycle = finishedWorkCycle ?? throw new ArgumentNullException(nameof(finishedWorkCycle));
        ActualCycleTime = cycleTime ?? throw new ArgumentNullException(nameof(cycleTime));
    }
}