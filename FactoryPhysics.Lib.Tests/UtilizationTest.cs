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

            Assert.AreEqual(1.0, productionLine
                .WithWorkInProcess(productionLine.CriticalWorkInProcess)
                .WithCycleTime(new(productionLine.RawProcessTime.Hours))
                .Utilization.CapacityFraction);
        }
        
        [TestMethod]
        public void CriticalWIP_Yields_Best_Congestion()
        {
            var productionLine = new ProductionLine([
                new(2), // 2 hours process time
                new(3), // 3 hours process time
                new(1)  // 1 hour process time
            ]);

            Assert.IsTrue(productionLine
                .WithWorkInProcess(productionLine.CriticalWorkInProcess)
                .WithCycleTime(new(productionLine.RawProcessTime.Hours))
                .Congestion.IsBestCase);
        }
    }
}