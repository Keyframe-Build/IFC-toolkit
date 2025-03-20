using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcShadingDevice : IfcElement
{
    public StepSymbol? PredefinedType => this[8] as StepSymbol;

    public IfcShadingDevice(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
