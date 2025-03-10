namespace Ara3D.IfcGeometry;
public abstract record IfcClass();

public abstract record IfcRepresentationItem()
    : IfcClass();

public abstract record IfcGeometricRepresentationItem()
    : IfcRepresentationItem();

public abstract record IfcTopologicalRepresentationItem()
    : IfcRepresentationItem();

public record IfcCartesianPoint(List<double> Coordinates)
    : IfcGeometricRepresentationItem();

public record IfcDirection(List<double> DirectionRatios)
    : IfcGeometricRepresentationItem();

public record IfcVector(IfcDirection Orientation, double Magnitude)
    : IfcGeometricRepresentationItem();

public record IfcAxis1Placement(IfcCartesianPoint Location, IfcDirection Axis)
    : IfcGeometricRepresentationItem();

public abstract record IfcPlacement(IfcCartesianPoint Location)
    : IfcGeometricRepresentationItem();

public record IfcAxis2Placement2D(IfcCartesianPoint Location, IfcDirection? RefDirection = null)
    : IfcPlacement(Location);

public record IfcAxis2Placement3D(
    IfcCartesianPoint Location,
    IfcDirection? Axis = null,
    IfcDirection? RefDirection = null
) : IfcPlacement(Location);

public abstract record IfcCurve()
    : IfcGeometricRepresentationItem();

public abstract record IfcBoundedCurve()
    : IfcCurve();

public record IfcPolyline(List<IfcCartesianPoint> Points)
    : IfcBoundedCurve();

public record IfcLine(IfcCartesianPoint Pnt, IfcVector Dir)
    : IfcCurve();

public abstract record IfcConic(IfcAxis2Placement2D Position)
    : IfcCurve();

public record IfcCircle(IfcAxis2Placement2D Position, double Radius)
    : IfcConic(Position);

public record IfcEllipse(IfcAxis2Placement2D Position, double SemiMajorAxis, double SemiMinorAxis)
    : IfcConic(Position);

public record IfcTrimmedCurve(
    IfcCurve BasisCurve,
    List<double>? Trim1,
    List<double>? Trim2,
    bool SenseAgreement,
    string? MasterRepresentation
) : IfcBoundedCurve();

public abstract record IfcSurface() : IfcGeometricRepresentationItem();

public abstract record IfcElementarySurface(IfcAxis2Placement3D Position) : IfcSurface();

public record IfcPlane(IfcAxis2Placement3D Position)
    : IfcElementarySurface(Position);

public record IfcCylindricalSurface(IfcAxis2Placement3D Position, double Radius)
    : IfcElementarySurface(Position);

public record IfcSurfaceOfLinearExtrusion(
    IfcProfileDef SweptCurve,
    IfcDirection ExtrudedDirection,
    double Depth
) : IfcSurface();

public record IfcSurfaceOfRevolution(
    IfcProfileDef SweptCurve,
    IfcAxis1Placement AxisPosition
) : IfcSurface();

public abstract record IfcSolidModel()
    : IfcGeometricRepresentationItem();

public abstract record IfcSweptAreaSolid(IfcProfileDef SweptArea, IfcAxis2Placement3D? Position = null)
    : IfcSolidModel();

public record IfcExtrudedAreaSolid(
    IfcProfileDef SweptArea,
    IfcAxis2Placement3D? Position,
    IfcDirection ExtrudedDirection,
    double Depth
) : IfcSweptAreaSolid(SweptArea, Position);

public record IfcRevolvedAreaSolid(
    IfcProfileDef SweptArea,
    IfcAxis2Placement3D? Position,
    IfcAxis1Placement Axis,
    double Angle
) : IfcSweptAreaSolid(SweptArea, Position);

public abstract record IfcProfileDef(string? ProfileName)
    : IfcClass();

public abstract record IfcParameterizedProfileDef(string? ProfileName)
    : IfcProfileDef(ProfileName);

public record IfcRectangleProfileDef(string? ProfileName, double XDim, double YDim)
    : IfcParameterizedProfileDef(ProfileName);

public record IfcCircleProfileDef(string? ProfileName, double Radius)
    : IfcParameterizedProfileDef(ProfileName);

