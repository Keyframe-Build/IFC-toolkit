using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcElementAssembly : IfcElement
{
    public StepSymbol? AssemblyPlace => this[8] as StepSymbol;
    public StepSymbol? PredefinedType => this[9] as StepSymbol;

    public IfcElementAssembly(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
