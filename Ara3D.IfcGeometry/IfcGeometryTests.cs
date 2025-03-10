using System.Reflection;
using Ara3D.IfcParser.Test;
using Ara3D.StepParser;
using Ara3D.Utils;

namespace Ara3D.IfcGeometry;

public class IfcFactory
{
    public Dictionary<uint, StepInstance> StepInstances  = new Dictionary<uint, StepInstance>();
    public Dictionary<string, Type> Types = new Dictionary<string, Type>();
    public Dictionary<uint, IfcClass> IfcInstances = new Dictionary<uint, IfcClass>();

    public IfcFactory()
    {
        Types = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.Name.StartsWith("Ifc"))
            .ToDictionary(t => t.Name.ToUpperInvariant(), t => t);
    }

    public void AddValue(StepInstance inst)
        => StepInstances.Add(inst.Id, inst);
    

    public Type? GetIfcType(StepInstance inst)
        => Types.GetValueOrDefault(inst.EntityType);

    public IfcClass GetCreateIfcInstance(uint id)
    {
        if (IfcInstances.TryGetValue(id, out var ifcInstance))
            return ifcInstance;

        if (!StepInstances.TryGetValue(id, out var stepInstance))
            throw new Exception($"Could not find step instance {id}");

        /*
                var type = Types.
                var vals = stepInstance.AttributeValues;
                var ctor = type
                if (vals.Count != )
                var ic = Activator.CreateInstance(type) as IfcClass;
                if (ic == null)
                    throw new Exception($"Unable to create instance of {type}");
                IfcInstances.Add(inst.Id, ic);

        */
        return null;
    }
}

public static class Tests
{

    public static FilePath InputFile = Config.AC20Haus;

    public static HashSet<string> GetLocalTypes()
    {
        return Assembly.GetExecutingAssembly().GetTypes().Select(t => t.Name.ToUpperInvariant())
            .Where(n => n.StartsWith("IFC")).ToHashSet();
    }

    [Test]
    public static void Test1()
    {
        var logger = Config.CreateLogger();
        var (rd, file) = RunDetails.LoadGraph(InputFile, false, logger);
        IfcLoadTests.OutputDetails(file, logger);
        Console.WriteLine(rd.Header());
        Console.WriteLine(rd.RowData());
        var localTypes = GetLocalTypes();
        var doc = file.Document;
        var numbers = new List<double>();
        var f = new IfcFactory();
        var d = new Dictionary<string, List<StepInstance>>();
        var cnt = 0;
        foreach (var rawInstance in file.Document.RawInstances)
        {
            if (rawInstance.Type.IsNull())
                continue;

            var str = rawInstance.Type.ToString().ToUpperInvariant();
            if (!localTypes.Contains(str))
                continue;

            var inst = doc.GetInstanceWithData(rawInstance);
            GatherNumbers(inst.AttributeValues, numbers);
            cnt++;

            f.AddValue(inst);

            if (!d.ContainsKey(str))
                d[str] = new List<StepInstance>() { inst };
            else
                d[str].Add(inst);
        }

        Console.WriteLine($"Found a total of {cnt} instances, and {numbers.Count} numbers");
        foreach (var kv in d.OrderBy(kv => kv.Key))
            Console.WriteLine($"{kv.Key} = {kv.Value.Count}");
    }

    public static void GatherNumbers(List<StepValue> list, List<double> numbers)
    {
        foreach (var tmp in list)
        {
            if (tmp is StepNumber n)
                numbers.Add(n.Value);
            else if (tmp is StepList stepList)
                GatherNumbers(stepList.Values, numbers);
        }
    }
}