namespace FactoryPhysics.Lib;

public record ProductionLine
{
    private readonly Workstations _workstations;

    public ProductionLine(Workstations workstations)
    {
        ArgumentNullException.ThrowIfNull(workstations);
        ArgumentOutOfRangeException.ThrowIfZero(workstations.Count);
        _workstations = workstations;
    }

    public Utilization GetUtilization(WorkInProcess wip, CycleTime ct)
    {
        var th = Formulas.GetThroughput(wip, ct);
        var rb = Formulas.GetBottleneckRate(_workstations);
        return Formulas.GetUtilization(th, rb);
    }
}