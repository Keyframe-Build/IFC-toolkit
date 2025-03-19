using System.Collections.Generic;
using System.Linq;
using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcElement : IfcProduct
{
    public string? Tag => (this[7] as StepString)?.Value.ToString();

    public IfcElement(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
