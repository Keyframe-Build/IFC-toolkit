namespace Ara3D.IfcLoader;

public class IfcModel
{
    public IntPtr ApiPtr;
    public IntPtr ModelPtr;
    public IfcFile File;

    public IfcModel(IfcFile file, IntPtr apiPtr, IntPtr modelPtr)
    {
        ApiPtr = apiPtr;
        ModelPtr = modelPtr;
        File = file;
    }

    public IfcGeometry? GetGeometry(uint id)
    {
        var gPtr = WebIfc.GetGeometryFromId(ModelPtr, id);
        return gPtr == IntPtr.Zero ? null : new IfcGeometry(ApiPtr, gPtr);
    }

    public int GetNumGeometries() => WebIfc.GetNumGeometries(ModelPtr);

    public IEnumerable<IfcGeometry> GetGeometries()
    {
        var numGeometries = WebIfc.GetNumGeometries(ModelPtr);
        for (int i = 0; i < numGeometries; ++i)
        {
            var gPtr = WebIfc.GetGeometryFromIndex(ModelPtr, i);
            if (gPtr != IntPtr.Zero)
                yield return new IfcGeometry(ApiPtr, gPtr);
        }
    }
}
