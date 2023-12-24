namespace NorthWind.Membership.Backend.AspNetIdentity.Options;

public class MembershipOptions
{
    public const string SectionKey = nameof(MembershipOptions);
    public string ConnectionString { get; set; }
}
