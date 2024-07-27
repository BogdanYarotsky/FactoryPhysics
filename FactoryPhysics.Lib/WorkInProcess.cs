namespace FactoryPhysics.Lib;

public record WorkInProcess
{
    public double Jobs { get; }
    public WorkInProcess(double jobs)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(jobs);
        Jobs = jobs;
    }
}