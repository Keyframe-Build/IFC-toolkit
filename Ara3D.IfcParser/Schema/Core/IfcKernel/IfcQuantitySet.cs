using System.Collections.Generic;
using System.Linq;
using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public abstract class IfcQuantitySet : IfcPropertySetDefinition
{
    public IfcQuantitySet(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
