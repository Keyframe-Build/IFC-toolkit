using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public abstract class IfcProduct : IfcObject
{
    public StepId? ObjectPlacement => this[5] as StepId;
    public IfcProductRepresentation? Representation
    {
        get
        {
            var representation = this[6] as StepId;
            return representation == null
                ? null
                : Graph.GetNode(representation) as IfcProductRepresentation;
        }
    }

    public IfcProduct(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
