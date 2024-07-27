namespace FactoryPhysics.Lib;

public record BottleneckRate
{
    public double JobsPerHour { get; }
    
    public BottleneckRate(double jobsPerHour)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(jobsPerHour);
        JobsPerHour = jobsPerHour;
    }
}