using System.Collections.Generic;
using System.Linq;
using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcPropertyDefinition : IfcNode
{
    public IfcPropertyDefinition(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
