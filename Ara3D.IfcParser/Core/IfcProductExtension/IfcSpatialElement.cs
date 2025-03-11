using Ara3D.StepParser;

namespace Ara3D.IfcParser;

public class IfcSpatialElement: IfcProduct
{
  public string? LongName => (this[7] as StepString)?.Value.ToString();

  public IfcSpatialElement(IfcGraph graph, StepInstance lineData)
    : base(graph, lineData)
  {
  }
}
