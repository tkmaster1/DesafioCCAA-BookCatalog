using BookCatalog.Core.Service.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BookCatalog.Core.WebApi.Configurations;

public static class AuthenticationConfigurationExtensions
{
    public static IServiceCollection AddCustomJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var appSettingsSection = configuration.GetSection("AuthorizationSettings");
        services.Configure<AuthorizationSettings>(appSettingsSection);

        var appSettings = appSettingsSection.Get<AuthorizationSettings>();
        var key = Encoding.ASCII.GetBytes(appSettings.Secret);

        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = true;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = appSettings.ValidOn,
                ValidIssuer = appSettings.Issuer,
                ClockSkew = TimeSpan.Zero
            };

            x.EventsType = typeof(JwtBearerEventsHandler); // 👈 Link para logar falhas
        });

        return services;
    }

    public static IApplicationBuilder UseAuthenticationConfiguration(this IApplicationBuilder app)
    {
        app.UseAuthentication();
        app.UseAuthorization();

        return app;
    }
}