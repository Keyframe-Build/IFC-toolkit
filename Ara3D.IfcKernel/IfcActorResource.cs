namespace Ara3D.IfcActorResource;

public record IfcActorRole(string Role, string UserDefinedRole, string Description);
public record IfcAddress(string Purpose, string Description, string UserDefinedPurpose);
public record IfcPerson(
    string Identification,
    string FamilyName,
    string GivenName,
    string MiddleNames,
    string PrefixTitles,
    string SuffixTitles,
    List<IfcActorRole> Roles,
    List<IfcAddress> Addresses
);
public record IfcOrganization(string Identification, string Name, string Description, List<IfcActorRole> Roles, List<IfcAddress> Addresses);
public record IfcPersonAndOrganization(IfcPerson ThePerson, IfcOrganization TheOrganization);