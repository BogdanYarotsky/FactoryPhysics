namespace FactoryPhysics.Lib;

public record Congestion
{
    public double AlphaCoefficient { get; }

    public Congestion(double alphaCoefficient)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(alphaCoefficient);
        AlphaCoefficient = alphaCoefficient;
    }

    public bool IsBestCase => AlphaCoefficient == 0.0;
    public bool IsBetterThanPracticalWorstCase => AlphaCoefficient < 1.0;
}