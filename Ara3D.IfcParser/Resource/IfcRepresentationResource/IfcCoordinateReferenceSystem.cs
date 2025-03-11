using Ara3D.StepParser;

namespace Ara3D.IfcParser;

public class IfcCoordinateReferenceSystem : IfcNode
{
  public new string? Name => (this[0] as StepString)?.Value.ToString();
  public new string? Description => (this[1] as StepString)?.Value.ToString();
  public string? GeodeticDatum => (this[2] as StepString)?.Value.ToString();
  public IfcCoordinateReferenceSystem(IfcGraph graph, StepInstance lineData)
    : base(graph, lineData)
  {
  }
}

