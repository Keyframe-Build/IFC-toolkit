using System;
using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcFurnishingElement : IfcElement
{
    public IfcFurnishingElement(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
