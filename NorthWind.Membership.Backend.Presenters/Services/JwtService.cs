namespace NorthWind.Membership.Backend.Presenters.Services;

internal class JwtService
{
    private readonly JwtOptions Options;

    public JwtService(IOptions<JwtOptions> options) => Options = options.Value;

    SigningCredentials GetSigningCredentials()
    {
        var key = Encoding.UTF8.GetBytes(Options.SecurityKey);
        var secret = new SymmetricSecurityKey(key);

        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    List<Claim> GetClaims(UserDto user) => [
        new Claim(ClaimTypes.Name, user.Email),
        new Claim("FullName", $"{user.FirstName} {user.LastName}")
    ];

    JwtSecurityToken GetTokenOptions(SigningCredentials signingCredentials, List<Claim> claims) => new JwtSecurityToken(
               issuer: Options.ValidIssuer,
               audience: Options.ValidAudience,
               claims: claims,
               expires: DateTime.Now.AddMinutes(Options.ExpireInMinutes),
               signingCredentials: signingCredentials
           );

    public string GetToken(UserDto userData)
    {
        var SigningCredentials = GetSigningCredentials();
        var UserClaims = GetClaims(userData);
        var TokenOptions = GetTokenOptions(SigningCredentials, UserClaims);

        return new JwtSecurityTokenHandler().WriteToken(TokenOptions);
    }
}
