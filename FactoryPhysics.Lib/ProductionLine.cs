namespace FactoryPhysics.Lib;

public record ProductionLine
{
    private readonly Workstations _workstations;

    public ProductionLine(Workstations workstations)
    {
        _workstations = workstations;
    }

    public Utilization GetUtilization(WorkInProcess wip, CycleTime ct)
    {
        var th = Factory.GetThroughput(wip, ct);
        var br = Factory.GetBottleneckRate(_workstations);
        return Factory.GetUtilization(th, br);
    }
}