namespace FactoryPhysics.Lib;

public record Workstation
{
    public double ProcessTimeHours { get; }

    public Workstation(double processTimeHours)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(processTimeHours);
        ProcessTimeHours = processTimeHours;
    }
}