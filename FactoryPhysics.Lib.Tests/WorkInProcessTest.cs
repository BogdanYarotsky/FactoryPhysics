using FactoryPhysics.Lib;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactoryPhysics.Lib.Tests;

[TestClass]
[TestSubject(typeof(WorkInProcess))]
public class WorkInProcessTest
{
    [TestMethod]
    public void GetExpectedWip()
    {
        var wip = WorkInProcess.Calculate(ct: new(2), th: new(0.4));
        Assert.AreEqual(0.8, wip.Jobs);
    }
}