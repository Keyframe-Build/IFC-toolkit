using Ara3D.IfcParser;
using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcProductDefinitionShape : IfcProductRepresentation
{
    public IfcProductDefinitionShape(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
