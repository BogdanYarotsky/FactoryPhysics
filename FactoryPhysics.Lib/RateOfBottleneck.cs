namespace FactoryPhysics.Lib;

public record RateOfBottleneck
{
    public double JobsPerHour { get; }
    
    public RateOfBottleneck(double jobsPerHour)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(jobsPerHour);
        JobsPerHour = jobsPerHour;
    }
}