namespace NorthWind.Membership.Backend.Presenters.UserLogin;

internal class UserLoginPresenter : IUserLoginOutputPort
{
    readonly JwtService Service;
    public IResult Result { get; private set; }

    public UserLoginPresenter(JwtService service) => Service = service;

    public Task Handle(Result<UserDto, IEnumerable<ValidationError>> userLoginResult)
    {
        userLoginResult.HandlerError(
            userDto =>
            {
                Result = Results.Ok(new TokensDto(Service.GetToken(userDto)));
            },
            errors =>
            {
                Result = Results.Problem(
                    errors.ToProblemDetails(
                        Messages.UserLoginErrorTitle,
                        Messages.UserLoginErrorDetails,
                        nameof(UserLoginPresenter)));
            });

        return Task.CompletedTask;
    }
}
