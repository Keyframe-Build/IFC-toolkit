using System.Collections.Generic;
using System.Linq;
using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcUnitAssignment : IfcNode
{
    public IEnumerable<IfcUnit> Units
    {
        get
        {
            var stepList = this[0] as StepList;
            return stepList
                    ?.Values?.OfType<StepId>()
                    .Select(x => Graph.GetNode(x.Id))
                    .OfType<IfcUnit>() ?? Enumerable.Empty<IfcUnit>();
        }
    }

    public IfcUnitAssignment(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
