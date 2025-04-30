namespace Ara3D.IfcLoader;

public class IfcGeometry
{
    public readonly IntPtr ApiPtr;
    public readonly IntPtr GeometryPtr;
    public readonly int NumMeshes;
    public readonly uint Id;

    public IfcGeometry(IntPtr apiPtr, IntPtr geometryPtr)
    {
        ApiPtr = apiPtr;
        GeometryPtr = geometryPtr;
        Id = WebIfc.GetMeshId(ApiPtr, GeometryPtr);
        NumMeshes = WebIfc.GetNumMeshes(GeometryPtr);
    }

    public IfcMesh GetMesh(int i) => new IfcMesh(WebIfc.GetMesh(GeometryPtr, i));

    public int GetNumMeshes() => NumMeshes;

    public IEnumerable<IfcMesh> GetMeshes()
    {
        for (int i = 0; i < NumMeshes; ++i)
            yield return GetMesh(i);
    }
}
