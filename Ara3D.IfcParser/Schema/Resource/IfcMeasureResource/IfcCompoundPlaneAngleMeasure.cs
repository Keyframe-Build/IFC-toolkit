using Ara3D.StepParser;

namespace Ara3D.IfcParser.Schema;

public class IfcCompoundPlaneAngleMeasure
{
    public int Degrees;
    public int Minutes;
    public int Seconds;
    public int? MillionthSeconds;

    public IfcCompoundPlaneAngleMeasure(StepList list)
    {
        Degrees = (list.Values[0] as StepNumber).IntValue;
        Minutes = (list.Values[1] as StepNumber).IntValue;
        Seconds = (list.Values[2] as StepNumber).IntValue;
        MillionthSeconds = list.Values.Count > 3 ? (list.Values[3] as StepNumber)?.IntValue : null;
    }

    public override string ToString()
    {
        return MillionthSeconds is null
            ? $"{Degrees}° {Minutes}' {Seconds}\""
            : $"{Degrees}° {Minutes}' {Seconds}\" {MillionthSeconds}";
    }
}
