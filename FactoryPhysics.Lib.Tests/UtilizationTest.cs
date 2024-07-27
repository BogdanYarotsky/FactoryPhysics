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

            var criticalWip = Factory.GetCriticalWorkInProcess(workstations);
            var rawProcessTime = Factory.GetRawProcessTime(workstations);

            var utilization = new ProductionLine(workstations)
                .GetUtilization(criticalWip, new(rawProcessTime.Hours));
            
            Assert.AreEqual(1.0, utilization.CapacityFraction);
        }
    }
}