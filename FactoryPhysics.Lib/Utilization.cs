namespace FactoryPhysics.Lib;

public record Utilization
{
    public double CapacityFraction { get; }

    public Utilization(double capacityFraction)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(capacityFraction);
        CapacityFraction = capacityFraction;
    }
}