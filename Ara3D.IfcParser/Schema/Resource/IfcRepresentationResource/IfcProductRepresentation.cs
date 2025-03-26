using System.Collections.Generic;
using System.Linq;
using Ara3D.IfcParser;
using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public abstract class IfcProductRepresentation : IfcNode
{
    public new string? Name => (this[0] as StepString)?.Value.ToString();
    public new string? Description => (this[1] as StepString)?.Value.ToString();
    public IEnumerable<IfcRepresentation> Representations
    {
        get
        {
            var stepList = this[2] as StepList;
            return stepList
                    ?.Values?.OfType<StepId>()
                    .Select(x => Graph.GetNode(x.Id))
                    .OfType<IfcRepresentation>() ?? Enumerable.Empty<IfcRepresentation>();
        }
    }

    public IfcProductRepresentation(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
