using System.Collections.ObjectModel;

namespace FactoryPhysics.Lib;

public class Workstations : ReadOnlyCollection<Workstation>
{
    public Workstations(IList<Workstation> list) : base(list)
    {
        ArgumentOutOfRangeException.ThrowIfZero(list.Count);
    }
}