using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactoryPhysics.Lib.Tests
{
    [TestClass]
    public class UtilizationTest
    {
        [TestMethod]
        public void CriticalWIP_Yields_Maximum_Utilization()
        {
            var productionLine = new ProductionLine([
                new(2), // 2 hours process time
                new(3), // 3 hours process time
                new(1)  // 1 hour process time
            ]);

            var criticalWip = productionLine.CriticalWorkInProcess;
            var rawProcessTime = productionLine.RawProcessTime;
            var bestThroughput = Throughput.Calculate(criticalWip, new(rawProcessTime.Hours));

            var utilization = productionLine.GetUtilization(bestThroughput);
            
            Assert.AreEqual(1.0, utilization.CapacityFraction);
        }
    }
}