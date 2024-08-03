namespace FactoryPhysics.Lib;

public record Workstation
{
    public double AverageProcessTimeHours { get; }

    public Workstation(double averageProcessTimeHours)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(averageProcessTimeHours);
        AverageProcessTimeHours = averageProcessTimeHours;
    }
}