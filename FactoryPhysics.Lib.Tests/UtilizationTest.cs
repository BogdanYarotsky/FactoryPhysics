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

            var timeMeasuredProductionLine = new TimeMeasuredProductionLine(
                new(productionLine, criticalWip), new(rawProcessTime.Hours));
            
            Assert.AreEqual(1.0, timeMeasuredProductionLine.Utilization.CapacityFraction);
        }
    }
}