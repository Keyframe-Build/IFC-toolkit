using Ara3D.StepParser;

namespace Ara3D.IfcParser;

public class IfcSpatialStructureElement : IfcSpatialElement
{
    public StepSymbol? CompositionType => this[8] as StepSymbol;

    public IfcSpatialStructureElement(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