public abstract record IfcBooleanResult(
    string Operation,
    IfcSolidModel FirstOperand,
    IfcSolidModel SecondOperand
) : IfcSolidModel();

public record IfcBooleanClippingResult(
    string Operation,
    IfcSolidModel FirstOperand,
    IfcSolidModel SecondOperand
) : IfcBooleanResult(Operation, FirstOperand, SecondOperand);

public abstract record IfcManifoldSolidBrep(IfcClosedShell Outer)
    : IfcSolidModel();

public record IfcFacetedBrep(IfcClosedShell Outer) : IfcManifoldSolidBrep(Outer);

public record IfcAdvancedBrep(IfcClosedShell Outer)
    : IfcManifoldSolidBrep(Outer);

public record IfcShellBasedSurfaceModel(List<IfcOpenShell> SbsmBoundary)
    : IfcGeometricRepresentationItem();

public record IfcFaceBasedSurfaceModel(List<IfcConnectedFaceSet> FbsmFaces)
    : IfcGeometricRepresentationItem();

public abstract record IfcTessellatedItem()
    : IfcGeometricRepresentationItem();

public record IfcPolygonalFaceSet(
    IfcCartesianPointList3D Coordinates,
    bool Closed,
    List<IfcIndexedPolygonalFace> Faces
) : IfcTessellatedItem();

public record IfcCartesianPointList3D(List<List<double>> CoordList) : IfcClass();

public record IfcIndexedPolygonalFace(List<int> CoordIndex) : IfcClass();

public abstract record IfcTopologicalRepresentationItem2DOr3D()
    : IfcTopologicalRepresentationItem(); // (Not an official IFC entity, just a placeholder if needed)

public abstract record IfcVertex()
    : IfcTopologicalRepresentationItem();

public record IfcVertexPoint(IfcPointOrVertexPoint? VertexGeometry)
    : IfcVertex(); // In IFC, IfcPointOrVertexPoint is a select. Here as nullable?

public abstract record IfcEdge(IfcVertex EdgeStart, IfcVertex EdgeEnd)
    : IfcTopologicalRepresentationItem();

public record IfcEdgeCurve(
    IfcVertex EdgeStart,
    IfcVertex EdgeEnd,
    IfcCurve EdgeGeometry,
    bool SameSense
) : IfcEdge(EdgeStart, EdgeEnd);

public record IfcOrientedEdge(
    IfcEdge EdgeElement,
    bool Orientation
) : IfcEdge(EdgeElement.EdgeStart, EdgeElement.EdgeEnd);

public record IfcPath(List<IfcOrientedEdge> EdgeList)
    : IfcTopologicalRepresentationItem();

public abstract record IfcLoop()
    : IfcTopologicalRepresentationItem();

public record IfcEdgeLoop(List<IfcOrientedEdge> EdgeList)
    : IfcLoop();

public record IfcVertexLoop(IfcVertex LoopVertex)
    : IfcLoop();

public abstract record IfcFaceBound(IfcLoop Bound, bool Orientation)
    : IfcTopologicalRepresentationItem();

public record IfcFaceOuterBound(IfcLoop Bound, bool Orientation)
    : IfcFaceBound(Bound, Orientation);

public record IfcFace(List<IfcFaceBound> Bounds)
    : IfcTopologicalRepresentationItem();

public record IfcFaceSurface(List<IfcFaceBound> Bounds, IfcSurface FaceSurface, bool SameSense)
    : IfcFace(Bounds);

public record IfcConnectedFaceSet(List<IfcFace> CfsFaces)
    : IfcTopologicalRepresentationItem();

public record IfcClosedShell(List<IfcFace> CfsFaces)
    : IfcConnectedFaceSet(CfsFaces);

public record IfcOpenShell(List<IfcFace> CfsFaces)
    : IfcConnectedFaceSet(CfsFaces);

// In IFC, IfcPointOrVertexPoint and other SELECT types are not formal entities. 
// You may adapt those to your own usage or code-generation strategy as needed.
public record IfcPointOrVertexPoint(IfcCartesianPoint? Point, IfcVertex? Vertex)
    : IfcClass();