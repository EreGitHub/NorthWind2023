namespace Microsoft.Extensions.DependencyInjection;

public static class SwaggerExtensions
{
    public static IServiceCollection AddSwaggerService(
        this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            // Agregar definición de seguridad.
            options.AddSecurityDefinition("BearerToken",
                 new OpenApiSecurityScheme
                 {
                     // Nombre del encabezado HTTP que se agregará
                     // en la petición.
                     Name = "Authorization",
                     Description = "Proporciona el valor del token.",
                     // Ubicación del Token
                     In = ParameterLocation.Header,
                     // Tipo del esquema de seguridad a utilizar.
                     // Al especificar HTTP, no necesitamos proporcionar
                     // la palabra bearer antes del token, solo necesitamos
                     // proporcionar el Token.
                     Type = SecuritySchemeType.Http,
                     // Nombre del esquema de autenticación.
                     // Para HTTP puede ser Basic o Bearer (no es sensible
                     // a mayúsculas/minúsculas)
                     Scheme = "Bearer"
                 });

            // Para agregar el encabezado de autorización en las 
            // peticiones de endpoints.
            options.AddSecurityRequirement(
                 new OpenApiSecurityRequirement
                 {

                       {
                           new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  // Id definido en AddSecurityDefinition.
                                  Id = "BearerToken"
                               }
                           },
                           // Solo se requiere en oauth2 o OIDC para enviar
                           // nombres de scopes. 
                           new string[] { }
                       }
                 });
        });

        return services;
    }
}
//namespace NorthWind.Sales.WebApi.Extensions;

//public static class SwaggerExtensions
//{
//    public static void AddSwagger(this IServiceCollection services)
//    {
//        services.AddSwaggerGen(c =>
//        {
//            c.SwaggerDoc("v1", new OpenApiInfo { Title = "NorthWind.Sales.WebApi", Version = "v1" });
//            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//            {
//                Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
//                Name = "Authorization",
//                In = ParameterLocation.Header,
//                Type = SecuritySchemeType.ApiKey,
//                Scheme = "Bearer"
//            });
//            c.AddSecurityRequirement(new OpenApiSecurityRequirement
//            {
//                {
//                    new OpenApiSecurityScheme
//                    {
//                        Reference = new OpenApiReference
//                        {
//                            Id = "Bearer",
//                            Type = ReferenceType.SecurityScheme
//                        }
//                    },
//                    new string[] { }
//                }
//            });
//        });
//    }

//    public static void UseSwagger(this IApplicationBuilder app)
//    {
//        app.UseSwagger();
//        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NorthWind.Sales.WebApi v1"));
//    }
//}
