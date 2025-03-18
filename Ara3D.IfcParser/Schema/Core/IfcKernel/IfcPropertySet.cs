using System.Collections.Generic;
using System.Linq;
using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcPropertyDefinition : IfcNode
{
    public IfcPropertyDefinition(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}

public class IfcPropertySetDefinition : IfcPropertyDefinition
{
    public IfcPropertySetDefinition(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}

public class IfcPropertySet : IfcPropertySetDefinition
{
    public IEnumerable<IfcProperty> HasProperties
    {
        get
        {
            var properties = this[3] as StepList;
            return properties
                    ?.Values?.OfType<StepId>()
                    .Select(x => Graph.GetNode(x.Id))
                    .OfType<IfcProperty>() ?? Enumerable.Empty<IfcProperty>();
        }
    }

    public IfcPropertySet(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}

public class IfcQuantitySet : IfcPropertySetDefinition
{
    public IfcQuantitySet(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
