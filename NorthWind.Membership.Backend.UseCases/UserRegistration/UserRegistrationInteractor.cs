namespace NorthWind.Membership.Backend.UseCases.UserRegistration;

internal class UserRegistrationInteractor : IUserRegistrationInputPort
{
    readonly IUserRegistrationOutputPort Presenter;
    readonly IMembershipService MembershipService;
    readonly IModelValidatorService<UserRegistrationDto> ValidatorService;

    public UserRegistrationInteractor(IUserRegistrationOutputPort presenter, IMembershipService membershipService, IModelValidatorService<UserRegistrationDto> validatorService)
    {
        Presenter = presenter;
        MembershipService = membershipService;
        ValidatorService = validatorService;
    }

    public async Task Handle(UserRegistrationDto userData)
    {
        Result<IEnumerable<ValidationError>> Result;

        if (!await ValidatorService.Validate(userData))
            Result = new(ValidatorService.Errors);
        else
            Result = await MembershipService.Register(userData);

        await Presenter.Handle(Result);
    }
}
