using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcMooringDevice : IfcElement
{
    public StepSymbol? PredefinedType => this[8] as StepSymbol;

    public IfcMooringDevice(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
