namespace FactoryPhysics.Lib;

public record ProductionLine
{
    private readonly Workstations _workstations;

    public ProductionLine(Workstations workstations)
    {
        ArgumentNullException.ThrowIfNull(workstations);
        _workstations = workstations;
    }

    public Utilization GetUtilization(WorkInProcess wip, CycleTime ct)
    {
        var rb = Factory.GetBottleneckRate(_workstations);
        var th = Factory.GetThroughput(wip, ct);
        return Factory.GetUtilization(th, rb);
    }
}