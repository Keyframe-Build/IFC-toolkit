using System.Collections.Generic;
using System.Linq;
using Ara3D.StepParser;

namespace Ara3D.IfcParser;

public class IfcContext : IfcObject
{
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
    public StepId? UnitsInContext => this[8] as StepId;

    public IfcContext(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
