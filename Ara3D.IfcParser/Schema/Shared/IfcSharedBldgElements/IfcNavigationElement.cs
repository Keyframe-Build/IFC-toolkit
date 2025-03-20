using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcNavigationElement : IfcElement
{
    public StepSymbol? PredefinedType => this[8] as StepSymbol;

    public IfcNavigationElement(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
