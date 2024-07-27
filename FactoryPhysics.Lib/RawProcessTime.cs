namespace FactoryPhysics.Lib;

public record RawProcessTime
{
    public double Hours { get; }

    public RawProcessTime(double hours)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(hours);
        Hours = hours;
    }
}