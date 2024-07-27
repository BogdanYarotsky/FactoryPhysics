using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactoryPhysics.Lib.Tests
{
    [TestClass]
    public class UtilizationTest
    {
        [TestMethod]
        public void CriticalWIP_Yields_Maximum_Utilization()
        {
            var workstations = new Workstations(new Workstation[]
            {
                new(2), // 2 hours process time
                new(3), // 3 hours process time
                new(1)  // 1 hour process time
            });
            
            var productionLine = new ProductionLine(workstations);
            var criticalWip = Factory.GetCriticalWorkInProcess(workstations);
            var rawProcessTime = Factory.GetRawProcessTime(workstations);
            var idealCycleTime = new CycleTime(rawProcessTime.Hours);

            var perfectUtilization = productionLine.GetUtilization(criticalWip, idealCycleTime);
            Assert.AreEqual(1.0, perfectUtilization.CapacityFraction);
        }
    }
}