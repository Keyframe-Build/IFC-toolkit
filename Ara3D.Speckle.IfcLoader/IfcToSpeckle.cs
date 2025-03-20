using System.Drawing;
using System.Reflection;
using Ara3D.IfcLoader;
using Ara3D.IfcParser;
using Ara3D.IfcParser.Schema;
using Ara3D.Utils;
using Objects.Geometry;
using Objects.Other;
using Speckle.Core.Models;

namespace Ara3D.Speckle.IfcLoader
{
    public static class IfcToSpeckle
    {
        public static Base ToSpeckle(this IfcFile f)
        {
            return f.ToSpeckle(f.Graph);
        }

        public static Base ToSpeckle(this IfcFile f, IfcGraph g)
        {
            var b = new Base();
            var children = g.GetSources().Select(f.ToSpeckle).ToList();
            b["elements"] = children;
            return b;
        }

        public static Base ToSpeckle(this IfcModel m)
        {
            var b = new Base();
            b["Name"] = "Root";
            return b;
        }

        public static unsafe Mesh ToSpeckle(this IfcMesh mesh)
        {
            var r = new Mesh();
            var vertexData = mesh.Vertices;
            var indexData = mesh.Indices;
            var m = (double*)mesh.Transform;
            var vp = (IfcVertex*)vertexData;
            var ip = (int*)indexData;

            for (var i = 0; i < mesh.NumVertices; i++)
            {
                var x = vp[i].PX;
                var y = vp[i].PY;
                var z = vp[i].PZ;
                r.vertices.Add(m[0] * x + m[4] * y + m[8] * z + m[12]);
                r.vertices.Add(-(m[2] * x + m[6] * y + m[10] * z + m[14]));
                r.vertices.Add(m[1] * x + m[5] * y + m[9] * z + m[13]);
            }

            for (var i = 0; i < mesh.NumIndices; i += 3)
            {
                var a = ip[i];
                var b = ip[i + 1];
                var c = ip[i + 2];
                r.faces.Add(0);
                r.faces.Add(a);
                r.faces.Add(b);
                r.faces.Add(c);
            }

            var rm = new RenderMaterial();
            var color = (IfcColor*)mesh.Color;
            rm.diffuseColor = Color.FromArgb(
                (int)(color->A * 255),
                (int)(color->R * 255),
                (int)(color->G * 255),
                (int)(color->B * 255)
            );
            r["renderMaterial"] = rm;
            return r;
        }

        public static Collection ToSpeckle(this IfcGeometry? geometry)
        {
            var c = new Collection();
            if (geometry != null)
                foreach (var tm in geometry.GetMeshes())
                    c.elements.Add(tm.ToSpeckle());
            return c;
        }

        public static Dictionary<string, object?> ConvertPropertySets(this IfcNode node)
        {
            var result = new Dictionary<string, object?>();
            foreach (var p in node.GetPropertySets())
            {
                var name = p.Name;
                if (string.IsNullOrWhiteSpace(name))
                    name = $"#{p.Id}";

                switch (p)
                {
                    case IfcPropertySet ps:
                        var psDict = ToSpeckleDictionary(ps);
                        if (psDict.Count > 0)
                            result[name] = psDict;
                        break;
                    case IfcElementQuantity eq:
                        var eqDict = ToSpeckleDictionary(eq);
                        if (eqDict.Count > 0)
                            result[name] = eqDict;
                        break;
                    default:
                        throw new NotImplementedException(
                            $"PropertySet type {p.GetType()} not implemented"
                        );
                }
            }

            return result;
        }

        public static Dictionary<string, object?> ToSpeckleDictionary(this IfcPropertySet ps)
        {
            var d = new Dictionary<string, object?>();
            foreach (var prop in ps.HasProperties)
            {
                switch (prop)
                {
                    case IfcPropertySingleValue psv:
                        d[psv.Name] = psv.NominalValue.ToJsonObject();
                        break;
                    default:
                        throw new NotImplementedException(
                            $"Property type {prop.GetType()} not implemented"
                        );
                }
            }
            return d;
        }

        public static Dictionary<string, object?> ToSpeckleDictionary(this IfcElementQuantity eq)
        {
            var d = new Dictionary<string, object?>();
            foreach (var item in eq.Quantities)
            {
                switch (item)
                {
                    case IfcQuantityArea qa:
                        d[qa.Name] = qa.AreaValue;
                        break;
                    case IfcQuantityCount qc:
                        d[qc.Name] = qc.CountValue;
                        break;
                    case IfcQuantityLength ql:
                        d[ql.Name] = ql.LengthValue;
                        break;
                    case IfcQuantityNumber qn:
                        d[qn.Name] = qn.NumberValue;
                        break;
                    case IfcQuantityTime qt:
                        d[qt.Name] = qt.TimeValue;
                        break;
                    case IfcQuantityVolume qv:
                        d[qv.Name] = qv.VolumeValue;
                        break;
                    case IfcQuantityWeight qw:
                        d[qw.Name] = qw.WeightValue;
                        break;
                    default:
                        throw new NotImplementedException(
                            $"Quantity type {item.GetType()} not implemented"
                        );
                }
            }
            return d;
        }

        public static Base ToSpeckle(this IfcFile file, IfcNode n)
        {
            var b = new Base();

            // https://github.com/specklesystems/speckle-server/issues/1180
            b["ifc_type"] = n.Type;

            // This is required because "speckle_type" has no setter, but is backed by a private field.
            var baseType = typeof(Base);
            var typeField = baseType.GetField(
                "_type",
                BindingFlags.Instance | BindingFlags.NonPublic
            );
            typeField?.SetValue(b, n.Type);

            // Guid is null for property values, and other Ifc entities not derived from IfcRoot
            b.applicationId = n.Guid;

            // This is the express ID used to identify an entity within a file.
            b["expressID"] = n.Id;

            // Even if there is no geometry, this will return an empty collection.
            var c = file.Model.GetGeometry(n.Id).ToSpeckle();
            if (c.elements.Count > 0)
                b["displayValue"] = c.elements;

            // Create the children
            var children = n.GetChildren().Select(file.ToSpeckle).ToList();
            b["elements"] = children;

            var propSets = n.ConvertPropertySets();
            if (propSets.Any())
            {
                b["properties"] = propSets;
            }

            // TODO: add the "type" properties

            return b;
        }
    }
}
