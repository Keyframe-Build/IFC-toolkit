using System;
using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

[Obsolete("This definition will be removed in a future major release of this standard")]
public class IfcWallStandardCase : IfcWall
{
    public IfcWallStandardCase(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
