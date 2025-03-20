using System.Collections.Generic;
using System.Linq;
using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public abstract class IfcContext : IfcObjectDefinition
{
    public string? ObjectType => (this[4] as StepString)?.Value.ToString();
    public string? LongName => (this[5] as StepString)?.Value.ToString();
    public string? Phase => (this[6] as StepString)?.Value.ToString();
    public IEnumerable<IfcRepresentationContext> RepresentationContexts
    {
        get
        {
            var stepList = this[7] as StepList;
            return stepList
                    ?.Values?.OfType<StepId>()
                    .Select(x => Graph.GetNode(x.Id))
                    .OfType<IfcRepresentationContext>()
                ?? Enumerable.Empty<IfcRepresentationContext>();
        }
    }
    public IEnumerable<IfcUnitAssignment> UnitsInContext
    {
        get
        {
            var stepList = this[8] as StepList;
            return stepList
                    ?.Values?.OfType<StepId>()
                    .Select(x => Graph.GetNode(x.Id))
                    .OfType<IfcUnitAssignment>() ?? Enumerable.Empty<IfcUnitAssignment>();
        }
    }
    public IEnumerable<IfcRelDefinesByProperties>? IsDefinedBy
    {
        get
        {
            return Graph
                .RelationsByNode.FirstOrDefault(x => x.Key == Id)
                .Value.OfType<IfcRelDefinesByProperties>();
        }
    }

    public IfcContext(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
