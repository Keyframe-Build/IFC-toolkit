using Ara3D.StepParser;

namespace Ara3D.IfcParser;

public class IfcProject : IfcContext
{
  public IfcProject(IfcGraph graph, StepInstance lineData)
    : base(graph, lineData)
  {
  }
}
