using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace BookCatalog.Core.WebApi.Configurations;

public class JwtBearerEventsHandler : JwtBearerEvents
{
    private readonly ILogger<JwtBearerEventsHandler> _logger;

    public JwtBearerEventsHandler(ILogger<JwtBearerEventsHandler> logger)
    {
        _logger = logger;
    }

    public override Task AuthenticationFailed(AuthenticationFailedContext context)
    {
        if (context.Exception is SecurityTokenExpiredException)
        {
            _logger.LogWarning($"[JWT] Token expirado: {context.Exception.Message}");
        }
        else
        {
            _logger.LogError($"[JWT] Falha na autenticação: {context.Exception.Message}");
        }

        return Task.CompletedTask;
    }

    public override Task Challenge(JwtBearerChallengeContext context)
    {
        if (!context.Handled)
        {
            _logger.LogWarning($"[JWT] Acesso negado (Challenge): {context.ErrorDescription}");
        }

        return Task.CompletedTask;
    }
}