using System.Collections.Generic;
using System.Linq;
using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public abstract class IfcPropertySetDefinition : IfcPropertyDefinition
{
    public IEnumerable<IfcRelDefinesByProperties>? DefinesOccurrence
    {
        get
        {
            return Graph
                .RelationsByNode.FirstOrDefault(x => x.Key == Id)
                .Value.OfType<IfcRelDefinesByProperties>();
        }
    }

    public IfcPropertySetDefinition(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
