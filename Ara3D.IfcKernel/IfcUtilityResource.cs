using Ara3D.IfcActorResource;

namespace Ara3D.IfcUtilityResource;

public record IfcApplication(IfcOrganization ApplicationDeveloper, string Version, string ApplicationFullName, string ApplicationIdentifier);
public record IfcOwnerHistory(IfcPersonAndOrganisation OwningUser, string OwningApplication, DateTime CreationDate);