using System.Collections.Generic;
using System.Linq;
using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public abstract class IfcObject : IfcObjectDefinition
{
    public string? ObjectType => (this[4] as StepString)?.Value.ToString();

    public IfcObject(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }

    public IEnumerable<IfcRelDefinesByType>? IsTypedBy
    {
        get
        {
            return Graph
                    .RelationsByNode.FirstOrDefault(x => x.Key == Id)
                    .Value?.OfType<IfcRelDefinesByType>()
                ?? Enumerable.Empty<IfcRelDefinesByType>();
        }
    }

    public IEnumerable<IfcRelDefinesByProperties>? IsDefinedBy
    {
        get
        {
            return Graph
                    .RelationsByNode.FirstOrDefault(x => x.Key == Id)
                    .Value?.OfType<IfcRelDefinesByProperties>()
                ?? Enumerable.Empty<IfcRelDefinesByProperties>();
        }
    }
}
