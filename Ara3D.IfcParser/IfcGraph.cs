using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Ara3D.IfcParser.Schema;
using Ara3D.Logging;
using Ara3D.StepParser;
using Ara3D.Utils;

namespace Ara3D.IfcParser;

/// <summary>
/// This is a high-level representation of an IFC model as a graph of nodes and relations.
/// It also contains the  properties, and property sets.
/// </summary>
public class IfcGraph
{
    public static IfcGraph Load(FilePath fp, ILogger? logger = null) =>
        new IfcGraph(new StepDocument(fp, logger), logger);

    public StepDocument Document { get; }

    public Dictionary<uint, IfcNode> Nodes { get; } = new Dictionary<uint, IfcNode>();
    public List<IfcRelationship> Relations { get; } = new List<IfcRelationship>();
    public Dictionary<uint, List<IfcRelationship>> RelationsByNode { get; } =
        new Dictionary<uint, List<IfcRelationship>>();

    /*
public Dictionary<uint, List<IfcPropSet>> PropertySetsByNode { get; } =
    new Dictionary<uint, List<IfcPropSet>>();
    */
    public Dictionary<uint, List<StepId>> PropertySetsByNode { get; } =
        new Dictionary<uint, List<StepId>>();

    public IReadOnlyList<uint> RootIds { get; }

    private static readonly Dictionary<string, Type> IfcTypeMap = new Dictionary<string, Type>(
        Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t =>
                t.Namespace == "Ara3D.IfcParser.Schema" && typeof(IfcNode).IsAssignableFrom(t)
            )
            .ToDictionary(t => t.Name.ToUpper(), t => t)
    );

    public IfcNode AddNode(IfcNode n) => Nodes[n.Id] = n;

    public IfcRelationship AddRelation(IfcRelationship r)
    {
        Relations.Add(r);
        RelationsByNode.Add(r.From.Id, r);
        return r;
    }

    public void AddPropertySetRelation(IfcRelDefinesByProperties r)
    {
        foreach (var id in r.To.Values.OfType<StepId>())
        {
            if (!PropertySetsByNode.TryGetValue(id.Id, out var list))
            {
                PropertySetsByNode[id.Id] = list = new List<StepId>();
            }

            list.Add(r.From);
        }
    }

    public IfcGraph(StepDocument d, ILogger? logger = null)
    {
        Document = d;
        List<uint> rootIds = new List<uint>();

        logger?.Log("Computing entities");
        foreach (var inst in Document.RawInstances)
        {
            if (!inst.IsValid())
                continue;

            var e = d.GetInstanceWithData(inst);

            if (IfcTypeMap.TryGetValue(inst.Type.AsString(), out var type))
            {
                var constructor = type.GetConstructor(
                    new[] { typeof(IfcGraph), typeof(StepInstance) }
                );
                if (constructor != null)
                {
                    var node = (IfcNode)constructor.Invoke(new object[] { this, e });
                    switch (node)
                    {
                        case IfcRelAggregates r:
                            AddRelation(r);
                            break;
                        case IfcRelContainedInSpatialStructure r:
                            AddRelation(r);
                            break;
                        case IfcRelDefinesByProperties r:
                            AddPropertySetRelation(r);
                            break;
                        default:
                            AddNode(node);
                            break;
                    }
                }
            }
            else
            {
                // Simple IFC node: without step entity data.
                AddNode(new IfcNode(this, e));
            }
        }

        logger?.Log("Retrieving the roots of all of the spatial relationship");

        // Find any IfcMapConversion and add them as a root
        var mapConversionIds = Nodes
            .Where(kvp => kvp.Value is IfcMapConversion)
            .Select(kvp => kvp.Key)
            .ToList();

        // Find the root identifiers using the aggregate and spatial relation mappings
        RootIds = mapConversionIds
            .Concat(
                GetAggregateRelations()
                    .Concat<IfcRelationship>(GetSpatialRelations())
                    .Where(r => r.From != null)
                    .Select(r => r.From.Id)
                    .Except(
                        GetAggregateRelations()
                            .Concat<IfcRelationship>(GetSpatialRelations())
                            .SelectMany<IfcRelationship, StepId>(r => r.To.Values.OfType<StepId>())
                            .Select(id => id.Id)
                    )
            )
            .Distinct()
            .ToList();

        logger?.Log("Completed creating model graph");
    }

    public IEnumerable<IfcNode> GetNodes() => Nodes.Values;

    public IEnumerable<IfcNode> GetNodes(IEnumerable<uint> ids) => ids.Select(GetNode);

    public IfcNode GetOrCreateNode(StepInstance lineData, int arg)
    {
        if (arg < 0 || arg >= lineData.AttributeValues.Count)
            throw new Exception("Argument index out of range");
        return GetOrCreateNode(lineData.AttributeValues[arg]);
    }

    public IfcNode GetOrCreateNode(StepValue o) =>
        GetOrCreateNode(
            o is StepId id ? (uint)id.Id : throw new Exception($"Expected a StepId value, not {o}")
        );

    public IfcNode GetOrCreateNode(uint id)
    {
        var r = Nodes.TryGetValue(id, out var node)
            ? node
            : AddNode(new IfcNode(this, Document.GetInstanceWithData(id)));
        Debug.Assert(r.Id == id);
        return r;
    }

    public List<IfcNode> GetOrCreateNodes(List<StepValue> list) =>
        list.Select(GetOrCreateNode).ToList();

    public List<IfcNode> GetOrCreateNodes(StepInstance line, int arg)
    {
        if (arg < 0 || arg >= line.AttributeValues.Count)
            throw new Exception("Argument out of range");
        if (!(line.AttributeValues[arg] is StepList agg))
            throw new Exception("Expected a list");
        return GetOrCreateNodes(agg.Values);
    }

    public IfcNode GetNode(StepId id) => GetNode(id.Id);

    public IfcNode GetNode(uint id)
    {
        var r = Nodes[id];
        Debug.Assert(r.Id == id);
        return r;
    }

    public IEnumerable<IfcNode> GetSources() => RootIds.Select(GetNode);

    public IEnumerable<IfcRelContainedInSpatialStructure> GetSpatialRelations() =>
        Relations.OfType<IfcRelContainedInSpatialStructure>();

    public IEnumerable<IfcRelAggregates> GetAggregateRelations() =>
        Relations.OfType<IfcRelAggregates>();

    public IReadOnlyList<IfcRelationship> GetRelationsFrom(uint id) =>
        RelationsByNode.TryGetValue(id, out var list) ? list : Array.Empty<IfcRelationship>();
}
