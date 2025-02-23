using Ara3D.StepParser;

namespace Ara3D.IfcParser;

public class IfcContext : IfcObject
{
  public string? LongName => this[5].AsString();
  public string? Phase => this[6].AsString();
  public StepList? RepresentationContexts => this[7] as StepList;
  public StepId? UnitsInContext => this[8] as StepId;

  public IfcContext(IfcGraph graph, StepInstance lineData)
    : base(graph, lineData)
  {
    // Add the representation context relationship
    if (RepresentationContexts is not null)
    {
      graph.AddRelation(new IfcRelation(graph, lineData, new StepId(Id), RepresentationContexts));
    }
  }
}
