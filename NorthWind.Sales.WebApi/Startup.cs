namespace NorthWind.Sales.WebApi;

public static class Startup
{
    //es este metodo lo usamos para configurarlos o registrarlos
    public static WebApplication CreateWebApplication(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerService();
        builder.Services.AddNorthWindSalesServices(
            dbOptions =>
                builder.Configuration.GetSection(DBOptions.SectionKey).Bind(dbOptions),
            smtpOptions =>
                builder.Configuration.GetSection(SmtpOptions.SectionKey).Bind(smtpOptions),
            membershipDbOptions =>
                builder.Configuration.GetSection(MembershipOptions.SectionKey).Bind(membershipDbOptions),
            jwtOptions =>
                builder.Configuration.GetSection(JwtOptions.SectionKey).Bind(jwtOptions));
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(config =>
            {
                config.AllowAnyHeader();
                config.AllowAnyMethod();
                config.AllowAnyOrigin();
            });
        });
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                var JwtConfigurationSection = builder.Configuration.GetSection(JwtOptions.SectionKey);
                JwtConfigurationSection.Bind(options.TokenValidationParameters);
                options.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConfigurationSection[nameof(JwtOptions.SecurityKey)]));
            });
        builder.Services.AddAuthorization();
        //builder.Services.AddAuthorization(options =>
        //{
        //    options.AddPolicy("Admin", policy => policy.RequireClaim("Admin", "true"));
        //});

        return builder.Build();
    }

    //es este metodo usamos los servicios que registramos
    public static WebApplication ConfigureWebApplication(this WebApplication app)
    {
        app.UseExceptionHandler(builder => { });

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapNorthWindSalesEndpoints();
        app.UseCors();
        app.UseAuthentication();
        app.UseAuthorization();

        return app;
    }
}
