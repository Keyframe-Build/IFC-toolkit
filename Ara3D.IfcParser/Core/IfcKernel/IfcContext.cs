using Ara3D.StepParser;

namespace Ara3D.IfcParser;

public class IfcContext : IfcObject
{
  public string? LongName => (this[5] as StepString)?.Value.ToString();
  public string? Phase => (this[6] as StepString)?.Value.ToString();
  public StepList? RepresentationContexts => this[7] as StepList;
  public StepId? UnitsInContext => this[8] as StepId;

  public IfcContext(IfcGraph graph, StepInstance lineData)
    : base(graph, lineData)
  {
  }
}
