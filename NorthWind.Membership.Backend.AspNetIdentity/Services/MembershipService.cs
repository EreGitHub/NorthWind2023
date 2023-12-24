namespace NorthWind.Membership.Backend.AspNetIdentity.Services;

internal class MembershipService : IMembershipService
{
    readonly UserManager<NorthWindUser> manager;

    public MembershipService(UserManager<NorthWindUser> userManager) => manager = userManager;

    public async Task<Result<IEnumerable<ValidationError>>> Register(UserRegistrationDto userData)
    {
        var User = new NorthWindUser
        {
            UserName = userData.Email,
            Email = userData.Email,
            FirstName = userData.FirstName,
            LastName = userData.LastName
        };

        var CreateResult = await manager.CreateAsync(User, userData.Password);

        return CreateResult.Succeeded ?
            new Result<IEnumerable<ValidationError>>() :
            new Result<IEnumerable<ValidationError>>(CreateResult.Errors.ToValidationError());
    }
}
