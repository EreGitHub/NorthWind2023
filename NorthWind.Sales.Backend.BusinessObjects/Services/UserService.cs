namespace NorthWind.Sales.Backend.BusinessObjects.Services;

internal class UserService(IHttpContextAccessor contextAccessor) : IUserService
{
    public bool IsAuthenticated =>
        contextAccessor.HttpContext.User.Identity.IsAuthenticated;

    public string UserName =>
        contextAccessor.HttpContext.User.Identity.Name;

    public string FullName =>
        contextAccessor.HttpContext.User.Claims
        .Where(context => context.Type == nameof(IUserService.FullName))
        .Select(context => context.Value).FirstOrDefault();
}
