using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcDiscreteAccessory : IfcElement
{
    public StepSymbol? PredefinedType => this[8] as StepSymbol;

    public IfcDiscreteAccessory(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
