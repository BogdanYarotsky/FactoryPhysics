namespace FactoryPhysics.Lib;

public record CycleTime
{
    public double Hours { get; }
    public CycleTime(double hours)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(hours);
        Hours = hours;
    }
}