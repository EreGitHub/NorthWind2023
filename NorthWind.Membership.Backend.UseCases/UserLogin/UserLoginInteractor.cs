namespace NorthWind.Membership.Backend.UseCases.UserLogin;

internal class UserLoginInteractor : IUserLoginInputPort
{
    readonly IMembershipService MembershipService;
    readonly IUserLoginOutputPort Presenter;
    readonly IModelValidatorService<UserCredentialsDto> ValidatorService;

    public UserLoginInteractor(IMembershipService membershipService, IUserLoginOutputPort presenter, IModelValidatorService<UserCredentialsDto> validatorService)
    {
        MembershipService = membershipService;
        Presenter = presenter;
        ValidatorService = validatorService;
    }

    public async Task Handle(UserCredentialsDto userData)
    {
        Result<UserDto, IEnumerable<ValidationError>> Result;

        if (!await ValidatorService.Validate(userData))
        {
            Result = new(ValidatorService.Errors);
        }
        else
        {
            var User = await MembershipService.GetUserByCredentials(userData);
            Result = User == null ?
                new([new ValidationError(nameof(userData.Email), UserLoginMessages.InvalidUserCredentialsErrorMessage)]) :
                Result = new(User);
        }

        await Presenter.Handle(Result);
    }
}
