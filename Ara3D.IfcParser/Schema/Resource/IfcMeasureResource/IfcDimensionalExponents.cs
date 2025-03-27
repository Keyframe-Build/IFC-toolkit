using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcDimensionalExponents : IfcNode
{
    int LengthExponent => (this[0] as StepNumber).IntValue;
    int MassExponent => (this[1] as StepNumber).IntValue;
    int TimeExponent => (this[2] as StepNumber).IntValue;
    int ElectricCurrentExponent => (this[3] as StepNumber).IntValue;
    int ThermodynamicTemperatureExponent => (this[4] as StepNumber).IntValue;
    int AmountOfSubstanceExponent => (this[5] as StepNumber).IntValue;
    int LuminousIntensityExponent => (this[6] as StepNumber).IntValue;

    public IfcDimensionalExponents(IfcGraph graph, StepInstance lineData)
        : base(graph, lineData) { }
}
