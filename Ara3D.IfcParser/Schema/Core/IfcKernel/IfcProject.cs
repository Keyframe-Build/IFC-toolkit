using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcProject : IfcContext
{
    public IfcProject(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
