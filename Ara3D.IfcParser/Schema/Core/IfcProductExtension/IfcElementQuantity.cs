using System.Collections.Generic;
using System.Linq;
using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcElementQuantity : IfcPropertySetDefinition
{
    public string? MethodOfMeasurement => (this[4] as StepString)?.Value.ToString();
    public IEnumerable<IfcPhysicalQuantity> Quantities
    {
        get
        {
            var quantities = this[5] as StepList;
            return quantities
                    ?.Values?.OfType<StepId>()
                    .Select(x => Graph.GetNode(x.Id))
                    .OfType<IfcPhysicalQuantity>() ?? Enumerable.Empty<IfcPhysicalQuantity>();
        }
    }

    public IfcElementQuantity(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
