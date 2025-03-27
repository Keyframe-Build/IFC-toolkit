using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcAnnotation : IfcSpatialStructureElement
{
    public StepSymbol? PredefinedType => this[7] as StepSymbol;

    public IfcAnnotation(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
