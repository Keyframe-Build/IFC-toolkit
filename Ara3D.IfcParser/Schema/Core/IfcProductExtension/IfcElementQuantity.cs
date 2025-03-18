using System.Collections.Generic;
using System.Linq;
using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcElementQuantity : IfcPropertySetDefinition
{
    // IFCELEMENTQUANTITY('32HXQFM09EYOpmaX_lQQjs',#29,'BaseQuantities',$,'',(#5638,#5640,#5642,#5644,#5646,#5648,#5650,#5652));
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
